using Bouncer.job.Startup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bouncer.job.function
{
    public class OrderFunction
    {
        private readonly HttpClient _client;
        private readonly JobApiOptions _settings;
        public OrderFunction(HttpClient httpClient, IOptions<JobApiOptions> options)
        {
            this._client = httpClient;
            _settings = options.Value;
        }

        [FunctionName("PayoutHttpTrigger")]
        public async Task Run([TimerTrigger("0 */01 * * * *")] TimerInfo myTimer, ILogger log)
        { 
            var jobUrl = _settings.JobApi;
            using (var httpClient = new HttpClient())
            {
                var url = @jobUrl;
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _settings.Token);
                var ggg = await httpClient.GetAsync(url);
            }
        }
    }
}


