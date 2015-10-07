using System;
using System.Collections.Generic;
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

namespace MyCountDownTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.Timer myDateTimeTimer;
        private System.Windows.Forms.Timer myTimer;
        private uint currentTick = 0, currentMilliSecond = 0, currentSecond = 0, currentMinute = 0, currentHour = 0;
                
        public MainWindow()
        {
            InitializeComponent();

            BtnStart.Content = "START";
            MyTimerText.Content = "00:00:00.00";
            MyDateTimeText.Content = string.Format("{0} - {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

            myDateTimeTimer = new System.Windows.Forms.Timer();
            myDateTimeTimer.Tick += new EventHandler(myDateTimeTimer_Tick);
            myDateTimeTimer.Interval = 1000;
            myDateTimeTimer.Start();

            myTimer = new System.Windows.Forms.Timer();
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Interval = 10;
        }

        void myDateTimeTimer_Tick(object sender, EventArgs e)
        {
            MyDateTimeText.Content = string.Format("{0} - {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (BtnStart.Content.ToString() == "START")
            {   
                myTimer.Start();
            }
            else
            {
                myTimer.Stop();
            }

            BtnStart.Content = (BtnStart.Content.ToString() == "START") ? "STOP" : "START";
        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            currentTick += 16;
            UpdateMyTimerText();
        }
        
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            myTimer.Stop();
            currentTick = 0;
            BtnStart.Content = "START";
            UpdateMyTimerText();
        }

        private void UpdateMyTimerText()
        {
            currentMilliSecond = currentTick % 1000;
            currentSecond = currentTick / 1000;
            currentMinute = currentTick / 1000 / 60;
            currentHour = currentTick / 1000 / 60 / 60;

            MyTimerText.Content = string.Format(
                "{0}:{1}:{2}.{3}",
                (currentHour % 60).ToString("D2"),
                (currentMinute % 60).ToString("D2"),
                (currentSecond % 60).ToString("D2"),
                (currentMilliSecond / 10).ToString("D2")
                //currentTick.ToString()
                );
        }
    }
}