///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuSettingsPage : Page
    {
        public MenuSettingsPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                AboutTheAppToggleButton.IsChecked = true;
                AboutTheAppToggleButton.IsEnabled = false;
            }
        }
        #region Click
        private void AboutTheAppToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            AboutTheAppToggleButton.IsChecked = true;
            AboutTheAppToggleButton.IsEnabled = false;
        }

        private void UpdateToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            UpdateToggleButton.IsChecked = true;
            UpdateToggleButton.IsEnabled = false;
        }

        private void DevelopersToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            DevelopersToggleButton.IsChecked = true;
            DevelopersToggleButton.IsEnabled = false;
            FrameNavigationClass.BodySettings_FNC.Navigate(new DevelopersPage());
        }

        private void ScanningToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            ScanningToggleButton.IsChecked = true;
            ScanningToggleButton.IsEnabled = false;
            FrameNavigationClass.BodySettings_FNC.Navigate(new ScanningPage());
        }
        #endregion
        #region Метод
        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            AboutTheAppToggleButton.IsChecked = false;
            UpdateToggleButton.IsChecked = false;
            DevelopersToggleButton.IsChecked = false;
            ScanningToggleButton.IsChecked = false;
        }
        private void IsEnabledToggleButton() // Включение кнопок
        {
            AboutTheAppToggleButton.IsEnabled = true;
            UpdateToggleButton.IsEnabled = true;
            DevelopersToggleButton.IsEnabled = true;
            ScanningToggleButton.IsEnabled = true;
        }
        #endregion
    }
}
