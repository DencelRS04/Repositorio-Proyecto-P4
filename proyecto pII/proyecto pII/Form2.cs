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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        public void VerificarUsuario(String contraseña, String Usuario)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ruta);
            XmlNode usuario = xmlDoc.SelectSingleNode($"/Usuarios/Usuario[UsuarioName='{Usuario}' and Contraseña='{contraseña}']");
           
            if (usuario != null)
            {
                MessageBox.Show("USUARIO ENCONTRADOR");
                Menu mimen = new Menu();
                mimen.Show();

            }
            else {
                MessageBox.Show("el usuario no se encuentra registrado, por favor registrese");
            }
        }
        private String ruta = "C:\\Users\\andra\\source\\repos\\proyecto pII\\proyecto pII\\XMLFile1.xml";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_IniS_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text;
            string contraseña = txt_Contraseña.Text;
            VerificarUsuario(contraseña,usuario);


        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            Registro mive = new Registro();
            mive .Show();
           
            
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
