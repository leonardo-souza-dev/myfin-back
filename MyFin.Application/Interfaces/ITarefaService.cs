using System;
using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Interfaces
{
    public interface ITarefaService
    {
        Semana ObterSemana(DateTime primeiroDia);
        bool Inserir(Tarefa tarefa);
        bool Atualizar(Tarefa tarefa);
    }
}
