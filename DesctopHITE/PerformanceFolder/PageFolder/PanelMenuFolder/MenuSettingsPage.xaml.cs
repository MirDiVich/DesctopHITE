using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.SettingsBodyFolder;

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
            AboutTheAppToggleButton.IsChecked = true;
            AboutTheAppToggleButton.IsEnabled = false;
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

        private void TestToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            TestToggleButton.IsChecked = true;
            TestToggleButton.IsEnabled = false;
        }
        #endregion
        #region Действие
        private void IsCheckedToggleButton()
        {
            AboutTheAppToggleButton.IsChecked = false;
            UpdateToggleButton.IsChecked = false;
            DevelopersToggleButton.IsChecked = false;
            TestToggleButton.IsChecked = false;
        }
        private void IsEnabledToggleButton()
        {
            AboutTheAppToggleButton.IsEnabled = true;
            UpdateToggleButton.IsEnabled = true;
            DevelopersToggleButton.IsEnabled = true;
            TestToggleButton.IsEnabled = true;
        }
        #endregion
    }
}
