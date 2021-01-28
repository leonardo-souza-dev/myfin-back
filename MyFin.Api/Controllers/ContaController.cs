using MyFin.Application.Messages;
using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyFin.Api.Controllers
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet("/obter-contas")]
        public List<Conta> ObterContas()
        {
            var contas = _contaService.ObterContas();

            return contas;
        }
    }
}
