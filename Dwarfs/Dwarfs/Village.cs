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
        public int goldMineLevel = 0;
        public int stoneMineLevel = 0;

        public Village(int startCorner_X, int startCorner_Y, int i_wallLenght, int i_goldMineLevel, int i_stoneMineLevel)
        {
            startCorner[0] = startCorner_X;
            startCorner[1] = startCorner_Y;
            wallLenght = i_wallLenght;
            goldMineLevel = i_goldMineLevel;
            stoneMineLevel = i_stoneMineLevel;
        }

        public void VillageMine(int goldMiningRate, int stoneMiningRate, ref int actGold, ref int actStone)
        {
            actGold += goldMiningRate;
            actStone += stoneMiningRate;
        }

    }
}
