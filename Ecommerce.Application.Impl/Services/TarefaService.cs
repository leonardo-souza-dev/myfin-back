using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using Ecommerce.Domain.Repositories;

namespace Ecommerce.Application.Impl
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

        public bool Inserir(Tarefa tarefa)
        {
            return _tarefaRepository.Inserir(tarefa);
        }

        public bool Atualizar(Tarefa tarefa)
        {
            return _tarefaRepository.Atualizar(tarefa);
        }
    }
}
