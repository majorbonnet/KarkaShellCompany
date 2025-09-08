using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaShellCompany.Domain.Gw2Api
{
    public abstract class Request
    {
        protected static HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://api.guildwars2.com/v2/")
        };

        protected delegate HttpRequestMessage ModifyRequestMethod(HttpRequestMessage message);

        protected ModifyRequestMethod? ModifyRequest { get; set; }

        protected async Task<T> GetResponse<T>(HttpMethod method, string endpoint)
        {
            var requestMessage = new HttpRequestMessage(method, endpoint);

            if (ModifyRequest is not null)
            {
                requestMessage = ModifyRequest(requestMessage);
            }

            var response = await _httpClient.SendAsync(requestMessage);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching data from {endpoint}: {response.ReasonPhrase}");
            }
            var content = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(content) ?? throw new InvalidOperationException("Deserialization failed.");
        }
    }
}
