﻿using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddQueryingOnWeb(this IServiceCollection services)
        {
            services.AddSingleton<IQueryFactory, QueryFactory>();
            
            services.AddScoped(typeof(QueryExecutor<,>), typeof(QueryExecutor<,>));

            services.AddSingleton<IQueryExecutorFactory, QueryExecutorFactory>();

            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        }

        public static void AddQueryingOnWeb(this IServiceCollection services, params Assembly[] assemblies)
        {
            AddQueryingOnWeb(services);

            foreach (var queryType in assemblies.GetQueryTypes())
            {
                services.AddScoped(queryType);
            }

            foreach (var typeInfo in assemblies.GetQueryHandlerTypes())
            {
                services.AddScoped(typeInfo.GetInterfaces().First(), typeInfo);
            }
        }
    }
}