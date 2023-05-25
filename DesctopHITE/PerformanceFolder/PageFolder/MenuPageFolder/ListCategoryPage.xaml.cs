///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для того, чтоб выгружать все категорию из базы данных;
/// Так же помимо всего, с выгружаемым категориями можно взаимодействовать;
/// Пользователю для взаимодействия доступно всего 4 возможности:
///     1. Найти через поиск;
///     2. Просмотреть подробную информацию;
///     3. Отредактировать информацию;
///     4. Удалить ингредиент.
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
                    CategoryListListView.Items.SortDescriptions.Add(new SortDescription("Title_MenuCategory", ListSortDirection.Ascending)); // Сортируем выведённую информацию в алфавитном порядке (Сортировка происходит по атрибуту "Name_Menu");
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListCategoryPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Event
        private void EventViewDataCategory(object sender, RoutedEventArgs e) // Просмотр информации об сотруднике
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    //ViewEditInfoemationWindow viewEditInfoemationWindow = new ViewEditInfoemationWindow();
                    //FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new ViewInformationWorkerPage(getMenuTable));
                    //viewEditInfoemationWindow.ShowDialog();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Ингредиент не выбран");
                }
            }
            catch (Exception exEventViewDataCategory)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventViewDataCategory в ListCategoryPage:\n\n " +
                        $"{exEventViewDataCategory.Message}");
            }
        }

        private void EventEditCategory(object sender, RoutedEventArgs e) // Редактирование информации
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    //ViewEditInfoemationWindow viewEditInfoemationWindow = new ViewEditInfoemationWindow();
                    //FrameNavigationClass.viewEditInformationWorker_FNC.Navigate(new NewMenuPage(getIngredientsTable));
                    //viewEditInfoemationWindow.ShowDialog();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Ингредиент не выбран");
                }
            }
            catch (Exception exEventEditCategory)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventEditCategory в ListCategoryPage:\n\n " +
                        $"{exEventEditCategory.Message}");
            }
        }

        private void EventDeleteCategory(object sender, RoutedEventArgs e) // Удаление информации
        {
            try
            {
                if (getMenuCategoryTable != null)
                {
                    //DeliteWorkerWindow deliteWorkerWindow = new DeliteWorkerWindow(getMenuTable);
                    //deliteWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Ингредиент не выбран");
                }
            }
            catch (Exception exEventDeleteCategory)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventDeleteCategory в ListCategoryPage:\n\n " +
                        $"{exEventDeleteCategory.Message}");
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

                    var SearchResults = Objects.Where(nameIngredientsu => 
                        nameIngredientsu.Title_MenuCategory.ToString().Contains(SearchTextBox.Text.ToString()));

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
            catch (Exception exIngridientListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IngridientListListView_SelectionChanged в ListCategoryPage:\n\n " +
                        $"{exIngridientListListView_SelectionChanged.Message}");
            }
        }

        private void CategoryListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

            }
            catch (Exception exIngridientListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IngridientListListView_MouseDoubleClick в ListCategoryPage:\n\n " +
                        $"{exIngridientListListView_MouseDoubleClick.Message}");
            }
        }
        #endregion
        #region _Click
        private void NewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
            }
            catch (Exception exNewCategoryButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCategoryButton_Click в ListCategoryPage:\n\n " +
                        $"{exNewCategoryButton_Click.Message}");
            }
        }
        #endregion
    }
}
