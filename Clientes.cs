using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LboratorioRep_2
{
    class Clientes
    {
        int nit;
        string nombre_cliente;
        string direccion;

        public int Nit { get => nit; set => nit = value; }
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
