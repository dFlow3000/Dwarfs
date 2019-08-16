using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class VillageGenerator
    {
        public static void Generate_Village(Village villageTemplate, Part[,] field)
        {

            BuildTheWalls(villageTemplate, field);
            FillVillageGround(villageTemplate, field);
            SetBase(villageTemplate, field);


        }

        private static void BuildTheWalls(Village villageTemplate, Part[,] field)
        {
            for (int x = villageTemplate.startCorner[0]; x <= villageTemplate.startCorner[0] + villageTemplate.wallLenght; x++)
            {
                field[x, villageTemplate.startCorner[1]].SetType(Const.Type_Stone_Wall);
                field[x, villageTemplate.startCorner[1] + villageTemplate.wallLenght].SetType(Const.Type_Stone_Wall);
            }
            for (int y = villageTemplate.startCorner[1]; y <= villageTemplate.startCorner[1] + villageTemplate.wallLenght; y++)
            {
                field[villageTemplate.startCorner[0], y].SetType(Const.Type_Stone_Wall);
                field[villageTemplate.startCorner[0] + villageTemplate.wallLenght, y].SetType(Const.Type_Stone_Wall);
            }
        }

        private static void FillVillageGround(Village villageTemplate, Part[,] field)
        {
            for(int x = villageTemplate.startCorner[0]+1; x <= villageTemplate.startCorner[0] + villageTemplate.wallLenght - 1; x++)
            {
                for (int y = villageTemplate.startCorner[1]+1; y <= villageTemplate.startCorner[1] + villageTemplate.wallLenght - 1; y++)
                {
                    field[x, y].SetType(Const.Type_Village_Ground);
                }
            }
        }

        private static void SetBase(Village villageTemplate, Part[,] field)
        {
            field[25, 25].SetType(Const.Type_Base);
        }

        private static void SetGoldMines(Village villageTemplate, Part[,] field)
        {

        }

    }
}
