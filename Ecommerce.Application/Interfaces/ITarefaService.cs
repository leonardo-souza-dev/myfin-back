using System;
using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interfaces
{
    public interface ITarefaService
    {
        Semana ObterSemana(DateTime primeiroDia);
        bool Inserir(Tarefa tarefa);
    }
}
