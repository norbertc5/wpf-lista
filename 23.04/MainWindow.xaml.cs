using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Record> records = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudentWindow = new AddStudent(this);
            addStudentWindow.Show();
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            while (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";
                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Record item in listView.Items)
                    {
                        var row = $"{item.pesel}{delimiter}{item.name}" +
                        $"{delimiter}{item.secondName}{delimiter}{item.surname}";
                        writer.WriteLine(row);
                    }
                }
            }
        }

        public void AddRecord(string _name, string _surname, string _pesel, 
            string _secondName, string _dob, string _phone, string _adress, string _place, string _postCode)
        {
            records.Add(new Record() { name = _name, surname = _surname, pesel = _pesel, secondName = _secondName, dob = _dob, phone = _phone, adress = _adress, 
            place = _place, postCode = _postCode});
            listView.Items.Add(records[records.Count - 1]);
        }
    }

    public class Record
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? pesel { get; set; }
        public string? secondName { get; set; }
        public string? dob{ get; set; }
        public string? phone { get; set; }
        public string? adress { get; set; }
        public string? place { get; set; }
        public string? postCode { get; set; }
    }
}