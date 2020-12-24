using System;
using System.Collections.Generic;
using Utils;

namespace Ecommerce.Domain.Models
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

        public Tarefa(int id, string descricao, string data)
        {
            this.Id = id;
            this.Descricao = descricao;
            var ano = Convert.ToInt32(data.Split('-')[0]);
            var mes = Convert.ToInt32(data.Split('-')[1]);
            var dia = Convert.ToInt32(data.Split('-')[2]);
            this.Data = new DateTime(ano, mes, dia);
        }
        public Tarefa(int id, string descricao, DateTime data, int pontos)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = data;
            this.Pontos = pontos;
        }

        public Tarefa(int id, string descricao, int ano, int mes, int dia, int hora, int minuto, int pontos)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = new DateTime(ano, mes, dia, hora, minuto, 0);
            this.Pontos = pontos;
        }

        public Tarefa(string descricao, DateTime data)
        {
            this.Descricao = descricao;
            this.Data = data;
        }

        public Tarefa(int id, string descricao, DateTime data)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Data = data;
        }
    }
}
