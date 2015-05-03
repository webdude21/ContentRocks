namespace Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using Web.Infrastructure.Mappings;

    public class AutoMapperConfig
    {
        public void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            LoadStandardMappings(types);
            LoadCustomMappings(types);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = from type in types
                       from i in type.GetInterfaces()
                       where typeof(IHaveCustomMappings).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface
                       select (IHaveCustomMappings)Activator.CreateInstance(type);

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = from type in types
                       from i in type.GetInterfaces()
                       where
                           i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !type.IsAbstract
                           && !type.IsInterface
                       select new { Source = i.GetGenericArguments()[0], Destination = type };

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private void LoadGlobalMappings()
        {
            Mapper.CreateMap<string, Guid>().ConvertUsing(
                s =>
                    {
                        var guid = Guid.Empty;
                        Guid.TryParse(s, out guid);
                        return guid;
                    });

            Mapper.CreateMap<Guid, string>().ConvertUsing(g => g.ToString());
        }
    }
}