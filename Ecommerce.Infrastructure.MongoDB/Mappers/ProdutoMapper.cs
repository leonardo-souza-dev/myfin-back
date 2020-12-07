using Ecommerce.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Infrastructure.MongoDB
{
    internal static class ProdutoMapper
    {
        internal static Produto Map(this ProdutoDocument document)
        {
            return new Produto(document.Descricao) { Id = document.Id };
        }

        internal static ProdutoDocument Map(this Produto produto)
        {
            return new ProdutoDocument { Id = produto.Id, Descricao = produto.Descricao };
        }

        internal static List<Produto> Map(this List<ProdutoDocument> documents)
        {
            var entities = new List<Produto>();
            foreach (var item in documents)
            {
                var entity = new Produto(item.Descricao) { Id = item.Id };
                entities.Add(entity);
            }
            return entities;
        }

        internal static List<ProdutoDocument> Map(this List<Produto> entities)
        {
            var documents = new List<ProdutoDocument>();
            foreach (var item in entities)
            {
                var entity = new ProdutoDocument { Id = item.Id, Descricao = item.Descricao };
                documents.Add(entity);
            }
            return documents;
        }
    }
}
