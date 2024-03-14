using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LboratorioRep_2
{
    class Informacion_alquiler
    {
        string nombre;
        string placa;
        string marca;
        string modelo;
        string color;
        string fecha_devolucion;
        int total;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public string Fecha_devolucion { get => fecha_devolucion; set => fecha_devolucion = value; }
        public int Total { get => total; set => total = value; }
    }
}
