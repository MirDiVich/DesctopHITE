///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для проведения тестов приложения пользователем
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class ScanningPage : Page
    {
        int targetTime;
        DateTime startTime;
        DispatcherTimer dispatcherTimer;
        int durationScan;

        public ScanningPage()
        {
            try
            {
                InitializeComponent();

                // Работа с таймером
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
                dispatcherTimer.Tick += Event_Timer_Tick;

                Event_ReceivingDataWaitingForStorage();
            }
            catch (Exception exScanningPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие ScanningPage в ScanningPage:\n\n " +
                     $"{exScanningPage.Message}");
            }
        }

        #region _Click
        private void CheckScanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckScanButton.IsChecked == true)
                {
                    Event_StartLoadingAnimation();
                    Event_ScanDeception();

                    TitleTextCheckScanTextBlock.Text = "ОСТАНОВИТЬ";
                    TitleIconCheckScanTextBlock1.Visibility = Visibility.Collapsed;
                    TitleIconCheckScanTextBlock2.Visibility = Visibility.Visible;

                    ProgressScanTextBlock.Text = "0%";
                    ResultScanTextBlock.Visibility = Visibility.Collapsed;

                    WhomCheckedTextBlock2.Visibility = Visibility.Visible;
                    ResultScanTextBlock2.Visibility = Visibility.Visible;
                    WhenCheckedTextBlock2.Visibility = Visibility.Visible;
                    DurationScanTextBlock2.Visibility = Visibility.Visible;
                    TitleErrorTextBlock2.Visibility = Visibility.Visible;

                    WhomCheckedTextBlock.Visibility = Visibility.Collapsed;
                    ResultScanTextBlock.Visibility = Visibility.Collapsed;
                    WhenCheckedTextBlock.Visibility = Visibility.Collapsed;
                    DurationScanTextBlock.Visibility = Visibility.Collapsed;
                    TitleErrorTextBlock.Visibility = Visibility.Collapsed;

                    FilesAtTimeScanningTextBlock.Text = "0";
                }
                else
                {
                    Event_StopLoadingAnimation();

                    dispatcherTimer.Stop();
                    ProgressScanTextBlock.Text = "///";

                    TitleTextCheckScanTextBlock.Text = "ПРОВЕРИТЬ";
                    TitleIconCheckScanTextBlock1.Visibility = Visibility.Visible;
                    TitleIconCheckScanTextBlock2.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception exCheckScanButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие CheckScanButton_Click в ScanningPage:\n\n " +
                     $"{exCheckScanButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
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
                     textMessage: $"Событие Event_StartLoadingAnimation в ScanningPage:\n\n " +
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
                         textMessage: $"Событие Event_StopLoadingAnimation в ScanningPage:\n\n " +
                         $"{exEvent_StopLoadingAnimation.Message}");
            }
        }

        private void Event_ScanDeception()
        {
            try
            {
                // Получаю рандомное время
                Random random = new Random();
                targetTime = random.Next(30, 181);
                startTime = DateTime.Now;

                // создание и запуск таймера
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += Event_Timer_Tick;
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Start();
            }
            catch (Exception exEvent_ScanDeception)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_ScanDeception в ScanningPage:\n\n " +
                         $"{exEvent_ScanDeception.Message}");
            }
        }

        private void Event_Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // определение интервала времени в процентах
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

                int filesAtTimeScanning = (int)(elapsedSeconds / (float)targetTime * 591);

                if (percentage >= 100)
                {
                    Event_StopLoadingAnimation();

                    dispatcherTimer.Stop();
                    ProgressScanTextBlock.Text = "100%";
                    durationScan = (int)(DateTime.Now - startTime).TotalSeconds;

                    Event_OutputDataWaitingForStorage();

                    FrameNavigationClass.bodySettings_FNC.Navigate(new ScanningPage());
                }
                else
                {
                    ProgressScanTextBlock.Text = $"{percentage}%";
                    FilesAtTimeScanningTextBlock.Text = $"{filesAtTimeScanning}";
                }
            }
            catch (Exception exEvent_Timer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_Timer_Tick в ScanningPage:\n\n " +
                         $"{exEvent_Timer_Tick.Message}");
            }
        }

        private void Event_ReceivingDataWaitingForStorage() // Вывод информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                WhenCheckedTextBlock.Text = Properties.Settings.Default.SNMScan;
                WhomCheckedTextBlock.Text = Properties.Settings.Default.DateTimeScan;
                DurationScanTextBlock.Text = Properties.Settings.Default.DurationScan;
            }
            catch (Exception exEvent_ReceivingDataWaitingForStorage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_ReceivingDataWaitingForStorage в ScanningPage:\n\n " +
                         $"{exEvent_ReceivingDataWaitingForStorage.Message}");
            }
        }

        private void Event_OutputDataWaitingForStorage() // Фиксация информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                var DateScanUser = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(AppConnectClass.receiveConnectUser_ACC).PassportTable; // Просто укоротил 3 слова в 1

                Properties.Settings.Default.SNMScan = $"{DateScanUser.Surname_Passport} {DateScanUser.Name_Passport[0]}. {DateScanUser.Middlename_Passport[0]}.";
                Properties.Settings.Default.DateTimeScan = DateTime.Now.ToString();
                Properties.Settings.Default.DurationScan = $"{durationScan} секунд";
                Properties.Settings.Default.Save();
            }
            catch (Exception exEvent_OutputDataWaitingForStorage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_OutputDataWaitingForStorage в ScanningPage:\n\n " +
                         $"{exEvent_OutputDataWaitingForStorage.Message}");
            }
        }
        #endregion
    }
}
