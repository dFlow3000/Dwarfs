using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class LevelManager
    {

        // Level Definition Consts
        // ---> Level 1
        private static Coords Level1_VillageStartCoords = new Coords(20, 20);
        private static int    Level1_WallLength = 10;
        private static int    Level1_ResourcePoints = 10;
        private static int    Level1_WallStage = 1;
        private static int    Level1_GoldMineLevel = 1;
        private static int    Level1_StoneMineLevel = 1;
        // ---> Level 2
        private static Coords Level2_VillageStartCoords = new Coords(18, 18);
        private static int    Level2_WallLength = 14;
        private static int    Level2_ResourcePoints = 20;
        private static int    Level2_WallStage = 2;
        private static int    Level2_GoldMineLevel = 5;
        private static int    Level2_StoneMineLevel = 5;
        // ---> Level 3
        private static Coords Level3_VillageStartCoords = new Coords(16, 16);
        private static int    Level3_WallLength = 18;
        private static int    Level3_ResourcePoints = 25;
        private static int    Level3_WallStage = 3;
        private static int    Level3_GoldMineLevel = 10;
        private static int    Level3_StoneMineLevel = 10;
        // ---> Level 4
        private static Coords Level4_VillageStartCoords = new Coords(14, 14);
        private static int    Level4_WallLength = 22;
        private static int    Level4_ResourcePoints = 30;
        private static int    Level4_WallStage = 10;
        private static int    Level4_GoldMineLevel = 12;
        private static int    Level4_StoneMineLevel = 10;


        private struct LevelDefs
        {
            public Coords VillageStartCornerCoords;
            public int WallLength;
            public int ResoucrePoints;
            public int WallStage;
            public int GoldMineLevel;
            public int StoneMineLevel;
        }
        private Level[] Levels = new Level[Const.Total_Amount_of_Levels];
        private LevelDefs[] Level_Defs = new LevelDefs[Const.Total_Amount_of_Levels];
        

        public LevelManager()
        {
            Fill_Level_Definitions();
            for(int i = 0; i < Const.Total_Amount_of_Levels; i++)
            {
                Levels[i] = new Level(i + 1,
                                      Level_Defs[i].VillageStartCornerCoords,
                                      Level_Defs[i].WallLength,
                                      Level_Defs[i].ResoucrePoints,
                                      Level_Defs[i].WallStage,
                                      Level_Defs[i].GoldMineLevel,
                                      Level_Defs[i].StoneMineLevel);
            }
        }

        private void Fill_Level_Definitions()
        {
            // Level 1
            Level_Defs[0].VillageStartCornerCoords = new Coords(Level1_VillageStartCoords.Get_X(), Level1_VillageStartCoords.Get_Y());
            Level_Defs[0].WallLength = Level1_WallLength;
            Level_Defs[0].ResoucrePoints = Level1_ResourcePoints;
            Level_Defs[0].WallStage = Level1_WallStage;
            Level_Defs[0].GoldMineLevel = Level1_GoldMineLevel;
            Level_Defs[0].StoneMineLevel = Level1_StoneMineLevel;
            // Level 2
            Level_Defs[1].VillageStartCornerCoords = new Coords(Level2_VillageStartCoords.Get_X(), Level2_VillageStartCoords.Get_Y());
            Level_Defs[1].WallLength = Level2_WallLength;
            Level_Defs[1].ResoucrePoints = Level2_ResourcePoints;
            Level_Defs[1].WallStage = Level2_WallStage;
            Level_Defs[1].GoldMineLevel = Level2_GoldMineLevel;
            Level_Defs[1].StoneMineLevel = Level2_StoneMineLevel;
            // Level 3
            Level_Defs[2].VillageStartCornerCoords = new Coords(Level3_VillageStartCoords.Get_X(), Level3_VillageStartCoords.Get_Y());
            Level_Defs[2].WallLength = Level3_WallLength;
            Level_Defs[2].ResoucrePoints = Level3_ResourcePoints;
            Level_Defs[2].WallStage = Level3_WallStage;
            Level_Defs[2].GoldMineLevel = Level3_GoldMineLevel;
            Level_Defs[2].StoneMineLevel = Level3_StoneMineLevel;
            // Level 4
            Level_Defs[3].VillageStartCornerCoords = new Coords(Level4_VillageStartCoords.Get_X(), Level4_VillageStartCoords.Get_Y());
            Level_Defs[3].WallLength = Level4_WallLength;
            Level_Defs[3].ResoucrePoints = Level4_ResourcePoints;
            Level_Defs[3].WallStage = Level4_WallStage;
            Level_Defs[3].GoldMineLevel = Level4_GoldMineLevel;
            Level_Defs[3].StoneMineLevel = Level4_StoneMineLevel;
        }

        public Level GetActLevel (int i_LevelNr)
        {
            return Levels[i_LevelNr - 1];
        }
    }
}
