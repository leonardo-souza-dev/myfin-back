﻿using MyFin.Application.Requests;
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
        public TarefaResponse Criar([FromBody] TarefaRequest request)
        {
            return new TarefaResponse(_tarefaService.Inserir(request.ToModel()));
        }

        [HttpPost("/alterar")]
        public TarefaResponse Alterar([FromBody] TarefaRequest request)
        {
            return new TarefaResponse(_tarefaService.Atualizar(request.ToModel(request.Id)));
        }

        [HttpGet("/obter-transacoes-mes")]
        public List<TarefaResponse> ObterTransacoesMes(int mes)
        {
            var tarefasResponse = _tarefaService.ObterTransacoesMes(mes);

            return tarefasResponse;
        }
    }
}
