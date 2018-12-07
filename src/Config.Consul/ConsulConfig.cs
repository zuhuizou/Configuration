using System;
using System.Collections.Generic;

namespace Config.Consul
{
    public class ConsulConfig
    {
        public List<string> Urls { get; set; }

        /// <summary>
        /// if the key is App1/Server1/Config, then KeyStoreFolder is App1/Server1
        /// </summary>
        public string KeyStoreFolder { get; set; }
    }
}
