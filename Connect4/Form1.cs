using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Connect4
{
    public partial class Ventana : Form
    {
        // instancia de Juego
        JuegoCOM juego = new JuegoCOM();
        // lista de Juego
        List<JuegoCOM> piezas;

        // constructor del Form
        public Ventana()
        {
            InitializeComponent();
            piezas = new List<JuegoCOM>();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            juego.dibujarTablero(e);
            
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color pcolor = new Color();
            JuegoCOM piece = new JuegoCOM(e.X, e.Y, pcolor);
            using (Graphics f = this.panel1.CreateGraphics())
            {
                juego.dibujarPieza(e, f);
                Thread.Sleep(500);

                if (juego.JugadorGanador(JuegoCOM.state.jugador1) == Color.Red)
                {
                    MessageBox.Show("Ganador jugador Rojo", "Game over!", MessageBoxButtons.OK);
                    juego.Reset();
                    panel1.Invalidate();
                }
                else {
                    juego.dibujarPiezaCOM(f);
                }


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

            if (juego.JugadorGanador(JuegoCOM.state.jugador1) == Color.Red)
            {
                MessageBox.Show("Ganador jugador Rojo", "Game over!", MessageBoxButtons.OK);
                juego.Reset();
                panel1.Invalidate();
            }
            else if (juego.JugadorGanador(JuegoCOM.state.jugadorCOM) == Color.Black)
            {
                MessageBox.Show("Ganador jugador Negro", "Game over!", MessageBoxButtons.OK);
                juego.Reset();
                panel1.Invalidate();
            }
            
            
        }

       
        private void btnReset_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Reiniciar juego?", "Reiniciar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                panel1.Invalidate();
                juego.Reset();
                lblTurn.ForeColor = Color.Red;
                lblTurn.Text = "Turno: jugador Rojo";
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
