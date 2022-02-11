using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Snake
{
    public class Manzana
    {
        public void Spawn()
        {
            Random random = new Random();

            do
            {
                x = random.Next(0, 19) * 30;

                y = random.Next(0, 19) * 30;
            } 
            while (x == MainWindow.Cabeza.X && y == MainWindow.Cabeza.Y || checkCuerpo());

        }

        public int X
        {
            get { return x; }

            set { x = value; }
        }

        public int Y
        {
            get { return y; }

            set { y = value; }
        }

        private bool checkCuerpo()
        {
            foreach(PartesSerpiente parte in MainWindow.Cuerpo)
            {
                if (x == parte.X && y == parte.Y) return true;
            }

            return false;
        }

        private int x, y;

    }

}
