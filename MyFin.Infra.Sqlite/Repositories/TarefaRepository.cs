﻿using System.Collections.Generic;
using MyFin.Domain.Models;
using MyFin.Domain.Repositories;
using System.IO;
using System.Data.SQLite;
using System;
using System.Globalization;

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
            var cultura = CultureInfo.CreateSpecificCulture("pt-BR");
            var diaInicioSqlite = diaInicio.ToString("s", cultura);
            var diaFimSqlite = diaFim.ToString("s", cultura);

            _con.Open();
            var query = $"SELECT * FROM TAREFAS WHERE Data BETWEEN '{diaInicioSqlite}.000' AND '{diaFimSqlite}.000'";
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
                    var pontosRead = rdr.GetInt32(7);

                    Tarefa tarefa = new Tarefa(id, descricao, anoRead, mesRead, diaRead, horaRead, minutoRead, pontosRead);

                    tarefas.Add(tarefa);
                }
            }

            _con.Close();

            return tarefas;
        }

        public int Inserir(Tarefa tarefa)
        {
            _con.Open();
            var query = $"INSERT OR REPLACE INTO Tarefas(Descricao, Ano, Mes, Dia, Hora, Minuto, Pontos) " +
                $" VALUES ('{tarefa.Descricao}', {tarefa.Data.Year}, {tarefa.Data.Month}, {tarefa.Data.Day}, 0,0, {tarefa.Pontos})";
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
                $" Ano = {tarefa.Data.Year}, " +
                $" Mes = {tarefa.Data.Month}, " +
                $" Dia = {tarefa.Data.Day}, " +
                $" Hora = 0, " +
                $" Minuto = 0, " +
                $" Pontos = {tarefa.Pontos} " +
                $" WHERE Id = {tarefa.Id} ";
            var cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();
            _con.Close();

            return tarefa;
        }
    }
}
