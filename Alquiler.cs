using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LboratorioRep_2
{
    class Alquiler
    {
        int nit;
        string placa;
        string fecha_alquiler;
        string fecha_devolucion;
        int kilometros;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Fecha_alquiler { get => fecha_alquiler; set => fecha_alquiler = value; }
        public string Fecha_devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
        public int Kilometros { get => kilometros; set => kilometros = value; }
    }
}
