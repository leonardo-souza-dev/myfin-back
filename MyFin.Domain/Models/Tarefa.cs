using System;
using Utils;

namespace MyFin.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public int PontosPrevistos { get; private set; }
        public DateTime Data { get; private set; }
        public decimal? Valor { get; private set; }
        public string Conta { get; private set; }
        public DateTime? DataVcto { get; private set; }
        public DateTime? DataPgto { get; private set; }
        public int PontosRealizados { get; private set; }
        public bool Concluido { get; private set; }

        public string DiaDaSemana
        {
            get
            {
                return Helper.RetonarDiaDaSemana(Data);                
            }
        }

        public Tarefa(int id, Tarefa tarefa) 
            : this(id, 
                   tarefa.Descricao, 
                   tarefa.Data, 
                   tarefa.PontosPrevistos, 
                   tarefa.PontosRealizados, 
                   tarefa.Valor,
                   tarefa.Conta, 
                   tarefa.DataVcto, 
                   tarefa.DataPgto, 
                   tarefa.Concluido)
        {

        }

        public Tarefa(int id,
                      string descricao,
                      DateTime data,
                      object pontosPrevistos,
                      object pontosRealizados,
                      decimal? valor,
                      string conta,
                      DateTime? dataVcto,
                      DateTime? dataPgto,
                      bool concluido)
            : this(descricao, data, pontosPrevistos, pontosRealizados, valor, conta, dataVcto, dataPgto, concluido)
        {
            this.Id = id;
        }

        public Tarefa(string descricao,
                      DateTime data,
                      object pontosPrevistos,
                      object pontosRealizados,
                      decimal? valor,
                      string conta,
                      DateTime? dataVcto,
                      DateTime? dataPgto,
                      bool concluido)
        {
            this.Descricao = descricao;
            this.Data = data;
            this.PontosPrevistos = ProcessarPontos(pontosPrevistos);
            this.PontosRealizados = ProcessarPontos(pontosRealizados);
            this.Valor = valor;
            this.Conta = conta;
            this.DataVcto = dataVcto;
            this.DataPgto = dataPgto;
            this.Concluido = concluido;
        }

        private int ProcessarPontos(object pontosObj)
        {
            string pontos = pontosObj != null ? pontosObj.ToString() : "0";
            return int.Parse(pontos);
        }
    }
}
