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
            string cs = $"Data Source={pastaAtual}/db/tarefas.db";
            _con = new SQLiteConnection(cs);            
        }

        public List<Tarefa> ObterTodas(DateTime diaInicio, DateTime diaFim)
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            var diaInicioSqlite = Helper.ConverterDataSqlite(diaInicio);
            var diaFimSqlite = Helper.ConverterDataSqlite(diaFim);

            _con.Open();
            var query = $" SELECT T.Id, " +
                        $"        T.Descricao, " +
                        $"        T.PontosPrevistos, " +
                        $"        T.Data, " +
                        $"        T.Valor, " +
                        $"        T.DataVcto, " +
                        $"        T.DataPgto, " +
                        $"        T.PontosRealizados, " +
                        $"        T.Concluido, " +
                        $"        T.Anotacoes, " +
                        $"        T.ContaId, " +
                        $"        C.Nome, " +
                        $"        C.SaldoInicial " +
                        $" FROM TAREFAS T " +
                         " LEFT JOIN CONTAS C ON T.ContaId = C.Id " +
                        $" WHERE Data BETWEEN '{diaInicioSqlite}' AND '{diaFimSqlite}' ";
            var cmd = new SQLiteCommand(query, _con);
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var id = rdr.GetInt32(0);
                    var descricao = rdr.GetString(1);
                    var pontosPrevistosRead = rdr.GetInt32(2);
                    var dataRead = rdr.GetDateTime(3);

                    var valorRead = rdr.GetValue(4);
                    var valorReadDecimal = Convert.ToDecimal(valorRead);

                    var dataVctoRead = rdr.GetString(5);
                    DateTime? dataVctoReadDateTime = null;
                    if (dataVctoRead != "")
                    {
                        dataVctoReadDateTime = Convert.ToDateTime(dataVctoRead);
                    }

                    var dataPgtoRead = rdr.GetString(6);
                    DateTime? dataPgtoReadDateTime = null;
                    if (dataPgtoRead != "")
                    {
                        dataPgtoReadDateTime = Convert.ToDateTime(dataPgtoRead);
                    }

                    var pontosRealizadosRead = rdr.GetInt32(7);
                    var concluidoRead = rdr.GetBoolean(8);
                    var anotacoesRead = rdr.GetValue(9);

                    Conta conta = null;

                    if (!rdr.IsDBNull(10))
                    {
                        var contaIdRead = rdr.GetInt32(10);
                        var contaNomeRead = rdr.GetString(11);
                        var contaSaldoInicialRead = rdr.GetDecimal(12);

                        conta = new Conta(contaIdRead, 
                                          contaNomeRead, 
                                          contaSaldoInicialRead);
                    }                   

                    Tarefa tarefa = new Tarefa(id,
                                               descricao,
                                               dataRead,
                                               pontosPrevistosRead,
                                               pontosRealizadosRead,
                                               valorReadDecimal,
                                               conta,
                                               dataVctoReadDateTime,
                                               dataPgtoReadDateTime,
                                               concluidoRead);

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

            var queryValor = string.Empty;
            if (tarefa.Valor.HasValue)
            {
                queryValor = tarefa.Valor.Value.ToString();
            }
            else
            {
                queryValor = "''";
            }

            string contaId = "NULL";
            if (tarefa.Conta != null)
            {
                contaId = tarefa.Conta.Id.ToString();
            }

            var query = $" INSERT OR REPLACE INTO Tarefas (" +
                        $"Descricao                                       , " +
                        $"PontosPrevistos                                 , " +
                        $"Data                                            , " +
                        $"Valor                                           , " +
                        $"ContaId                                         , " +
                        $"DataVcto                                        , " +
                        $"DataPgto                                        , " +
                        $"PontosRealizados                                , " +
                        $"Concluido) " +                  
                            $" VALUES (" +                  
                        $"'{tarefa.Descricao}'                            , " +
                        $" {tarefa.PontosPrevistos}                       , " +
                        $"'{data}'                                        , " +
                        $" {queryValor}                                   , " +
                        $" {contaId}                                      , " +
                        $"'{tarefa.DataVcto}'                             , " +
                        $"'{tarefa.DataPgto}'                             ,  " +
                        $"'{tarefa.PontosRealizados}'                     ,  " +
                        $"'{Helper.ConverteBoolSqlite(tarefa.Concluido)}'    " +
                        $") ";
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

            string valor = "";
            if (tarefa.Valor.HasValue)
            {
                valor = tarefa.Valor.ToString();
            }

            string contaId = "NULL";
            if (tarefa.Conta != null)
            {
                contaId = tarefa.Conta.Id.ToString();
            }


            var query = $"UPDATE Tarefas SET Descricao = '{tarefa.Descricao}'  , " +
                $" PontosPrevistos = {tarefa.PontosPrevistos}                  , " +
                $" Data = '{Helper.ConverterDataSqlite(tarefa.Data)}'          , " +
                $" Valor = '{valor}'                                           , " +
                $" ContaId = {contaId}                                         , " +
                $" DataVcto = '{Helper.ConverterDataSqlite(tarefa.DataVcto)}'  , " +
                $" DataPgto = '{Helper.ConverterDataSqlite(tarefa.DataPgto)}'  , " +
                $" PontosRealizados = '{tarefa.PontosRealizados}'              , " +
                $" Concluido = '{Helper.ConverteBoolSqlite(tarefa.Concluido)}'   " +
                $" WHERE Id = {tarefa.Id} ";
            var cmd = new SQLiteCommand(query, _con);
            cmd.ExecuteNonQuery();
            _con.Close();

            return tarefa;
        }
    }
}
