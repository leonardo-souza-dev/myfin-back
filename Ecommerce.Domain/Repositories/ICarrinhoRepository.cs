using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface ICarrinhoRepository
    {
        void Criar(Carrinho carrinho);
        Carrinho Obter(string idCarrinho);
        void Atualizar(Carrinho carrinho);
    }
}
