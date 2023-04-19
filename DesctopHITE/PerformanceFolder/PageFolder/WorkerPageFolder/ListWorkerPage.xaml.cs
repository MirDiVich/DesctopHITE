///----------------------------------------------------------------------------------------------------------
/// 
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.WindowsFolder;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class ListWorkerPage : Page
    {
        public WorkerTable dataContextWorker;

        public ListWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities(); // Подключил базу данных к этой странице
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) 
            {
                EditButton.IsEnabled = false;
                DeliteButton.IsEnabled = false;

                ListWorkerListView.ItemsSource = AppConnectClass.DataBase.WorkerTable.ToList();
                ListWorkerListView.Items.SortDescriptions.Add(new SortDescription("PassportTable.Surname_Passport", ListSortDirection.Ascending)); // Сортируем выведённую информацию в элементе "ListWorkwrListView" в алфовитном порядке (Сортировка происходит по атрибуту "SurnameWorker");
            }
        }
        #region Click

        private void ActionEditWorker(object sender, RoutedEventArgs e) // Открытия страницы для возможности редактирования информации об сотруднике
        {
            if (dataContextWorker != null)
            {
                ViewEditInfoemationWorkerWindow viewEditInfoemationWorkerWindow = new ViewEditInfoemationWorkerWindow();
                FrameNavigationClass.ViewEditInformationWorker_FNC.Navigate(new NewWorkerPage(dataContextWorker));
                viewEditInfoemationWorkerWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Сотрудник не выбран", "Ошибка - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ActionDeliteWorker(object sender, RoutedEventArgs e) // Реализация удаления сотрудника
        {
            if (dataContextWorker != null)
            {
                DeliteWorkerWindow deliteWorkerWindow = new DeliteWorkerWindow(dataContextWorker);
                deliteWorkerWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Сотрудник не выбран", "Ошибка - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
        #region SelectionChanged_MouseDoubleClick

        private void ListWorkerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Переход к странице с информацией об сотруднике
        {

        }

        private void ListWorkerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) // Активация кнопок для Редактирования или удаления сотрудника, когда выбран объект из ListWorkerListView
        {
            dataContextWorker = (WorkerTable)ListWorkerListView.SelectedItem; // Получаем информацию об выбранном сотруднике
            EditButton.IsEnabled = true;
            DeliteButton.IsEnabled = true;
        }

        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) // Реализация метода поиск по таблице PassportTable и вывод результатов из таблицы WorkerTable
        {
            try
            {
                if (SearchTextBox.Text == "") // Если SearchTextBox пустой
                {
                    HintSearchTextBlock.Visibility = Visibility.Visible;
                    ListWorkerListView.ItemsSource = AppConnectClass.DataBase.WorkerTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.DataBase.WorkerTable.Include(WorkerPassport => WorkerPassport.PassportTable).ToList(); //Получаем лист обыектов из таблицы WorkerTable по таблице PassportTable

                    var SearchResults = Objects.Where(worker => // Делаем поиск из полученного списка
                        worker.PassportTable.Surname_Passport.ToString().Contains(SearchTextBox.Text.ToString()) || // По атрибуту Surname_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Name_Passport.ToString().Contains(SearchTextBox.Text.ToString()) || // По атрибуту Name_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Middlename_Passport.ToString().Contains(SearchTextBox.Text.ToString())); // По атрибуту Middlename_Passport из таблицы PassportTable по похожему контенту в SearchTextBox

                    ListWorkerListView.ItemsSource = SearchResults.ToList();

                    if (ListWorkerListView.Items.Count == 0 && SearchTextBox.Text != null)
                    {
                        HintSearchNullElementsTextBlock.Text =
                            $"По запросу '{SearchTextBox.Text}' не удалось ничего найти...";
                    }
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
