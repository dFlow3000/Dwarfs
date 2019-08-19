using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class Village
    {
        public int[] startCorner = new int[2];
        public int wallLenght = 0;

        public Village(int startCorner_X, int startCorner_Y, int i_wallLenght)
        {
            startCorner[0] = startCorner_X;
            startCorner[1] = startCorner_Y;
            wallLenght = i_wallLenght;
        }

        public void VillageMine(int goldMiningRate, int stoneMiningRate, ref int actGold, ref int actStone)
        {
            actGold += goldMiningRate;
            actStone += stoneMiningRate;
        }

    }
}
