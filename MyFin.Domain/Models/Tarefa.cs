using System;
using Utils;

namespace MyFin.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }
        public int Pontos { get; private set; }

        public string DiaDaSemana
        {
            get
            {
                return Helper.RetonarDiaDaSemana(Data);                
            }
        }

        public Tarefa(int id, string descricao, int pontos, DateTime data)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Pontos = pontos;
            this.Data = data;
        }

        public Tarefa(int id, string descricao, DateTime data, object pontos)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = data;
            this.Pontos = ProcessarPontos(pontos);
        }

        public Tarefa(int id, string descricao, int ano, int mes, int dia, int hora, int minuto, int pontos)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = new DateTime(ano, mes, dia, hora, minuto, 0);
            this.Pontos = pontos;
        }

        public Tarefa(string descricao, DateTime data, object pontos)
        {
            this.Descricao = descricao;
            this.Data = data;
            this.Pontos = ProcessarPontos(pontos);
        }

        public Tarefa(int id, string descricao, DateTime data)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = data;
        }

        private int ProcessarPontos(object pontosObj)
        {
            string pontos = pontosObj != null ? pontosObj.ToString() : "0";
            return int.Parse(pontos);

        }
    }
}
