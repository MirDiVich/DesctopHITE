///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для проведения тестов приложения пользователем
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class ScanningPage : Page
    {
        private int targetTime;
        private DateTime startTime;
        private DispatcherTimer dispatcherTimer;

        public ScanningPage()
        {
            InitializeComponent();

            // Работа с таймером
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += Timer_Tick;
        }

        #region Click
        private void CheckScanButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckScanButton.IsChecked == true)
            {
                StartLoadingAnimation();
                ScanDeception();

                CheckScanButton.Content = "Остановить";
                ProgressScanTextBlock.Text = "0%";
            }
            else
            {
                StopLoadingAnimation();

                dispatcherTimer.Stop();
                CheckScanButton.Content = "Проверить обновление";
                ProgressScanTextBlock.Text = "///";
            }
        }
        #endregion
        #region Метод
        private void StartLoadingAnimation() // Запуск анимации
        {
            // Задаю свойства для элементов
            LoadingCircle0.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle0.RenderTransform = new RotateTransform();

            LoadingCircle1.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle1.RenderTransform = new RotateTransform();

            LoadingCircle2.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle2.RenderTransform = new RotateTransform();

            LoadingCircle3.RenderTransformOrigin = new Point(0.5, 0.5);
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

        private void StopLoadingAnimation() // Остановка анимации
        {
            LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        }

        private void ScanDeception()
        {
            // Получаю рандомное время
            Random random = new Random();
            targetTime = random.Next(10, 181);
            startTime = DateTime.Now;

            // создание и запуск таймера
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // определение интервала времени в процентах
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

            if (percentage >= 100)
            {
                StopLoadingAnimation();

                dispatcherTimer.Stop();
                ProgressScanTextBlock.Text = "100%";
            }
            else
            {
                ProgressScanTextBlock.Text = $"{percentage}%";
            }
        }

        private void ReceivingDataWaitingForStorage() // Вывод информации о том, кто последний раз проверял обновления приложения
        {
           
        }

        private void OutputDataWaitingForStorage() // Фиксация информации о том, кто последний раз проверял обновления приложения
        {
            
        }
        #endregion
    }
}
