using System;
using System.Collections.Generic;
using MyFin.Application.Responses;
using MyFin.Domain.Models;

namespace MyFin.Domain.Interfaces
{
    public interface ITarefaService
    {
        List<SemanaResponse> ObterSemanas(DateTime primeiroDia, int qtdSemanas);
        Tarefa Inserir(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
        List<TarefaResponse> ObterTarefasMes(int mes);
        List<TarefaResponse> ObterTransacoesMes(int mes);
    }
}
