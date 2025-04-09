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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow;

        public Window1(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*if(!idBox.Text.All(c => Char.IsNumber(c)))
            {
                idBox.Background = Brushes.Red;
                return;
            }
            else
            {
                idBox.Background = Brushes.White;
            }*/

            mainWindow.AddRecord(1, nameBox.Text, surnameBox.Text, peselBox.Text);
        }
    }
}
