using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Interfaces
{
    public interface IContaService
    {
        List<Conta> ObterContas();
    }
}
