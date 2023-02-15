using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaModificacion { get; set; }

        public List<object> ClienteList { get; set; }
        public ML.Planes Planes { get; set; }
        public ML.Cobertura Coberturas { get; set; }
    }
}
