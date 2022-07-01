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
    public partial class ventanaJvJ : Form
    {
       
        // instancia de Juego
        Juego juego = new Juego();

        // lista de Juego
        List<Juego> piezas;

        // constructor del Form
        public ventanaJvJ()
        {
            InitializeComponent();
            piezas = new List<Juego>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color pcolor = new Color();
            Juego piece = new Juego(e.X, e.Y, pcolor);
            using (Graphics f = this.panel1.CreateGraphics())
            {
                juego.dibujarPieza(e, f);
                if (juego.jugador1)
                {
                    lblTurn.ForeColor = Color.Red;
                    lblTurn.Text = "Turno: jugador Rojo.";
                    pcolor = Color.Black;
                    piezas.Add(piece);
                }
                else
                {
                    lblTurn.ForeColor = Color.Black;
                    lblTurn.Text = "Turno: jugador Negro.";
                    pcolor = Color.Red;
                    piezas.Add(piece);
                }

            }

            if (juego.JugadorGanador(Juego.state.jugador1) == Color.Red)
            {
                MessageBox.Show("Ganador jugador Rojo", "Game over!", MessageBoxButtons.OK);
                juego.Reset();
                panel1.Invalidate();
            }
            else if (juego.JugadorGanador(Juego.state.jugador2) == Color.Black)
            {
                MessageBox.Show("Ganador jugador Negro", "Game over!", MessageBoxButtons.OK);
                juego.Reset();
                panel1.Invalidate();
            }

        }


        private void btnReset_MouseClick(object sender, MouseEventArgs e)
        {
            


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Reiniciar juego?", "Reiniciar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                panel1.Invalidate();
                juego.Reset();
                lblTurn.ForeColor = Color.Red;
                lblTurn.Text = "Turno: jugador Rojo";
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            juego.dibujarTablero(e);
        }
    }
}
