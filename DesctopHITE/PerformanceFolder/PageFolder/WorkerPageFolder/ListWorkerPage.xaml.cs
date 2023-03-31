using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class ListWorkerPage : Page
    {
        WorkerTabe DataContextWorker;
        public ListWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities(); // Подключил базу данных к этой странице
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) //Если страница видна
            {
                EditButton.IsEnabled = false;
                DeliteButton.IsEnabled = false;

                ListWorkerListView.ItemsSource = AppConnectClass.DataBase.WorkerTabe.ToList();
                ListWorkerListView.Items.SortDescriptions.Add(new SortDescription("PassportTable.Surname_Passport", ListSortDirection.Ascending)); // Сортируем выведённую информацию в элементе "ListWorkwrListView" в алфовитном порядке (Сортировка происходит по атрибуту "SurnameWorker");
            }
        }
        #region Click
        private void EditButton_Click(object sender, RoutedEventArgs e) // Открытия страницы для возможности редактирования информации об сотруднике
        {
            if (DataContextWorker == null)
            {
                MessageBox.Show(
                    "Сотрудник не выбран", "Ошибка - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(DataContextWorker));
            }
        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e) // Реализация удаления сотрудника
        {
            DeliteWorkerMethod();
        }
        #endregion
        #region Действие
        private void DeliteWorkerMethod()
        {
            if (DataContextWorker == null)
            {
                // Перед удалением проверяем, что сотрудник выбран
                MessageBox.Show(
                    "Сотрудник не выбран", "Ошибка - E002",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try // помешаем рабочий код в "безопасную каробку"
                {
                    string SurnameNameWorker = DataContextWorker.PassportTable.Surname_Passport + " " + DataContextWorker.PassportTable.Name_Passport; ; // Получаем Фамилия и Имя для уведомления

                    // Если пользователь подтверждает удаление сотрудника
                    string MessageTitle = "Вы действительно хотите удалить: " + SurnameNameWorker + " ?";
                    if (MessageBox.Show(
                        MessageTitle, "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        // Выполняем удаление
                        AppConnectClass.DataBase.PlaceResidenceTable.Remove(DataContextWorker.PlaceResidenceTable);
                        AppConnectClass.DataBase.MedicalBookTable.Remove(DataContextWorker.MedicalBookTable);
                        AppConnectClass.DataBase.SalaryCardTable.Remove(DataContextWorker.SalaryCardTable);
                        AppConnectClass.DataBase.PassportTable.Remove(DataContextWorker.PassportTable);
                        AppConnectClass.DataBase.SnilsTable.Remove(DataContextWorker.SnilsTable);
                        AppConnectClass.DataBase.INNTable.Remove(DataContextWorker.INNTable);
                        AppConnectClass.DataBase.WorkerTabe.Remove(DataContextWorker);

                        // Сохраняем изменения
                        AppConnectClass.DataBase.SaveChanges();

                        // Выводим уведомление с переменными выше
                        string MessageTitleDelit = "Сотрудник " + SurnameNameWorker + " удалён";
                        MessageBox.Show(
                            MessageTitleDelit, "Удаление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                //Если произошла ошибка в коде сверху, обрабатываем эту ошибку
                catch (Exception Ex)
                {
                    MessageBox.Show(
                        Ex.Message.ToString(), "Ошибка - E003",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Действие после удачного или неудачного выполнения работы кода
                finally
                {
                    // Обновляем содержимое ListBox
                    ListWorkerListView.Items.Refresh();

                    DataContextWorker = null;
                    DeliteButton.IsEnabled = false;
                    EditButton.IsEnabled = false;
                }
            }
        }
        #endregion
        #region SelectionChanged_MouseDoubleClick
        private void ListWorkerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Переход к странице с информацией об сотруднике
        {

        }
        private void ListWorkerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) // Активация кнопок для Редактирования или удаления сотрудника, когда выбран объект из ListWorkerListView
        {
            DataContextWorker = (WorkerTabe)ListWorkerListView.SelectedItem; // Получаем информацию об выбранном сотруднике
            EditButton.IsEnabled = true;
            DeliteButton.IsEnabled = true;
        }
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) // Реализация метода поиск по таблице PassportTable и вывод результатов из таблицы WorkerTabe
        {
            try
            {
                if (SearchTextBox.Text == "") // Если SearchTextBox пустой
                {
                    HintSearchTextBlock.Visibility = Visibility.Visible;
                    ListWorkerListView.ItemsSource = AppConnectClass.DataBase.WorkerTabe.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.DataBase.WorkerTabe.Include(w => w.PassportTable).ToList(); //Получаем лист обыектов из таблицы WorkerTabe по таблице PassportTable

                    var SearchResults = Objects.Where(worker => // Делаем поиск из полученного списка
                        worker.PassportTable.Surname_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) || // По атрибуту Surname_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Name_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) || // По атрибуту Name_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Middlename_Passport.ToLower().Contains(SearchTextBox.Text.ToLower())); // По атрибуту Middlename_Passport из таблицы PassportTable по похожему контенту в SearchTextBox

                    ListWorkerListView.ItemsSource = SearchResults.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "Ошибка поиска - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
