using MassTransit.Transports;

using RabbitMQ_w_Mongo_apifirst.Repository.Factory;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ_w_Mongo_apifirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ_w_Mongo_apifirst.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ILogger<MessageRepository> _logger;
        public MessageRepository(ILogger<MessageRepository> logger)
        {
            _logger = logger;
        }

        public void Insert(Message Message)
        {
            try
            {
                var collection = MongoDBConnectionFactory<Message>.GetCollection();

                collection.InsertOne(Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao tentar inserir uma nova mensagem. MessageId: {Message.MessageId}", ex);
                throw;
            }
        }
    }
}