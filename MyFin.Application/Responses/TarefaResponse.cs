using System;
using System.Collections.Generic;
using MyFin.Domain.Models;
using Utils;

namespace MyFin.Application.Responses
{
    public class TarefaResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int PontosPrevistos { get; set; }
        public DateTime Data { get; set; }
        public decimal? Valor { get; set; }
        public ContaResponse Conta { get; set; }
        public DateTime? DataVcto { get; set; }
        public DateTime? DataPgto { get; set; }
        public int PontosRealizados { get; set; }
        public bool Concluido { get; set; }
        public string DiaDaSemana { get; set; }

        public TarefaResponse(Tarefa tarefa)
        {
            this.Id = tarefa.Id;
            this.Descricao = tarefa.Descricao;
            this.PontosPrevistos = tarefa.PontosPrevistos;
            this.Data = tarefa.Data;
            this.Valor = tarefa.Valor;

            if (tarefa.Conta != null)
            {
                this.Conta = new ContaResponse(tarefa.Conta);
            }

            this.DataVcto = tarefa.DataVcto;
            this.DataPgto = tarefa.DataPgto;
            this.PontosPrevistos = tarefa.PontosPrevistos;
            this.Concluido = tarefa.Concluido;
            this.DiaDaSemana = tarefa.DiaDaSemana;
        }
    }
}
