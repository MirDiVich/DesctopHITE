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
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuWorkerPage : Page
    {
        public MenuWorkerPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                NewWorkerToggleButton.IsChecked = true;
                NewWorkerToggleButton.IsEnabled = false;
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(null));
            }
        }
        #region Click
        private void NewWorkerToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            NewWorkerToggleButton.IsChecked = true;
            NewWorkerToggleButton.IsEnabled = false;
            FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(null));
        }

        private void ListWorkweToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            ListWorkweToggleButton.IsChecked = true;
            ListWorkweToggleButton.IsEnabled = false;
            FrameNavigationClass.BodyWorker_FNC.Navigate(new ListWorkerPage());
        }

        private void GeneralInformationWorkerToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsCheckedToggleButton();
            IsEnabledToggleButton();
            GeneralInformationWorkerToggleButton.IsChecked = true;
            GeneralInformationWorkerToggleButton.IsEnabled = false;
            FrameNavigationClass.BodyWorker_FNC.Navigate(new GeneralInformationWorkerPage());
        }
        #endregion
        #region Действие
        private void IsCheckedToggleButton()
        {
            NewWorkerToggleButton.IsChecked = false;
            ListWorkweToggleButton.IsChecked = false;
            GeneralInformationWorkerToggleButton.IsChecked = false;
        }
        private void IsEnabledToggleButton()
        {
            NewWorkerToggleButton.IsEnabled = true;
            ListWorkweToggleButton.IsEnabled = true;
            GeneralInformationWorkerToggleButton.IsEnabled = true;
        }
        #endregion
    }
}
