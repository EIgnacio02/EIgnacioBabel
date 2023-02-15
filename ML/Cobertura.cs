using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cobertura
    {
        public int IdCobertura { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaModicacionCobertura { get; set; }
        public List<object> CoberturaList { get; set; }
    }
}
