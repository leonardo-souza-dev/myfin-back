using System;
using System.Collections.Generic;
using MyFin.Domain.Models;
using Utils;

namespace MyFin.Application.Responses
{
    public class DiaResponse
    {
        public string DiaDaSemana { get; set; }
        public List<TarefaResponse> Tarefas { get; set; } = new List<TarefaResponse>();
        public DateTime Data { get; set; }
        //public List<Saldo> Saldos { get; set; }

        public DiaResponse(Dia dia)
        {
            this.DiaDaSemana = dia.DiaDaSemana;

            foreach (var item in dia.Tarefas)
            {
                this.Tarefas.Add(new TarefaResponse(item));
            }

            this.Data = dia.Data;
        }
    }
}
