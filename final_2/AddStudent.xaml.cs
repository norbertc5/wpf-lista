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
        bool isEditing;

        public AddStudent(MainWindow _mainWindow, bool _isEditing=false, Record record = null)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            this.isEditing= _isEditing;

            if (_isEditing)
            {
                AddButton.Content = "Edytuj";
                nameBox.Text = record.name;
                surnameBox.Text = record.surname;
                peselBox.Text = record.pesel;
                secondNameBox.Text = record.secondName;
                dobBox.Text = record.dob;
                phoneBox.Text = record.phone;
                adressBox.Text = record.adress;
                placeBox.Text = record.place;
                postCodeBox.Text = record.postCode; 
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string nameContent = nameBox.Text.Trim();
            string surnameContent = surnameBox.Text.Trim();
            string peselContent = peselBox.Text.Trim();
            string secondNameContent = secondNameBox.Text.Trim();
            string dobContent = dobBox.Text.Trim();
            string phoneContent = phoneBox.Text.Trim();
            string adressContent = adressBox.Text.Trim();
            string placeContent = placeBox.Text.Trim();
            string postCodeContent = postCodeBox.Text.Trim();

            bool isInvalid = false;

            if (nameContent == "")
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

            if (peselContent == "" || !CheckPESELControlSum(peselContent) || !CheckPESELDate(peselContent, dobContent))
            {
                peselBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                peselBox.Background = Brushes.White;
            }

            if (dobContent == "")
            {
                dobBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                dobBox.Background = Brushes.White;
            }

            if (adressContent == "")
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

            if (postCodeContent == "")
            {
                postCodeBox.Background = Brushes.Red;
                isInvalid = true;
            }
            else
            {
                postCodeBox.Background = Brushes.White;
            }

            if (phoneContent != "")
            {
                phoneContent = ValidatePhone(phoneContent);
                bool areLettersInPhone = phoneContent.All(char.IsAsciiLetter);
                if (areLettersInPhone)
                {
                    phoneBox.Background = Brushes.Red;
                    isInvalid = true;
                }
            }
            else
            {
                phoneBox.Background = Brushes.White;
            }

            if (isInvalid)
                return;

            if (!isEditing)
            {
                mainWindow.AddRecord(nameContent, surnameContent, peselContent, secondNameContent,
                dobContent, phoneContent, adressContent, placeContent, postCodeContent);
            }
            else
            {
                mainWindow.EditRecord(nameContent, surnameContent, peselContent, secondNameContent,
                dobContent, phoneContent, adressContent, placeContent, postCodeContent);
            }

            Close();
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        bool CheckPESELControlSum(string pesel)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int c = int.Parse(pesel[i].ToString());
                    c *= weights[i];
                    sum += c;
                }
                int last = 10 - (sum % 10);
                if (pesel[10].ToString() == last.ToString())
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        bool CheckPESELDate(string pesel, string dob)
        {
            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));
            string[] dobElements = dob.Split('.');

            if(month > 20)
            {
                year += 2000;
                month -= 20;
            }
            else
            {
                year += 1900;
            }

            if(year == int.Parse(dobElements[2]) && month == int.Parse(dobElements[1]) && day == int.Parse(dobElements[0]))
            {
                return true;
            }

            return false;
        }

        string ValidatePhone(string phone)
        {
            if (!phone.Contains("+48"))
            {
                phone = phone.Insert(0, "+48");
            }
            phone =  phone.Replace(" ", "");
            return phone;
        }
    }
}
