using System;

namespace MyFin.Domain.Models
{
    public class Produto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoDe { get; set; }
        public decimal PrecoPor { get; set; }

        public Produto(string descricao, string id = null)
        {
            this.Id = id ?? Guid.NewGuid().ToString().Replace("-", "").Substring(0, 24);
            this.Descricao = descricao;
        }
    }
}
