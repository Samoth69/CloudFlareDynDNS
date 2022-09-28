using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CloudflareDynDNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(x => x.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                    options.SingleLine = true;
                    options.TimestampFormat = "yyyy/MM/dd hh:mm:ss ";
                }).SetMinimumLevel(LogLevel.Debug))
                .AddSingleton<Config>()
                .BuildServiceProvider();

            var log = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();

            var conf = serviceProvider.GetService<Config>();
            var test = conf.GetConfigTemplate("conf.json");
            log.LogInformation(conf.ToString());
        }
    }
}