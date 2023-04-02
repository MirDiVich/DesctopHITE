///----------------------------------------------------------------------------------------------------------
/// Данная страница является "главной" и открывается при авторизации пользователя.
/// На странице реализовано то, что считается нужным быть на главной странице.
/// Данная страница берёт некоторую информацию из класса TimeClass
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class MainPage : Page
    {
        public static TimeClass GetTimeClass = new TimeClass();
        DispatcherTimer GetTimer;
        public MainPage()
        {
            InitializeComponent();
        }
        #region Действие
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            HelloyTextBlock.Text = GetTimeClass.WhatTimeIsIt.ToString();
            NowTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss"); // xx:xx:xx
            NowDateTextBlock.Text = DateTime.Now.ToString("dd MMMM" + ("(MM) ") + "yyyy"); // xx Month(xx) xxxx
            NowHolidayTextBlock.Text = GetTimeClass.WhatDayIsIt.ToString(); // Показывает, какой сегодня праздник

            if (GetTimeClass.WhatDayIsIt == "Сегодня нет праздников")
            {
                NowHolidayTextBlock.FontSize = 20;
                NowHolidayTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(42, 42, 42));
            }
        }
        #endregion

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                // Свойства для Таймера
                GetTimer = new DispatcherTimer();
                GetTimer.Tick += new EventHandler(GetTimer_Tick);
                GetTimer.Interval = TimeSpan.FromSeconds(1);
                GetTimer.Start();
            }
            else
            {
                GetTimer.Stop();
            }
        }
    }
}
