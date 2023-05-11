///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuMenuPage : Page
    {
        public MenuMenuPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                      textMessage: $"Событие MenuMenuPage в MenuMenuPage:\n\n " +
                      $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    NewMenuToggleButton.IsChecked = true;
                    NewMenuToggleButton.IsEnabled = false;
                    FrameNavigationClass.BodyMenu_FNC.Navigate(new NewMenuPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuMenuPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Clicl
        private void NewMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                NewMenuToggleButton.IsChecked = true;
                NewMenuToggleButton.IsEnabled = false;
                FrameNavigationClass.BodyMenu_FNC.Navigate(new NewMenuPage());
            }
            catch (Exception exNewMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие NewMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exNewMenuToggleButton_Click.Message}");
            }
        }

        private void ListMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                ListMenuToggleButton.IsChecked = true;
                ListMenuToggleButton.IsEnabled = false;
                FrameNavigationClass.BodyMenu_FNC.Navigate(new ListMenuPage());
            }
            catch (Exception exListMenuToggleButton)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие ListMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exListMenuToggleButton.Message}");
            }
        }

        private void GeneralInformationToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsCheckedToggleButton();
                IsEnabledToggleButton();
                GeneralInformationToggleButton.IsChecked = true;
                GeneralInformationToggleButton.IsEnabled = false;
                //FrameNavigationClass.BodyMenu_FNC.Navigate(new ());
            }
            catch (Exception exGeneralInformationToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие GeneralInformationToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exGeneralInformationToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Метод
        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                NewMenuToggleButton.IsChecked = false;
                ListMenuToggleButton.IsChecked = false;
                GeneralInformationToggleButton.IsChecked = false;
            }
            catch (Exception exIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие IsCheckedToggleButton в MenuSettingsPage:\n\n " +
                       $"{exIsCheckedToggleButton.Message}");
            }
        }
        private void IsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                NewMenuToggleButton.IsEnabled = true;
                ListMenuToggleButton.IsEnabled = true;
                GeneralInformationToggleButton.IsEnabled = true;
            }
            catch (Exception exIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие IsEnabledToggleButton в MenuSettingsPage:\n\n " +
                       $"{exIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
