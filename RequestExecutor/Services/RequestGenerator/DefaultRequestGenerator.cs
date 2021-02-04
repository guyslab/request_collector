using Microsoft.Extensions.Options;
using RequestExecutor.Models;
using RequestExecutor.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RequestExecutor.Services
{
    public class DefaultRequestGenerator: IRequestGenerator
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RequestGenerationOptions _options;

        public DefaultRequestGenerator(
            IHttpClientFactory httpClientFactory,
            IOptions<RequestGenerationOptions> options)
        {
            _options = options.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<RequestObjectModel>> GenerateMany(int objectsCount)
        {
            string url = _options.EndpointBaseUrl + "requestObject";
            var response = await _httpClientFactory.CreateClient().GetAsync(url);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IEnumerable<RequestObjectModel>>(json);

            return result;
        }
    }
}
