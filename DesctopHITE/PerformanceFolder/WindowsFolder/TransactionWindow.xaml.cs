using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class TransactionWindow : Window
    {
        int targetTime;
        DateTime startTime;
        DispatcherTimer dispatcherTimer;

        public TransactionWindow(ChequeTable chequeTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                DataContext = chequeTable;

                Event_Transaction();
            }
            catch (Exception exTransactionWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие TransactionWindow в TransactionWindow:\n\n " +
                         $"{exTransactionWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) /// Если окно видно
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    Event_StartLoadingAnimation();
                    dispatcherTimer.Start();
                }
                else
                {
                    dispatcherTimer.Stop();
                    Event_StopLoadingAnimation();
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Window_IsVisibleChanged в TransactionWindow:\n\n " +
                         $"{exWindow_IsVisibleChanged.Message}");
            }
        }
        #region _Click
        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WaitingForANewOrderWindow waitingForANewOrderWindow = new WaitingForANewOrderWindow();
                waitingForANewOrderWindow.Show();

                this.Close();
            }
            catch (Exception exEndButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие EndButton_Click в TransactionWindow:\n\n " +
                         $"{exEndButton_Click.Message}");
            }
        }
        #endregion
        #region Event_

        private void Event_Timer_Tick(object sender, EventArgs e) /// Событие таймера
        {
            try
            {
                // определение интервала времени в процентах
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

                if (percentage >= 100)
                {
                    Event_StopLoadingAnimation();

                    dispatcherTimer.Stop();
                    ProgressTransactionTextBlock.Text = "Приятного аппетита";

                    FrameNavigationClass.bodySettings_FNC.Navigate(new ScanningPage());
                }
                else
                {
                    AnimationTransactionStackPanel.Visibility = Visibility.Collapsed;
                    EndTextStackPanel.Visibility = Visibility.Visible;
                    EndButton.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exEvent_Timer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_Timer_Tick в ScanningPage:\n\n " +
                         $"{exEvent_Timer_Tick.Message}");
            }
        }

        private void Event_Transaction() /// Транзакция
        {
            try
            {
                // Получаю рандомное время
                Random random = new Random();
                targetTime = random.Next(10, 20);
                startTime = DateTime.Now;

                // создание и запуск таймера
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += Event_Timer_Tick;
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Start();
            }
            catch (Exception exEvent_Transaction)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_Transaction в ScanningPage:\n\n " +
                         $"{exEvent_Transaction.Message}");
            }
        }

        private void Event_StartLoadingAnimation() // Запуск анимации
        {
            try
            {
                var point = new Point(0.5, 0.5);

                // Задаю свойства для элементов
                LoadingCircle0.RenderTransformOrigin = point;
                LoadingCircle0.RenderTransform = new RotateTransform();

                LoadingCircle1.RenderTransformOrigin = point;
                LoadingCircle1.RenderTransform = new RotateTransform();

                LoadingCircle2.RenderTransformOrigin = point;
                LoadingCircle2.RenderTransform = new RotateTransform();

                LoadingCircle3.RenderTransformOrigin = point;
                LoadingCircle3.RenderTransform = new RotateTransform();

                // Задаю свойства для анимации
                DoubleAnimation animationLeft = new DoubleAnimation();
                animationLeft.From = 0;
                animationLeft.To = 360;
                animationLeft.Duration = new Duration(TimeSpan.FromSeconds(2));
                animationLeft.RepeatBehavior = RepeatBehavior.Forever;

                DoubleAnimation animationRight = new DoubleAnimation();
                animationRight.From = 0;
                animationRight.To = -360;
                animationRight.Duration = new Duration(TimeSpan.FromSeconds(4));
                animationRight.RepeatBehavior = RepeatBehavior.Forever;

                // Подключаю анимацию
                LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animationLeft);
                LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animationRight);

                // Меняю свойство анимации и подключаю её
                animationLeft = new DoubleAnimation();
                animationLeft.From = 0;
                animationLeft.To = 360;
                animationLeft.Duration = new Duration(TimeSpan.FromSeconds(6));
                animationLeft.RepeatBehavior = RepeatBehavior.Forever;
                LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animationLeft);

                animationRight = new DoubleAnimation();
                animationRight.From = 0;
                animationRight.To = -360;
                animationRight.Duration = new Duration(TimeSpan.FromSeconds(8));
                animationRight.RepeatBehavior = RepeatBehavior.Forever;
                LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animationRight);
            }
            catch (Exception exEvent_StartLoadingAnimation)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие Event_StartLoadingAnimation в TransactionWindow:\n\n " +
                     $"{exEvent_StartLoadingAnimation.Message}");
            }
        }

        private void Event_StopLoadingAnimation() // Остановка анимации
        {
            try
            {
                LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            }
            catch (Exception exEvent_StopLoadingAnimation)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_StopLoadingAnimation в TransactionWindow:\n\n " +
                         $"{exEvent_StopLoadingAnimation.Message}");
            }
        }
        #endregion
    }
}
