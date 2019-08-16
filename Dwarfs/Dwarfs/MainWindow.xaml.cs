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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserControl uc_Field = new Field();
            ConCont_Field.Content = uc_Field;
            GRIDS
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
