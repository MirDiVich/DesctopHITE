///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMenuWorkerPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
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
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());

                    Event_IsCheckedToggleButton();
                    Event_IsEnabledToggleButton();

                    ListWorkweToggleButton.IsChecked = true;
                    ListWorkweToggleButton.IsEnabled = false;
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuWorkerPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region _Click
        private void ListWorkweToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

                ListWorkweToggleButton.IsChecked = true;
                ListWorkweToggleButton.IsEnabled = false;

                FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());
            }
            catch (Exception exListWorkweToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие ListWorkweToggleButton_Click в MenuWorkerPage:\n\n " +
                       $"{exListWorkweToggleButton_Click.Message}");
            }
        }

        private void GeneralInformationWorkerToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Event_IsCheckedToggleButton();
                Event_IsEnabledToggleButton();

                GeneralInformationWorkerToggleButton.IsChecked = true;
                GeneralInformationWorkerToggleButton.IsEnabled = false;

                FrameNavigationClass.bodyWorker_FNC.Navigate(new GeneralInformationWorkerPage());
            }
            catch (Exception exGeneralInformationWorkerToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие GeneralInformationWorkerToggleButton_Click в MenuWorkerPage:\n\n " +
                       $"{exGeneralInformationWorkerToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
        private void Event_IsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                ListWorkweToggleButton.IsChecked = false;
                GeneralInformationWorkerToggleButton.IsChecked = false;
            }
            catch (Exception exEvent_IsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_IsCheckedToggleButton в MenuWorkerPage:\n\n " +
                       $"{exEvent_IsCheckedToggleButton.Message}");
            }
        }

        private void Event_IsEnabledToggleButton() // Отключение кнопок
        {
            try
            {
                ListWorkweToggleButton.IsEnabled = true;
                GeneralInformationWorkerToggleButton.IsEnabled = true;
            }
            catch (Exception exEvent_IsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_IsEnabledToggleButton в MenuWorkerPage:\n\n " +
                       $"{exEvent_IsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
