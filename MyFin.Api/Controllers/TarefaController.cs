using MyFin.Application.Messages;
using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyFin.Api.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("/obter-semanas")]
        public List<Semana> ObterSemanas(DateTime primeiroDia, int qtdSemanas)
        {
            var semanas = _tarefaService.ObterSemanas(primeiroDia, qtdSemanas);

            return semanas;
        }

        [HttpPut("/criar")]
        public Tarefa Criar([FromBody] TarefaRequest request)
        {
            return _tarefaService.Inserir(request.ToModel());
        }

        [HttpPost("/alterar")]
        public Tarefa Alterar([FromBody] TarefaRequest request)
        {
            return _tarefaService.Atualizar(request.ToModel(request.Id));
        }
    }
}
