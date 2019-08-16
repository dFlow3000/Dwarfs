using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dwarfs
{
    class GameField
    {
        public Part[,] Grid = new Part[Const.GameFieldLength , Const.GameFieldLength];

        public GameField(bool restart = false)
        {
            if (restart)
            {
                for (int x = 0; x < Const.GameFieldLength; x++)
                {
                    for (int y = 0; y < Const.GameFieldLength; y++)
                    {
                        Grid[x, y] = new Part(UC_Field.GameFieldButton[x, y], x, y, Const.Type_Goblin_Land);
                    }
                }
            }
        }
    }

}
