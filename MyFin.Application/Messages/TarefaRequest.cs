using System;

namespace MyFin.Application.Messages
{
    public class TarefaRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Pontos { get; set; }
    }
}
