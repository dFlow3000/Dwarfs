using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Dwarfs
{
    public class Game
    {
        private UserControl uc_ControlArea;
        private UserControl uc_Field;

        private MainWindow mainWndw;

        public GameField gameField;
        Village village;
        public System.Windows.Forms.Timer mainTimer;
        private Clock gameClock;
        private LevelManager levelManager;
        private Level actLevel;

        private bool timerFullSec = false;
        private bool nightAlarmSwitch = false;

        private int actBaseStage;
        private int actDay;
        private int actWallStage;

        private int actResourcePoints; // Total Resource capacity

        private int actGoldMineLevel; // gold degration rate per resource point
        private int actStoneMineLevel; // stone degration rate per resource point

        private int actGoldMineValPerSec; // assigned resource points * gold degration rate
        private int actStoneMineValPerSec; // assigned resource points * stone degration rate
        
        private int actGoldValue;
        private int actStoneValue;
        private int actRecoveryPercentage;

        private Goblin gb1;
        private Goblin gb2;
        private Goblin gb3;
        private Goblin gb4;
        private Goblin gb5;
        private Goblin gb6;
        private Goblin gb7;
        private Goblin gb8;

        public Game(UserControl i_UCConArea, UserControl i_UCField, MainWindow mndw)
        {
            mainWndw = mndw;
            uc_ControlArea = i_UCConArea;
            uc_Field = i_UCField;
            gameField = new GameField(true);
            gameClock = new Clock();
            levelManager = new LevelManager();

            UC_ControlArea.game = this;

            mainTimer = new System.Windows.Forms.Timer();
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(TimerTick_HalfSec_Func);
            mainTimer.Start();

            actLevel = levelManager.GetActLevel(1);
            actBaseStage = actLevel.levelNr;
            actResourcePoints = actLevel.resourcePoints;
            actWallStage = actLevel.wallStage;
            actGoldMineLevel = actLevel.village.goldMineLevel;
            actStoneMineLevel = actLevel.village.stoneMineLevel;
            village = actLevel.village;

            actGoldValue = 0;
            actStoneValue = 0;
            
            VillageGenerator.Generate_Village(village, gameField.Grid);

            gb1 = new Goblin(gameField);
            gb2 = new Goblin(gameField);
            gb3 = new Goblin(gameField);
            gb4 = new Goblin(gameField);
            gb5 = new Goblin(gameField);
            gb6 = new Goblin(gameField);
            gb7 = new Goblin(gameField);
            gb8 = new Goblin(gameField);

        }

        private void TimerTick_HalfSec_Func(object sender, EventArgs e)
        {
            if (timerFullSec)
            {
                TimerTickFunc(sender, e);
            } else
            {
                timerFullSec = true;
            }

            gb1.searchForDwarfBase();
            gb2.searchForDwarfBase();
            gb3.searchForDwarfBase();
            gb4.searchForDwarfBase();
            gb5.searchForDwarfBase();
            gb6.searchForDwarfBase();
            gb7.searchForDwarfBase();
            gb8.searchForDwarfBase();

            if (gameClock.nightTime)
            {
                ImageBrush nightBackground = new ImageBrush();
                nightBackground.ImageSource = (ImageSource)Application.Current.Resources["BackgroundImage_Night"];
                mainWndw.Background = nightBackground;
                if (nightAlarmSwitch)
                {
                    UC_ControlArea.NightAlarm.Source = (ImageSource)Application.Current.Resources["Night_Alarm_ON"];
                    nightAlarmSwitch = false;
                } else
                {
                    UC_ControlArea.NightAlarm.Source = (ImageSource)Application.Current.Resources["Night_Alarm_OFF"];
                    nightAlarmSwitch = true;
                }
            } else
            {
                ImageBrush dayBackground = new ImageBrush();
                dayBackground.ImageSource = (ImageSource)Application.Current.Resources["BackgroundImage_Day"];
                if (mainWndw.Background != dayBackground)
                {
                    mainWndw.Background = dayBackground;
                }
            }
        }

        private void TimerTickFunc(object sender, EventArgs e)
        {
            gameClock.Clock_Tick(ref actDay);
            village.VillageMine(actGoldMineValPerSec, actStoneMineValPerSec, ref actGoldValue, ref actStoneValue);
            UpdateMiningRate();
            CheckIfLevelUp();
            UpdateContArea_Top_Labels(actBaseStage, actDay, actResourcePoints);
            UpdateContArea_Mid_Labels(actGoldValue, actStoneValue, actRecoveryPercentage);
            timerFullSec = false;

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
            actGoldMineValPerSec = actGoldMineLevel * Convert.ToInt32(UC_ControlArea.GoldMiningValue.Content) * actResourcePoints / 100;
            actStoneMineValPerSec = actStoneMineLevel * Convert.ToInt32(UC_ControlArea.StoneMiningValue.Content) * actResourcePoints / 100;
        }

        private void CheckIfLevelUp()
        {
            if(Convert.ToInt32(UC_ControlArea.BaseStage.Content) > actLevel.levelNr)
            {
                actLevel = levelManager.GetActLevel(Convert.ToInt32(UC_ControlArea.BaseStage.Content));
                actBaseStage = actLevel.levelNr;
                actResourcePoints = actLevel.resourcePoints;
                actWallStage = actLevel.wallStage;
                actGoldMineLevel = actLevel.village.goldMineLevel;
                actStoneMineLevel = actLevel.village.stoneMineLevel;
                village = actLevel.village;
                VillageGenerator.Generate_Village(village, gameField.Grid);
            }
        }
    }
}
