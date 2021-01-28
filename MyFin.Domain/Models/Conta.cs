using System;
using System.Collections.Generic;

namespace MyFin.Domain.Models
{
    public record Conta(int Id, string Descricao, decimal SaldoInicial);    
}
