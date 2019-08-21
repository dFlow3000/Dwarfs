using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwarfs
{
    class Goblin
    {
        private static Random rnd = new Random();
        private GameField i_gameField;
        private Coords newCoords;
        private Coords oldCoords;
        private int health;
        private int strength;
        private bool attack;
        private bool reroute;
        

        public Goblin(GameField i_gameField)
        {
            this.i_gameField = i_gameField;
            newCoords = generateGoblinStartCoords();
            oldCoords = newCoords;
            attack = false;
            reroute = false;
        }

        public void searchForDwarfBase()
        {
            if (!attack)
            {
                newCoords = getNewCoords();
                if (!attack)
                {
                    i_gameField.Grid[oldCoords.Get_X(), oldCoords.Get_Y()].SetType(Const.Type_Goblin_Land);
                    oldCoords = newCoords;
                }
            }
        }

        private Coords getNewCoords()
        {
            Coords newAttackCoords;
            int x = newCoords.Get_X();
            int y = newCoords.Get_Y();
            do
            {
                if (x < 25)
                {
                    x++;
                }
                else if (x > 25)
                {
                    x--;
                }

                if (y < 25)
                {
                    y++;
                }
                else if (y > 25)
                {
                    y--;
                }

            } while (checkIfAttackNeeded(x,y));
            if (!attack)
            {
                newAttackCoords = new Coords(x, y);
                i_gameField.Grid[newAttackCoords.Get_X(), newAttackCoords.Get_Y()].SetType(Const.Type_Goblin);
                return newAttackCoords;
            } else if (reroute)
            {
                //do
                //{
                //    if(rnd.Next(2) == 0)
                //    {
                //        if(x < )
                //    }
                //}
            }
            else
            {
                return newCoords;
            }
        
        }

        private bool checkIfAttackNeeded(int x, int y)
        {
            if (i_gameField.Grid[x, y].GetType() != Const.Type_Goblin_Land)
            {

                if (i_gameField.Grid[x, y].GetType() == Const.Type_Stone_Wall)
                {
                    attack = true;
                    return false;
                } else if (i_gameField.Grid[x, y].GetType() == Const.Type_Goblin)
                {
                    reroute = true;
                    return false;
                } else
                {
                    return true;
                }
            } else
            {
                return false;
            }
        }

        private Coords generateGoblinStartCoords()
        {
            Coords goblinStartCoords;
            do
            {
                if (rnd.Next(2) == 0)
                {
                    if (rnd.Next(2) == 0)
                    {
                        goblinStartCoords = new Coords(rnd.Next(2), rnd.Next(0, 50));
                    } else
                    {
                        goblinStartCoords = new Coords(rnd.Next(48,50), rnd.Next(0, 50));
                    }
                }
                else
                {
                    if (rnd.Next(2) == 0)
                    {
                        goblinStartCoords = new Coords(rnd.Next(0, 50), rnd.Next(2));
                    }
                    else
                    {
                        goblinStartCoords = new Coords(rnd.Next(0, 50), rnd.Next(48,50));
                    }

                }
            } while (i_gameField.Grid[goblinStartCoords.Get_X(), goblinStartCoords.Get_Y()].GetType()
                    != Const.Type_Goblin_Land);
            i_gameField.Grid[goblinStartCoords.Get_X(), goblinStartCoords.Get_Y()].SetType(Const.Type_Goblin);
            return goblinStartCoords;
        }
    }
}
