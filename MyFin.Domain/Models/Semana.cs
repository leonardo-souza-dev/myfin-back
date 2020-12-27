using System;
using System.Collections.Generic;
using Utils;

namespace MyFin.Domain.Models
{
    public class Semana
    {
        public int Num { get; private set; }

        private Dia Dom { get; } = new Dia("dom");
        private Dia Seg { get; } = new Dia("seg");
        private Dia Ter { get; } = new Dia("ter");
        private Dia Qua { get; } = new Dia("qua");
        private Dia Qui { get; } = new Dia("qui");
        private Dia Sex { get; } = new Dia("sex");
        private Dia Sab { get; } = new Dia("sab");

        public List<Dia> Dias { get; private set; } = new List<Dia>();

        public Semana(DateTime domingo)
        {
            this.Dom.SetarData(domingo);
            this.Dias.Add(this.Dom);

            this.Seg.SetarData(domingo.AddDays(1));
            this.Dias.Add(this.Seg);

            this.Ter.SetarData(domingo.AddDays(2));
            this.Dias.Add(this.Ter);

            this.Qua.SetarData(domingo.AddDays(3));
            this.Dias.Add(this.Qua);

            this.Qui.SetarData(domingo.AddDays(4));
            this.Dias.Add(this.Qui);

            this.Sex.SetarData(domingo.AddDays(5));
            this.Dias.Add(this.Sex);

            this.Sab.SetarData(domingo.AddDays(6));
            this.Dias.Add(this.Sab);

            this.Num = Helper.ObterNumeroDaSemana(domingo);
        }        
    }
}
