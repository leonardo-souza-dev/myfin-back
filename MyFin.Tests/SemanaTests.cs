using System;
using MyFin.Domain.Models;
using Xunit;

namespace MyFin.Tests
{

    public class SemanaTests
    {
        [Theory]
        [InlineData(2020, 1, 1, 1)]
        [InlineData(2020, 2, 29, 9)]
        [InlineData(2020, 3, 14, 11)]
        [InlineData(2020, 4, 11, 15)]
        [InlineData(2020, 5, 4, 19)]
        [InlineData(2020, 6, 13, 24)]
        [InlineData(2020, 6, 14, 25)]
        [InlineData(2020, 6, 15, 25)]
        [InlineData(2020, 6, 16, 25)]
        [InlineData(2020, 6, 17, 25)]
        [InlineData(2020, 6, 18, 25)]
        [InlineData(2020, 6, 19, 25)]
        [InlineData(2020, 6, 20, 25)]
        [InlineData(2020, 6, 21, 26)]
        [InlineData(2020, 7, 9, 28)]
        [InlineData(2020, 8, 16, 34)]
        [InlineData(2020, 9, 7, 37)]
        [InlineData(2020, 10, 12, 42)]
        [InlineData(2020, 11, 15, 47)]
        [InlineData(2020, 12, 31, 53)]
        [InlineData(2021, 1, 1, 1)]
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
