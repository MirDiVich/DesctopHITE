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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU001 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU002 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion

        int personalNumberWorker = 0; // Переменная для дальнейших действий над сотрудником по его персональному номеру

        public DeliteWorkerWindow(WorkerTabe workerTabe)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();

                if (workerTabe != null )
                {
                    DataContext = workerTabe; // Присваиваю DataContext на данном окне переданное значение из workerTabe
                    personalNumberWorker = workerTabe.PersonalNumber_Worker; // Присваиваю переменной персональному номеру сотрудника, над которым и происходит действие

                    var addedWhomWorker = workerTabe.AddpnWorker_Worker; // Получаю персональный номер сотрудника, который добавил сотрудника над которым происходит действие
                    var informationAddedWhomWorker = AppConnectClass.DataBase.WorkerTabe.Find(addedWhomWorker);

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
                MessageBox.Show(
                    ex.Message, "Ошибка (NewWorkerPage - E-001)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region Click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
                personalNumberWorker = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU002 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e)
        {
            if (personalNumberWorker == 0)
            {
                MessageBox.Show(
                    "Сотрудник не выбран", "Ошибка - E002",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DeliteWorkerMethod();
            }
        }
        #endregion
        #region Метод
        private void DeliteWorkerMethod() // Реализация удаления выбранного сотрудника
        {
            try
            {
                var informationDeliteWorker = AppConnectClass.DataBase.WorkerTabe.Find(personalNumberWorker);

                string SurnameNameWorker = $"{informationDeliteWorker.PassportTable.Surname_Passport} {informationDeliteWorker.PassportTable.Name_Passport}"; // Получаем Фамилия и Имя для уведомления
                string MessageTitle = $"Вы действительно хотите удалить: {SurnameNameWorker} ?";

                if (MessageBox.Show(
                    MessageTitle, "Удаление",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    AppConnectClass.DataBase.ImagePassportTable.Remove(informationDeliteWorker.PassportTable.ImagePassportTable);
                    AppConnectClass.DataBase.PlaceResidenceTable.Remove(informationDeliteWorker.PlaceResidenceTable);
                    AppConnectClass.DataBase.MedicalBookTable.Remove(informationDeliteWorker.MedicalBookTable);
                    AppConnectClass.DataBase.SalaryCardTable.Remove(informationDeliteWorker.SalaryCardTable);
                    AppConnectClass.DataBase.PassportTable.Remove(informationDeliteWorker.PassportTable);
                    AppConnectClass.DataBase.SnilsTable.Remove(informationDeliteWorker.SnilsTable);
                    AppConnectClass.DataBase.INNTable.Remove(informationDeliteWorker.INNTable);
                    AppConnectClass.DataBase.WorkerTabe.Remove(informationDeliteWorker);

                    AppConnectClass.DataBase.SaveChanges();

                    string MessageTitleDelit = "Сотрудник " + SurnameNameWorker + " удалён";

                    MessageBox.Show(
                        MessageTitleDelit, "Удаление",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(
                    Ex.Message.ToString(), "Ошибка - E003",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
