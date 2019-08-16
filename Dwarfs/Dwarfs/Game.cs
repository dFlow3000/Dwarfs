using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class Game
    {
        public GameField gameField;


        public Game()
        {
            gameField = new GameField(true);
            Village village1 = new Village(20, 20, 10);
            VillageGenerator.Generate_Village(village1, gameField.Grid);
        }
    }
}
