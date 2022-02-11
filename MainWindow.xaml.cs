using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Snake
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Width = 600;

            this.Height = 700;

            InitializeComponent();

            Puntaje = 0;

            Cuerpo = new List<PartesSerpiente>();

            cabezaCanvas.Width = 30;

            cabezaCanvas.Height = 30;

            manzanaCanvas.Width = 30;

            manzanaCanvas.Height = 30;

            miCanvas.Focus();

            Cabeza = new CabezaSerpiente('R', 90, 90);

            Manzana = new Manzana();

            Manzana.Spawn();
            
            cabezaCanvas.Fill = Brushes.Violet;

            manzanaCanvas.Fill = Brushes.Red;

            PartesSerpiente.PointToCanvas(miCanvas);

            mainLoop = new DispatcherTimer();

            mainLoop.Tick += new EventHandler(loopHandler);

            mainLoop.Interval = TimeSpan.FromMilliseconds(125);

            mainLoop.Start();
        }

        private void loopHandler(object sender, EventArgs e)
        {

            if (Cabeza.Direccion == 'U') Cabeza.Y -= 30;

            else if (Cabeza.Direccion == 'D') Cabeza.Y += 30;

            else if (Cabeza.Direccion == 'L') Cabeza.X -= 30;

            else Cabeza.X += 30;

            if (Cabeza.X == -30 || Cabeza.X == 600 || Cabeza.Y == -30 || Cabeza.Y == 600) gameOver();

            else if (checkColisionCuerpo()) gameOver();

            else
            {
                PartesSerpiente.Moverse(Cabeza.Direccion, 0);

                if (Cabeza.X == Manzana.X && Cabeza.Y == Manzana.Y) Cabeza.ComerManzana();

                Canvas.SetLeft(cabezaCanvas, Cabeza.X);

                Canvas.SetTop(cabezaCanvas, Cabeza.Y);

                Canvas.SetLeft(manzanaCanvas, Manzana.X);

                Canvas.SetTop(manzanaCanvas, Manzana.Y);

                textoPuntaje.Text = "Puntaje: " + Puntaje;

                for (int i = 0; i < Cuerpo.Count; i++)
                {
                    Canvas.SetLeft(miCanvas.Children[i + 2], Cuerpo[i].X);

                    Canvas.SetTop(miCanvas.Children[i + 2], Cuerpo[i].Y);

                }
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && Cabeza.Direccion!='D') Cabeza.Direccion = 'U';

            else if (e.Key == Key.Down && Cabeza.Direccion != 'U') Cabeza.Direccion = 'D';

            else if (e.Key == Key.Left && Cabeza.Direccion != 'R') Cabeza.Direccion = 'L';

            else if (e.Key == Key.Right && Cabeza.Direccion != 'L') Cabeza.Direccion = 'R';

        }

        private bool checkColisionCuerpo()
        {
            foreach(PartesSerpiente parte in Cuerpo)
            {
                if(parte.X==Cabeza.X && parte.Y==Cabeza.Y) return true;
            }

            return false;
        }

        private void gameOver()
        {
            textoPuntaje.Text = "Perdiste. Puntaje: " + Puntaje;

            mainLoop.Stop();
        }

        private DispatcherTimer mainLoop;

        public static CabezaSerpiente Cabeza;

        public static Manzana Manzana;

        public static int Puntaje;

        public static List<PartesSerpiente> Cuerpo;

    }

}
