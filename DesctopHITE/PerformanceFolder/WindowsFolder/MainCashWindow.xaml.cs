//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Просто главное окно, которое нужно для того, чтоб туда выгружать страницы, с
///     которыми уже и взаимодействует пользователь.
/// На данный момент, окно представляет из себя пустышку, с 2 "Frame" и всёёё....
/// 
/// да.... я удалил таймер, так как с ним у меня проблемы, которые  я думал, что решу, но у меня уже нет времени на решение проблемы с таймером.
/// Мне нужно сделать программу, чтоб я её мог сегодня (21.06.2023) презентовать.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;
using System;
using System.Windows;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class MainCashWindow : Window
    {
        //DispatcherTimer dispatcherTimer;

        public MainCashWindow()
        {
            try
            {
                InitializeComponent();
                FrameNavigationClass.munuCash_FNC = MenuCashFrame;
                FrameNavigationClass.bodyCash_FNC = BodyCashFrame;

                // Инициализация таймера
                //dispatcherTimer = new DispatcherTimer();
                //dispatcherTimer.Interval = TimeSpan.FromSeconds(20);
                //dispatcherTimer.Tick += DispatcherTimer_Tick;

                // Привязка обработчика события к окну
                //this.MouseMove += MainCashWindow_MouseMove;
                //this.MouseDown += MainCashWindow_MouseDown;
            }
            catch (Exception exMainCashWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие MainCashWindow в MainCashWindow:\n\n " +
                        $"{exMainCashWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.munuCash_FNC.Navigate(new MenuCashPage());
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Window_IsVisibleChanged в MainCashWindow:\n\n " +
                        $"{exWindow_IsVisibleChanged.Message}");
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                WaitingTimerWindow waitingTimerWindow = new WaitingTimerWindow();
                waitingTimerWindow.ShowDialog();
            }
            catch (Exception exDispatcherTimer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DispatcherTimer_Tick в MainCashWindow:\n\n " +
                        $"{exDispatcherTimer_Tick.Message}");
            }
        }
        #region _MouseDown _MouseMove
        //private void MainCashWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        // При нажатии на кнопку сбрасываем таймер
        //        dispatcherTimer.Stop();
        //        dispatcherTimer.Start();
        //    }
        //    catch (Exception exMainCashWindow_MouseDown)
        //    {
        //        MessageBoxClass.ExceptionMessageBox_MBC(
        //                textMessage: $"Событие MainCashWindow_MouseDown в MainCashWindow:\n\n " +
        //                $"{exMainCashWindow_MouseDown.Message}");
        //    }
        //}

        //private void MainCashWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    try
        //    {
        //        // При движении мышки сбрасываем таймер
        //        dispatcherTimer.Stop();
        //        dispatcherTimer.Start();
        //    }
        //    catch (Exception exMainCashWindow_MouseMove)
        //    {
        //        MessageBoxClass.ExceptionMessageBox_MBC(
        //                textMessage: $"Событие MainCashWindow_MouseMove в MainCashWindow:\n\n " +
        //                $"{exMainCashWindow_MouseMove.Message}");
        //    }
        //}
        #endregion
        #region _Click
        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BasketWindow basketWindow = new BasketWindow();
                basketWindow.ShowDialog();
            }
            catch (Exception exBasketButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие BasketButton_Click в MainCashWindow:\n\n " +
                        $"{exBasketButton_Click.Message}");
            }
        }
        #endregion
    }
}
