using Ecommerce.Application.Messages;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("/obter")]
        public Semana ObterSemana(DateTime primeiroDia)
        {
            //return new DiaTarefas("seg", _tarefas);
            return _tarefaService.ObterSemana(primeiroDia);
        }

        [HttpPut("/criar")]
        public bool Inserir([FromBody]CriarTarefaRequest request)
        {
            _tarefaService.Inserir(new Tarefa(request.Descricao, request.Data));

            return true;
        }
    }
}
