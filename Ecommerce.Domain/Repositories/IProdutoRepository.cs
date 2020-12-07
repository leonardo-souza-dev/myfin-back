using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface IProdutoRepository
    {
        void Inserir(Produto produto);
        Produto Obter(string idProduto);
        void Deletar(string idProduto);
        void Atualizar(Produto produto);
    }
}