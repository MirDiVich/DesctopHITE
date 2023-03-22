using System.Linq;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class ListWorkerPage : Page
    {
        public ListWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities(); // Подключил базу данных к этой странице
            ListWorkerListBox.ItemsSource = AppConnectClass.DataBase.WorkerTabe.ToList(); // Вывел в ListWorkerListBox объекты из WorkerTabe в виде листа
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) //Если страница видна
            {
                EditButton.IsEnabled = false;
                DeliteButton.IsEnabled = false;
            }
        }
        #region Click
        private void EditButton_Click(object sender, RoutedEventArgs e) // Открытия страницы для возможности редактирования информации об сотруднике
        {
            WorkerTabe workerTabe = (WorkerTabe)ListWorkerListBox.SelectedItem;
            if (workerTabe == null)
            {
                MessageBox.Show(
                    "Сотрудник не выбран",
                    "Ошибка - E001",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(workerTabe));
            }
        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e) // Реализация удаления сотрудника
        {

        }
        #endregion
        #region SelectionChanged_MouseDoubleClick
        private void ListWorkerListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Переход к странице с информацией об сотруднике
        {

        }
        private void ListWorkerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Активация кнопок для Редактирования или удаления сотрудника, когда выбран объект из ListWorkerListBox
        {
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
                    ListWorkerListBox.ItemsSource = AppConnectClass.DataBase.WorkerTabe.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.DataBase.WorkerTabe.Include(w => w.PassportTable).ToList(); //Получаем лист обыектов из таблицы WorkerTabe по таблице PassportTable

                    var SearchResults = Objects.Where(worker => // Делаем поиск из полученного списка
                        worker.PassportTable.Surname_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) || // По атрибуту Surname_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Name_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) || // По атрибуту Name_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Middlename_Passport.ToLower().Contains(SearchTextBox.Text.ToLower())); // По атрибуту Middlename_Passport из таблицы PassportTable по похожему контенту в SearchTextBox

                    ListWorkerListBox.ItemsSource = SearchResults.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "Ошибка поиска - E001",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
