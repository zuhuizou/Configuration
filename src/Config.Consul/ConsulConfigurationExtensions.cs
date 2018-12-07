using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Config.Consul
{
    public static class ConsulConfigurationExtensions
    {
        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<Uri> consulUrls, string consulPath)
        {
            return configurationBuilder.Add(new ConsulConfigurationSource(consulUrls, consulPath));
        }

        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<string> consulUrls, string consulPath)
        {
            return configurationBuilder.AddConsul(consulUrls.Select(u => new Uri(u)), consulPath);
        }

        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, ConsulConfig consulConfig)
        {
            return configurationBuilder.AddConsul(consulConfig.Urls, consulConfig.KeyStoreFolder);
        }
        
        public static void ConsulConfig(this IConfigurationBuilder context)
        {
            var configuration = context.Build();
            var consulConfig = configuration.GetSection(nameof(ConsulConfig)).Get<ConsulConfig>();
            if (consulConfig == null || consulConfig.Urls == null || consulConfig.Urls.Count == 0)
                throw new ArgumentNullException("can not find consul config");

            context.AddConsul(consulConfig);
        }
    }
}
