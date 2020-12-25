using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using MyFin.Domain.Repositories;

namespace MyFin.Application.Impl
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;            
        }

        public Semana ObterSemana(DateTime primeiroDia)
        {
            Semana semana = new Semana();
            var tarefas = _tarefaRepository.ObterTodas(primeiroDia.Year, primeiroDia.Month, primeiroDia.Day, primeiroDia.Day + 6);

            foreach(var dia in semana.Dias)
            {
                dia.AdicionarTarefas(tarefas.Where(x => x.DiaDaSemana == dia.DiaDaSemana).ToList());
            }

            return semana;
        }

        public Tarefa Inserir(Tarefa tarefa)
        {
            return new Tarefa(_tarefaRepository.Inserir(tarefa), tarefa.Descricao, tarefa.Data, tarefa.Pontos);
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            return _tarefaRepository.Atualizar(tarefa);
        }
    }
}
