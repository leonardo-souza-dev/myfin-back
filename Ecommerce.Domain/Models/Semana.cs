using System.Collections.Generic;

namespace Ecommerce.Domain.Models
{
    public class Semana
    {
        private Dia Dom { get; } = new Dia("dom");
        private Dia Seg { get; } = new Dia("seg");
        private Dia Ter { get; } = new Dia("ter");
        private Dia Qua { get; } = new Dia("qua");
        private Dia Qui { get; } = new Dia("qui");
        private Dia Sex { get; } = new Dia("sex");
        private Dia Sab { get; } = new Dia("sab");

        public List<Dia> Dias { get; private set; } = new List<Dia>();

        public Semana()
        {
            this.Dias.Add(this.Dom);
            this.Dias.Add(this.Seg);
            this.Dias.Add(this.Ter);
            this.Dias.Add(this.Qua);
            this.Dias.Add(this.Qui);
            this.Dias.Add(this.Sex);
            this.Dias.Add(this.Sab);
        }
    }
}
