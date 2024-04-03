using MassTransit.Transports;
using RabbitMQ_w_Mongo_apifirst.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ_w_Mongo_apifirst.Repository
{
    public interface IMessageRepository
    {
        void Insert(Message Message);
    }
}