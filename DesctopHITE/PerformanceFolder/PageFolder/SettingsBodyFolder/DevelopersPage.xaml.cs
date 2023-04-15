///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для возможности пользователя связаться с разработчиками
///----------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class DevelopersPage : Page
    {
        public DevelopersPage()
        {
            InitializeComponent();
        }
        #region Click
        private void TelegramHyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://t.me/MaRlXyAnA"); //открытие ссылки в браузере
        }

        private void WhatsAppHyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://web.whatsapp.com/89671643646"); //открытие ссылки в браузере
        }

        private void VKHyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.com/vaskakavat"); //открытие ссылки в браузере
        }
        #endregion
    }
}
