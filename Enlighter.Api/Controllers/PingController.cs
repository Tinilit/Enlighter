using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Enlighter.Api.Controllers
{
    [ApiController]
    [Route("api/ping")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        private static DateTime startupTime = DateTime.UtcNow;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = new
            {
                StartupTime = startupTime,
                Uptime = (DateTime.UtcNow - startupTime).ToString(),
                Response = "pong"
            };

            _logger.LogInformation("pong", result);

            return Ok(result);
        }
    }
}