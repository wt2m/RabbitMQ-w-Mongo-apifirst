using MassTransit.Transports;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ_w_Mongo_apifirst.Domain;

namespace RabbitMQ_w_Mongo_apifirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IBusControl _bus;

        public MessageController(ILogger<MessageController> logger, IBusControl bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Message Message)
        {
            await _bus.Publish(Message);

            _logger.LogInformation($"Message received. MessageId: {Message.MessageId}");

            return Ok($"{DateTime.Now:o}");
        }
    }
}
