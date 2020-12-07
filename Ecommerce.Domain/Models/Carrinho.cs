using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Models
{
    public class Carrinho
    {
        public string Id { get; set; }

        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public void AdicionarProduto(Produto produto) => this.Produtos.Add(produto);

        public Carrinho(string id = null)
        {
            Id = id ?? Guid.NewGuid().ToString().Replace("-","").Substring(0,24);
        }

        public static Carrinho Criar(string id, List<Produto> produtos)
        {
            return new Carrinho
            {
                Id = id,
                Produtos = produtos
            };
        }
    }
}
