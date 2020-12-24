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

        [HttpGet("/obter-semana")]
        public Semana ObterSemana(DateTime primeiroDia)
        {
            var semana = _tarefaService.ObterSemana(primeiroDia);
            return semana;
        }

        [HttpPut("/criar")]
        public bool Criar([FromBody] TarefaRequest request)
        {
            _tarefaService.Inserir(new Tarefa(request.Descricao, request.Data));

            return true;
        }

        [HttpPost("/alterar")]
        public bool Alterar([FromBody] TarefaRequest request)
        {
            _tarefaService.Atualizar(new Tarefa(request.Id, request.Descricao, request.Data, request.Pontos));

            return true;
        }
    }
}
