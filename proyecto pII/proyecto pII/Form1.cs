using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_pII
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas micon=new Consultas();
            micon.Show();
        }

        private void busesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas micon = new Consultas();
            micon.Show();
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas micon = new Consultas();
            micon.Show();
        }

        private void modificacionDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUD mivn = new CRUD();
            mivn.Show();
        }

        private void reservarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservas mivn = new Reservas();
            mivn.Show();
        }
    }
}
