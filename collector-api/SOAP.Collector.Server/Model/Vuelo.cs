using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOAP.Collector.Server.Model
{
    public class Vuelo
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string FechaSalida { get; set; }
        public string FechaLlegada { get; set; }
        public int Personas { get; set; }
        public double Precio { get; set; }
        public string Aerolinea { get; set; }
    }
}
