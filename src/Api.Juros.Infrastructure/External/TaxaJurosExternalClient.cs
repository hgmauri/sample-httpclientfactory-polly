using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Juros.Infrastructure.Output;

namespace Api.Juros.Infrastructure.External
{
    public class TaxaJurosExternalClient : ITaxaJurosExternalClient
    {
        public readonly IHttpClientFactory _factory;

        public TaxaJurosExternalClient(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<double> GetTaxaJuros()
        {
            var client = _factory.CreateClient("taxa");

            var result = await client.GetAsync("Get");

            var resultContent = await result.Content.ReadAsStringAsync();

            var resultObject = JsonSerializer.Deserialize<TaxaJurosOutput>(resultContent, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            return resultObject.Taxa;

        }
    }
}
