using System;
using System.Diagnostics;
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
using System.Xml.Serialization;
using Python.Runtime;


namespace FormeCastWeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GeoJson.Root readGeoJson()
        {
            string jsonString = File.ReadAllText(@"..\..\..\ss_data.json");
            GeoJson.Root forecast = JsonSerializer.Deserialize<GeoJson.Root>(jsonString)!;
            return forecast;

        }
        public static bool weatherUpToDate()
        {
            GeoJson.Root forecast = readGeoJson();
            String date = DateTime.UtcNow.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
            date = date.Remove(14, 13).Insert(14, "00");                                                                //removes time more specific than hour
            return (forecast.features[0].properties.modelRunDate == date);
        }
        public static void Download_SS()
        {
            //TODO check if data needs updating (access 1st entry of json & compare to current time)


            //gets api to return recent data to ss_data.json
            pythonExeDir dir = new();
            string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            Process ss_download = new();
            ss_download.StartInfo = new ProcessStartInfo
                {
                    FileName = dir.getDirectory(),                                                                      //gets the directory of the current python install
                    WorkingDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\..\")),    //sets the directory ss_download.py is located in
                    Arguments = @"ss_download.py",  
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };
            ss_download.ErrorDataReceived += ss_download_ErrorDataReceived;
            ss_download.OutputDataReceived += ss_download_OutputDataReceived;

            ss_download.Start();
            ss_download.BeginErrorReadLine();
            ss_download.BeginOutputReadLine();
            ss_download.WaitForExit();
            MessageBox.Show("completed download");  //TODO make this a little notification

            

            //TODO write error messages and stuff like that :>
        }

        private static void ss_download_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e);
        }

        private static void ss_download_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e);
        }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGetWeather_Click(object sender, RoutedEventArgs e)
        {
            
            Download_SS();

            
            //TODO write data into Forecast class
            //TODO display data from json
        }

        private void checkCurrent_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(weatherUpToDate());
        }
    }
}