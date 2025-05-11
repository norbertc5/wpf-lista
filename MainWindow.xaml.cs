using Microsoft.Win32;
using System.Collections.Generic;
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
using System;
using System.Linq;

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
            AddStudent addStudentWindow = new AddStudent(this, false);
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
                        $"{delimiter}{item.secondName}{delimiter}{item.surname}" +
                        $"{delimiter}{item.dob}{delimiter}{item.phone}{delimiter}{item.adress}{delimiter}{item.place}" +
                        $"{delimiter}{item.postCode}";
                        writer.WriteLine(row);
                    }
                }
            }
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            openFileDialog.Title = "Otwórz plik CSV";
            if (openFileDialog.ShowDialog() == true)
            {
                listView.Items.Clear();
                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";
                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }
                Encoding encoding = Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            Record uczen = new();
                            uczen.pesel = columns.ElementAtOrDefault(0);
                            uczen.name = columns.ElementAtOrDefault(1);
                            uczen.secondName = columns.ElementAtOrDefault(2);
                            uczen.surname = columns.ElementAtOrDefault(3);
                            uczen.dob = columns.ElementAtOrDefault(4);
                            uczen.phone = columns.ElementAtOrDefault(5);
                            uczen.adress = columns.ElementAtOrDefault(6);
                            uczen.place = columns.ElementAtOrDefault(7);
                            uczen.postCode = columns.ElementAtOrDefault(8);
                            listView.Items.Add(uczen);
                        }
                    }
                }
            }

        }

        public void AddRecord(string _name, string _surname, string _pesel,
            string _secondName, string _dob, string _phone, string _adress, string _place, string _postCode)
        {
            records.Add(new Record()
            {
                name = _name,
                surname = _surname,
                pesel = _pesel,
                secondName = _secondName,
                dob = _dob,
                phone = _phone,
                adress = _adress,
                place = _place,
                postCode = _postCode
            });
            listView.Items.Add(records[records.Count - 1]);
        }

        public void EditRecord(string _name, string _surname, string _pesel,
            string _secondName, string _dob, string _phone, string _adress, string _place, string _postCode)
        {
            if (listView.SelectedItems.Count <= 0)
                return;

            records[listView.SelectedIndex].name = _name;
            records[listView.SelectedIndex].surname = _surname;
            records[listView.SelectedIndex].pesel = _pesel;
            records[listView.SelectedIndex].secondName= _secondName;
            records[listView.SelectedIndex].dob = _dob;
            records[listView.SelectedIndex].phone = _phone;
            records[listView.SelectedIndex].adress = _adress;
            records[listView.SelectedIndex].place = _place;
            records[listView.SelectedIndex].postCode = _postCode;


            int index = listView.SelectedIndex;

            if (index >= 0 && index < listView.Items.Count)
            {
                listView.Items.RemoveAt(index);
                listView.Items.Insert(index, records[index]);
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddStudent addStudentWindow = new AddStudent(this, true, records[listView.SelectedIndex]);
                addStudentWindow.Show();
            }
            catch{ }
        }

    }

    public class Record
    {
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? pesel { get; set; }
        public string? secondName { get; set; }
        public string? dob { get; set; }
        public string? phone { get; set; }
        public string? adress { get; set; }
        public string? place { get; set; }
        public string? postCode { get; set; }
    }
}