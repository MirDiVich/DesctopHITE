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
                dispatcherTimer.Tick += Timer_Tick;
                ReceivingDataWaitingForStorage();
            }
            catch (Exception ex)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие ScanningPage в ScanningPage:\n\n " +
                     $"{ex.Message}");
            }
        }

        #region _Click
        private void CheckScanButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckScanButton.IsChecked == true)
                {
                    StartLoadingAnimation();
                    ScanDeception();

                    CheckScanButton.Content = "Остановить";
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
                    StopLoadingAnimation();

                    dispatcherTimer.Stop();
                    CheckScanButton.Content = "Проверить обновление";
                    ProgressScanTextBlock.Text = "///";
                }
            }
            catch (Exception exCheckScanButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие CheckScanButton_Click в ScanningPage:\n\n " +
                     $"{exCheckScanButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void StartLoadingAnimation() // Запуск анимации
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
            catch (Exception exStartLoadingAnimation)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие StartLoadingAnimation в ScanningPage:\n\n " +
                     $"{exStartLoadingAnimation.Message}");
            }
        }

        private void StopLoadingAnimation() // Остановка анимации
        {
            try
            {
                LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            }
            catch ( Exception exStopLoadingAnimation) 
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                         textMessage: $"Событие StopLoadingAnimation в ScanningPage:\n\n " +
                         $"{exStopLoadingAnimation.Message}");
            }
        }

        private void ScanDeception()
        {
            try
            {
                // Получаю рандомное время
                Random random = new Random();
                targetTime = random.Next(30, 181);
                startTime = DateTime.Now;

                // создание и запуск таймера
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += Timer_Tick;
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Start();
            }
            catch (Exception exScanDeception)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                         textMessage: $"Событие ScanDeception в ScanningPage:\n\n " +
                         $"{exScanDeception.Message}");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // определение интервала времени в процентах
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

                int filesAtTimeScanning = (int)(elapsedSeconds / (float)targetTime * 591);

                if (percentage >= 100)
                {
                    StopLoadingAnimation();

                    dispatcherTimer.Stop();
                    ProgressScanTextBlock.Text = "100%";
                    durationScan = (int)(DateTime.Now - startTime).TotalSeconds;

                    OutputDataWaitingForStorage();

                    FrameNavigationClass.bodySettings_FNC.Navigate(new ScanningPage());
                }
                else
                {
                    ProgressScanTextBlock.Text = $"{percentage}%";
                    FilesAtTimeScanningTextBlock.Text = $"{filesAtTimeScanning}";
                }
            }
            catch (Exception exTimer_Tick)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                         textMessage: $"Событие Timer_Tick в ScanningPage:\n\n " +
                         $"{exTimer_Tick.Message}");
            }
        }

        private void ReceivingDataWaitingForStorage() // Вывод информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                WhenCheckedTextBlock.Text = Properties.Settings.Default.SNMScan;
                WhomCheckedTextBlock.Text = Properties.Settings.Default.DateTimeScan;
                DurationScanTextBlock.Text = Properties.Settings.Default.DurationScan;
            }
            catch (Exception exReceivingDataWaitingForStorage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                         textMessage: $"Событие ReceivingDataWaitingForStorage в ScanningPage:\n\n " +
                         $"{exReceivingDataWaitingForStorage.Message}");
            }
        }

        private void OutputDataWaitingForStorage() // Фиксация информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                var DateScanUser = AppConnectClass.receiveConnectUser_ACC.PassportTable; // Просто укоротил 3 слова в 1

                Properties.Settings.Default.SNMScan = $"{DateScanUser.Surname_Passport} {DateScanUser.Name_Passport[0]}. {DateScanUser.Middlename_Passport[0]}.";
                Properties.Settings.Default.DateTimeScan = DateTime.Now.ToString();
                Properties.Settings.Default.DurationScan = $"{durationScan} секунд";
                Properties.Settings.Default.Save();
            }
            catch (Exception exOutputDataWaitingForStorage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                         textMessage: $"Событие OutputDataWaitingForStorage в ScanningPage:\n\n " +
                         $"{exOutputDataWaitingForStorage.Message}");
            }
        }
        #endregion
    }
}
