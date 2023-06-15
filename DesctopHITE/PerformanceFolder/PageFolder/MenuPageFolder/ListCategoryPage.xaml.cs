///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для того, чтоб выгружать все категорию из базы данных;
/// Так же помимо всего, с выгружаемым категориями можно взаимодействовать;
/// Пользователю для взаимодействия доступно всего 4 возможности:
///     1. Найти через поиск;
///     2. Просмотреть подробную информацию;
///     3. Отредактировать информацию;
///     4. Удалить Категория.
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
    public partial class ListCategoryPage : Page
    {
        MenuCategoryTable getMenuCategoryTable;
        public ListCategoryPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exListCategoryPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ListCategoryPage в ListCategoryPage:\n\n " +
                        $"{exListCategoryPage.Message}");
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

                    CategoryListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.ToList();
                    CategoryListListView.Items.SortDescriptions.Add(new SortDescription("Title_MenuCategory", ListSortDirection.Ascending)); // Сортируем выведенную информацию в алфавитном порядке (Сортировка происходит по атрибуту "Title_MenuCategory");
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListCategoryPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Event_
        private void Event_EditCategory(object sender, RoutedEventArgs e) // Редактирование информации
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    FrameNavigationClass.bodyMenu_FNC.Navigate(new NewCategoryPage(getMenuCategoryTable));
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Категория не выбрана");
                }
            }
            catch (Exception exEvent_EditCategory)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_EditCategory в ListCategoryPage:\n\n " +
                        $"{exEvent_EditCategory.Message}");
            }
        }

        private void Event_DeleteCategory(object sender, RoutedEventArgs e) // Удаление информации
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить " + getMenuCategoryTable.Title_MenuCategory, "Удаление",
                       MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var deliteCategory = AppConnectClass.connectDataBase_ACC.MenuCategoryTable;
                        deliteCategory.Remove(getMenuCategoryTable);
                        AppConnectClass.connectDataBase_ACC.SaveChanges();

                        MessageBoxClass.GoodMessageBox_MBC(textMessage: $"Вы удалили {getMenuCategoryTable.Title_MenuCategory}");
                        FrameNavigationClass.bodyMenu_FNC.Navigate(new ListCategoryPage());
                    }
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Категория не выбрана");
                }
            }
            catch (Exception exEvent_DeleteCategory)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_DeleteCategory в ListCategoryPage:\n\n " +
                        $"{exEvent_DeleteCategory.Message}");
            }
        }
        #endregion
        #region _SelectionChanged _MouseDoubleClick
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e) // Простой алгоритм поиска
        {
            try
            {
                if (SearchTextBox.Text == null) // Если SearchTextBox пустой
                {
                    HintSearchTextBlock.Visibility = Visibility.Visible;
                    CategoryListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.ToList();

                    var SearchResults = Objects.Where(nameCategories =>
                        nameCategories.Title_MenuCategory.ToString().Contains(SearchTextBox.Text.ToString()));

                    CategoryListListView.ItemsSource = SearchResults.ToList();
                }

                // Если пользователь делает поиск и в результате поиска ничего не нашлось то появляется сообщение о неудачном поиске "чтоб пользователь не думал, что приложение сломалось"
                if (SearchTextBox.Text != null && CategoryListListView.Items.Count == 0)
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
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListCategoryPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }

        private void CategoryListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                getMenuCategoryTable = (MenuCategoryTable)CategoryListListView.SelectedItem; // Получаем информацию
                EditButton.IsEnabled = true;
                DeliteButton.IsEnabled = true;
            }
            catch (Exception exCategoryListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CategoryListListView_SelectionChanged в ListCategoryPage:\n\n " +
                        $"{exCategoryListListView_SelectionChanged.Message}");
            }
        }

        private void CategoryListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Event_EditCategory(this, e);
            }
            catch (Exception exCategoryListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CategoryListListView_MouseDoubleClick в ListCategoryPage:\n\n " +
                        $"{exCategoryListListView_MouseDoubleClick.Message}");
            }
        }
        #endregion
        #region _Click
        private void NewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyMenu_FNC.Navigate(new NewCategoryPage(null));
            }
            catch (Exception exNewCategoryButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCategoryButton_Click в ListCategoryPage:\n\n " +
                        $"{exNewCategoryButton_Click.Message}");
            }
        }

        private void KeyboardShortcuts(object sender, KeyEventArgs e)
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.F2) { Event_EditCategory(this, e); }
                    if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.Key == Key.Delete) { Event_DeleteCategory(this, e); }
                }
            }
            catch (Exception exKeyboardShortcuts)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие KeyboardShortcuts в ListWorkerPage:\n\n " +
                       $"{exKeyboardShortcuts.Message}");
            }
        }
        #endregion
    }
}
