using Microsoft.AspNetCore.Mvc;
using RequestExecutor.Commands;

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
