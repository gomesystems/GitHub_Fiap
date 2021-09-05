using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaRepouso.Models
{
    public class VisitaModel
    {
        public int VisitaId { get; set; }
        public string VisitaNome { get; set; }
        public string VisitaDesc { get; set; }
        public string VisitaDtInclusao { get; set; }
    }
}
