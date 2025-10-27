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
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
            CargarDatosDGV();
        }
        private void actualizaDatos(String id, String nombre, String cargo, String telefono, String correo)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ruta);
            XmlNode usuario = xmlDoc.SelectSingleNode($"/Usuarios/Usuario[Id='{id}']");

            if (usuario != null)
            {
                
                usuario["NombreCompleto"].InnerText = nombre;
                usuario["Cargo"].InnerText = cargo;
                usuario["Telefono"].InnerText = telefono;
                usuario["CorreoElectronico"].InnerText = correo;

               
                xmlDoc.Save(ruta);
                CargarDatosDGV();  
            }
            else
            {
                MessageBox.Show("No se encontraron datos para este ID.");
            }
        }





        public void CargarDatosDGV()
        {
            DataSet dataset = new DataSet();
            // cargamos el archivo en data set, estructura en memoria
            dataset.ReadXml(ruta);
            // luego le asignamos al data al datagriview
            midgv1.DataSource = dataset.Tables[0];
        }
        public void midgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_identificacion.Text = midgv1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            txt_nombreC.Text = midgv1.Rows[e.RowIndex].Cells["NombreCompleto"].Value.ToString();
            txt_Cargo.Text = midgv1.Rows[e.RowIndex].Cells["Cargo"].Value.ToString();
            txt_correo.Text = midgv1.Rows[e.RowIndex].Cells["CorreoElectronico"].Value.ToString();
            txt_telefono.Text = midgv1.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
        }

        private String ruta = "C:\\Users\\andra\\source\\repos\\proyecto pII\\proyecto pII\\XMLFile1.xml";

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Borrar_Click(object sender, EventArgs e)
        {

        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            CargarDatosDGV();
        }

        private void midgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_identificacion.Text = midgv1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txt_nombreC.Text = midgv1.Rows[e.RowIndex].Cells["NombreCompleto"].Value.ToString();
                txt_Cargo.Text = midgv1.Rows[e.RowIndex].Cells["Cargo"].Value.ToString();
                txt_correo.Text = midgv1.Rows[e.RowIndex].Cells["CorreoElectronico"].Value.ToString();
                txt_telefono.Text = midgv1.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            }

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            actualizaDatos(txt_identificacion.Text,txt_nombreC.Text,txt_Cargo.Text,txt_telefono.Text,txt_correo.Text);
        }
    }
}
