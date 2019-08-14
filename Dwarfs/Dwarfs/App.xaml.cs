using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace Dwarfs
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();

            System.Windows.Forms.Screen s1 = System.Windows.Forms.Screen.AllScreens[0];
            Rectangle r1 = s1.WorkingArea;
            mainWindow.Top = r1.Top;
            mainWindow.Left = r1.Left;
            mainWindow.Show();

        }
    }

}
