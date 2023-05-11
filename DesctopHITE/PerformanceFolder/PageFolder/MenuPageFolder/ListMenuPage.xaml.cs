///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для того, чтоб выгружать всё меню из базы данных;
/// Так же помимо всего, с выгружаемым меню можно взаимодействовать;
/// Пользователю для взаимодействия доступно всего 4 возможности:
///     1. Найти через поиск;
///     2. Просмотреть подробную информацию;
///     3. Отредактировать информацию;
///     4. Удалить сотрудника.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class ListMenuPage : Page
    {
        MenuTable getMenuTable;

        public ListMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exListMenuPage)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ListMenuPage в ListMenuPage:\n\n " +
                        $"{exListMenuPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if(Visibility == Visibility.Visible)
                {
                    EditButton.IsEnabled = false;
                    DeliteButton.IsEnabled = false;

                    ListMenuListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuTable.ToList();
                    ListMenuListView.Items.SortDescriptions.Add(new SortDescription("Name_Menu", ListSortDirection.Ascending)); // Сортируем выведённую информацию в алфавитном порядке (Сортировка происходит по атрибуту "Name_Menu");
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListMenuPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region Event
        private void EventViewDataMenu(object sender, RoutedEventArgs e) // Просмотр информации об сотруднике
        {
            try
            {
                if (getMenuTable != null)
                {
                    //ViewEditInfoemationWorkerWindow viewEditInfoemationWorkerWindow = new ViewEditInfoemationWorkerWindow();
                    //FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new ViewInformationWorkerPage(getMenuTable));
                    //viewEditInfoemationWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exViewDataMenu)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ViewDataMenu в ListMenuPage:\n\n " +
                        $"{exViewDataMenu.Message}");
            }
        }

        private void EventEditMunu(object sender, RoutedEventArgs e) // Редактирование информации
        {
            try
            {
                if (getMenuTable != null)
                {
                    //ViewEditInfoemationWorkerWindow viewEditInfoemationWorkerWindow = new ViewEditInfoemationWorkerWindow();
                    //FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new NewWorkerPage(getMenuTable));
                    //viewEditInfoemationWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exGetEditMunu)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие GetEditMunu в ListMenuPage:\n\n " +
                        $"{exGetEditMunu.Message}");
            }
        }

        private void EventDeleteMenu(object sender, RoutedEventArgs e) // Удаление информации
        {
            try
            {
                if (getMenuTable != null)
                {
                    //DeliteWorkerWindow deliteWorkerWindow = new DeliteWorkerWindow(getMenuTable);
                    //deliteWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exGetDeleteMenu)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие GetDeleteMenu в ListMenuPage:\n\n " +
                        $"{exGetDeleteMenu.Message}");
            }
        }
        #endregion
        #region _SelectionChanged _MouseDoubleClick
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) // Простой алгоритм поиска
        {
            try
            {
                if (SearchTextBox.Text == "") // Если SearchTextBox пустой
                {
                    HintSearchTextBlock.Visibility = Visibility.Visible;
                    ListMenuListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.connectDataBase_ACC.MenuTable.ToList(); //Получаем лист объектов из таблицы MenuTable

                    var SearchResults = Objects.Where(nameMunu => // Делаем поиск из полученного списка
                        nameMunu.Name_Menu.ToString().Contains(SearchTextBox.Text.ToString())); // По атрибуту Name_Menu из таблицы MenuTable по похожему контенту в SearchTextBox

                    ListMenuListView.ItemsSource = SearchResults.ToList();
                }

                // Если пользователь делает поиск и в результате поиска ничего не нашлось то появляется сообщение о неудачном поиске "чтоб пользователь не думал, что приложение сломалось"
                if (SearchTextBox.Text != null && ListMenuListView.Items.Count == 0)
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
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListMenuPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }

        private void ListMenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                getMenuTable = (MenuTable)ListMenuListView.SelectedItem; // Получаем информацию об выбранном сотруднике
                EditButton.IsEnabled = true;
                DeliteButton.IsEnabled = true;
            }
            catch (Exception exListWorkerListView_SelectionChanged)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ListMenuListView_SelectionChanged в ListWorkerPage:\n\n " +
                        $"{exListWorkerListView_SelectionChanged.Message}");
            }
        }
        #endregion

        private void ListMenuListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
