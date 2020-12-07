using NUnit.Framework;
using Ecommerce.Application.Impl;
using Moq;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Models;

namespace Ecommerce.Tests
{
    public class ProdutoTestesDeUnidade
    {
        [Test]
        [TestCase("Ar")]
        public void Nao_deve_cadastrar_produto_com_descricao_curta(string descricao)
        {
            // arrange
            var produtoRepository = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(produtoRepository.Object);
            var produto = new Produto(descricao);

            // act
            var resultado = produtoService.Inserir(produto);

            // assert
            Assert.AreEqual("Descrição do produto deve ter mais de 2 caracteres", resultado.Mensagem);
        }
    }
}