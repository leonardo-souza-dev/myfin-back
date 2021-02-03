using System;
using System.Collections.Generic;
using MyFin.Domain.Models;
using Utils;

namespace MyFin.Application.Responses
{
    public class ContaResponse
    {
        public int Id { get; set; }
        
        public ContaResponse(Conta conta)
        {
            this.Id = conta.Id;
        }
    }
}
