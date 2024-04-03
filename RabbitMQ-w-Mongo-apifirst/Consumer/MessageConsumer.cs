using MassTransit;
using MassTransit.Transports;
using RabbitMQ_w_Mongo_apifirst.Domain;
using RabbitMQ_w_Mongo_apifirst.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ_w_Mongo_apifirst.Consumer
{
    public sealed class MessageConsumer : IConsumer<Message>
    {
        private readonly ILogger<MessageConsumer> _logger;
        private readonly IMessageRepository _MessageRepository;


        public MessageConsumer(ILogger<MessageConsumer> logger, IMessageRepository MessageRepository)
        {
            _logger = logger;
            _MessageRepository = MessageRepository;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            try
            {
                var Message = context.Message;

                _logger.LogInformation($"Message received on consumer: {Message.MessageId}");

                _MessageRepository.Insert(Message);

                _logger.LogInformation($"Message received: {Message.MessageId}");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error on try to consume Message", ex);
            }

            return Task.CompletedTask;
        }
    }
}