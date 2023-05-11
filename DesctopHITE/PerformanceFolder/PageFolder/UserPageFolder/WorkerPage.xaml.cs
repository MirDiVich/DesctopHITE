///----------------------------------------------------------------------------------------------------------
/// Просто страница - пустышка с 2 "Frame", для вывода в них:
///     1. Страница с меню;
///     2. Основные страницы, которые переключаются при помощи меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            try
            {
                InitializeComponent();
                FrameNavigationClass.munuWorker_FNC = MenuWorkerFrame;
                FrameNavigationClass.bodyWorker_FNC = BodyWorkerFrame;
            }
            catch (Exception ex) 
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                      textMessage: $"Событие WorkerPage в WorkerPage:\n\n " +
                      $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.munuWorker_FNC.Navigate(new MenuWorkerPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                      textMessage: $"Событие Page_IsVisibleChanged в WorkerPage:\n\n " +
                      $"{exPage_IsVisibleChanged.Message}");
            }
        }
    }
}
