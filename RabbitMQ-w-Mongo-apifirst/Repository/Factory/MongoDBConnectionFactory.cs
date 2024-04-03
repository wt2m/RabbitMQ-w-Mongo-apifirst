using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ_w_Mongo_apifirst.Repository.Factory
{
    public static class MongoDBConnectionFactory<T> where T : class
    {
        public static IMongoCollection<T> GetCollection()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
            var dataBaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE_NAME");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dataBaseName);
            var collection = database.GetCollection<T>(typeof(T).Name);

            return collection;
        }
    }
}