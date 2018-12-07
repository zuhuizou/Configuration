using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Config.Consul
{
    public class ConsulConfigurationSource : IConfigurationSource
    {
        public IEnumerable<Uri> ConsulUrls { get; }
        public string KeyStoreFolder { get; }

        public ConsulConfigurationSource(IEnumerable<Uri> consulUrls, string storeFolder)
        {
            ConsulUrls = consulUrls;
            KeyStoreFolder = storeFolder;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConsulConfigurationProvider(ConsulUrls, KeyStoreFolder);
        }
    }
}
