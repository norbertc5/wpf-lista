using System.ComponentModel;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudentWindow = new AddStudent(this);
            addStudentWindow.Show();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void AddRecord(int _id, string _name, string _surname, string _pesel, 
            string _secondName, string _dob, string _phone, string _adress, string _place, string _postCode)
        {
            records.Add(new Record() { id = _id, name = _name, surname = _surname, pesel = _pesel, secondName = _secondName, dob = _dob, phone = _phone, adress = _adress, 
            place = _place, postCode = _postCode});
            listView.Items.Add(records[records.Count - 1]);
        }
    }

    public class Record
    {
        public int id { get; set; }
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