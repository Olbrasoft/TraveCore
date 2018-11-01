using FastMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using Microsoft.SqlServer.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;

namespace Olbrasoft.Data.Entity.Framework.Bulk
{
    internal class ObjectReaderEx : ObjectReader // Overridden to fix ShadowProperties in FastMember library
    {
        private readonly HashSet<string> _shadowProperties;
        private readonly Dictionary<string, ValueConverter> _convertibleProperties;
        private readonly DbContext _context;
        private readonly string[] _members;
        private readonly FieldInfo _current;

        public ObjectReaderEx(Type type, IEnumerable source, HashSet<string> shadowProperties, Dictionary<string, ValueConverter> convertibleProperties, DbContext context, params string[] members) : base(type, source, members)
        {
            _shadowProperties = shadowProperties;
            _convertibleProperties = convertibleProperties;
            _context = context;
            _members = members;
            _current = typeof(ObjectReader).GetField("current", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static ObjectReader Create<T>(IEnumerable<T> source, HashSet<string> shadowProperties, Dictionary<string, ValueConverter> convertibleProperties, DbContext context, params string[] members)
        {
            bool hasShadowProp = shadowProperties.Count > 0;
            bool hasConvertibleProperties = convertibleProperties.Keys.Count > 0;
            return (hasShadowProp || hasConvertibleProperties) ? new ObjectReaderEx(typeof(T), source, shadowProperties, convertibleProperties, context, members) : Create(source, members);
        }

        /// <summary>
        /// Creates a new ObjectReader instance for reading the supplied data
        /// </summary>
        /// <param name="source">The sequence of objects to represent</param>
        /// <param name="members">The members that should be exposed to the reader</param>
        public new static ObjectReaderEx Create<T>(IEnumerable<T> source, params string[] members)
        {
            return new ObjectReaderEx(typeof(T), source, members);
        }

        public ObjectReaderEx(Type type, IEnumerable source, params string[] members) : base(type, source, members)
        {
            _members = members;
            _shadowProperties = new HashSet<string>();
        }

        public override object GetValue(int i)
        {
            var value = base.GetValue(i);

            //switch (value)
            //{
            //    case NetTopologySuite.Geometries.Point dbPoint:
            //        {
            //            var chars = new SqlChars(dbPoint.AsText());
            //            return SqlGeography.STGeomFromText(chars, dbPoint.SRID);
            //        }
            //    case NetTopologySuite.Geometries.Polygon dbPolygon:
            //        {
            //            var chars = new SqlChars(dbPolygon.AsText());
            //            return SqlGeography.STGeomFromText(chars, dbPolygon.SRID);
            //        }
            //}

            return value;
        }

        public override object this[string name]
        {
            get
            {
                if (!_shadowProperties.Contains(name)) return base[name];

                var current = _current.GetValue(this);
                return _context.Entry(current).Property(name).CurrentValue;
            }
        }

        public override object this[int i]
        {
            get
            {
                var name = _members[i];
                return this[name];
            }
        }
    }
}