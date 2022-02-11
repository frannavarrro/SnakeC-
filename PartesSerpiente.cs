using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    public class PartesSerpiente
    {
        public PartesSerpiente(char direccion, int x, int y)
        {
            this.direccion= direccion;

            this.x= x;

            this.y= y;  
        }

        //añade un rectangulo al cuerpo de la serpiente
        public static void Crecer()
        {
            if (MainWindow.Cuerpo.Count==0)
            {
                char direccion = MainWindow.Cabeza.Direccion;

                if(direccion=='D') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, MainWindow.Cabeza.X, MainWindow.Cabeza.Y-30));

                else if (direccion == 'U') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, MainWindow.Cabeza.X, MainWindow.Cabeza.Y + 30));

                else if (direccion == 'L') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, MainWindow.Cabeza.X+30, MainWindow.Cabeza.Y));
                
                else MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, MainWindow.Cabeza.X-30, MainWindow.Cabeza.Y));

            }

            else
            {
                PartesSerpiente ultimaParte = MainWindow.Cuerpo[MainWindow.Cuerpo.Count - 1];

                char direccion = ultimaParte.Direccion;

                if (direccion == 'D') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, ultimaParte.X, ultimaParte.Y - 30));

                else if (direccion == 'U') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, ultimaParte.X, ultimaParte.Y + 30));

                else if (direccion == 'L') MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, ultimaParte.X + 30, ultimaParte.Y));

                else MainWindow.Cuerpo.Add(new PartesSerpiente(direccion, ultimaParte.X - 30, ultimaParte.Y));
            }

            Rectangle rect = new Rectangle() { Width = 30, Height = 30, Fill = Brushes.BlueViolet };

            canvasPointer.Children.Add(rect);
           
        }

        //establece la posicion y direccion de cada parte del cuerpo de manera recursiva
        public static void Moverse(char direccion, int index)
        {

            if (index == MainWindow.Cuerpo.Count) return;

            if (MainWindow.Cuerpo[index].Direccion == 'U') MainWindow.Cuerpo[index].Y -= 30;

            else if (MainWindow.Cuerpo[index].Direccion == 'D') MainWindow.Cuerpo[index].Y += 30;

            else if (MainWindow.Cuerpo[index].Direccion == 'L') MainWindow.Cuerpo[index].X -= 30;

            else MainWindow.Cuerpo[index].X += 30;

            char direccionSiguienteElemento = MainWindow.Cuerpo[index].Direccion;

            MainWindow.Cuerpo[index].Direccion = direccion;

            Moverse(direccionSiguienteElemento, index + 1);

        }
        public char Direccion
        {
            get { return this.direccion; } 

            set { this.direccion = value; } 
        }

        //Crea una referencia al canvas de la clase principal

        //para poder acceder a sus propiedades desde esta clase
        public static void PointToCanvas(Canvas canvas)
        {
            canvasPointer = canvas;
        }

        public int X
        {
            get { return this.x; }

            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }

            set { this.y = value; }
        }

        private char direccion;

        private int x, y;

        private static Canvas canvasPointer;

         
    }

    
}
