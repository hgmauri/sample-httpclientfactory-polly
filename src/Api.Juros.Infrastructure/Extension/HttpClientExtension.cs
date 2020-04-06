using System;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Api.Juros.Infrastructure.Extension
{
    public static class HttpClientCollectionEExtension
    {
        public static void ConfigureHttpClientService(this IServiceCollection services, IConfiguration configuration)
        {
            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode && r.StatusCode != HttpStatusCode.BadRequest)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(6)
                });

            services.AddHttpClient("taxa", c =>
            {
                c.BaseAddress = new Uri($"{configuration.GetSection("UrlApiTaxa").Value}");

                c.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                c.DefaultRequestHeaders.Add("Keep-Alive", "3600");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            }).AddPolicyHandler(retryPolicy);
        }
    }
}
