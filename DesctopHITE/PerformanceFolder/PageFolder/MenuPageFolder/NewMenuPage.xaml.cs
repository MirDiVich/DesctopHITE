//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Данная страница представляет из себя страницу для:
///     1. Добавления нового меню;
///     2. Редактирование информации об существующем.
/// При сохранении данных, программа проверяет, правильную валидность данных, и наличие пустоты в тех полях, где не должно быть пустоты.
/// На данной странице реализован список, в которой выгружается список всех ингредиентов, которые используются для данного меню (если такие имеются).
/// Это позволяет, как удалять позиции из данного списка, так и добавлять, после чего просто присвоить данный список редактируемому или добавляемому меню.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class NewMenuPage : Page
    {
        List<IngredientsTable> ingredientsList = new List<IngredientsTable>(); /// Тот самый список

        byte[] imageData;

        int personlNumberMenu = 0;

        string pathImage = "";
        string messageNull;
        string messageValidData;

        public NewMenuPage(MenuTable menuTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                // Проверяем, идёт редактирование меню или добавление нового 
                if (menuTable != null)
                {
                    DataContext = menuTable;
                    personlNumberMenu = menuTable.PersonalNumber_Menu;

                    AppConnectClass.connectDataBase_ACC.MenuTable.Include(ingredients => ingredients.IngredientsTable).Load();
                    var ingredientsMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu).IngredientsTable;

                    SelectionIngredientsListListView.Items.Refresh();
                    ingredientsList = ingredientsMenu.ToList();

                    SelectionIngredientsListListView.ItemsSource = ingredientsMenu.ToList();
                }
                else
                {
                    // В случае, если пользователь добавляет новое меню, то программа просто выводит стандартное изображение
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute));
                    MenuPhotoImage.Source = userImage;
                }

                // Привязка данных для соответствующих UI элементов
                pnCategoryMenuComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.ToList();
                pnSystemSIComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.SystemSITable.ToList();
                AllIngredientsListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.IngredientsTable.ToList();

                // Сортировка списка ингридиентов
                AllIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
            }
            catch (Exception exNewMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewMenuPage в NewMenuPage:\n\n " +
                        $"{exNewMenuPage.Message}");
            }
        }

        #region _Click
        private void NewMenuButton_Click(object sender, RoutedEventArgs e) /// Кнопка на добавление\редактирование меню
        {
            try
            {
                // Проверяем на пустоту поля
                messageNull = "";
                Event_MessageNull();

                if (messageNull != "")
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: $"Ошибка добавления нового блюда\n\n{messageNull}");
                }
                else
                {
                    // Проверяем поля на правильную валидность данных
                    messageValidData = "";
                    Event_MessageNull();

                    if (messageValidData != "")
                    {
                        MessageBoxClass.FailureMessageBox_MBC(textMessage: $"Ошибка добавления нового блюда\n\n{messageValidData}");
                    }
                    else
                    {
                        Event_NewDataMenu();
                    }
                }
            }
            catch (Exception exNewMenuButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewMenuButton_Click в NewMenuPage:\n\n " +
                        $"{exNewMenuButton_Click.Message}");
            }
        }

        private void NewMenuImageButton_Click(object sender, RoutedEventArgs e) /// При нажатии на кнопку открываем FileDialog и получаем путь к картинке
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; // Выбираем в OpenFileDialog формат файла

                if (openFileDialog.ShowDialog() == true)
                {
                    pathImage = openFileDialog.FileName;
                    MenuPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName)); // Вставить фото в пользовательский элемент управления
                }
            }
            catch (Exception exNewMenuImageButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие NewMenuImageButton_Click в NewMenuPage:\n\n " +
                         $"{exNewMenuImageButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
        public void Event_NewDataMenu() /// Добавление нового меню в базу данных
        {
            try
            {
                string infoAddEditDataText = "Сохранено";

                // Объявляем таблицы
                var addEditMenuTable = new MenuTable();
                var addEditImageMenuTable = new ImageMenuTable();

                if (personlNumberMenu != 0)
                {
                    infoAddEditDataText = "Изменено";

                    addEditMenuTable = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu);

                    if (addEditMenuTable.pnImageMunu_Menu != 404)
                    {
                        addEditImageMenuTable = AppConnectClass.connectDataBase_ACC.ImageMenuTable.Find(addEditMenuTable.pnImageMunu_Menu);
                    }
                }

                // Работа с основной таблицей меню
                addEditMenuTable.Name_Menu = NameMenuTextBox.Text;
                addEditMenuTable.Description_Menu = DescriptionMenuTextBox.Text;
                addEditMenuTable.pnMenuCategory_Menu = (pnCategoryMenuComboBox.SelectedItem as MenuCategoryTable).PersonalNumber_MenuCategory;
                addEditMenuTable.pnSystemSI = (pnSystemSIComboBox.SelectedItem as SystemSITable).PersonalNumber_SystemSI;
                addEditMenuTable.Prise_Menu = Convert.ToInt32(PriseMenuTextBox.Text);
                addEditMenuTable.Weight_Menu = Convert.ToInt32(WeightMenuTextBox.Text);

                // Работа с фото
                if (pathImage != "")
                {
                    // Конвертация изображения в байты
                    using (FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }

                    addEditImageMenuTable.Name_ImageMenu = $"{NameMenuTextBox.Text}";
                    addEditImageMenuTable.Image_ImageMenu = imageData;
                    AppConnectClass.connectDataBase_ACC.ImageMenuTable.AddOrUpdate(addEditImageMenuTable);

                    addEditMenuTable.pnImageMunu_Menu = addEditImageMenuTable.PersonalNumber_ImageMenu;
                }

                if (personlNumberMenu == 0 && pathImage == "")
                {
                    addEditMenuTable.pnImageMunu_Menu = 404;
                }

                AppConnectClass.connectDataBase_ACC.MenuTable.AddOrUpdate(addEditMenuTable);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                personlNumberMenu = addEditMenuTable.PersonalNumber_Menu;

                Event_SelectedIngredients();

                MessageBoxClass.GoodMessageBox_MBC(textMessage: $"{addEditMenuTable.Name_Menu} {infoAddEditDataText}");
            }
            catch (Exception exEvent_NewDataMenu)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_NewDataMenu в NewMenuPage:\n\n " +
                         $"{exEvent_NewDataMenu.Message}");
            }
        }

        private void Event_SelectedIngredients() /// Добавление списка в связь многие ко многим
        {
            try
            {
                // Ищем редактируемое меню (В случае 0, будет идти работа с новым меню, в случае с xxx будет идти работа с тем меню, которое имеет значение xxx)
                var objectMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu);

                // Очищаем список ингредиентов дял того, чтобы его перезаписать
                objectMenu.IngredientsTable.Clear();
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                // Цикл для того, чтоб добавить несколько элементов в таблицу
                foreach (var ingredient in ingredientsList)
                {
                    var objectListIngredients = ingredient as IngredientsTable;
                    objectMenu.IngredientsTable.Add(objectListIngredients);
                }

                AppConnectClass.connectDataBase_ACC.SaveChanges();
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListMenuPage());
            }
            catch (Exception exEvent_SelectedIngredients)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_SelectedIngredients в NewMenuPage:\n\n " +
                        $"{exEvent_SelectedIngredients.Message}");
            }
        }

        private void Event_MessageNull() /// Проверки полей на пустоту и валидность данных 
        {
            try
            {
                // Проверка на пустоту
                if (string.IsNullOrWhiteSpace(NameMenuTextBox.Text)) messageNull += "Вы не указали 'Название'\n";
                if (string.IsNullOrWhiteSpace(DescriptionMenuTextBox.Text)) messageNull += "Вы не указали 'Описание'\n";
                if (string.IsNullOrWhiteSpace(pnCategoryMenuComboBox.Text)) messageNull += "Вы не указали 'Категорию'\n";
                if (string.IsNullOrWhiteSpace(PriseMenuTextBox.Text)) messageNull += "Вы не указали 'Стоимость'\n";
                if (string.IsNullOrWhiteSpace(WeightMenuTextBox.Text)) messageNull += "Вы не указали 'Вес (грамм)'";

                // ПРоверка на валидность
                if (NameMenuTextBox.Text.Length <= 1) messageValidData += "'Название' не может быть меньше или быть равным 1 символу\n";
                if (DescriptionMenuTextBox.Text.Length <= 5) messageValidData += "'Описание' не может быть меньше или быть равным 5 символам\n";
                if (pnCategoryMenuComboBox.Text == "") messageValidData += "'Категория' не выбрана\n";
                if (PriseMenuTextBox.Text.Length <= 1) messageValidData += "'Стоимость' не может быть меньше или быть равным 1 символу\n";
                if (WeightMenuTextBox.Text.Length <= 1) messageValidData += "'Вес (грамм)' не может быть меньше или быть равным 1 символу\n";
            }
            catch (Exception exEvent_MessageNull)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MessageNull в NewMenuPage:\n\n " +
                        $"{exEvent_MessageNull.Message}");
            }
        }
        #endregion
        #region _MouseDoubleClick _PreviewKeyDown
        private void AllIngredientsListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) /// Событие при двойном нажатии на полный список ингредиентов
        {
            try
            {
                // получаем выбранный элемент
                var allIngredients = (IngredientsTable)AllIngredientsListListView.SelectedItem; // Получаем информацию

                if (allIngredients != null)
                {
                    // Если такого в списке нет, добавляем, иначе, удаляем
                    if (!ingredientsList.Contains(allIngredients))
                    {
                        ingredientsList.Add(allIngredients);
                    }
                    else
                    {
                        ingredientsList.Remove(allIngredients);
                    }

                    // Обновляем список
                    SelectionIngredientsListListView.ItemsSource = ingredientsList;

                    // Производим сортировку
                    AllIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
                    SelectionIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
                }
            }
            catch (Exception exAllIngredientsListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие AllIngredientsListListView_MouseDoubleClick в NewMenuPage:\n\n " +
                        $"{exAllIngredientsListListView_MouseDoubleClick.Message}");
            }
        }

        private void SelectionIngredientsListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e) /// Событие при двойном нажатии на список ингредиентов для конкретного меню
        {
            try
            {
                // получаем выбранный элемент
                var selectionIngredients = (IngredientsTable)SelectionIngredientsListListView.SelectedItem;

                // Если выбранный элемент существует, то производим его удаление
                if (selectionIngredients != null)
                {
                    ingredientsList.Remove(selectionIngredients);

                    // Обновляем список
                    SelectionIngredientsListListView.ItemsSource = ingredientsList;

                    // Производим сортировку
                    AllIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
                    SelectionIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
                }
            }
            catch (Exception exSelectionIngredientsListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие SelectionIngredientsListListView_MouseDoubleClick в NewMenuPage:\n\n " +
                        $"{exSelectionIngredientsListListView_MouseDoubleClick.Message}");
            }
        }

        private void CtrlV_PreviewKeyDown(object sender, KeyEventArgs e) /// Запретить использовать "ctrl + v" в некоторых TextBox
        {
            try
            {
                if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
                {
                    e.Handled = true;
                }
            }
            catch (Exception exCtrlV_PreviewKeyDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие CtrlV_PreviewKeyDown в NewMenuPage:\n\n " +
                         $"{exCtrlV_PreviewKeyDown.Message}");
            }
        }
        #endregion
        #region ValidData
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)  /// Разрешить писать только цифры
        {
            try
            {
                Regex NumberRegex = new Regex("[^0-9]");
                e.Handled = NumberRegex.IsMatch(e.Text);
            }
            catch (Exception exNumberValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NumberValidationTextBox в NewMenuPage:\n\n " +
                        $"{exNumberValidationTextBox.Message}");
            }
        }
        #endregion

        private void GoBackButton_Click(object sender, RoutedEventArgs e) /// Вернуться назад
        {
            try
            {
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListMenuPage());
            }
            catch (Exception exGoBackButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GoBackButton_Click в NewMenuPage:\n\n " +
                        $"{exGoBackButton_Click.Message}");
            }
        }

        private void NewIngridientToggleButton_Click(object sender, RoutedEventArgs e) /// Показать или скрыть список всех ингредиентов
        {
            try
            {
                if (NewIngridientToggleButton.IsChecked == true)
                {
                    AllIngridientBorder.Visibility = Visibility.Visible;
                    NewIngridientToggleButton.Content = "Скрыть список всех ингредиентов";
                    NewIngridientToggleButton.ToolTip = "Скрыть список всех ингредиентов";
                }
                else
                {
                    AllIngridientBorder.Visibility = Visibility.Collapsed;

                    NewIngridientToggleButton.Content = "Показать список всех ингредиентов";
                    NewIngridientToggleButton.ToolTip = "Показать список всех ингредиентов";
                }
            }
            catch (Exception exNewIngridientToggleButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewIngridientToggleButton_Click в NewMenuPage:\n\n " +
                        $"{exNewIngridientToggleButton_Click.Message}");
            }
        }
    }
}
