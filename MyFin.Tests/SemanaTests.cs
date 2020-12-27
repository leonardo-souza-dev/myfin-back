using System;
using MyFin.Domain.Models;
using Xunit;

namespace MyFin.Tests
{

    public class SemanaTests
    {
        [Theory]
        [InlineData(2020, 12, 26, 52)]
        [InlineData(2020, 1, 1, 1)]
        [InlineData(2020, 3, 14, 11)]
        [InlineData(2020, 2, 29, 9)]
        public void DeveObterNumeroDaSemana(int ano, int mes, int dia, int numSemana)
        {
            // arrange & act
            var data = new DateTime(ano, mes, dia);
            var sut = new Semana(data);

            // assert
            Assert.Equal(numSemana, sut.Num);
        }
    }
}
