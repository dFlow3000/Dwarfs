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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserControl uc_Field;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            uc_Field = new UC_Field();
            ConCont_Field.Content = uc_Field;
            UserControl uc_ControlArea = new UC_ControlArea();
            ConCont_ControlArea.Content = uc_ControlArea;
            Game game = new Game(uc_ControlArea, uc_Field, this);
        }

        private void BTN_TB_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BTN_TB_MIN_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DragAndDrop_Titelbar(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }
    }
}
