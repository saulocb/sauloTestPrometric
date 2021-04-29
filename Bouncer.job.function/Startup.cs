using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(Bouncer.job.Startup.Startup))]

namespace Bouncer.job.Startup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddOptions<JobApiOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("Api").Bind(settings);
            });
        }
    }

    public class JobApiOptions
    {
        public string JobApi { get; set; }
        public string PayoutApi { get; set; }
        public string Token { get; set; }
    }
}