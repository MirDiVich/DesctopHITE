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
            catch (Exception ex)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие MenuSettingsPage в MenuSettingsPage:\n\n " +
                       $"{ex.Message}");
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
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuSettingsPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region _Click
        private void AboutTheAppToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                AboutTheAppToggleButton.IsChecked = true;
                AboutTheAppToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new AboutAppPage());
            }
            catch (Exception exAboutTheAppToggleButton_Click) 
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие AboutTheAppToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exAboutTheAppToggleButton_Click.Message}");
            }
        }

        private void UpdateToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                UpdateToggleButton.IsChecked = true;
                UpdateToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new UpdateApplicationPage());
            }
            catch (Exception exUpdateToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие UpdateToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exUpdateToggleButton_Click.Message}");
            }
        }

        private void DevelopersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                DevelopersToggleButton.IsChecked = true;
                DevelopersToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new DevelopersPage());
            }
            catch (Exception exDevelopersToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие DevelopersToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exDevelopersToggleButton_Click.Message}");
            }
        }

        private void ScanningToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                ScanningToggleButton.IsChecked = true;
                ScanningToggleButton.IsEnabled = false;
                FrameNavigationClass.bodySettings_FNC.Navigate(new ScanningPage());
            }
            catch (Exception exScanningToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие ScanningToggleButton_Click в MenuSettingsPage:\n\n " +
                       $"{exScanningToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsChecked = false;
                UpdateToggleButton.IsChecked = false;
                DevelopersToggleButton.IsChecked = false;
                ScanningToggleButton.IsChecked = false;
            }
            catch (Exception exIsCheckedToggleButton)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие IsCheckedToggleButton в MenuSettingsPage:\n\n " +
                       $"{exIsCheckedToggleButton.Message}");
            }
        }
        private void IsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsEnabled = true;
                UpdateToggleButton.IsEnabled = true;
                DevelopersToggleButton.IsEnabled = true;
                ScanningToggleButton.IsEnabled = true;
            }
            catch (Exception exIsEnabledToggleButton)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие IsEnabledToggleButton в MenuSettingsPage:\n\n " +
                       $"{exIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
