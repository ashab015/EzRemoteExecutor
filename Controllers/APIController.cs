using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzRemoteExecutor.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EzRemoteExecutor.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;
        private readonly IPowerShellCommandService _powerShellCommandService;

        public APIController(ILogger<APIController> logger, IPowerShellCommandService powerShellCommandService)
        { 
            _logger = logger;
            _powerShellCommandService = powerShellCommandService;
        }

        [HttpGet, HttpPost, Route("health")]
        public async Task<IActionResult> Health()
        {
            return Ok(true);
        }

        [HttpGet, HttpPost, Route("execute")]
        public async Task<IActionResult> ExecuteAsync([FromQuery]string command)
        {
            _logger.LogInformation(command);

            var powerShellResult = await _powerShellCommandService.Execute(command);

            _logger.LogInformation(nameof(powerShellResult), powerShellResult);

            return Ok(powerShellResult);
        }
    }
}
