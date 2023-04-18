///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для работы меню
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
using System.Windows;
using System.Windows.Controls;

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
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(null));

                NewWorkerToggleButton.IsChecked = true;
                NewWorkerToggleButton.IsEnabled = false;
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
        #region Метод

        private void IsCheckedToggleButton() // Отключение проверки кнопок
        {
            NewWorkerToggleButton.IsChecked = false;
            ListWorkweToggleButton.IsChecked = false;
            GeneralInformationWorkerToggleButton.IsChecked = false;
        }

        private void IsEnabledToggleButton() // Отключение кнопок
        {
            NewWorkerToggleButton.IsEnabled = true;
            ListWorkweToggleButton.IsEnabled = true;
            GeneralInformationWorkerToggleButton.IsEnabled = true;
        }

        #endregion
    }
}
