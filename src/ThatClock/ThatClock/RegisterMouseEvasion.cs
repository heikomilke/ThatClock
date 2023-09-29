using System;
using System.Windows;
using System.Windows.Input;

namespace ThatClock;

partial class MainWindow
{
    private bool isMouseOver = false;


    private void RegisterMouseEvasion()
    {
        this.MouseMove += MainWindow_MouseMove;

        this.MouseEnter += MainWindow_MouseEnter;
        this.MouseLeave += MainWindow_MouseLeave;
    }

    private void MainWindow_MouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseOver)
        {
            Point mousePosition = e.GetPosition(this);

            this.Left = mousePosition.X;
            this.Top = mousePosition.Y;
        }
    }

    private void MainWindow_MouseEnter(object sender, MouseEventArgs e)
    {
        isMouseOver = true;
    }

    private void MainWindow_MouseLeave(object sender, MouseEventArgs e)
    {
        isMouseOver = false;
    }
}