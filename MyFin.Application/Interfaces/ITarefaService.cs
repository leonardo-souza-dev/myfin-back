using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Interfaces
{
    public interface ITarefaService
    {
        List<Semana> ObterSemanas(DateTime primeiroDia, int qtdSemanas);
        Tarefa Inserir(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
    }
}
