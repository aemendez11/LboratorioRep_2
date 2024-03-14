using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LboratorioRep_2
{
    public partial class Form1 : Form
    {
        List<Vehiculos> vehiculos = new List<Vehiculos>();
        List<Clientes> clientes = new List<Clientes>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Informacion_alquiler> información = new List<Informacion_alquiler>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mayorrs.Visible = false;
            label9.Visible = false;
        }
        private void cargar_clientes()
        {
            string fileName = "Clientes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Clientes clientes_1 = new Clientes();
                clientes_1.Nit = int.Parse(reader.ReadLine());
                clientes_1.Nombre_cliente = reader.ReadLine();
                clientes_1.Direccion = reader.ReadLine();
                clientes.Add(clientes_1);
            }
            reader.Close();
        }
        private void mostrar_clientes()
        {
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
            dataGridViewClientes.Refresh();
        }
        private void cargar_alquileres()
        {
            string fileName = "Alquiler.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquiler alquileress = new Alquiler();
                alquileress.Nit = int.Parse(reader.ReadLine());
                alquileress.Placa = reader.ReadLine();
                alquileress.Fecha_alquiler = reader.ReadLine();
                alquileress.Fecha_devolucion = reader.ReadLine();
                alquileress.Kilometros = int.Parse(reader.ReadLine());
                alquileres.Add(alquileress);
            }
            reader.Close();
        }
        
        private void guardar_vehiculo(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

          foreach (Vehiculos vehiculoss in vehiculos)
                    {
                        writer.WriteLine(vehiculoss.Placa);
                        writer.WriteLine(vehiculoss.Marca);
                        writer.WriteLine(vehiculoss.Modelo);
                        writer.WriteLine(vehiculoss.Color);
                        writer.WriteLine(vehiculoss.Precio_kilometro);
                    }
                    writer.Close();     
        }
        private void cargar_vehiculo()
        {
            string fileName = "Vehiculos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Vehiculos vehiculoss = new Vehiculos();
                vehiculoss.Placa = reader.ReadLine();
                vehiculoss.Marca = reader.ReadLine();
                vehiculoss.Modelo = reader.ReadLine();
                vehiculoss.Color = reader.ReadLine();
                vehiculoss.Precio_kilometro = int.Parse(reader.ReadLine());
                vehiculos.Add(vehiculoss);
            }
            reader.Close();
        }
        public void MostrarVehiculos()
        {
            dataGridViewVehiculos.DataSource = null;
            dataGridViewVehiculos.DataSource = vehiculos;
            dataGridViewVehiculos.Refresh();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            vehiculos.Clear();
            cargar_vehiculo();
            MostrarVehiculos();

            clientes.Clear();
            cargar_clientes();
            mostrar_clientes();
        }
        private void borrar()
        {
            textBoxColor.Clear();
            textBoxMarca.Clear();
            textBoxPre_km.Clear();
            textBoxPlaca.Clear();
            textBoxModelo.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Vehiculos vehiculo = new Vehiculos();
            textBoxPlaca.Focus();
            vehiculo.Placa = textBoxPlaca.Text;
            vehiculo.Marca = textBoxMarca.Text;
            vehiculo.Modelo = textBoxModelo.Text;
            vehiculo.Color = textBoxColor.Text;
            vehiculo.Precio_kilometro = Convert.ToInt32(textBoxPre_km.Text);

            vehiculos.Add(vehiculo);
            
            guardar_vehiculo("Vehiculos.txt");
            borrar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargar_alquileres();
            información.Clear();
            foreach (Alquiler alquiler in alquileres)
            {
                Clientes clientess = clientes.FirstOrDefault(c => c.Nit == alquiler.Nit);
                if(clientess!= null)
                {
                    Vehiculos vehiculoss = vehiculos.FirstOrDefault(v => v.Placa == alquiler.Placa);
                    if (vehiculoss != null)
                    {
                        Informacion_alquiler informacion_Alquiler = new Informacion_alquiler();
                        informacion_Alquiler.Nombre = clientess.Nombre_cliente;
                        informacion_Alquiler.Placa = vehiculoss.Placa;
                        informacion_Alquiler.Marca = vehiculoss.Marca;
                        informacion_Alquiler.Modelo = vehiculoss.Modelo;
                        informacion_Alquiler.Color = vehiculoss.Color;
                        informacion_Alquiler.Fecha_devolucion = alquiler.Fecha_devolucion;
                        informacion_Alquiler.Total = vehiculoss.Precio_kilometro * alquiler.Kilometros;
                        información.Add(informacion_Alquiler);
                    }
                }
            }
            int mayor =alquileres.Max(a => a.Kilometros);
            Informacion_alquiler informacion_Alquiler1 = información.OrderByDescending(a=> a.Total).First();
            Mayorrs.Text = mayor.ToString();
            dataGridViewInfo_alqui.DataSource = null;
            dataGridViewInfo_alqui.DataSource = información;
            dataGridViewInfo_alqui.Refresh();
            Mayorrs.Visible = true;
            label9.Visible = true;

        }
    }
}
