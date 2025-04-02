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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Window1 window1 = new Window1(this);
            //window1.Show();            

            //MyItem myItem = new();
            //listView.Items.Add(myItem);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Record
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string pesel { get; set; }

        public Record(int id, string name, string sname, string pesel)
        {
            Random rand = new();
            id = rand.Next();
            name = "Jan";
            sname = "Nowak";
            pesel = "00000000000";
        }
    }
}