using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace ThatClock;

partial class MainWindow
{
    private TaskbarIcon taskbarIcon;

    private void InitializeNotifyIcon()
    {
        
        ImageSource imageSource = LoadEmbeddedImage("media/clock.ico");

        
        
        taskbarIcon = new TaskbarIcon();
        taskbarIcon.IconSource = imageSource;
        taskbarIcon.ToolTipText = "ThatClock";

        // Fügen Sie ein Kontextmenü für das Symbol hinzu
        ContextMenu contextMenu = new ContextMenu();

        // MenuItem showMenuItem = new MenuItem();
        // showMenuItem.Header = "Show";
        // showMenuItem.Click += ShowMenuItem_Click;
        // contextMenu.Items.Add(showMenuItem);

        MenuItem exitMenuItem = new MenuItem();
        exitMenuItem.Header = "Exit";
        exitMenuItem.Click += ExitMenuItem_Click;

        contextMenu.Items.Add(exitMenuItem);

        taskbarIcon.ContextMenu = contextMenu;
    }
    
    private ImageSource LoadEmbeddedImage(string imagePath)
    {
        try
        {
            Uri uri = new Uri("pack://application:,,,/" + imagePath);
            return new BitmapImage(uri);
        }
        catch 
        {
            return null;
        }
    }

    private void ShowMenuItem_Click(object sender, RoutedEventArgs e)
    {
        // Ihre App anzeigen
        this.Show();
        this.WindowState = WindowState.Normal;
    }

    private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
    {
        // Ihre App beenden
        Application.Current.Shutdown();
    }

    private void Window_StateChanged(object sender, EventArgs e)
    {
        // Minimieren Sie das Fenster in das Systray, wenn es minimiert wird
        if (this.WindowState == WindowState.Minimized)
        {
            this.Hide();
        }
    }
}