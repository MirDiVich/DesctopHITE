///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для просмотра полной информации о сотруднике;
/// Если пользователь захочет изменить какую либо информацию о пользователе, то он может
///     сделать это просто нажав по кнопке "Редактировать".
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class ViewInformationWorkerPage : Page
    {
        public WorkerTable dataContextWorker;

        public ViewInformationWorkerPage(WorkerTable workerTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();

                if (workerTable != null)
                {
                    DataContext = workerTable;
                    dataContextWorker = workerTable;
                }
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие ViewInformationWorkerPage в ViewInformationWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    PassportToggleButton.IsChecked = true;
                    PassportBorder.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие Page_IsVisibleChanged в ViewInformationWorkerPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region Click
        // Так как код очень простой и короткий, было принято решение написать его в "длину"
        private void PassportToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassportToggleButton.IsChecked == true) { PassportBorder.Visibility = Visibility.Visible; }
            else { PassportBorder.Visibility = Visibility.Collapsed; }
        }

        private void PlaceResidenceToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceResidenceToggleButton.IsChecked == true) { PlaceResidenceBorder.Visibility = Visibility.Visible; }
            else { PlaceResidenceBorder.Visibility = Visibility.Collapsed; }
        }

        private void MedicalBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalBookToggleButton.IsChecked == true) { MedicalBookBorder.Visibility = Visibility.Visible; }
            else { MedicalBookBorder.Visibility = Visibility.Collapsed; }
        }

        private void SnilsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SnilsToggleButton.IsChecked == true) { SnilsBorder.Visibility = Visibility.Visible; }
            else { SnilsBorder.Visibility = Visibility.Collapsed; }
        }

        private void INNToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (INNToggleButton.IsChecked == true) { INNBorder.Visibility = Visibility.Visible; }
            else { INNBorder.Visibility = Visibility.Collapsed; }
        }

        private void SalaryCardToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryCardToggleButton.IsChecked == true) { SalaryCardBorder.Visibility = Visibility.Visible; }
            else { SalaryCardBorder.Visibility = Visibility.Collapsed; }
        }

        private void GeneralDataToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (GeneralDataToggleButton.IsChecked == true) { GeneralDataBorder.Visibility = Visibility.Visible; }
            else { GeneralDataBorder.Visibility = Visibility.Collapsed; }
        }

        private void EditWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.ViewEditInformationWorker_FNC.Navigate(new NewWorkerPage(dataContextWorker));
            }
            catch (Exception exEditWorkerButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие EditWorkerButton_Click в ViewInformationWorkerPage:\n\n " +
                        $"{exEditWorkerButton_Click.Message}");
            }
        }
        #endregion
    }
}
