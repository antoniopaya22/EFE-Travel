using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST.Collector.Server.Model
{
    public class Vuelo
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalidaIda { get; set; }
        public DateTime FechaLlegadaIda { get; set; }
        public DateTime FechaSalidaVuelta { get; set; }
        public DateTime FechaLlegadaVuelta { get; set; }
        public int Personas { get; set; }
        public double Precio { get; set; }
        public string Aerolinea { get; set; }
        public string Enlace { get; set; }
    }
}
