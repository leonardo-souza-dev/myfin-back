using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Interfaces
{
    public interface ICarrinhoService
    {
        Carrinho Obter(string idCarrinho);
        //Resultado<Carrinho> AdicionarProdutoAoCarrinho(Produto produto, Carrinho carrinho);
    }
}
