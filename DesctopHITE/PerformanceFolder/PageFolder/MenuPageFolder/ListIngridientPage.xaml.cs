///----------------------------------------------------------------------------------------------------------
/// Данная страница нужна для того, чтоб выгружать все ингредиенты из базы данных;
/// Так же помимо всего, с выгружаемым ингредиентами можно взаимодействовать;
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
    public partial class ListIngridientPage : Page
    {
        IngredientsTable getIngredientsTable;

        public ListIngridientPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exListIngridientPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ListIngridientPage в ListIngridientPage:\n\n " +
                        $"{exListIngridientPage.Message}");
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

                    IngridientListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.IngredientsTable.ToList();
                    IngridientListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending)); // Сортируем выведённую информацию в алфавитном порядке (Сортировка происходит по атрибуту "Name_Menu");
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в ListIngridientPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Event
        private void EventViewDataIngredients(object sender, RoutedEventArgs e) // Просмотр информации об сотруднике
        {
            try
            {
                if (getIngredientsTable != null)
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
            catch (Exception exEventViewDataIngredients)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventViewDataIngredients в ListIngridientPage:\n\n " +
                        $"{exEventViewDataIngredients.Message}");
            }
        }

        private void EventEditIngredients(object sender, RoutedEventArgs e) // Редактирование информации
        {
            try
            {
                if (getIngredientsTable != null)
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
            catch (Exception exEventEditIngredients)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventEditIngredients в ListIngridientPage:\n\n " +
                        $"{exEventEditIngredients.Message}");
            }
        }

        private void EventDeleteIngredients(object sender, RoutedEventArgs e) // Удаление информации
        {
            try
            {
                if (getIngredientsTable != null)
                {
                    //DeliteWorkerWindow deliteWorkerWindow = new DeliteWorkerWindow(getMenuTable);
                    //deliteWorkerWindow.ShowDialog();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: "Ингредиент не выбран");
                }
            }
            catch (Exception exEventDeleteIngredients)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventDeleteIngredients в ListIngridientPage:\n\n " +
                        $"{exEventDeleteIngredients.Message}");
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
                    IngridientListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuTable.ToList();
                }
                else // Если же в SearchTextBox есть что-то то:
                {
                    HintSearchTextBlock.Visibility = Visibility.Collapsed;

                    var Objects = AppConnectClass.connectDataBase_ACC.IngredientsTable.ToList(); //Получаем лист объектов из таблицы MenuTable

                    var SearchResults = Objects.Where(nameIngredientsu => // Делаем поиск из полученного списка
                        nameIngredientsu.Name_Ingredients.ToString().Contains(SearchTextBox.Text.ToString())); // По атрибуту Name_Menu из таблицы MenuTable по похожему контенту в SearchTextBox

                    IngridientListListView.ItemsSource = SearchResults.ToList();
                }

                // Если пользователь делает поиск и в результате поиска ничего не нашлось то появляется сообщение о неудачном поиске "чтоб пользователь не думал, что приложение сломалось"
                if (SearchTextBox.Text != null && IngridientListListView.Items.Count == 0)
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
                        textMessage: $"Событие SearchTextBox_SelectionChanged в ListIngridientPage:\n\n " +
                        $"{exSearchTextBox_SelectionChanged.Message}");
            }
        }

        private void IngridientListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                getIngredientsTable = (IngredientsTable)IngridientListListView.SelectedItem; // Получаем информацию об выбранном сотруднике
                EditButton.IsEnabled = true;
                DeliteButton.IsEnabled = true;
            }
            catch (Exception exIngridientListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IngridientListListView_SelectionChanged в ListIngridientPage:\n\n " +
                        $"{exIngridientListListView_SelectionChanged.Message}");
            }
        }
        #endregion

        private void IngridientListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
            }
            catch (Exception exIngridientListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IngridientListListView_MouseDoubleClick в ListIngridientPage:\n\n " +
                        $"{exIngridientListListView_MouseDoubleClick.Message}");
            }
        }
    }
}
