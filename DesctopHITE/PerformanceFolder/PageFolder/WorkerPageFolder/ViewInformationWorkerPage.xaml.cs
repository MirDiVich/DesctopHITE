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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                if (workerTable != null)
                {
                    DataContext = workerTable;
                    dataContextWorker = workerTable;
                }
            }
            catch (Exception exViewInformationWorkerPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ViewInformationWorkerPage в ViewInformationWorkerPage:\n\n " +
                        $"{exViewInformationWorkerPage.Message}");
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
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ViewInformationWorkerPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region _Click
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());
            }
            catch (Exception exGoBackButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие GoBackButton_Click в NewWorkerPage:\n\n " +
                         $"{exGoBackButton_Click.Message}");
            }
        }

        #region Показать или скрыть Border
        private void PassportToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassportToggleButton.IsChecked == true)
            {
                PassportBorder.Visibility = Visibility.Visible;
                PassportToggleButton.ToolTip = "Скрыть паспорт";
            }
            else
            {
                PassportBorder.Visibility = Visibility.Collapsed;
                PassportToggleButton.ToolTip = "Показать паспорт";
            }
        }

        private void PlaceResidenceToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceResidenceToggleButton.IsChecked == true)
            {
                PlaceResidenceBorder.Visibility = Visibility.Visible;
                PlaceResidenceToggleButton.ToolTip = "Скрыть место жительства";
            }
            else
            {
                PlaceResidenceBorder.Visibility = Visibility.Collapsed;
                PlaceResidenceToggleButton.ToolTip = "Показать место жительства";
            }
        }

        private void MedicalBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalBookToggleButton.IsChecked == true)
            {
                MedicalBookBorder.Visibility = Visibility.Visible;
                MedicalBookToggleButton.ToolTip = "Скрыть медицинскую книжку";
            }
            else
            {
                MedicalBookBorder.Visibility = Visibility.Collapsed;
                MedicalBookToggleButton.ToolTip = "Показать медицинскую книжку";
            }
        }

        private void SnilsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SnilsToggleButton.IsChecked == true)
            {
                SnilsBorder.Visibility = Visibility.Visible;
                SnilsToggleButton.ToolTip = "Скрыть снилс";
            }
            else
            {
                SnilsBorder.Visibility = Visibility.Collapsed;
                SnilsToggleButton.ToolTip = "Показать снилс";
            }
        }

        private void INNToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (INNToggleButton.IsChecked == true)
            {
                INNBorder.Visibility = Visibility.Visible;
                INNToggleButton.ToolTip = "Скрыть инн";
            }
            else
            {
                INNBorder.Visibility = Visibility.Collapsed;
                INNToggleButton.ToolTip = "Показать инн";
            }
        }

        private void SalaryCardToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryCardToggleButton.IsChecked == true)
            {
                SalaryCardBorder.Visibility = Visibility.Visible;
                SalaryCardToggleButton.ToolTip = "Скрыть заработную карту";
            }
            else
            {
                SalaryCardBorder.Visibility = Visibility.Collapsed;
                SalaryCardToggleButton.ToolTip = "Показать заработную карту";
            }
        }

        private void GeneralDataToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (GeneralDataToggleButton.IsChecked == true)
            {
                GeneralDataBorder.Visibility = Visibility.Visible;
                GeneralDataToggleButton.ToolTip = "Скрыть основную информацию";
            }
            else
            {
                GeneralDataBorder.Visibility = Visibility.Collapsed;
                GeneralDataToggleButton.ToolTip = "Показать основную информацию";
            }
        }
        #endregion

        private void EditWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(dataContextWorker));
            }
            catch (Exception exEditWorkerButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EditWorkerButton_Click в ViewInformationWorkerPage:\n\n " +
                        $"{exEditWorkerButton_Click.Message}");
            }
        }
        #endregion
    }
}
