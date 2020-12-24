using MyFin.Domain.Models;

namespace MyFin.Application.Interfaces
{
    public interface ICarrinhoService
    {
        Carrinho Obter(string idCarrinho);
        //Resultado<Carrinho> AdicionarProdutoAoCarrinho(Produto produto, Carrinho carrinho);
    }
}
