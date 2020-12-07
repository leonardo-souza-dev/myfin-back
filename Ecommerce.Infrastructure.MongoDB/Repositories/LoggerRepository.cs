using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using MongoDB.Driver;
using System.Linq;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly IMongoCollection<LogDocument> _logs;

        public LoggerRepository(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _logs = database.GetCollection<LogDocument>(settings.LoggerCollectionName);
        }

        public void Logar(string conteudo)
        {
            _logs.InsertOne(conteudo.Map());
        }
    }
}