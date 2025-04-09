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
            Window1 window1 = new Window1(this);
            window1.Show();            
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void AddRecord(int _id, string _name, string _sname, string _pesel)
        {
            records.Add(new Record() { id = _id, name = _name, sname = _sname, pesel = _pesel});
            listView.Items.Add(records[records.Count-1]);
        }
    }

    public class Record
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? sname { get; set; }
        public string? pesel { get; set; }
    }
}