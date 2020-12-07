using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Impl
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly ILoggerRepository _loggerRepository;

        public CarrinhoService(
            ICarrinhoRepository carrinhoRepository,
            ILoggerRepository loggerRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _loggerRepository = loggerRepository;
        }

        public Carrinho Obter(string idCarrinho)
        {
            return _carrinhoRepository.Obter(idCarrinho);
        }

    }
}
