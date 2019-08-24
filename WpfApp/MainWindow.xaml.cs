using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WpfApp
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var url = textBox.Text;
            var isValidUrl =  Uri.TryCreate(url, UriKind.Absolute, out _);
            if (!isValidUrl)
            {
                textBlock.Text = "Given url is not valid.";
                return;
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            try
            {

                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                textBlock.Text = data;
            }
            catch (Exception ex)
            {
                textBlock.Text = ex.Message;
            }
        }
    }
}
