using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> ObterTodas(DateTime diaInicio, DateTime diaFim);
        int Inserir(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
    }
}