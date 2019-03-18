using System.Reflection;
using AutoMapper;

namespace Olbrasoft.Travel.Data.Mapping
{
    public class MapperConfigurationProvider : MapperConfiguration
    {
        public MapperConfigurationProvider() : base(cfg => cfg.AddProfiles(Assembly.GetAssembly(typeof(MapperConfigurationProvider))))
        {
        }
    }
}