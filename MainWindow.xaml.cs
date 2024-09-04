using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Python.Runtime;


namespace FormeCastWeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void Download_SS()
        {
            //TODO check if data needs updating (access 1st entry of json & compare to current time)


            //gets api to return recent data to ss_data.json
            using (Py.GIL())
            {
                PythonEngine.Initialize();
                dynamic ss_download = Py.Import("MetAPI.ss_download");
                dynamic ss_geojson = ss_download.retrieve_forecast();
                PythonEngine.Shutdown();
            }

            //TODO write error messages and stuff like that :>
        }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            
            Download_SS();

            using (FileStream fs = File.Open("ss_data.json", FileMode.Open, FileAccess.Read))
            {
                string ss_data = JsonSerializer.Serialize(fs);
            }
            
            //TODO write data into Forecast class
            //TODO display data from json
        }
    }
}