using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class Coords
    {
        private int X = 0;
        private int Y = 0;

        public Coords(int i_X, int i_Y)
        {
            X = i_X;
            Y = i_Y;
        }

        public int Get_X()
        {
            return X;
        } 

        public int Get_Y()
        {
            return Y;
        }

        public void Set_X(int i_X)
        {
            X = i_X;
        }

        public void Set_Y(int i_Y)
        {
            Y = i_Y;
        }

    }
}
