using System.Collections.Generic;
using MyFin.Domain.Models;
using MyFin.Domain.Repositories;
using System.IO;
using System.Data.SQLite;
using System;
using Utils;

namespace MyFin.Infra.Sqlite
{
    public class ContaRepository : IContaRepository
    {
        private SQLiteConnection _con;

        public ContaRepository()
        {
            var pastaAtual = Directory.GetCurrentDirectory();
            string cs = $"Data Source={pastaAtual}/../tarefas.db";
            _con = new SQLiteConnection(cs);            
        }

        public List<Conta> ObterTodas()
        {
            var contas = new List<Conta>();

            _con.Open();
            var query = $" SELECT * FROM CONTAS ";
            var cmd = new SQLiteCommand(query, _con);
            using (SQLiteDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    var id = rdr.GetInt32(0);
                    var descricao = rdr.GetString(1);
                    var saldoInicial = rdr.GetDecimal(2);
                    var conta = new Conta(id, descricao, saldoInicial);

                    contas.Add(conta);
                }
            }

            _con.Close();

            return contas;
        }
    }
}
