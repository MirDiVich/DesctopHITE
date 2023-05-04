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
                FrameNavigationClass.MunuSettings_FNC = MenuSettingsFrame;
                FrameNavigationClass.BodySettings_FNC = BodySettingsFrame;
            }
            catch (Exception ex) 
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие SettingsPage в SettingsPage:\n\n " +
                      $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.MunuSettings_FNC.Navigate(new MenuSettingsPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие Page_IsVisibleChanged в SettingsPage:\n\n " +
                      $"{exPage_IsVisibleChanged.Message}");
            }
        }
    }
}
