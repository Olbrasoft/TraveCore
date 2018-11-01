using AutoMapper;
using System;
using System.Reflection;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class Configuration : MapperConfiguration
    {
     
        private Configuration(Action<IMapperConfigurationExpression> configure) : base(configure)
        {
        }

        public Configuration():this(cfg=>cfg.AddProfiles(Assembly.GetAssembly(typeof(Configuration))))
        {
            
        }
    }
}