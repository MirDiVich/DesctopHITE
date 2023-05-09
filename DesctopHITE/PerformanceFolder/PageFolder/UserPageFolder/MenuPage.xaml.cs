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
                FrameNavigationClass.MunuMenu_FNC = MenuMenuFrame;
                FrameNavigationClass.BodyMenu_FNC = BodyMenuFrame;
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие MenuPage в MenuPage:\n\n " +
                      $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.MunuMenu_FNC.Navigate(new MenuMenuPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие Page_IsVisibleChanged в MenuPage:\n\n " +
                      $"{exPage_IsVisibleChanged.Message}");
            }
        }
    }
}
