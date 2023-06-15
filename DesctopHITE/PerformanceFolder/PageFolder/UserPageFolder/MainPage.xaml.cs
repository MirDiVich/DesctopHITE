///----------------------------------------------------------------------------------------------------------
/// Данная страница является "главной" и открывается при авторизации пользователя.
/// На странице реализовано то, что считается нужным быть на главной странице.
/// Данная страница берёт некоторую информацию из класса TimeClass
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
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
        public static TimeClass getTimeClass = new TimeClass();
        public static HolidayClass getDayClass = new HolidayClass();

        DispatcherTimer getTimer;

        public MainPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMainPage) 
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие MainPage в MainPage:\n\n " +
                       $"{exMainPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    // Свойства для Таймера
                    getTimer = new DispatcherTimer();
                    getTimer.Tick += new EventHandler(Event_Timer_Tick);
                    getTimer.Interval = TimeSpan.FromMilliseconds(1);
                    getTimer.Start();
                }
                else
                {
                    getTimer.Stop();
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MainPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region Event_
        private void Event_Timer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                // Работа с часами
                HelloyTextBlock.Text = getTimeClass.Event_WhatTimeIsIt_TC.ToString();
                NowTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
                NowDateTextBlock.Text = DateTime.Now.ToString("dd MMMM" + "(MM) " + "yyyy");
                BirthdayTextBlock.Text = getDayClass.Event_HappyBirthdayGreetings_HC.ToString();
                NowHolidayTextBlock.Text = getDayClass.Event_WhatDayIsIt_HC.ToString();
                DayOfTheWeekTextBlock.Text = DateTime.Now.ToString("dddd", new CultureInfo("ru-RU"));

                if (getDayClass.Event_HappyBirthdayGreetings_HC == "")
                {
                    BirthdayTextBlock.Visibility = Visibility.Collapsed;
                }
                if (getDayClass.Event_WhatDayIsIt_HC == "Сегодня нет праздников")
                {
                    NowHolidayTextBlock.FontSize = 15;
                    NowHolidayTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(42, 42, 42));
                }
            }
            catch (Exception exEvent_Timer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие Event_Timer_Tick в MainPage:\n\n " +
                      $"{exEvent_Timer_Tick.Message}");
            }
        }
        #endregion
    }
}
