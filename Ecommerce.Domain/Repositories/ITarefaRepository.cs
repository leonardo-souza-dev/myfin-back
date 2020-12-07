using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> ObterTodas(int ano, int mes, int diaInicio, int diaFim);
        bool Criar(Tarefa tarefa);
    }
}