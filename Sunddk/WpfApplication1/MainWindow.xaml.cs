using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfApplication1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WebClient client = new WebClient();
            //string parameters =
            //    "name=" + "wpf" +
            //    "&dateOfBirth=" + DateTime.Now +
            //    "&isAdmin=" + false +
            //    "&gender=" + "Mand" +
            //    "&email=" + "wpf@wpf.dk" +
            //    "&password=" + "Wpf1234" +
            //    "&date=" + DateTime.Now +
            //    "&weight=" + 70.5 +
            //    "&height=" + 170 +
            //    "&bmr=" + 455;
            string parameters = "name=PhillipV";
            client.Headers["Content-Type"] = "application/json";
            string uri = "http://localhost:52006/api/Person";
            client.UploadString(uri, parameters);
            
        }
    }
}
