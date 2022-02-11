using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class CabezaSerpiente : PartesSerpiente
    {
        public CabezaSerpiente(char direccion, int x, int y) : base(direccion, x, y)
        {
            
        }

        public void ComerManzana()
        {
            PartesSerpiente.Crecer();

            MainWindow.Manzana.Spawn();

            MainWindow.Puntaje += 50;
        }
    }
}
