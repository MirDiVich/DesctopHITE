///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMenuMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие MenuMenuPage в MenuMenuPage:\n\n " +
                      $"{exMenuMenuPage.Message}");
            }
        }

        private void IngridientsMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    EventIsCheckedToggleButton();
                    EventIsEnabledToggleButton();

                    IngridientsMenuToggleButton.IsChecked = true;
                    IngridientsMenuToggleButton.IsEnabled = false;

                    FrameNavigationClass.bodyMenu_FNC.Navigate(new ListIngridientPage());
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие IngridientsMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    EventIsCheckedToggleButton();
                    EventIsEnabledToggleButton();

                    NewMenuToggleButton.IsChecked = true;
                    NewMenuToggleButton.IsEnabled = false;

                    FrameNavigationClass.bodyMenu_FNC.Navigate(new NewMenuPage(null));
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Page_IsVisibleChanged в MenuMenuPage:\n\n " +
                       $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region _Click
        private void NewMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();

                NewMenuToggleButton.IsChecked = true;
                NewMenuToggleButton.IsEnabled = false;

                FrameNavigationClass.bodyMenu_FNC.Navigate(new NewMenuPage(null));
            }
            catch (Exception exNewMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие NewMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exNewMenuToggleButton_Click.Message}");
            }
        }

        private void ListMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();

                ListMenuToggleButton.IsChecked = true;
                ListMenuToggleButton.IsEnabled = false;

                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListMenuPage());
            }
            catch (Exception exListMenuToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие ListMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exListMenuToggleButton.Message}");
            }
        }

        private void GeneralInformationToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();

                GeneralInformationToggleButton.IsChecked = true;
                GeneralInformationToggleButton.IsEnabled = false;

                //FrameNavigationClass.bodyMenu_FNC.Navigate(new ());
            }
            catch (Exception exGeneralInformationToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие GeneralInformationToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exGeneralInformationToggleButton_Click.Message}");
            }
        }
        #endregion
        #region Event
        private void EventIsCheckedToggleButton() // Отключение проверки кнопок
        {
            try
            {
                NewMenuToggleButton.IsChecked = false;
                ListMenuToggleButton.IsChecked = false;
                GeneralInformationToggleButton.IsChecked = false;
                IngridientsMenuToggleButton.IsChecked = false;
            }
            catch (Exception exEventIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsCheckedToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEventIsCheckedToggleButton.Message}");
            }
        }
        private void EventIsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                NewMenuToggleButton.IsEnabled = true;
                ListMenuToggleButton.IsEnabled = true;
                GeneralInformationToggleButton.IsEnabled = true;
                IngridientsMenuToggleButton.IsEnabled = true;
            }
            catch (Exception exEventIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsEnabledToggleButton в MenuSettingsPage:\n\n " +
                       $"{exEventIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
