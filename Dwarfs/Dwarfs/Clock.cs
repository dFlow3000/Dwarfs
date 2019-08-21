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
        private Label clock_Label;
        private int secTick;
        public bool nightTime;

        public Clock()
        {
            clock_Label = UC_ControlArea.DigitalClock;
            secTick = 0;
            nightTime = false;
        }

        public void Clock_Tick(ref int actDay)
        {
            if(secTick == 0)
            {
                nightTime = false;
                secTick = 60;
                clock_Label.Content = "01:00";
            } else
            {
                clock_Label.Content = "00:" + (secTick < 10 ? "0" + secTick.ToString() : secTick.ToString());
            }

            if(secTick <= 45 && secTick >= 1)
            {
                nightTime = true;
            }

            secTick--;
        }
    }
}
