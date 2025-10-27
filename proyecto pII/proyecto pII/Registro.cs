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
using static System.Net.Mime.MediaTypeNames;

namespace proyecto_pII
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            txt_UsuarioR.Text = "";
            txt_contra.Text = "";
            txt_Cargo.Text = "";
            txt_correo.Text = "";
            txt_nombreC.Text = "";
            txt_telefono.Text = "";
            txt_identificacion.Text = "";


        }

        private String ruta = "C:\\Users\\andra\\source\\repos\\proyecto pII\\proyecto pII\\XMLFile1.xml";

        private void Registro_Load(object sender, EventArgs e)
        { }
             private void AgregarUsuario(String id, String nombre, String cargo, String telefono,String correo ,String contraseña,String Usuario) { 
        
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ruta);
            XmlNode usuario = xmlDoc.SelectSingleNode($"/ Usuarios / Usuarios[Id='{id}']");
            if (usuario == null)
            {
                //obtenemos el nodo root
                XmlNode root = xmlDoc.DocumentElement;
                //creamos el elemnto empleado
                XmlElement newUsuario = xmlDoc.CreateElement("Usuarios");
                //creamos el elmento id
                XmlElement newId = xmlDoc.CreateElement("Id");
                //insertamos el texto que lleva el nodo <Id>texto</Id
                newId.InnerText = id;
                //insertamos el nodo id en el nodo de empleado
                newUsuario.AppendChild(newId);
                XmlElement newnombre = xmlDoc.CreateElement("NombreCompleto");
                newnombre.InnerText = nombre;
                newUsuario.AppendChild(newnombre);
                XmlElement newcargo = xmlDoc.CreateElement("Cargo");
                newcargo.InnerText = cargo;
                newUsuario.AppendChild(newcargo);
                XmlElement newtelefono = xmlDoc.CreateElement("Telefono");
                newtelefono.InnerText = telefono;
                newUsuario.AppendChild(newtelefono);
                XmlElement newcorreo = xmlDoc.CreateElement("CorreoElectronico");
                newcorreo.InnerText = correo;
                newUsuario.AppendChild(newcorreo);
                XmlElement newusuarioR = xmlDoc.CreateElement("UsuarioName");
                newusuarioR.InnerText = Usuario;
                newUsuario.AppendChild(newusuarioR);
                XmlElement newcontra = xmlDoc.CreateElement("Contraseña");
                newcontra.InnerText = contraseña;
                newUsuario.AppendChild(newcontra);
                root.AppendChild(newUsuario);
                xmlDoc.Save(ruta);
               



            }
            else
            {
                MessageBox.Show("el elmplado ya exite");
            }
        }
        
        



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Crear_Usuario_Click(object sender, EventArgs e)
        {
           AgregarUsuario(txt_identificacion.Text,txt_Cargo.Text,txt_correo.Text,txt_nombreC.Text,txt_telefono.Text,txt_UsuarioR.Text,txt_contra.Text);
            MessageBox.Show("se ha agregado");
            Inicio miven= new Inicio();
            miven.Show();
          
        }
    }
}
