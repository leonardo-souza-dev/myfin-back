using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Domain.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> ObterTodas(int ano, int mes, int diaInicio, int diaFim);
        bool Inserir(Tarefa tarefa);
        bool Atualizar(Tarefa tarefa);
    }
}