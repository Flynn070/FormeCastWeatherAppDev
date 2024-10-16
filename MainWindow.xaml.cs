﻿using System;
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
        public static void Download_SS()
        {
            //TODO check if data needs updating (access 1st entry of json & compare to current time)


            //gets api to return recent data to ss_data.json
            pythonExeDir dir = new();
            string currentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            Process ss_download = new();
            ss_download.StartInfo = new ProcessStartInfo
                {
                    FileName = dir.getDirectory(),
                    WorkingDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\..\")),
                    Arguments = @"py ss_download.py",  //TODO THIS DOESNT WORK YET IT DOESNT ACTUALLY RUN!!!
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = false,
                };
            ss_download.ErrorDataReceived += ss_download_ErrorDataReceived;
            ss_download.OutputDataReceived += ss_download_OutputDataReceived;

            ss_download.Start();
            ss_download.BeginErrorReadLine();
            ss_download.BeginOutputReadLine();
            ss_download.WaitForExit();
            MessageBox.Show("completed download");

            

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
    }
}