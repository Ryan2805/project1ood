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

namespace project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            List<string> previousplayers = new List<string>
            {
            "Alice",
            "Bob",
            "Charlie",
            "David",
            "Emma"
            };

            Playerslbx.ItemsSource = previousplayers;
        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            gameplay gameplayWindow = new gameplay();
            gameplayWindow.Show();
          
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}