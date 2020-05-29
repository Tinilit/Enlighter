using Enlighter.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Enlighter.Api.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public ValuesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string payload)
        {
            Console.WriteLine("received a Post: " + payload);
            _messageService.Enqueue(payload);
            return Ok("{\"success\": \"true\"}");
        }
    }
}