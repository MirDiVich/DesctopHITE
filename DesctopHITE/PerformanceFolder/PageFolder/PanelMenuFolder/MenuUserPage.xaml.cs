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
                AppConnectClass.DataBase = new DesctopHiteEntities();
                DataContext = AppConnectClass.GetUser;

                var DataUser = AppConnectClass.GetUser.PassportTable;
                SNMUsetTextBlock.Text = $"{DataUser.Surname_Passport} {DataUser.Name_Passport[0]}. {DataUser.Middlename_Passport[0]}.";
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие MenuUserPage в MenuUserPage:\n\n " +
                       $"{ex.Message}");
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    MainToggleButton.IsChecked = true;
                    MainToggleButton.IsEnabled = false;
                    FrameNavigationClass.MainUser_FNC.Navigate(new MainPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuUserPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Click
        private void MainToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                MainToggleButton.IsChecked = true;
                MainToggleButton.IsEnabled = false;
                FrameNavigationClass.MainUser_FNC.Navigate(new MainPage());
            }
            catch (Exception exMainToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие MainToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exMainToggleButton_Click.Message}");
            }
        }
        private void WorkersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                WorkersToggleButton.IsChecked = true;
                WorkersToggleButton.IsEnabled = false;
                FrameNavigationClass.MainUser_FNC.Navigate(new WorkerPage());
            }
            catch (Exception exWorkersToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие WorkersToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exWorkersToggleButton_Click.Message}");
            }
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                MenuToggleButton.IsChecked = true;
                MenuToggleButton.IsEnabled = false;
            }
            catch (Exception exMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие MenuToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exMenuToggleButton_Click.Message}");
            }
        }
        private void SettingsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                SettingsToggleButton.IsChecked = true;
                SettingsToggleButton.IsEnabled = false;
                FrameNavigationClass.MainUser_FNC.Navigate(new SettingsPage());
            }
            catch (Exception exSettingsToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие SettingsToggleButton_Click в MenuUserPage:\n\n " +
                       $"{exSettingsToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Метод
        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                MainToggleButton.IsChecked = false;
                WorkersToggleButton.IsChecked = false;
                MenuToggleButton.IsChecked = false;
                SettingsToggleButton.IsChecked = false;
            }
            catch (Exception exIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие IsCheckedToggleButton в MenuUserPage:\n\n " +
                       $"{exIsCheckedToggleButton.Message}");
            }
        }
        private void IsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                MainToggleButton.IsEnabled = true;
                WorkersToggleButton.IsEnabled = true;
                MenuToggleButton.IsEnabled = true;
                SettingsToggleButton.IsEnabled = true;
            }
            catch (Exception exIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие IsEnabledToggleButton в MenuUserPage:\n\n " +
                       $"{exIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
