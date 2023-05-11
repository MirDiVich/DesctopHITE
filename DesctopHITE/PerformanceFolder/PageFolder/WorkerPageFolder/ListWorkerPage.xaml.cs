///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для того, чтоб выгружать всех сотрудников из базы данных;
/// Так же помимо всего, с выгружаемыми сотрудниками можно взаимодействовать;
/// Пользователю для взаимодействия доступно всего 4 возможности:
///     1. Найти через поиск;
///     2. Просмотреть подробную информацию;
///     3. Отредактировать информацию;
///     4. Удалить сотрудника.
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
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities(); // Подключил базу данных к этой странице
            }
            catch (Exception ex)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ListWorkerPage в ListWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    EditButton.IsEnabled = false;
                    DeliteButton.IsEnabled = false;

                    ListWorkerListView.ItemsSource = AppConnectClass.connectDataBase_ACC.WorkerTable.ToList();
                    ListWorkerListView.Items.SortDescriptions.Add(new SortDescription("PassportTable.Surname_Passport", ListSortDirection.Ascending)); // Сортируем выведённую информацию в элементе "ListWorkwrListView" в алфовитном порядке (Сортировка происходит по атрибуту "SurnameWorker");
                }
            }
            catch (Exception exVisible)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListWorkerPage:\n\n " +
                        $"{exVisible.Message}");
            }
        }

        #region Event
        private void ViewDataWorker() // Просмотр информации об сотруднике
        {
            try
            {
                if (dataContextWorker != null)
                {
                    ViewEditInfoemationWorkerWindow viewEditInfoemationWorkerWindow = new ViewEditInfoemationWorkerWindow();
                    FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new ViewInformationWorkerPage(dataContextWorker));
                    viewEditInfoemationWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exViewDataWorker)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ViewDataWorker в ListWorkerPage:\n\n " +
                        $"{exViewDataWorker.Message}");
            }
        }

        private void GetEditWorker() // Редактирование информации об сотруднике
        {
            try
            {
                if (dataContextWorker != null)
                {
                    ViewEditInfoemationWorkerWindow viewEditInfoemationWorkerWindow = new ViewEditInfoemationWorkerWindow();
                    FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new NewWorkerPage(dataContextWorker));
                    viewEditInfoemationWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exGetEditWorker)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие GetEditWorker в ListWorkerPage:\n\n " +
                        $"{exGetEditWorker.Message}");
            }
        }

        private void GetDeleteWorker() // Удаление информации об сотруднике
        {
            try
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
            catch (Exception exGetDeleteWorker)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие GetDeleteWorker в ListWorkerPage:\n\n " +
                        $"{exGetDeleteWorker.Message}");
            }
        }
        #endregion
        #region _Click
        private void KeyboardShortcuts(object sender, KeyEventArgs e)
        {
            try
            {
                if (dataContextWorker != null)
                {
                    if (e.Key == Key.F1)
                    {
                        ViewDataWorker();
                    }
                    if (e.Key == Key.F2)
                    {
                        GetEditWorker();
                    }
                    if (e.Key == Key.Delete)
                    {
                        GetDeleteWorker();
                    }
                }
            }
            catch(Exception exKeyboardShortcuts)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие KeyboardShortcuts в ListWorkerPage:\n\n " +
                       $"{exKeyboardShortcuts.Message}");
            }
        }

        private void ActionEditWorker(object sender, RoutedEventArgs e) // Открытия страницы для возможности редактирования информации об сотруднике
        {
            GetEditWorker();
        }

        private void ActionDeliteWorker(object sender, RoutedEventArgs e) // Реализация удаления сотрудника
        {
            GetDeleteWorker();
        }
        #endregion
        #region SelectionChanged_MouseDoubleClick
        private void ListWorkerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) // Переход к странице с информацией об сотруднике
        {
            ViewDataWorker();
        }

        private void ListWorkerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) // Активация кнопок для Редактирования или удаления сотрудника, когда выбран объект из ListWorkerListView
        {
            try
            {
                dataContextWorker = (WorkerTable)ListWorkerListView.SelectedItem; // Получаем информацию об выбранном сотруднике
                EditButton.IsEnabled = true;
                DeliteButton.IsEnabled = true;
            }
            catch (Exception exListWorkerListView_SelectionChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ListWorkerListView_SelectionChanged в ListWorkerPage:\n\n " +
                        $"{exListWorkerListView_SelectionChanged.Message}");
            }
        }

        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) // Реализация Eventа поиск по таблице PassportTable и вывод результатов из таблицы WorkerTable
        {
            try
            {
                if (SearchTextBox.Text == "") // Если SearchTextBox пустой
                {
                    HintSearchTextBlock.Visibility = Visibility.Visible;
                    ListWorkerListView.ItemsSource = AppConnectClass.connectDataBase_ACC.WorkerTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.connectDataBase_ACC.WorkerTable.Include(WorkerPassport => WorkerPassport.PassportTable).ToList(); //Получаем лист объектов из таблицы WorkerTable по таблице PassportTable

                    var SearchResults = Objects.Where(worker => // Делаем поиск из полученного списка
                        worker.PassportTable.Surname_Passport.ToString().Contains(SearchTextBox.Text.ToString()) || // По атрибуту Surname_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Name_Passport.ToString().Contains(SearchTextBox.Text.ToString()) || // По атрибуту Name_Passport из таблицы PassportTable по похожему контенту в SearchTextBox
                        worker.PassportTable.Middlename_Passport.ToString().Contains(SearchTextBox.Text.ToString())); // По атрибуту Middlename_Passport из таблицы PassportTable по похожему контенту в SearchTextBox

                    ListWorkerListView.ItemsSource = SearchResults.ToList();
                }

                // Если пользователь делает поиск и в результате поиска ничего не нашлось то появляется сообщение о неудачном поиске "чтоб пользователь не думал, что приложение сломалось"
                if (SearchTextBox.Text != null && ListWorkerListView.Items.Count == 0)
                {
                    HintSearchNullElementsTextBlock.Visibility = Visibility.Visible;
                    HintSearchNullElementsTextBlock.Text =
                        $"По запросу '{SearchTextBox.Text}' не удалось ничего найти...";
                }
                else
                {
                    HintSearchNullElementsTextBlock.Visibility = Visibility.Collapsed;
                    HintSearchNullElementsTextBlock.Text = "";
                }
            }
            catch (Exception exSearchTextBox_SelectionChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListWorkerPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }
        #endregion
    }
}
