///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuUserPage : Page
    {
        public MenuUserPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MainToggleButton.IsChecked = true;
                MainToggleButton.IsEnabled = false;
                FrameNavigationClass.MainUser_FNC.Navigate(new MainPage());
            }
        }

        #region Click
        private void MainToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            MainToggleButton.IsChecked = true;
            MainToggleButton.IsEnabled = false;
            FrameNavigationClass.MainUser_FNC.Navigate(new MainPage());
        }
        private void WorkersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            WorkersToggleButton.IsChecked = true;
            WorkersToggleButton.IsEnabled = false;
            FrameNavigationClass.MainUser_FNC.Navigate(new WorkerPage());
        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //IsCheckedToggleButton();
            //IsEnabledToggleButton();
            //MenuToggleButton.IsChecked = true;
            //MenuToggleButton.IsEnabled = false;
        }
        private void SettingsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            SettingsToggleButton.IsChecked = true;
            SettingsToggleButton.IsEnabled = false;
            FrameNavigationClass.MainUser_FNC.Navigate(new SettingsPage());
        }
        #endregion
        #region Метод
        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            MainToggleButton.IsChecked = false;
            WorkersToggleButton.IsChecked = false;
            //MenuToggleButton.IsChecked = false;
            SettingsToggleButton.IsChecked = false;
        }
        private void IsEnabledToggleButton() // Включение кнопок
        {
            MainToggleButton.IsEnabled = true;
            WorkersToggleButton.IsEnabled = true;
            //MenuToggleButton.IsEnabled = true;
            SettingsToggleButton.IsEnabled = true;
        }
        #endregion
    }
}
