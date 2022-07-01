using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Connect4
{
    class JuegoCOM
    {

        // Enteros para el ancho y el alto del tablero
        int AnchoTablero, AltoTablero;

        // Booleanos para los jugadores

        public bool jugador1;
        public bool jugadorCOM;

        // Color para el color de las piezas
        private Color colorPieza;

        // State Enum para el estado de cada lugar en el tablero
        public enum state { vacio = 0, jugador1 = 1, jugadorCOM = 2};
        // Matriz de dos dimensiones para representar el tablero
        private state[,] tablero = new state[7, 6];
        // Lista de enteros
        List<int> lleno = new List<int> { 5, 5, 5, 5, 5, 5, 5 };
        int aux;

        // Constructor para Juego
        public JuegoCOM()
        {
            AnchoTablero = 700;
            AltoTablero = 600;
            jugador1 = true;
            jugadorCOM = false;
            colorPieza = Color.Red;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tablero[i, j] = state.vacio;
                }
            }
        }

        // Constructor for dibujar
        public JuegoCOM(int x, int y, Color pcolor)
        {
            state estado = new state();
            if (pcolor == Color.Red)
            {
                jugador1 = true;
                jugadorCOM = false;
                colorPieza = Color.Red;
                estado = state.jugador1;
            }
            else if (pcolor == Color.Black)
            {
                jugadorCOM = true;
                jugador1 = false;
                colorPieza = Color.Black;
            }

            tablero[x / 100, y / 100] = estado;
            aux = x / 100;

        }
        // Método para reiniciar el tablero
        public void Reset()
        {
            lleno = new List<int>(7) { 5, 5, 5, 5, 5, 5, 5 };
            jugador1 = true;
            jugadorCOM = false;
            colorPieza = Color.Red;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    tablero[i, j] = state.vacio;
                }
            }
        }
        // Método para dibujar tablero de juego en blanco
        public void dibujarTablero(PaintEventArgs e)
        {
            Pen linea = new Pen(Color.Black);
            int lineaXi = 0, lineaXf = 700;
            int lineaYi = 0, lineaYf = 600;
            System.Drawing.SolidBrush pincel = new System.Drawing.SolidBrush(System.Drawing.Color.SaddleBrown);

            for (int startY = 0; startY <= AnchoTablero; startY += 100)
            {
                e.Graphics.DrawLine(linea, startY, lineaYi, startY, lineaYf);
            }

            for (int startX = 0; startX <= AltoTablero; startX += 100)
            {
                e.Graphics.DrawLine(linea, lineaXi, startX, lineaXf, startX);
            }

            for (int y = 0; y <= AltoTablero; y += 100)
            {
                for (int x = 0; x <= AnchoTablero; x += 100)
                {
                    e.Graphics.FillEllipse(pincel, new Rectangle(x, y, 100, 100));
                }
            }

        }

        // Método que cambia el turno de los jugadores y el color de la pieza del juego.
        private void turnoJugador()
        {
            jugador1 = !jugador1;
            jugadorCOM = !jugadorCOM;
            if (jugador1)
            {
                colorPieza = Color.Red;
            }
            else
            {
                colorPieza = Color.Black;
            }
        }

        /* 
        Método para dibujar las piezas individuales del juego
        Dibuja la pieza roja si el jugador 1 y la pieza negra si el jugador 2 
        */

        public void dibujarPieza(MouseEventArgs e, Graphics f)
        {
            System.Drawing.SolidBrush pincel = new System.Drawing.SolidBrush(colorPieza);
            int xlocal = (e.X / 100);

            

            if (lleno[xlocal] >= 0)
            {

                if (jugador1 && tablero[xlocal, lleno[xlocal]] == state.vacio)
                {
                    tablero[xlocal, lleno[xlocal]] = state.jugador1;
                    f.FillEllipse(pincel, xlocal * 100, lleno[xlocal] * 100, 100, 100);
                    lleno[xlocal]--;
                    turnoJugador();
                }
            }
        }

        public void dibujarPiezaCOM(Graphics f) {

            System.Drawing.SolidBrush pincel = new System.Drawing.SolidBrush(colorPieza);

            Random rd = new Random();

            int xlocalCOM = rd.Next(0, 6);
            if (lleno[xlocalCOM] >= 0)
            {
                if (jugadorCOM && tablero[xlocalCOM, lleno[xlocalCOM]] == state.vacio)
                {
                    tablero[xlocalCOM, lleno[xlocalCOM]] = state.jugadorCOM;
                    f.FillEllipse(pincel, xlocalCOM * 100, lleno[xlocalCOM] * 100, 100, 100);
                    lleno[xlocalCOM]--;
                    turnoJugador();
                }
            }

        }

        // Método para comprobar si hay un ganador
        public Color JugadorGanador(state verificarJugador)
        {
            bool jugadorRojo = false;
            bool jugadorNegro = false;

            //verificar ganador vertical (|)
            for (int fila = 0; fila < this.tablero.GetLength(0) - 3; fila++)
            {
                for (int Columna = 0; Columna < this.tablero.GetLength(1); Columna++)
                {
                    if (this.NumerosIguales(verificarJugador, this.tablero[fila, Columna], this.tablero[fila + 1, Columna], this.tablero[fila + 2, Columna], this.tablero[fila + 3, Columna]))
                    {
                        if (state.jugador1 == verificarJugador)
                        {
                            jugadorRojo = true;
                        }
                        else
                        {
                            jugadorNegro = true;
                        }
                    }

                }
            }
            //verificar ganador horizontal (--)
            for (int fila = 0; fila < this.tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < this.tablero.GetLength(1) - 3; columna++)
                {
                    if (this.NumerosIguales(verificarJugador, this.tablero[fila, columna], this.tablero[fila, columna + 1], this.tablero[fila, columna + 2], this.tablero[fila, columna + 3]))
                    {
                        if (state.jugador1 == verificarJugador)
                        {
                            jugadorRojo = true;
                        }
                        else
                        {
                            jugadorNegro = true;
                        }
                    }
                }
            }
            //verificar ganador diagonal izquierda (\)
            for (int fila = 0; fila < this.tablero.GetLength(0) - 3; fila++)
            {
                for (int columna = 0; columna < this.tablero.GetLength(1) - 3; columna++)
                {
                    if (this.NumerosIguales(verificarJugador, this.tablero[fila, columna], this.tablero[fila + 1, columna + 1], this.tablero[fila + 2, columna + 2], this.tablero[fila + 3, columna + 3]))
                    {
                        if (state.jugador1 == verificarJugador)
                        {
                            jugadorRojo = true;
                        }
                        else
                        {
                            jugadorNegro = true;
                        }
                    }
                }
            }
            //verificar ganador diagonal derecha (/)
            for (int fila = 0; fila < this.tablero.GetLength(0) - 3; fila++)
            {
                for (int columna = 3; columna < this.tablero.GetLength(1); columna++)
                {
                    if (this.NumerosIguales(verificarJugador, this.tablero[fila, columna], this.tablero[fila + 1, columna - 1], this.tablero[fila + 2, columna - 2], this.tablero[fila + 3, columna - 3]))
                    {
                        if (state.jugador1 == verificarJugador)
                        {
                            jugadorRojo = true;
                        }
                        else
                        {
                            jugadorNegro = true;
                        }
                    }
                }
            }
            if (jugadorRojo)
                return Color.Red;
            else if (jugadorNegro)
                return Color.Black;
            else
                return Color.Empty;
        }
        private bool NumerosIguales(state Verificar, params state[] Numeros)
        {
            foreach (state num in Numeros)
            {
                if (num != Verificar)
                {
                    return false;
                }
            }
            return true;
        }
    }

}

