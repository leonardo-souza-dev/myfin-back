using System.Collections.Generic;
using MyFin.Domain.Models;

namespace MyFin.Application.Responses
{
    public class SemanaResponse
    {
        public int Num { get; set; }

        private DiaResponse Dom { get; set; }
        private DiaResponse Seg { get; set; }
        private DiaResponse Ter { get; set; }
        private DiaResponse Qua { get; set; }
        private DiaResponse Qui { get; set; }
        private DiaResponse Sex { get; set; }
        private DiaResponse Sab { get; set; }

        public List<DiaResponse> Dias { get; private set; } = new List<DiaResponse>();

        public SemanaResponse(Semana semana)
        {
            foreach (var item in semana.Dias)
            {
                Dias.Add(new DiaResponse(item));
            }
        }
    }
}
