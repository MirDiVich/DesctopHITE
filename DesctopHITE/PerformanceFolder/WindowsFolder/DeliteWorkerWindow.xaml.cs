//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном окне реализован код удаления выбранного сотрудника и взаимодействие с данным окном
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

                    RoleAddedWhomWorkerTextBlock.Text = $"({informationAddedWhomWorker.RoleTable.Name_Role})";
                }
            }
            catch (Exception exDeliteWorkerWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DeliteWorkerWindow в DeliteWorkerWindow:\n\n " +
                        $"{exDeliteWorkerWindow.Message}");
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
            }
            catch (Exception exSpaseBarGrid_MouseDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие SpaseBarGrid_MouseDown в DeliteWorkerWindow:\n\n " +
                        $"{exSpaseBarGrid_MouseDown.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try { this.Close(); }
            catch (Exception exCloseButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CloseButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exCloseButton_Click.Message}");
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
            catch (Exception exCancelButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CancelButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exCancelButton_Click.Message}");
            }
        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (personalNumberWorker == 0)
                {
                    MessageBoxClass.FailureMessageBox_MBC( textMessage: "Сотрудник не выбран");
                }
                else { Event_DeliteWorker(); }
            }
            catch (Exception exDeliteButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DeliteButton_Click в DeliteWorkerWindow:\n\n " +
                        $"{exDeliteButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
        private void Event_DeliteWorker() // Реализация удаления выбранного сотрудника
        {
            try
            {
                var informationDeliteWorker = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(personalNumberWorker);

                string SurnameNameWorker = $"{informationDeliteWorker.PassportTable.Surname_Passport} {informationDeliteWorker.PassportTable.Name_Passport}"; // Получаем Фамилия и Имя для уведомления
                string MessageTitle = $"Вы действительно хотите удалить: {SurnameNameWorker} ?";

                if (MessageBox.Show( MessageTitle, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var dataDelitWorker = AppConnectClass.connectDataBase_ACC;

                    // Удаление данных о сотруднике
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
                    MessageBoxClass.GoodMessageBox_MBC(textMessage: MessageTitleDelit);

                    this.Close();
                }
            }
            catch (Exception exDeliteWorkerEvent_)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DeliteWorkerEvent_ в DeliteWorkerWindow:\n\n " +
                        $"{exDeliteWorkerEvent_.Message}");
            }
        }
        #endregion
    }
}
