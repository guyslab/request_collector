using Microsoft.AspNetCore.Mvc;
using RequestGenerator.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestObjectController : ControllerBase
    {
        private readonly IFactory<RequestModel> _factory;
        public RequestObjectController(IFactory<RequestModel> factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public IEnumerable<RequestModel> GetMany([FromQuery] int count = 1)
        {
            var rng = new Random();
            return Enumerable.Range(1, count)
                .Select(index => _factory.Create())
                .ToArray();
        }
    }
}
