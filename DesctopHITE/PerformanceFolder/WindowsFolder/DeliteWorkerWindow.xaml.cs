///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код удаления выбранного сотрудника и взаимодействие с данным окном
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class DeliteWorkerWindow : Window
    {
        int personalNumberWorker = 0; // Переменная для дальнейших действий над сотрудником по его персональному номеру

        public DeliteWorkerWindow(WorkerTable workerTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                if (workerTable != null )
                {
                    DataContext = workerTable; // Присваиваю DataContext на данном окне переданное значение из workerTable
                    personalNumberWorker = workerTable.PersonalNumber_Worker; // Присваиваю переменной персональному номеру сотрудника, над которым и происходит действие

                    var addedWhomWorker = workerTable.AddpnWorker_Worker; // Получаю персональный номер сотрудника, который добавил сотрудника над которым происходит действие
                    var informationAddedWhomWorker = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(addedWhomWorker);

                    SNMAddedWhomWorkerTextBlock.Text =
                        $"{informationAddedWhomWorker.PassportTable.Surname_Passport} " +
                        $"{informationAddedWhomWorker.PassportTable.Name_Passport} " +
                        $"{informationAddedWhomWorker.PassportTable.Middlename_Passport}";

                    RoleAddedWhomWorkerTextBlock.Text =
                        $"({informationAddedWhomWorker.RoleTable.Name_Role})";
                }
            }
            catch (Exception ex)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие DeliteWorkerWindow в DeliteWorkerWindow:\n\n " +
                        $"{ex.Message}");
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception exSpaseBar)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие SpaseBarGrid_MouseDown в DeliteWorkerWindow:\n\n " +
                        $"{exSpaseBar.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception exClose)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие CloseButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exClose.Message}");
            }
        }
        #endregion
        #region _Click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                personalNumberWorker = 0;
            }
            catch (Exception exCancel)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие CancelButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exCancel.Message}");
            }
        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (personalNumberWorker == 0)
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E005",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    DeliteWorkerEvent();
                }
            }
            catch (Exception exDelite)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие DeliteButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exDelite.Message}");
            }
        }
        #endregion
        #region Event
        private void DeliteWorkerEvent() // Реализация удаления выбранного сотрудника
        {
            try
            {
                var informationDeliteWorker = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(personalNumberWorker);

                string SurnameNameWorker = $"{informationDeliteWorker.PassportTable.Surname_Passport} {informationDeliteWorker.PassportTable.Name_Passport}"; // Получаем Фамилия и Имя для уведомления
                string MessageTitle = $"Вы действительно хотите удалить: {SurnameNameWorker} ?";

                if (MessageBox.Show( MessageTitle, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var dataDelitWorker = AppConnectClass.connectDataBase_ACC;
                    dataDelitWorker.ImagePassportTable.Remove(informationDeliteWorker.PassportTable.ImagePassportTable);
                    dataDelitWorker.PlaceResidenceTable.Remove(informationDeliteWorker.PlaceResidenceTable);
                    dataDelitWorker.MedicalBookTable.Remove(informationDeliteWorker.MedicalBookTable);
                    dataDelitWorker.SalaryCardTable.Remove(informationDeliteWorker.SalaryCardTable);
                    dataDelitWorker.PassportTable.Remove(informationDeliteWorker.PassportTable);
                    dataDelitWorker.SnilsTable.Remove(informationDeliteWorker.SnilsTable);
                    dataDelitWorker.INNTable.Remove(informationDeliteWorker.INNTable);
                    dataDelitWorker.WorkerTable.Remove(informationDeliteWorker);

                    dataDelitWorker.SaveChanges();

                    string MessageTitleDelit = "Сотрудник " + SurnameNameWorker + " удалён";

                    MessageBox.Show(
                        MessageTitleDelit, "Удаление",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
            }
            catch (Exception exDeliteWorkerEvent)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие DeliteWorkerEvent в DeliteWorkerWindow:\n\n " +
                        $"{exDeliteWorkerEvent.Message}");
            }
        }
        #endregion
    }
}
