///----------------------------------------------------------------------------------------------------------
/// Данная страница является "главной" и открывается при авторизации пользователя.
/// На странице реализовано то, что считается нужным быть на главной странице.
/// Данная страница берёт некоторую информацию из класса TimeClass
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class MainPage : Page
    {
        public static TimeClass GetTimeClass = new TimeClass();
        public static HolidayClass GetDayClass = new HolidayClass();

        DispatcherTimer GetTimer;

        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex) 
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие MainPage в MainPage:\n\n " +
                       $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    // Свойства для Таймера
                    GetTimer = new DispatcherTimer();
                    GetTimer.Tick += new EventHandler(GetTimer_Tick);
                    GetTimer.Interval = TimeSpan.FromMilliseconds(1);
                    GetTimer.Start();
                }
                else
                {
                    GetTimer.Stop();
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие Page_IsVisibleChanged в MainPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region Действие
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                // Работа с часами
                HelloyTextBlock.Text = GetTimeClass.WhatTimeIsIt.ToString();
                NowTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
                NowDateTextBlock.Text = DateTime.Now.ToString("dd MMMM" + "(MM) " + "yyyy");
                BirthdayTextBlock.Text = GetDayClass.HappyBirthdayGreetings.ToString();
                NowHolidayTextBlock.Text = GetDayClass.WhatDayIsIt.ToString();
                DayOfTheWeekTextBlock.Text = DateTime.Now.ToString("dddd", new CultureInfo("ru-RU"));

                if (GetDayClass.HappyBirthdayGreetings == "")
                {
                    BirthdayTextBlock.Visibility = Visibility.Collapsed;
                }
                if (GetDayClass.WhatDayIsIt == "Сегодня нет праздников")
                {
                    NowHolidayTextBlock.FontSize = 15;
                    NowHolidayTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(42, 42, 42));
                }
            }
            catch (Exception exGetTimer_Tick)
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие GetTimer_Tick в MainPage:\n\n " +
                      $"{exGetTimer_Tick.Message}");
            }
        }
        #endregion
    }
}
