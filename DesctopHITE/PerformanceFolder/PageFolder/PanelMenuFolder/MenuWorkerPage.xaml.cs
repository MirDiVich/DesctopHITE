///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuWorkerPage : Page
    {
        public MenuWorkerPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exMenuWorkerPage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие MenuWorkerPage в MenuWorkerPage:\n\n " +
                       $"{exMenuWorkerPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(null));

                    NewWorkerToggleButton.IsChecked = true;
                    NewWorkerToggleButton.IsEnabled = false;
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuWorkerPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region _Click
        private void NewWorkerToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                NewWorkerToggleButton.IsChecked = true;
                NewWorkerToggleButton.IsEnabled = false;
                FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(null));
            }
            catch (Exception exNewWorkerToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие NewWorkerToggleButton_Click в MenuWorkerPage:\n\n " +
                       $"{exNewWorkerToggleButton_Click.Message}");
            }
        }

        private void ListWorkweToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                ListWorkweToggleButton.IsChecked = true;
                ListWorkweToggleButton.IsEnabled = false;
                FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());
            }
            catch (Exception exListWorkweToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие ListWorkweToggleButton_Click в MenuWorkerPage:\n\n " +
                       $"{exListWorkweToggleButton_Click.Message}");
            }
        }

        private void GeneralInformationWorkerToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                GeneralInformationWorkerToggleButton.IsChecked = true;
                GeneralInformationWorkerToggleButton.IsEnabled = false;
                FrameNavigationClass.bodyWorker_FNC.Navigate(new GeneralInformationWorkerPage());
            }
            catch (Exception exGeneralInformationWorkerToggleButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие GeneralInformationWorkerToggleButton_Click в MenuWorkerPage:\n\n " +
                       $"{exGeneralInformationWorkerToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void EventIsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                NewWorkerToggleButton.IsChecked = false;
                ListWorkweToggleButton.IsChecked = false;
                GeneralInformationWorkerToggleButton.IsChecked = false;
            }
            catch (Exception exEventIsCheckedToggleButton)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие EventIsCheckedToggleButton в MenuWorkerPage:\n\n " +
                       $"{exEventIsCheckedToggleButton.Message}");
            }
        }

        private void EventIsEnabledToggleButton() // Отключение кнопок
        {
            try
            {
                NewWorkerToggleButton.IsEnabled = true;
                ListWorkweToggleButton.IsEnabled = true;
                GeneralInformationWorkerToggleButton.IsEnabled = true;
            }
            catch (Exception exEventIsEnabledToggleButton)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие IsEventEnabledToggleButton в MenuWorkerPage:\n\n " +
                       $"{exEventIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
