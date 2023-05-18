///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuUserPage : Page
    {
        public MenuUserPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMenuUserPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие MenuUserPage в MenuUserPage:\n\n " +
                       $"{exMenuUserPage.Message}");
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                try
                {
                    var dataUser = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(AppConnectClass.receiveConnectUser_ACC);

                    DataContext = dataUser;

                    SNMUsetTextBlock.Text = 
                        $"{dataUser.PassportTable.Surname_Passport} " +
                        $"{dataUser.PassportTable.Name_Passport[0]}. " +
                        $"{dataUser.PassportTable.Middlename_Passport[0]}.";

                    MainToggleButton.IsChecked = true;
                    MainToggleButton.IsEnabled = false;
                    FrameNavigationClass.mainUser_FNC.Navigate(new MainPage());
                }
                catch (Exception exPage_IsVisibleChanged)
                {
                    MessageBoxClass.ExceptionMessageBox_MBC(
                           textMessage: $"Событие Page_IsVisibleChanged в MenuUserPage:\n\n " +
                           $"{exPage_IsVisibleChanged.Message}");
                }
            }
        }

        #region _Click
        private void MainToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                MainToggleButton.IsChecked = true;
                MainToggleButton.IsEnabled = false;
                FrameNavigationClass.mainUser_FNC.Navigate(new MainPage());
            }
            catch (Exception exMainToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие MainToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exMainToggleButton_Click.Message}");
            }
        }
        private void WorkersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                WorkersToggleButton.IsChecked = true;
                WorkersToggleButton.IsEnabled = false;
                FrameNavigationClass.mainUser_FNC.Navigate(new WorkerPage());
            }
            catch (Exception exWorkersToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие WorkersToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exWorkersToggleButton_Click.Message}");
            }
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                MenuToggleButton.IsChecked = true;
                MenuToggleButton.IsEnabled = false;
                FrameNavigationClass.mainUser_FNC.Navigate(new MenuPage());
            }
            catch (Exception exMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие MenuToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exMenuToggleButton_Click.Message}");
            }
        }
        private void SettingsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();
                SettingsToggleButton.IsChecked = true;
                SettingsToggleButton.IsEnabled = false;
                FrameNavigationClass.mainUser_FNC.Navigate(new SettingsPage());
            }
            catch (Exception exSettingsToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие SettingsToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exSettingsToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void EventIsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                MainToggleButton.IsChecked = false;
                WorkersToggleButton.IsChecked = false;
                MenuToggleButton.IsChecked = false;
                SettingsToggleButton.IsChecked = false;
            }
            catch (Exception exEventIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsCheckedToggleButton в MenuUserPage:\n\n " +
                       $"{exEventIsCheckedToggleButton.Message}");
            }
        }
        private void EventIsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                MainToggleButton.IsEnabled = true;
                WorkersToggleButton.IsEnabled = true;
                MenuToggleButton.IsEnabled = true;
                SettingsToggleButton.IsEnabled = true;
            }
            catch (Exception exEventIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsEnabledToggleButton в MenuUserPage:\n\n " +
                       $"{exEventIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
