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
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            try
            {
                InitializeComponent();
                FrameNavigationClass.munuMenu_FNC = MenuMenuFrame;
                FrameNavigationClass.bodyMenu_FNC = BodyMenuFrame;
            }
            catch (Exception exMenuPage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                      textMessage: $"Событие MenuPage в MenuPage:\n\n " +
                      $"{exMenuPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.munuMenu_FNC.Navigate(new MenuMenuPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                      textMessage: $"Событие Page_IsVisibleChanged в MenuPage:\n\n " +
                      $"{exPage_IsVisibleChanged.Message}");
            }
        }
    }
}
