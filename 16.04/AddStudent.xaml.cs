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
    public partial class AddStudent : Window
    {
        MainWindow mainWindow;

        public AddStudent(MainWindow _mainWindow)
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

            string nameContent = nameBox.Text.Trim();
            string surnameContent = surnameBox.Text.Trim();
            string peselContent = peselBox.Text.Trim();
            string secondNameContent = secondNameBox.Text.Trim();
            string dobContent = dobBox.Text.Trim();
            string phoneContent = phoneBox.Text.Trim();
            string adressContent = adressBox.Text.Trim();
            string placeContent = placeBox.Text.Trim();
            string postCodeContent= postCodeBox.Text.Trim();

            bool isInvalid = false;

            if(nameContent == "")
            {
                nameBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                nameBox.Background = Brushes.White;
                nameContent = CapitalOnBeginnign(nameContent); 
            }

            if (surnameContent == "")
            {
                surnameBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                surnameBox.Background = Brushes.White;
                surnameContent = CapitalOnBeginnign(surnameContent);
            }

            if(peselContent == "")
            {
                peselBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                peselBox.Background = Brushes.White;
            }

            if(dobContent == "")
            {
                dobBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                dobBox.Background = Brushes.White;
            }

            if(adressContent == "")
            {
                adressBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                adressBox.Background = Brushes.White;
            }

            if (placeContent == "")
            {
                placeBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                placeBox.Background = Brushes.White;
                placeContent = CapitalOnBeginnign(placeContent);
            }

            if(postCodeContent == "")
            {
                postCodeBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                postCodeBox.Background = Brushes.White;
            }

            if (isInvalid)
                return;


            mainWindow.AddRecord(1, nameContent, surnameContent, peselContent, secondNameContent,
                dobContent, phoneContent, adressContent, placeContent, postCodeContent);
        }

        /// <summary>
        /// Makes string starts with capital letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string CapitalOnBeginnign(string s)
        {
            return s = s[0].ToString().ToUpper() + s.Remove(0, 1);
        }
    }
}
