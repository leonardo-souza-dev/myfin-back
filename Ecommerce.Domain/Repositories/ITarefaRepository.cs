using System.Collections.Generic;
using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> ObterTodas(int ano, int mes, int diaInicio, int diaFim);
        bool Inserir(Tarefa tarefa);
        bool Atualizar(Tarefa tarefa);
    }
}