using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using MyFin.Domain.Repositories;

namespace MyFin.Application.Impl
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public List<Conta> ObterContas()
        {
            var contas = _contaRepository.ObterTodas();
                        
            return contas;
        }
    }
}
