using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class Level
    {
        public int levelNr; // Base Stage
        public int wallStage;
        public int resourcePoints;
        public Village village;

        public Level(int i_levelNr, Coords i_villStartCorner, int i_wallLength, int i_resourcePoints, int i_wallStage, 
                     int i_goldMineLevel, int i_stoneMineLevel)
        {
            levelNr = i_levelNr;
            wallStage = i_wallStage;
            resourcePoints = i_resourcePoints;
            village = new Village(i_villStartCorner.Get_X(), i_villStartCorner.Get_Y(), i_wallLength, i_goldMineLevel, i_stoneMineLevel);
        }
    }
}
