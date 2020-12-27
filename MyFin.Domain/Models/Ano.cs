using System;
using System.Collections.Generic;

namespace MyFin.Domain.Models
{
    public class Ano
    {
        public string Id { get; private set; }

        public List<Semana> Semanas { get; private set; } = new List<Semana>();
    }
}
