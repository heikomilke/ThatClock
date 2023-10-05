using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ThatClock
{
    public partial class MainWindow
    {
        private readonly DispatcherTimer _timer = new();

        public MainWindow()
        {
            InitializeComponent();
            

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            // initial call 
            UpdateTime();

            InitializeNotifyIcon();

            //RegisterMouseEvasion();
            
            
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            CurrentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem menuItem = new MenuItem
            {
                Header = "Exit"
            };
            menuItem.Click += ExitItem_Click;

            contextMenu.Items.Add(menuItem);

            contextMenu.IsOpen = true;
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnInitialized(EventArgs e)
        {
            Left = Properties.Settings.Default.Left;
            Top = Properties.Settings.Default.Top;
            base.OnInitialized(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Save();
                
            base.OnClosing(e);
        }
    }
}