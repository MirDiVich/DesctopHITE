//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Данная страница нужна для того, чтоб выгружать всё меню из базы данных;
/// Так же помимо всего, с выгружаемым меню можно взаимодействовать;
/// Пользователю для взаимодействия доступно всего 4 возможности:
///     1. Найти через поиск;
///     2. Просмотреть подробную информацию;
///     3. Отредактировать информацию;
///     4. Удалить меню.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
        MenuTable dataContextMenu;

        public ListMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exListMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ListMenuPage в ListMenuPage:\n\n " +
                        $"{exListMenuPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) /// Если страница видна
        {
            try
            {
                if(Visibility == Visibility.Visible)
                {
                    EditButton.IsEnabled = false;
                    DeliteButton.IsEnabled = false;

                    ListMenuListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuTable.ToList();
                    ListMenuListView.Items.SortDescriptions.Add(new SortDescription("PersonalNumber_Menu", ListSortDirection.Ascending)); // Сортируем выведённую информацию в алфавитном порядке (Сортировка происходит по атрибуту "Name_Menu");
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListMenuPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region Event_
        private void Event_ViewDataMenu(object sender, RoutedEventArgs e) /// Просмотр информации
        {
            try
            {
                if (dataContextMenu != null)
                {
                    FrameNavigationClass.bodyMenu_FNC.Navigate(new ViewMenuPage(dataContextMenu));
                }
                else
                {
                    MessageBox.Show(
                        "Сотрудник не выбран", "Ошибка - E001",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exEvent_ViewDataMenu)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_ViewDataMenu в ListMenuPage:\n\n " +
                        $"{exEvent_ViewDataMenu.Message}");
            }
        }

        private void Event_EditMunu(object sender, RoutedEventArgs e) /// Редактирование
        {
            try
            {
                if (dataContextMenu != null)
                {
                    FrameNavigationClass.bodyMenu_FNC.Navigate(new NewMenuPage(dataContextMenu));
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Меню не выбрано");
                }
            }
            catch (Exception exEvent_EditMunu)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_EditMunu в ListMenuPage:\n\n " +
                        $"{exEvent_EditMunu.Message}");
            }
        }

        private void Event_DeleteMenu(object sender, RoutedEventArgs e) /// Удаление информации
        {
            try
            {
                if (dataContextMenu != null)
                {
                    ///<!--
                    /// TODO: Реализовать удаление
                    /// -->
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Меню не выбрано");
                }
            }
            catch (Exception exEvent_DeleteMenu)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_DeleteMenu в ListMenuPage:\n\n " +
                        $"{exEvent_DeleteMenu.Message}");
            }
        }
        #endregion
        #region _SelectionChanged _MouseDoubleClick
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) /// Простой алгоритм поиска
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

                    var Objects = AppConnectClass.connectDataBase_ACC.MenuTable.ToList(); /// Получаем лист объектов из таблицы MenuTable

                    var SearchResults = Objects.Where(nameMunu => // Делаем поиск из полученного списка
                        nameMunu.Name_Menu.ToString().Contains(SearchTextBox.Text.ToString())); // По атрибуту Name_Menu из таблицы MenuTable по похожему контенту в SearchTextBox

                    ListMenuListView.ItemsSource = SearchResults.ToList();
                }

                // Если пользователь делает поиск и в результате поиска ничего не нашлось то появляется сообщение о неудачном поиске "чтоб пользователь не думал, что приложение сломалось"
                if (SearchTextBox.Text != null && ListMenuListView.Items.Count == 0)
                {
                    HintSearchNullElementsTextBlock.Visibility = Visibility.Visible;
                    HintSearchNullElementsTextBlock.Text = $"По запросу '{SearchTextBox.Text}' не удалось ничего найти...";
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
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListMenuPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }

        private void ListMenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dataContextMenu = (MenuTable)ListMenuListView.SelectedItem; /// Получаем информацию об выбранном меню
                EditButton.IsEnabled = true;
                DeliteButton.IsEnabled = true;
            }
            catch (Exception exListMenuListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ListMenuListView_SelectionChanged в ListWorkerPage:\n\n " +
                        $"{exListMenuListView_SelectionChanged.Message}");
            }
        }

        private void ListMenuListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) { Event_EditMunu(this, e); }
        #endregion
        #region _Click
        private void KeyboardShortcuts(object sender, KeyEventArgs e) /// Работа с сочетанием клавиш
        {
            try
            {
                if (dataContextMenu != null)
                {
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.F1) { Event_ViewDataMenu(this, e); }
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.F2) { Event_EditMunu(this, e); }
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Delete) { Event_DeleteMenu(this, e); }
                }
            }
            catch (Exception exKeyboardShortcuts)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие KeyboardShortcuts в ListWorkerPage:\n\n " +
                       $"{exKeyboardShortcuts.Message}");
            }
        }

        private void NewMenuButton_Click(object sender, RoutedEventArgs e) /// Переход к добавлению нового меню
        {
            try
            {
                FrameNavigationClass.bodyMenu_FNC.Navigate(new NewMenuPage(null));
            }
            catch (Exception exNewMenuButton)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewMenuButton в ListWorkerPage:\n\n " +
                        $"{exNewMenuButton.Message}");
            }
        }
        #endregion
    }
}
