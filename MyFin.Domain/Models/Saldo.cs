using System.Linq;
using System.Collections.Generic;

namespace MyFin.Domain.Models
{
    public class Saldo
    {
        public List<Conta> Contas { get; private set; } = new List<Conta>();

        // public decimal SaldoTotal
        // {
        //     get
        //     {
        //         return this.Contas.Sum(x => x.Saldo)

        //     }
        // }
    }
}
