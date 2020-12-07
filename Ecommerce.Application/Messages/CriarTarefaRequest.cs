using System;

namespace Ecommerce.Application.Messages
{
    public class CriarTarefaRequest
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
