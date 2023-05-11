///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
using DesctopHITE.PerformanceFolder.WindowsFolder;
using System;
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
                AppConnectClass.DataBase = new DesctopHiteEntities();
                ListMenuListView.ItemsSource = AppConnectClass.DataBase.MenuTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие NewWorkerPage в ListMenuPage:\n\n " +
                        $"{ex.Message}");
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
                    //FrameNavigationClass.ViewEditInformationWorker_FNC.Navigate(new ViewInformationWorkerPage(getMenuTable));
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
                MessageBoxClass.ExceptionMessage(
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
                    //FrameNavigationClass.ViewEditInformationWorker_FNC.Navigate(new NewWorkerPage(getMenuTable));
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
                MessageBoxClass.ExceptionMessage(
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
                MessageBoxClass.ExceptionMessage(
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
                    ListMenuListView.ItemsSource = AppConnectClass.DataBase.MenuTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.DataBase.MenuTable.ToList(); //Получаем лист объектов из таблицы MenuTable

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
                MessageBoxClass.ExceptionMessage(
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
                MessageBoxClass.ExceptionMessage(
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
