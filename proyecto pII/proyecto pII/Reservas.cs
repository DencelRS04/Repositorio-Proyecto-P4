using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace proyecto_pII
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }
        public void CargarDatosDGVR()
        {
            // Creamos un DataSet
            DataSet dataset = new DataSet();

            // Leemos el archivo XML
            dataset.ReadXml(ruta); // 'ruta' es la ubicación del archivo XML de reservas

            // Verificamos si el archivo tiene datos (al menos una tabla de reservas)
            if (dataset.Tables.Count > 0)
            {
                // Asignamos la primera tabla del dataset al DataGridView
                dataGridViewReser.DataSource = dataset.Tables[0];
            }
            else
            {
                MessageBox.Show("No se encontraron reservas en el archivo XML.");
            }
        }
        private void actualizaDatosR(string ruta, string hora)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ruta);

            // Buscar el nodo de la reserva que tenga la hora específica
            XmlNode reserva = xmlDoc.SelectSingleNode($"/reservas/reserva[hora='{hora}']");

            if (reserva != null)
            {
                // Supongamos que quieres actualizar el campo "ruta" con un nuevo valor
                string nuevaRuta = "Nueva Ruta";  // Cambia esto por la nueva ruta que quieras asignar

                // Actualizar el campo "ruta"
                reserva["ruta"].InnerText = nuevaRuta;

                // Guardar el XML después de la actualización
                xmlDoc.Save(ruta);

                // Recargar los datos si es necesario
                CargarDatosDGVR();
            }
            else
            {
                MessageBox.Show("No se encontraron reservas para la hora especificada.");
            }
        }



        private string ruta = "C:\\Users\\andra\\source\\repos\\proyecto pII\\proyecto pII\\XMLFile2.xml";

        private void AgregarReserva(String dia, String hora, String rutaReserva,String idR)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ruta);

            // Verificar si ya existe una reserva con la misma fecha y hora
            XmlNode reservaExistente = xmlDoc.SelectSingleNode($"/reservas/reserva[fecha='{dia}' and hora='{hora}']");

            if (reservaExistente == null)
            {
                // Si no existe, creamos la nueva reserva
                XmlNode root = xmlDoc.DocumentElement;

                // Crear el nodo de la nueva reserva
                XmlElement nuevaReserva = xmlDoc.CreateElement("reserva");

                // Crear el nodo de la fecha
                XmlElement newFecha = xmlDoc.CreateElement("fecha");
                newFecha.InnerText = dia;
                nuevaReserva.AppendChild(newFecha);

                // Crear el nodo de la hora
                XmlElement newHora = xmlDoc.CreateElement("hora");
                newHora.InnerText = hora;
                nuevaReserva.AppendChild(newHora);

                // Crear el nodo de la ruta
                XmlElement newRuta = xmlDoc.CreateElement("ruta");
                newRuta.InnerText = rutaReserva;
                nuevaReserva.AppendChild(newRuta);

                XmlElement newId = xmlDoc.CreateElement("id");
                newId.InnerText = idR;
                nuevaReserva.AppendChild(newId);

                // Agregar la nueva reserva al archivo XML
                root.AppendChild(nuevaReserva);
                xmlDoc.Save(ruta);

                MessageBox.Show("Reserva agregada correctamente.");
            }
            else
            {
                // Si ya existe una reserva con esa fecha y hora
                MessageBox.Show("Ya existe una reserva para este día y hora.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        
            string diaReserva = Fechas.Value.ToString("yyyy-MM-dd");  // Obtenemos la fecha seleccionada
            string horaReserva = txt_Hora.Text;  // Hora ingresada
            string rutaReserva = txt_Ruta.Text;
            String idR = txt_IdR.Text;
            // Ruta seleccionada o ingresada

            // Validar que la hora y la ruta no estén vacías
            if (string.IsNullOrEmpty(horaReserva) || string.IsNullOrEmpty(rutaReserva))
            {
                MessageBox.Show("Por favor, ingrese la hora y la ruta.");
                return;
            }

            // Llamamos a la función para agregar la reserva
            AgregarReserva(diaReserva, horaReserva, rutaReserva,idR);

            // Opcional: Cargar las reservas nuevamente en un DataGridView o realizar otras acciones necesarias
                CargarDatosDGVR();
            txt_IdR.Text = "";
            txt_Hora.Text = "";
            txt_Ruta.Text = "";

        }
        


        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            Fechas.MinDate = DateTime.Now;

        }

        private void Reservas_Load(object sender, EventArgs e)
        {

        }

        private void Btn_MR_Click(object sender, EventArgs e)
        {
            actualizaDatosR(txt_Hora.Text,txt_Ruta.Text);
        }
    }
}
