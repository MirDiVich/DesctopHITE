///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для возможности проверки на обновление;
/// На самом деле это страница пустышка. Никакой проверки на обновление нет. Код реализован тем
///     что он просто выбирает рандомное время и выполняет анимацию за отведённое время и выдаёт 
///     всегда результат, что стоит последняя версия приложения.
///----------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class UpdateApplicationPage : Page
    {
        private int targetTime;
        private DateTime startTime;
        private DispatcherTimer dispatcherTimer;


        public UpdateApplicationPage()
        {
            InitializeComponent();
            TitleUpDateTextBlock.Text =
                $"- Исправлена ошибка при изменении данных о сотруднике;\n" +
                $"- Исправлена ошибка при добавлении сотрудника;\n" +
                $"- Добавлена капча;\n" +
                $"- Изменён дизайн на более яркий;\n" +
                $"- Добавлена данная страница;\n" +
                $"- Сделан код более читаемый;\n" +
                $"- Улучшина производительность приложения.";

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += Timer_Tick;
        }

        #region Click
        private void CheckUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUpdateButton.IsChecked == true)
            {
                StartLoadingAnimation();
                ScanDeception();
            }
            else
            {
                StopLoadingAnimation();
                dispatcherTimer.Stop();
            }
        }
        #endregion
        #region Метод
        private void StartLoadingAnimation()
        {
            LoadingCircle0.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle0.RenderTransform = new RotateTransform();

            LoadingCircle1.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle1.RenderTransform = new RotateTransform();

            LoadingCircle2.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle2.RenderTransform = new RotateTransform();

            LoadingCircle3.RenderTransformOrigin = new Point(0.5, 0.5);
            LoadingCircle3.RenderTransform = new RotateTransform();

            DoubleAnimation rotateAnimation0 = new DoubleAnimation();
            rotateAnimation0.From = 0;
            rotateAnimation0.To = 360;
            rotateAnimation0.Duration = new Duration(TimeSpan.FromSeconds(2));
            rotateAnimation0.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation0);

            DoubleAnimation rotateAnimation1 = new DoubleAnimation();
            rotateAnimation1.From = 0;
            rotateAnimation1.To = -360;
            rotateAnimation1.Duration = new Duration(TimeSpan.FromSeconds(4));
            rotateAnimation1.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1);

            DoubleAnimation rotateAnimation2 = new DoubleAnimation();
            rotateAnimation2.From = 0;
            rotateAnimation2.To = 360;
            rotateAnimation2.Duration = new Duration(TimeSpan.FromSeconds(6));
            rotateAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation2);

            DoubleAnimation rotateAnimation3 = new DoubleAnimation();
            rotateAnimation3.From = 0;
            rotateAnimation3.To = -360;
            rotateAnimation3.Duration = new Duration(TimeSpan.FromSeconds(8));
            rotateAnimation3.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3);
        }

        private void StopLoadingAnimation()
        {
            LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        }

        private void ScanDeception()
        {
            Random random = new Random();
            targetTime = random.Next(10, 121);
            startTime = DateTime.Now;

            // создание и запуск таймера
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // определение интервала времени в процентах
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

            if (percentage >= 100)
            {
                // остановка таймера
                dispatcherTimer.Stop();
                ProgressScanTextBlock.Text = "100%";
                StopLoadingAnimation();
            }
            else
            {
                ProgressScanTextBlock.Text = $"{percentage}%";
            }
        }
        #endregion
    }
}
