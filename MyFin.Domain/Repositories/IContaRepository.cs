using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Repositories
{
    public interface IContaRepository
    {
        List<Conta> ObterTodas();
    }
}