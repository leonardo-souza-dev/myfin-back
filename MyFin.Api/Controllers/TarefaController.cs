using MyFin.Application.Requests;
using MyFin.Application.Responses;
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
        public List<SemanaResponse> ObterSemanas(DateTime primeiroDia, int qtdSemanas)
        {
            var semanasResponse = _tarefaService.ObterSemanas(primeiroDia, qtdSemanas);

            return semanasResponse;
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
