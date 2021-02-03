using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RequestExecutor.Commands;
using RequestExecutor.Options;
using RequestExecutor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestExecutor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiRequestProcessController : ControllerBase
    {
        private readonly ICommand _processCommand;

        public MultiRequestProcessController(ICommand command)
        {
            _processCommand = command;
        }

        [HttpPost]
        public void ProcessNext()
        {
            _processCommand.Execute();
        }
    }
}
