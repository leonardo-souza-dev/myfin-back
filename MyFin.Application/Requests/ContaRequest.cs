using System;
using MyFin.Domain.Models;

namespace MyFin.Application.Requests
{
    public class ContaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoInicial { get; set; }

        public Conta ToModel()
        {
            return new Conta(this.Id, this.Descricao, this.SaldoInicial);
        }
    }
}
