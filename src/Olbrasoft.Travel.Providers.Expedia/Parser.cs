using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Olbrasoft.Travel.Providers.Expedia
{
    public class Parser<TEan> : BaseParser<TEan> where TEan : class, new()
    {
        protected readonly string[] PropertiesNames;

        public Parser(string firstLine)
        {
            PropertiesNames = Split(firstLine);

            if (PropertiesNames.Length != typeof(TEan).GetProperties().Length)
                throw new ArgumentException(nameof(firstLine));
        }

        private static string[] Split(string s)
        {
            return s.Split('|');
        }


        public override TEan Parse(string[] items)
        {
            if (items.Length != PropertiesNames.Length)
                throw new ArgumentException($"Count properties { nameof(items)} not corespondent with {nameof(PropertiesNames)}!");

            var entity = new TEan();
            var counter = 0;
            foreach (var propertiesName in PropertiesNames)
            {
                var property = entity.GetType().GetProperty(propertiesName);

                if (property != null)
                {
                    var t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                    if (!string.IsNullOrEmpty(items[counter]))
                    {
                        if (t != typeof(bool))
                        {
                            property.SetValue(entity, Convert.ChangeType(items[counter], t,
                                CultureInfo.InvariantCulture.NumberFormat), null);
                        }
                        else
                        {
                            if (items[counter] == "1") property.SetValue(entity, true);
                        }
                    }
                }

                counter++;
            }

            return entity;
        }

        public override bool TryParse(string line, out TEan entity)
        {
            var items = Split(line);
            
            entity = Parse(items);

            return Validator.TryValidateObject(entity, new ValidationContext(entity), null, true);
        }
        
    }
}


