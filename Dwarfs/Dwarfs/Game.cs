using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dwarfs
{
    class Game
    {
        private UserControl uc_ControlArea;
        private UserControl uc_Field;

        public GameField gameField;
        Village village;
        private System.Windows.Forms.Timer mainTimer;
        private Clock gameClock;

        private int actBaseStage;
        private int actDay;
        private int actWallStage;
        private int actGlobalMiningValPerSec;
        private int actGoldMineValPerSec;
        private int actStoneMineValPerSec;

        private int actResourcePoints;
        private int actGoldValue;
        private int actStoneValue;
        private int actRecoveryPercentage;

        public Game(UserControl i_UCConArea, UserControl i_UCField, MainWindow mndw)
        {
            uc_ControlArea = i_UCConArea;
            uc_Field = i_UCField;
            gameField = new GameField(true);

            actBaseStage = 1;
            actDay = 1;
            actWallStage = 1;
            actResourcePoints = 150;
            actGlobalMiningValPerSec = actResourcePoints;
            actGoldMineValPerSec = 10;
            actStoneMineValPerSec = 10;

            actGoldValue = 0;
            actStoneValue = 0;


            village = new Village(20, 20, 10);
            VillageGenerator.Generate_Village(village, gameField.Grid);

            gameClock = new Clock();

            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 1000;
            mainTimer.Tick += new EventHandler(TimerTickFunc);
            mainTimer.Start();
        }

        private void TimerTickFunc(object sender, EventArgs e)
        {
            gameClock.Clock_Tick(ref actDay);
            village.VillageMine(actGoldMineValPerSec, actStoneMineValPerSec, ref actGoldValue, ref actStoneValue);
            UpdateMiningRate();
            UpdateContArea_Top_Labels(actBaseStage, actDay, actResourcePoints);
            UpdateContArea_Mid_Labels(actGoldValue, actStoneValue, actRecoveryPercentage);

        }

        private void UpdateContArea_Top_Labels(int baseStage, int day, int resourcePoints)
        {
            UC_ControlArea.BaseStage.Content = baseStage.ToString();
            UC_ControlArea.Days.Content = day.ToString();
            UC_ControlArea.ResourcePoints.Content = resourcePoints.ToString();
        }

        private void UpdateContArea_Mid_Labels(int gold, int stone, int recovery)
        {
            UC_ControlArea.GoldValue.Content = gold.ToString();
            UC_ControlArea.StoneValue.Content = stone.ToString();
            UC_ControlArea.RecoveryValue.Content = recovery.ToString();
            UC_ControlArea.GoldMiningPerSec.Content = actGoldMineValPerSec.ToString();
            UC_ControlArea.StoneMiningPerSec.Content = actStoneMineValPerSec.ToString();

        }

        private void UpdateMiningRate()
        {
            actGoldMineValPerSec = Convert.ToInt32(UC_ControlArea.GoldMiningValue.Content) * actGlobalMiningValPerSec / 100;
            actStoneMineValPerSec = Convert.ToInt32(UC_ControlArea.StoneMiningValue.Content) * actGlobalMiningValPerSec / 100;
        }
    }
}
