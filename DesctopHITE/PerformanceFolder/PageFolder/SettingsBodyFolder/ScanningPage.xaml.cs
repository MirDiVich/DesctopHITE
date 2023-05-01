///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для проведения тестов приложения пользователем
///----------------------------------------------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class ScanningPage : Page
    {
        DispatcherTimer timer;
        int timeScan;

        public ScanningPage()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if (TestButton.IsChecked == true)
            {
                TestButton.Content = "Отменить";
                TestButton.Width = 220;

                ProgressScanTextBlock.Visibility = Visibility.Visible;

                //CreatingFalseScan();
            }
            else
            {
                TestButton.Content = "Запустить сканирование системы";
                TestButton.Width = 360;

                ProgressScanTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        //private void CreatingFalseScan()
        //{
        //    Random randomScan = new Random();
        //    timeScan = randomScan.Next(20, 151);

        //    timer.Interval = TimeSpan.FromSeconds(timeScan);
        //    timer.Tick += Timer_Tick;
        //    timer.Start();
        //}

        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    ProgressScanTextBlock.Text = $"{timeScan}";
        //}
    }
}
