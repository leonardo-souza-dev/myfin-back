using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFin.Application.Messages
{
    public class InserirProdutoResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
