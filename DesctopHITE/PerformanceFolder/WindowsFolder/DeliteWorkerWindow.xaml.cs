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
                AppConnectClass.DataBase = new DesctopHiteEntities();

                if (workerTable != null )
                {
                    DataContext = workerTable; // Присваиваю DataContext на данном окне переданное значение из workerTable
                    personalNumberWorker = workerTable.PersonalNumber_Worker; // Присваиваю переменной персональному номеру сотрудника, над которым и происходит действие

                    var addedWhomWorker = workerTable.AddpnWorker_Worker; // Получаю персональный номер сотрудника, который добавил сотрудника над которым происходит действие
                    var informationAddedWhomWorker = AppConnectClass.DataBase.WorkerTable.Find(addedWhomWorker);

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
                var nameMessageOne = $"Ошибка (DeliteWorkerWindowError - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageSpaseBar = $"Ошибка (DeliteWorkerWindowError - 002)";
                var titleMessageSpaseBar = $"{exSpaseBar.Message}";
                MessageBox.Show(
                    nameMessageSpaseBar, titleMessageSpaseBar,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageClose = $"Ошибка (DeliteWorkerWindowError - 003)";
                var titleMessageClose = $"{exClose.Message}";
                MessageBox.Show(
                    nameMessageClose, titleMessageClose,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                personalNumberWorker = 0;
            }
            catch (Exception exCancel)
            {
                var nameMessageCancel = $"Ошибка (DeliteWorkerWindowError - 004)";
                var titleMessageCancel = $"{exCancel.Message}";
                MessageBox.Show(
                    nameMessageCancel, titleMessageCancel,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                    DeliteWorkerMethod();
                }
            }
            catch (Exception exDelite)
            {
                var nameMessageDelite = $"Ошибка (DeliteWorkerWindowError - 006)";
                var titleMessageDelite = $"{exDelite.Message}";
                MessageBox.Show(
                    nameMessageDelite, titleMessageDelite,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Метод
        private void DeliteWorkerMethod() // Реализация удаления выбранного сотрудника
        {
            try
            {
                var informationDeliteWorker = AppConnectClass.DataBase.WorkerTable.Find(personalNumberWorker);

                string SurnameNameWorker = $"{informationDeliteWorker.PassportTable.Surname_Passport} {informationDeliteWorker.PassportTable.Name_Passport}"; // Получаем Фамилия и Имя для уведомления
                string MessageTitle = $"Вы действительно хотите удалить: {SurnameNameWorker} ?";

                if (MessageBox.Show( MessageTitle, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var dataDelitWorker = AppConnectClass.DataBase;
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
            catch (Exception exDeliteWorkerMethod)
            {
                var nameMessageDeliteWorkerMethod = $"Ошибка (DeliteWorkerWindowError - 007)";
                var titleMessageDeliteWorkerMethod = $"{exDeliteWorkerMethod.Message}";
                MessageBox.Show(
                    nameMessageDeliteWorkerMethod, titleMessageDeliteWorkerMethod,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
