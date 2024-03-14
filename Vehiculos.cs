using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LboratorioRep_2
{
    class Vehiculos
    {
        string placa;
        string marca;
        string modelo;
        string color;
       int precio_kilometro;

        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public int Precio_kilometro { get => precio_kilometro; set => precio_kilometro = value; }
    }
}
