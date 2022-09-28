using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudflareDynDNS
{
    public class Config
    {
        private static ILogger _logger;

        public Config(ILogger<Config> log)
        {
            _logger = log;
        }

        public ConfigTemplate GetConfigTemplate(string filename)
        {
            if (File.Exists(filename))
            {

            }
            else
            {
                _logger.LogCritical("File {filename} not found, please fill it before restarting the app", filename);
            }
            return null;
        }

        public class ConfigTemplate
        {
            public string DiscordWebhookAddress { get; set; }
            public string CloudflareToken { get; set; }
            /// <summary>
            /// Domain name that we need to find on cloudflare backend
            /// </summary>
            public string DomainName { get; set; }
        }
    }
}
