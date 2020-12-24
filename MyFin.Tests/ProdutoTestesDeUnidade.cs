using NUnit.Framework;
using MyFin.Application.Impl;
using Moq;
using MyFin.Domain.Repositories;
using MyFin.Domain.Models;

namespace MyFin.Tests
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