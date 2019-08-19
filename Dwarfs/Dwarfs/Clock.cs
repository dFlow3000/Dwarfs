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
    class Clock
    {
        private Image clock_Img;
        private int secTick;

        public Clock()
        {
            clock_Img = UC_ControlArea.Clock_Img;
            secTick = 60;
        }

        public void Clock_Tick(ref int actDay)
        {
            bool visibleTick = false;
            switch(secTick)
            {
                case 60: visibleTick = true; break;
                case 55: visibleTick = true; break;
                case 50: visibleTick = true; break;
                case 45: visibleTick = true; break;
                case 40: visibleTick = true; break;
                case 35: visibleTick = true; break;
                case 30: visibleTick = true; break;
                case 25: visibleTick = true; break;
                case 20: visibleTick = true; break;
                case 15: visibleTick = true; break;
                case 10: visibleTick = true; break;
                case 5:  visibleTick = true; break;
                case 0:  secTick = 60; actDay++; visibleTick = true; break;
            }

            if(visibleTick)
            {
                clock_Img.Source = (ImageSource)Application.Current.Resources["Clock_" + secTick.ToString()];
            }
            secTick--;
        }
    }
}
