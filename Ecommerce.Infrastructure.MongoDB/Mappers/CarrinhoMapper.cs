using Ecommerce.Domain.Models;

namespace Ecommerce.Infrastructure.MongoDB
{
    internal static class CarrinhoMapper
    {
        internal static Carrinho Map(this CarrinhoDocument document)
        {
            return Carrinho.Criar(document.Id, document.Produtos?.Map());
        }

        internal static CarrinhoDocument Map(this Carrinho carrinho)
        {
            return new CarrinhoDocument { Id = carrinho.Id, Produtos = carrinho.Produtos?.Map() };
        }
    }
}
