///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для проведения тестов приложения пользователем
///----------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class ScanningPage : Page
    {

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

                CreatingFalseScan();
            }
            else
            {
                TestButton.Content = "Запустить сканирование системы";
                TestButton.Width = 360;

                ProgressScanTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private CancellationTokenSource cancellationTokenSource;

        private async void CreatingFalseScan()
        {
            // если предыдущее сканирование еще не завершено, отменяем его
            if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
            }

            cancellationTokenSource = new CancellationTokenSource();

            Random randomScan = new Random();
            var TimeScan = randomScan.Next(10, 121);
            int sleepTime = TimeScan / 100;

            for (int i = 0; i <= 100; i++)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }

                ProgressScanTextBlock.Text = $"{i}%";
                await Task.Delay(sleepTime * 1000, cancellationTokenSource.Token);
            }
        }
    }
}
