using System.Collections.Generic;
using MyFin.Domain.Models;
using MyFin.Domain.Repositories;
using System.IO;
using System.Data.SQLite;
using System;
using Utils;

namespace MyFin.Infra.Sqlite
{
    public class TarefaRepository : ITarefaRepository
    {
        private SQLiteConnection _con;

        public TarefaRepository()
        {
            var pastaAtual = Directory.GetCurrentDirectory();
            string cs = $"Data Source={pastaAtual}/../../myfin-db/tarefas.db";
            _con = new SQLiteConnection(cs);            
        }

        public List<Tarefa> ObterTodas(DateTime diaInicio, DateTime diaFim)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            var diaInicioSqlite = Helper.ConverterDataSqlite(diaInicio);
            var diaFimSqlite = Helper.ConverterDataSqlite(diaFim);

            _con.Open();
            var query = $"SELECT * FROM TAREFAS WHERE Data BETWEEN '{diaInicioSqlite}' AND '{diaFimSqlite}'";
            var cmd = new SQLiteCommand(query, _con);
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var id = rdr.GetInt32(0);
                    var descricao = rdr.GetString(1);
                    var pontosRead = rdr.GetInt32(2);
                    var dataRead = rdr.GetDateTime(3);

                    Tarefa tarefa = new Tarefa(id, descricao, pontosRead, dataRead);

                    tarefas.Add(tarefa);
                }
            }

            _con.Close();

            return tarefas;
        }

        public int Inserir(Tarefa tarefa)
        {
            _con.Open();
            var data = Helper.ConverterDataSqlite(tarefa.Data);
            var query = $" INSERT OR REPLACE INTO Tarefas(Descricao, Pontos, Data) " +
                        $" VALUES ('{tarefa.Descricao}', {tarefa.Pontos}, '{data}') ";
            var cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT last_insert_rowid() ";

            int ultimoId = Convert.ToInt32(cmd.ExecuteScalar());
            
            _con.Close();

            return ultimoId;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            _con.Open();
            var query = $"UPDATE Tarefas SET Descricao = '{tarefa.Descricao}', " +
                $" Pontos = {tarefa.Pontos}, " +
                $" Data = '{Helper.ConverterDataSqlite(tarefa.Data)}' " +
                $" WHERE Id = {tarefa.Id} ";
            var cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();
            _con.Close();

            return tarefa;
        }
    }
}
