using System;
using System.Collections.Generic;

namespace MyFin.Domain.Models
{
    public class Dia
    {
        public string DiaDaSemana { get; private set; }
        public List<Tarefa> Tarefas { get; private set; } = new List<Tarefa>();

        public Dia(string diaDaSemana, List<Tarefa> tarefas)
        {
            this.DiaDaSemana = diaDaSemana;
            this.Tarefas = tarefas;
        }

        public Dia(string diaDaSemana)
        {
            this.DiaDaSemana = diaDaSemana;
        }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            this.Tarefas.Add(tarefa);
        }

        public void AdicionarTarefas(List<Tarefa> tarefas)
        {
            this.Tarefas.AddRange(tarefas);
        }
    }
}
