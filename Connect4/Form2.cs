using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class ventanaMenu : Form
    {
        public ventanaMenu()
        {
            InitializeComponent();
        }

        private void JvsCOM_Click(object sender, EventArgs e)
        {
            Ventana ventana = new Ventana();

            ventana.ShowDialog();

        }

        private void JvJ_Click(object sender, EventArgs e)
        {
            ventanaJvJ ventana = new ventanaJvJ();

            ventana.ShowDialog();

        }

        private void ventanaMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
