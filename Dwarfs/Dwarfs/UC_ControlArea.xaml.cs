using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dwarfs
{
    /// <summary>
    /// Interaktionslogik für UC_ControlArea.xaml
    /// </summary>
    public partial class UC_ControlArea : UserControl
    {
        public static Image Clock_Img;

        public static Label BaseStage;
        public static Label Days;
        public static Label ResourcePoints;
        public static Label GoldValue;
        public static Label StoneValue;
        public static Label RecoveryValue;
        public static Label GoldMiningValue;
        public static Label StoneMiningValue;
        public static Label GoldMiningPerSec;
        public static Label StoneMiningPerSec;

        private bool dragStarted = false;

        public UC_ControlArea()
        {
            InitializeComponent();
            Clock_Img = IMG_Clock;
            BaseStage = LBL_BaseStage_Out;
            Days = LBL_Days_Out;
            ResourcePoints = LBL_ResourcePoints_Out;
            GoldValue = LBL_GoldValue_Out;
            StoneValue = LBL_StoneValue_Out;
            RecoveryValue = LBL_RecoveryValue_Out;
            GoldMiningValue = LBL_GoldMinigValue_Out;
            StoneMiningValue = LBL_StoneMinigValue_Out;
            GoldMiningPerSec = LBL_GoldMiningValue_PerSec_Out;
            StoneMiningPerSec = LBL_StoneMiningValue_PerSec_Out;

            Stone_Slider.Maximum = 100;
            Stone_Slider.Value = 50;
            Stone_Slider.Minimum = 0;
            Gold_Slider.Maximum = 100;
            Gold_Slider.Value = 50;
            Gold_Slider.Minimum = 0;
            dragStarted = true;
        }

        private void Gold_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider thisOne = (Slider)sender;
            SliderValueChanged(thisOne.Uid);
        }

        private void Stone_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider thisOne = (Slider)sender;
            SliderValueChanged(thisOne.Uid);
        }

        private void SliderValueChanged(string sliderIdentificator)
        {
            if (Stone_Slider != null && Gold_Slider != null && dragStarted)
            {
                if (sliderIdentificator == "Gold")
                {
                    int actResourcePoints = Convert.ToInt32(LBL_ResourcePoints_Out.Content);
                    Stone_Slider.Value = 100 - Math.Round(Gold_Slider.Value);
                    LBL_GoldMinigValue_Out.Content = Math.Round(Gold_Slider.Value).ToString();
                    LBL_StoneMinigValue_Out.Content = Stone_Slider.Value.ToString();
                }
                else
                {
                    int actResourcePoints = Convert.ToInt32(LBL_ResourcePoints_Out.Content);
                    Gold_Slider.Value = 100 - Math.Round(Stone_Slider.Value);
                    LBL_GoldMinigValue_Out.Content = Gold_Slider.Value.ToString();
                    LBL_StoneMinigValue_Out.Content = Math.Round(Stone_Slider.Value).ToString();
                }
            }
        }
    }
}
