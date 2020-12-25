using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Interfaces
{
    public interface ITarefaService
    {
        Semana ObterSemana(DateTime primeiroDia);
        Tarefa Inserir(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
    }
}
