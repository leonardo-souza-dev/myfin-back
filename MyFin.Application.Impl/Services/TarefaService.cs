using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using MyFin.Domain.Repositories;
using MyFin.Application.Responses;

namespace MyFin.Application.Impl
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;            
        }

        public List<SemanaResponse> ObterSemanas(DateTime primeiroDia, int qdtSemanas)
        {
            if (qdtSemanas < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(qdtSemanas));
            }

            List<Semana> semanas = new List<Semana>();
            for(var i = 0; i < qdtSemanas; i++)
            {
                semanas.Add(new Semana(primeiroDia.AddDays(i * 7)));
            }

            var tarefas = _tarefaRepository.ObterTodas(primeiroDia, primeiroDia.AddDays(6 + (qdtSemanas - 1) * 7));
            foreach(var semana in semanas)
            {
                foreach(var dia in semana.Dias)
                {
                    dia.AdicionarTarefas(tarefas.Where(x => x.DiaDaSemana == dia.DiaDaSemana && x.Data == dia.Data).ToList());
                }
            }
            
            var semanasResponse = new List<SemanaResponse>();
            semanas.ForEach(semana => semanasResponse.Add(new SemanaResponse(semana)));
            
            return semanasResponse;
        }

        public Tarefa Inserir(Tarefa tarefa)
        {
            var id = _tarefaRepository.Inserir(tarefa);

            return new Tarefa(id, tarefa);
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            return _tarefaRepository.Atualizar(tarefa);
        }
    }
}
