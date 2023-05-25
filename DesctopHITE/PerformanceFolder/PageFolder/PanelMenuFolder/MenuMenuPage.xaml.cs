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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    EventIsCheckedToggleButton();
                    EventIsEnabledToggleButton();

                    ListMenuToggleButton.IsChecked = true;
                    ListMenuToggleButton.IsEnabled = false;

                    FrameNavigationClass.bodyMenu_FNC.Navigate(new ListMenuPage());
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
            catch (Exception exListMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие ListMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exListMenuToggleButton_Click.Message}");
            }
        }

        private void IngridientsMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();

                IngridientsMenuToggleButton.IsChecked = true;
                IngridientsMenuToggleButton.IsEnabled = false;

                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListIngridientPage());
            }
            catch (Exception exIngridientsMenuToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие IngridientsMenuToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exIngridientsMenuToggleButton_Click.Message}");
            }
        }

        private void CategoryMenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventIsCheckedToggleButton();
                EventIsEnabledToggleButton();

                CategoryMenuToggleButton.IsChecked = true;
                CategoryMenuToggleButton.IsEnabled = false;

               FrameNavigationClass.bodyMenu_FNC.Navigate(new ListCategoryPage());
            }
            catch (Exception exGeneralInformationToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие GeneralInformationToggleButton_Click в MenuMenuPage:\n\n " +
                       $"{exGeneralInformationToggleButton_Click.Message}");
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

                FrameNavigationClass.bodyMenu_FNC.Navigate(new GeneralInformationMenuPage());
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
                ListMenuToggleButton.IsChecked = false;
                IngridientsMenuToggleButton.IsChecked = false;
                CategoryMenuToggleButton.IsChecked = false;
                GeneralInformationToggleButton.IsChecked = false;
            }
            catch (Exception exEventIsCheckedToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsCheckedToggleButton в MenuMenuPage:\n\n " +
                       $"{exEventIsCheckedToggleButton.Message}");
            }
        }
        private void EventIsEnabledToggleButton() // Включение кнопок
        {
            try
            {
                ListMenuToggleButton.IsEnabled = true;
                IngridientsMenuToggleButton.IsEnabled = true;
                CategoryMenuToggleButton.IsEnabled = true;
                GeneralInformationToggleButton.IsEnabled = true;
            }
            catch (Exception exEventIsEnabledToggleButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие EventIsEnabledToggleButton в MenuMenuPage:\n\n " +
                       $"{exEventIsEnabledToggleButton.Message}");
            }
        }
        #endregion
    }
}
