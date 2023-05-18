///----------------------------------------------------------------------------------------------------------
/// 
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            try
            {
                InitializeComponent();

                FrameNavigationClass.munuSettings_FNC = MenuSettingsFrame;
                FrameNavigationClass.bodySettings_FNC = BodySettingsFrame;
            }
            catch (Exception exSettingsPage) 
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие SettingsPage в SettingsPage:\n\n " +
                      $"{exSettingsPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.munuSettings_FNC.Navigate(new MenuSettingsPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие Page_IsVisibleChanged в SettingsPage:\n\n " +
                      $"{exPage_IsVisibleChanged.Message}");
            }
        }
    }
}
