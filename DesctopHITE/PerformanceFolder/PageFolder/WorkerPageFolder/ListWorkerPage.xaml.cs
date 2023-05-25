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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exListWorkerPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ListWorkerPage в ListWorkerPage:\n\n " +
                        $"{exListWorkerPage.Message}");
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
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListWorkerPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Event
        private void EventViewDataWorker(object sender, RoutedEventArgs e) // Просмотр информации
        {
            try
            {
                if (dataContextWorker != null)
                {
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new ViewInformationWorkerPage(dataContextWorker));
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage:"Сотрудник не выбран");
                }
            }
            catch (Exception exEventViewDataWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventViewDataWorker в ListWorkerPage:\n\n " +
                        $"{exEventViewDataWorker.Message}");
            }
        }

        private void EventEditWorker(object sender, RoutedEventArgs e) // Редактирование информации
        {
            try
            {
                if (dataContextWorker != null)
                {
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(dataContextWorker));
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Сотрудник не выбран");
                }
            }
            catch (Exception exEventEditWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GetEditWorker в ListWorkerPage:\n\n " +
                        $"{exEventEditWorker.Message}");
            }
        }

        private void EventDeleteWorker(object sender, RoutedEventArgs e) // Удаление информации
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
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Сотрудник не выбран");
                }
            }
            catch (Exception exEventDeleteWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventDeleteWorker в ListWorkerPage:\n\n " +
                        $"{exEventDeleteWorker.Message}");
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
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.F1) { EventViewDataWorker(this, e); }
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.F2) { EventEditWorker(this, e); }
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Delete) { EventDeleteWorker(this, e); }
                }
            }
            catch(Exception exKeyboardShortcuts)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие KeyboardShortcuts в ListWorkerPage:\n\n " +
                       $"{exKeyboardShortcuts.Message}");
            }
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(null));
            }
            catch (Exception exNewWorkerButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие NewWorkerButton_Click в ListWorkerPage:\n\n " +
                       $"{exNewWorkerButton_Click.Message}");
            }
        }
        #endregion
        #region SelectionChanged_MouseDoubleClick
        private void ListWorkerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) { EventViewDataWorker(this, e); } // Переход к странице с информацией об сотруднике
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
                MessageBoxClass.ExceptionMessageBox_MBC(
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
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListWorkerPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }
        #endregion
    }
}
