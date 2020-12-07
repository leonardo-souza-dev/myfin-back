using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using MongoDB.Driver;
using System.Linq;

namespace Ecommerce.Infrastructure.MongoDB
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IMongoCollection<CarrinhoDocument> _carrinhos;

        public CarrinhoRepository(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carrinhos = database.GetCollection<CarrinhoDocument>(settings.CarrinhoCollectionName);
        }

        public void Criar(Carrinho carrinho)
        {
            _carrinhos.InsertOne(carrinho.Map());
        }

        public Carrinho Obter(string idCarrinho)
        {
            return _carrinhos.Find(x => x.Id == idCarrinho).FirstOrDefault()?.Map();
        }

        public void Atualizar(Carrinho carrinho)
        {
            var document = carrinho.Map();

            var result = _carrinhos.ReplaceOne(c => c.Id == carrinho.Id, document);
        }
    }
}