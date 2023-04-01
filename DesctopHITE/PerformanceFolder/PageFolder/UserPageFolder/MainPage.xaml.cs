using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        private void PartOfTheDay()
        {

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            HelloyTextBlock.Text = GetTimeClass.WhatTimeIsIt.ToString();
            NowTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            NowDayTextBlock.Text = DateTime.Now.ToString("dd MMMM" + ("(MM) ") + "yyyy");
            NowHolidayTextBlock.Text = GetTimeClass.WhatDayIsIt.ToString();
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
                GetTimer = new DispatcherTimer();
                GetTimer.Tick += new EventHandler(timer_Tick);
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
