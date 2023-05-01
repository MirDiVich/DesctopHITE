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

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class UpdateApplicationPage : Page
    {
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
        }
        #region Click
        private void CheckUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUpdateButton.IsChecked == true)
            {
                StartLoadingAnimation();
            }
            else
            {
                StopLoadingAnimation();
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

            DoubleAnimation rotateAnimation = new DoubleAnimation();

            rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = 360;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

            rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = -360;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(4));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

            rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = 360;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(6));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

            rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = 0;
            rotateAnimation.To = -360;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(8));
            rotateAnimation.RepeatBehavior = RepeatBehavior.Forever;
            LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }

        private void StopLoadingAnimation()
        {
            LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
        }
        #endregion
    }
}
