///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuSettingsPage : Page
    {
        public MenuSettingsPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exMenuSettingsPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие MenuSettingsPage в MenuSettingsPage:\n\n " +
                       $"{exMenuSettingsPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    AboutTheAppToggleButton.IsChecked = true;
                    AboutTheAppToggleButton.IsEnabled = false;
                    FrameNavigationClass.bodySettings_FNC.Navigate(new AboutAppPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuSettingsPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region _Click
        private void AboutTheAppToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                AboutTheAppToggleButton.IsChecked = true;
                AboutTheAppToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new AboutAppPage());
            }
            catch (Exception exAboutTheAppToggleButton_Click) 
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие AboutTheAppToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exAboutTheAppToggleButton_Click.Message}");
            }
        }

        private void UpdateToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                UpdateToggleButton.IsChecked = true;
                UpdateToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new UpdateApplicationPage());
            }
            catch (Exception exUpdateToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие UpdateToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exUpdateToggleButton_Click.Message}");
            }
        }

        private void DevelopersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                DevelopersToggleButton.IsChecked = true;
                DevelopersToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new DevelopersPage());
            }
            catch (Exception exDevelopersToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие DevelopersToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exDevelopersToggleButton_Click.Message}");
            }
        }

        private void ScanningToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                ScanningToggleButton.IsChecked = true;
                ScanningToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new ScanningPage());
            }
            catch (Exception exScanningToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие ScanningToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exScanningToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void EventIsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsChecked = false;
                UpdateToggleButton.IsChecked = false;
                DevelopersToggleButton.IsChecked = false;
                ScanningToggleButton.IsChecked = false;
            }
            catch (Exception exEventIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsCheckedToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEventIsCheckedToggleButton.Message}");
            }
        }
        private void EventIsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsEnabled = true;
                UpdateToggleButton.IsEnabled = true;
                DevelopersToggleButton.IsEnabled = true;
                ScanningToggleButton.IsEnabled = true;
            }
            catch (Exception exEventIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsEnabledToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEventIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
