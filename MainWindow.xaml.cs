using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using System.Windows.Threading;

namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        String cur;
        
        public MainWindow()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            
                TimeSpan ts = sw.Elapsed;
                cur = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                timebox.Text = cur;
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Pausebutton.IsEnabled = true;
            Pause.IsEnabled = true;
            if (Start.Header.ToString() == "Start")
            {
                Startbutton.Content = "Stop";
                Start.Header = "Stop";
                sw.Start();
                dt.Start();
            }
            else
            {
                Startbutton.Content = "Start";
                Start.Header = "Start";
                sw.Stop();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            dt.Start();
            Pausebutton.IsEnabled = false;
            Pause.IsEnabled = false;
            Pausebutton.Content = "Pause";
            Pause.Header = "Pause";
            Startbutton.Content = "Start";
            Start.Header = "Start";
            timebox.Text = "00:00:00.00";
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (Pause.Header.ToString() == "Pause")
            {
                Pausebutton.Content = "Unpause";
                Pause.Header = "Unpause";
                dt.Stop();
            }
            else
            {
                Pausebutton.Content = "Pause";
                Pause.Header = "Pause";
                dt.Start();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Resetbutton_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            dt.Start();
            Pausebutton.IsEnabled = false;
            Pause.IsEnabled = false;
            Pausebutton.Content = "Pause";
            Pause.Header = "Pause";
            Startbutton.Content = "Start";
            Start.Header = "Start";
            timebox.Text = "00:00:00.00";
        }

        private void Startbutton_Click(object sender, RoutedEventArgs e)
        {
            Pausebutton.IsEnabled = true;
            Pause.IsEnabled = true;
            if(Startbutton.Content.ToString() == "Start")
            {
                Startbutton.Content = "Stop";
                Start.Header = "Stop";
                sw.Start();
                
            }
            else
            {
                Startbutton.Content = "Start";
                Start.Header = "Start";
                sw.Stop();
            }
        }

        private void Pausebutton_Click(object sender, RoutedEventArgs e)
        {
            if(Pausebutton.Content.ToString() == "Pause")
            {
                Pausebutton.Content = "Unpause";
                Pause.Header = "Unpause";
                dt.Stop();
            }
            else
            {
                Pausebutton.Content = "Pause";
                Pause.Header = "Pause";
                dt.Start();
            }
        }

        private void Stopwatch_Keydown(object sender, KeyEventArgs e)
        {
            if ((e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))  && e.Key == Key.R)       // Ctrl-S Save
            {
                sw.Reset();
                Pausebutton.IsEnabled = false;
                Pause.IsEnabled = false;
                Pausebutton.Content = "Pause";
                Pause.Header = "Pause";
                Startbutton.Content = "Start";
                Start.Header = "Start";
                timebox.Text = "00:00:00.00";

            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
