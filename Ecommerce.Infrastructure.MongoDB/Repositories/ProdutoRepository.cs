using Ecommerce.Domain;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IMongoCollection<ProdutoDocument> _produtos;

        public ProdutoRepository(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<ProdutoDocument>(settings.ProdutoCollectionName);
        }

        public Produto Inserir(Produto produto)
        {
            _produtos.InsertOne(produto.Map());

            return produto;
        }

        public void Deletar(string id)
        {
            _produtos.DeleteOne(p => p.Id == id);
        }

        public Produto Obter(string id)
        {
            return _produtos.Find(x => x.Id == id).FirstOrDefault()?.Map();
        }
    }
}
