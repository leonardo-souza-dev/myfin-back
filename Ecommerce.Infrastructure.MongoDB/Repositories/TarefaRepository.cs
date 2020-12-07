using System.Collections.Generic;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System.IO;
using System.Data.SQLite;

namespace Ecommerce.Infrastructure.Sqlite
{
    public class TarefaRepository : ITarefaRepository
    {
        private SQLiteConnection _con;

        public TarefaRepository()
        {
            var pastaAtual = Directory.GetCurrentDirectory();
            string cs = $"Data Source={pastaAtual}/tarefas.db";
            _con = new SQLiteConnection(cs);            
        }

        public List<Tarefa> ObterTodas(int ano, int mes, int diaInicio, int diaFim)
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            _con.Open();
            var query = $"SELECT * FROM TAREFAS WHERE Ano = {ano} AND MES = {mes} AND DIA BETWEEN {diaInicio} AND {diaFim} ";
            var cmd = new SQLiteCommand(query, _con);
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var id = rdr.GetInt32(0);
                    var descricao = rdr.GetString(1);
                    var anoRead = rdr.GetInt32(2);
                    var mesRead = rdr.GetInt32(3);
                    var diaRead = rdr.GetInt32(4);
                    var horaRead = rdr.GetInt32(5);
                    var minutoRead = rdr.GetInt32(6);
                    Tarefa tarefa = new Tarefa(id, descricao, anoRead, mesRead, diaRead, horaRead, minutoRead);

                    tarefas.Add(tarefa);
                }
            }

            _con.Close();

            return tarefas;
        }

        public bool Criar(Tarefa tarefa)
        {
            _con.Open();
            var query = $"INSERT OR REPLACE INTO Tarefas(Descricao, Ano, Mes, Dia, Hora, Minuto) " +
                $" VALUES ('{tarefa.Descricao}', {tarefa.Data.Year}, {tarefa.Data.Month}, {tarefa.Data.Day}, 0,0)";
            var cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();
            _con.Close();

            return true;
        }
    }
}
