﻿///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для возможности проверки на наличие обновление;
/// На самом деле это страница пустышка. Никакой проверки на обновление НЕТ. Код реализован тем
///     что он просто выбирает рандомное время (от 5 до 30 секунд) и выполняет анимацию за отведённое время и выдаёт 
///     всегда результат, что стоит последняя версия приложения;
/// Да, да, да.... Знаю.... Страница-пустышка на 189 строк кода в "cs" и 367 строк кода в xaml.
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
    public partial class UpdateApplicationPage : Page
    {
        private int targetTime;
        private DateTime startTime;
        private DispatcherTimer dispatcherTimer;

        public UpdateApplicationPage()
        {
            try
            {
                InitializeComponent();

                // Работа с таймером
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
                dispatcherTimer.Tick += EventTimer_Tick;

                TitleUpDateTextBlock.Text =
                    $"- Добавлена анимация на проверку обновления;\n" +
                    $"- Добавлена анимация сканирования;\n" +
                    $"- Добавлена капча;\n" +
                    $"- Добавлена страница для сканирования приложения на наличие ошибок;\n" +
                    $"- Добавлена страница обновления;\n" +
                    $"- Изменён дизайн на более яркий;\n" +
                    $"- Исправлена ошибка при добавлении сотрудника;\n" +
                    $"- Исправлена ошибка при изменении данных о сотруднике;\n" +
                    $"- Оптимизация приложения;\n" +
                    $"- Оптимизированный код;\n" +
                    $"- Реализован поиск сотрудников;\n" +
                    $"- Реализовано удаление сотрудников;\n" +
                    $"- Сделан код более читаемый;\n" +
                    $"- Улучшена производительность приложения.";

                EventReceivingDataWaitingForStorage();
            }
            catch (Exception exUpdateApplicationPage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие UpdateApplicationPage в UpdateApplicationPage:\n\n " +
                   $"{exUpdateApplicationPage.Message}");
            }
        }
        #region _Click
        private void CheckUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckUpdateButton.IsChecked == true)
                {
                    EventStartLoadingAnimation();
                    EventScanDeception();

                    CheckUpdateButton.Content = "Остановить";
                    ProgressScanTextBlock.Text = "0%";
                    IndoVersionTodayBorder.Visibility = Visibility.Collapsed;
                }
                else
                {
                    EventStopLoadingAnimation();

                    dispatcherTimer.Stop();
                    CheckUpdateButton.Content = "Проверить обновление";
                    ProgressScanTextBlock.Text = "///";
                    IndoVersionTodayBorder.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exCheckUpdateButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие CheckUpdateButton_Click в UpdateApplicationPage:\n\n " +
                   $"{exCheckUpdateButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void EventStartLoadingAnimation() // Запуск анимации
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
            catch (Exception exEventStartLoadingAnimation)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventStartLoadingAnimation в UpdateApplicationPage:\n\n " +
                   $"{exEventStartLoadingAnimation.Message}");
            }
        }

        private void EventStopLoadingAnimation() // Остановка анимации
        {
            try
            {
                LoadingCircle0.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle1.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle2.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                LoadingCircle3.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            }
            catch (Exception exEventStopLoadingAnimation)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventStopLoadingAnimation в UpdateApplicationPage:\n\n " +
                   $"{exEventStopLoadingAnimation.Message}");
            }
        }

        private void EventScanDeception()
        {
            try
            {
                // Получаю рандомное время
                Random random = new Random();
                targetTime = random.Next(10, 30);
                startTime = DateTime.Now;

                // создание и запуск таймера
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += EventTimer_Tick;
                dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                dispatcherTimer.Start();
            }
            catch (Exception exEventScanDeception)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventScanDeception в UpdateApplicationPage:\n\n " +
                   $"{exEventScanDeception.Message}");
            }
        }

        private void EventTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // определение интервала времени в процентах
                int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int percentage = (int)(elapsedSeconds / (float)targetTime * 100);

                if (percentage >= 100)
                {
                    EventStopLoadingAnimation();

                    dispatcherTimer.Stop();
                    ProgressScanTextBlock.Text = "100%";

                    EventOutputDataWaitingForStorage();

                    FrameNavigationClass.bodySettings_FNC.Navigate(new UpdateApplicationPage());
                }
                else
                {
                    ProgressScanTextBlock.Text = $"{percentage}%";
                }
            }
            catch (Exception exEventTimer_Tick)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventTimer_Tick в UpdateApplicationPage:\n\n " +
                   $"{exEventTimer_Tick.Message}");
            }
        }

        private void EventReceivingDataWaitingForStorage() // Вывод информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                if (Properties.Settings.Default.SNMUpdateScan == null)
                {
                    ResultScanBorder.Visibility = Visibility.Collapsed;
                }
                else
                {
                    WhenCheckedTextBlock.Text = Properties.Settings.Default.SNMUpdateScan;
                    WhomCheckedTextBlock.Text = Properties.Settings.Default.DateTimeUpdateScan;
                    ResultCheckedTextBlock.Text = Properties.Settings.Default.ResultUpdateScan;
                }
            }
            catch (Exception exEventReceivingDataWaitingForStorage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventReceivingDataWaitingForStorage в UpdateApplicationPage:\n\n " +
                   $"{exEventReceivingDataWaitingForStorage.Message}");
            }
        }

        private void EventOutputDataWaitingForStorage() // Фиксация информации о том, кто последний раз проверял обновления приложения
        {
            try
            {
                var DateScanUser = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(AppConnectClass.receiveConnectUser_ACC).PassportTable; // Просто укоротил 3 слова в 1

                Properties.Settings.Default.SNMUpdateScan = $"{DateScanUser.Surname_Passport} {DateScanUser.Name_Passport[0]}. {DateScanUser.Middlename_Passport[0]}.";
                Properties.Settings.Default.DateTimeUpdateScan = DateTime.Now.ToString();
                Properties.Settings.Default.ResultUpdateScan = "Стоит последняя версия обновления";
                Properties.Settings.Default.Save();
            }
            catch (Exception exEventOutputDataWaitingForStorage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                   textMessage: $"Событие EventOutputDataWaitingForStorage в UpdateApplicationPage:\n\n " +
                   $"{exEventOutputDataWaitingForStorage.Message}");
            }
        }
        #endregion
    }
}
