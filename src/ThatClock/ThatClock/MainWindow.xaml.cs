using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ThatClock
{
    public partial class MainWindow
    {
        private DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            // initial call 
            UpdateTime();


            //RegisterMouseEvasion();
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            CurrentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}