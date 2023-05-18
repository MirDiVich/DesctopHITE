///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для возможности пользователя связаться с разработчиками.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder
{
    public partial class DevelopersPage : Page
    {
        public DevelopersPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exDevelopersPage) 
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие DevelopersPage в DevelopersPage:\n\n " +
                      $"{exDevelopersPage.Message}");
            }
        }
        #region _Click
        private void TelegramHyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://t.me/MaRlXyAnA"); //открытие ссылки в браузере
            }
            catch (Exception exTelegramHyperlink_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие TelegramHyperlink_Click в DevelopersPage:\n\n " +
                      $"{exTelegramHyperlink_Click.Message}");
            }
        }

        private void WhatsAppHyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://web.whatsapp.com/89671643646"); //открытие ссылки в браузере
            }
            catch (Exception exWhatsAppHyperlink_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие WhatsAppHyperlink_Click в DevelopersPage:\n\n " +
                      $"{exWhatsAppHyperlink_Click.Message}");
            }
        }

        private void VKHyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://vk.com/vaskakavat"); //открытие ссылки в браузере
            }
            catch (Exception exVKHyperlink_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие VKHyperlink_Click в DevelopersPage:\n\n " +
                      $"{exVKHyperlink_Click.Message}");
            }
        }

        private void GitHubHyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/MaR1XyAnA/DesctopHITE"); //открытие ссылки в браузере
            }
            catch (Exception exGitHubHyperlink_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие GitHubHyperlink_Click в DevelopersPage:\n\n " +
                      $"{exGitHubHyperlink_Click.Message}");
            }
        }
        #endregion
    }
}
