using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RequestExecutor.Extensions;
using RequestExecutor.Options;
using RequestExecutor.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace RequestExecutor.Commands
{
    public class MutliRequestProcessCommnd: ICommand
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<MutliRequestProcessCommnd> _logger;
        private readonly IMessageService _messaging;
        private readonly IRequestGenerator _reqGen;
        private readonly int _reqObjectCount;

        private const int DefaultRequestObjectsCount = 5;

        public MutliRequestProcessCommnd(
            ILogger<MutliRequestProcessCommnd> logger,
            IMessageService messaging,
            IRequestGenerator requestGenerator,
            IOptions<RequestGenerationOptions> genOptions,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _messaging = messaging;
            _reqGen = requestGenerator;
            _reqObjectCount = genOptions?.Value?.RequestObjectsCount ?? DefaultRequestObjectsCount;
            _httpClientFactory = httpClientFactory;
        }

        public void Execute()
        {
            Guid processUid = Guid.NewGuid();
            _logger.LogTrace($"Process {processUid}: Started");

            _logger.LogTrace($"Process {processUid}: Generating {_reqObjectCount} request objects");
            var reqObjects = _reqGen.GenerateMany(_reqObjectCount).Result;

            foreach (var reqObject in reqObjects.OrderBy(r => r.Priority))
            {
                var response = _httpClientFactory.CreateClient().GetAsync(reqObject.Url).Result;
                var responseModel = response.ToResponseModel(reqObject, processUid.ToString());
                var responseModelJson = JsonSerializer.Serialize(responseModel);
                _messaging.Enqueue(responseModelJson);
            }            
        }
    }
}
