//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// На данной странице реализован код для работы меню
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
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
                    Event_IsCheckedToggleButton();
                    Event_IsEnabledToggleButton();

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
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

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
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

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
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

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
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

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
        #region Event_
        private void Event_IsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsChecked = false;
                UpdateToggleButton.IsChecked = false;
                DevelopersToggleButton.IsChecked = false;
                ScanningToggleButton.IsChecked = false;
            }
            catch (Exception exEvent_IsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_IsCheckedToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEvent_IsCheckedToggleButton.Message}");
            }
        }
        private void Event_IsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                AboutTheAppToggleButton.IsEnabled = true;
                UpdateToggleButton.IsEnabled = true;
                DevelopersToggleButton.IsEnabled = true;
                ScanningToggleButton.IsEnabled = true;
            }
            catch (Exception exEvent_IsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_IsEnabledToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEvent_IsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
