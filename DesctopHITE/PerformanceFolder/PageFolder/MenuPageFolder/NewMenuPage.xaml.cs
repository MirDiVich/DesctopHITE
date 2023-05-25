///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
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
        byte[] imageData;

        int personlNumberMenu;

        string pathImage = "";
        string messageNull;
        string messageValidData;

        public NewMenuPage(MenuTable menuTable)
        {
            try
            {
                InitializeComponent();

                if (menuTable != null)
                {
                    DataContext = menuTable;
                    personlNumberMenu = menuTable.PersonalNumber_Menu;

                    AppConnectClass.connectDataBase_ACC.MenuTable.Include(ingredients => ingredients.IngredientsTable).Load();
                    var ingredientsMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu).IngredientsTable;

                    SelectionIngredientsListListView.Items.Refresh();
                    SelectionIngredientsListListView.ItemsSource = ingredientsMenu.ToList();
                }
                else
                {
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute)); // Вывод стандартного фото
                    MenuPhotoImage.Source = userImage;
                }

                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
                pnCategoryMenuComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.ToList();
                pnSystemSIComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.SystemSITable.ToList();
                AllIngredientsListListView.ItemsSource = AppConnectClass.connectDataBase_ACC.IngredientsTable.ToList();
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
        private void NewMenuButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                messageNull = "";
                EventMessageNull();

                if (messageNull != "")
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: $"Ошибка добавления нового блюда\n\n{messageNull}");
                }
                else
                {
                    messageValidData = "";
                    EventMessageNull();

                    if (messageValidData != "")
                    {
                        MessageBoxClass.FailureMessageBox_MBC(textMessage: $"Ошибка добавления нового блюда\n\n{messageValidData}");
                    }
                    else
                    {
                        EventNewDataMenu();
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

        private void NewMenuImageButton_Click(object sender, RoutedEventArgs e) // При нажатии на кнопку открываем FileDialog и получаем путь к картинке
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
        #region Event
        public void EventNewDataMenu() // Добавление нового меню в базу данных
        {
            try
            {
                // Объявляем таблицы
                var addEditMenuTable = new MenuTable();
                var addEditImageMenuTable = new ImageMenuTable();

                // Работа с основной таблицей меню
                addEditMenuTable.Name_Menu = NameMenuTextBox.Text;
                addEditMenuTable.Description_Menu = DescriptionMenuTextBox.Text;
                addEditMenuTable.pnMenuCategory_Menu = (pnCategoryMenuComboBox.SelectedItem as MenuCategoryTable).PersonalNumber_MenuCategory;
                addEditMenuTable.pnSystemSI = (pnSystemSIComboBox.SelectedItem as SystemSITable).PersonalNumber_SystemSI;
                addEditMenuTable.Prise_Menu = Convert.ToDecimal(PriseMenuTextBox.Text);
                addEditMenuTable.Weight_Menu = Convert.ToInt32(WeightMenuTextBox.Text);

                if (DataContext != null)
                {
                    addEditMenuTable.PersonalNumber_Menu = personlNumberMenu;
                }

                // Работа с фото
                if (pathImage != "")
                {
                    // Конвертация изображения в байты
                    using (FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }
                    if (DataContext != null) 
                    {
                        addEditImageMenuTable.PersonalNumber_ImageMenu = addEditMenuTable.pnImageMunu_Menu;
                    }

                    addEditImageMenuTable.Name_ImageMenu = $"{NameMenuTextBox.Text}";
                    addEditImageMenuTable.Image_ImageMenu = imageData;
                    AppConnectClass.connectDataBase_ACC.ImageMenuTable.AddOrUpdate(addEditImageMenuTable);

                    addEditMenuTable.pnImageMunu_Menu = addEditImageMenuTable.PersonalNumber_ImageMenu;
                }

                if (DataContext == null)
                {
                    if (pathImage == "")
                    {
                        addEditMenuTable.pnImageMunu_Menu = 404;
                    }
                }

                AppConnectClass.connectDataBase_ACC.MenuTable.AddOrUpdate(addEditMenuTable);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                personlNumberMenu = addEditMenuTable.PersonalNumber_Menu;

                EventSelectedIngredients();
            }
            catch (Exception exEventNewDataMenu)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие EventNewDataMenu в NewMenuPage:\n\n " +
                         $"{exEventNewDataMenu.Message}");
            }
}

        private void EventSelectedIngredients() // Добавление списка в связь многие ко многим
        {
            try
            {
                var objectMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu);

                // Цикл для того, чтоб добавить несколько элементов в таблицу
                foreach (var ingredient in SelectionIngredientsListListView.Items)
                {
                    var objectListIngredients = ingredient as IngredientsTable;
                    objectMenu.IngredientsTable.Add(objectListIngredients);
                }

                AppConnectClass.connectDataBase_ACC.SaveChanges();

                var nameMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(personlNumberMenu);
                MessageBoxClass.GoodMessageBox_MBC(textMessage: $"{nameMenu.Name_Menu} успешно добавлено");
                FrameNavigationClass.bodyMenu_FNC.Navigate(new NewMenuPage(null));
            }
            catch (Exception exEventSelectedIngredients)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventSelectedIngredients в NewMenuPage:\n\n " +
                        $"{exEventSelectedIngredients.Message}");
            }
        }

        private void EventMessageNull() // Event на проверки полей на валидность данных 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameMenuTextBox.Text)) messageNull += "Вы не указали 'Название'\n";
                if (string.IsNullOrWhiteSpace(DescriptionMenuTextBox.Text)) messageNull += "Вы не указали 'Описание'\n";
                if (string.IsNullOrWhiteSpace(pnCategoryMenuComboBox.Text)) messageNull += "Вы не указали 'Категорию'\n";
                if (string.IsNullOrWhiteSpace(PriseMenuTextBox.Text)) messageNull += "Вы не указали 'Стоимость'\n";
                if (string.IsNullOrWhiteSpace(WeightMenuTextBox.Text)) messageNull += "Вы не указали 'Вес (грамм)'";

                if (NameMenuTextBox.Text.Length <= 1) messageValidData += "'Название' не может быть меньше или быть равным 1 символу\n";
                if (DescriptionMenuTextBox.Text.Length <= 5) messageValidData += "'Описание' не может быть меньше или быть равным 5 символам\n";
                if (pnCategoryMenuComboBox.Text == "") messageValidData += "'Категория' не выбрана\n";
                if (PriseMenuTextBox.Text.Length <= 1) messageValidData += "'Стоимость' не может быть меньше или быть равным 1 символу\n";
                if (WeightMenuTextBox.Text.Length <= 1) messageValidData += "'Вес (грамм)' не может быть меньше или быть равным 1 символу\n";
            }
            catch (Exception exEventMessageNull)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventMessageNull в NewMenuPage:\n\n " +
                        $"{exEventMessageNull.Message}");
            }
        }
        #endregion
        #region _SelectionChanged _MouseDoubleClick _PreviewKeyDown
        private void AllIngredientsListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var allIngredients = (IngredientsTable)AllIngredientsListListView.SelectedItem; // Получаем информацию
                SelectionIngredientsListListView.Items.Add(allIngredients);
                SelectionIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
            }
            catch (Exception exAllIngredientsListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие AllIngredientsListListView_SelectionChanged в NewMenuPage:\n\n " +
                        $"{exAllIngredientsListListView_SelectionChanged.Message}");
            }
        }

        private void SelectionIngredientsListListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectionIngredients = SelectionIngredientsListListView.SelectedItem; // Получаем информацию
                SelectionIngredientsListListView.Items.Remove(selectionIngredients);
                SelectionIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
            }
            catch (Exception exSelectionIngredientsListListView_MouseDoubleClick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие SelectionIngredientsListListView_MouseDoubleClick в NewMenuPage:\n\n " +
                        $"{exSelectionIngredientsListListView_MouseDoubleClick.Message}");
            }
        }

        private void CtrlV_PreviewKeyDown(object sender, KeyEventArgs e) // Запретить использовать Ctrl + v в некоторых TextBox
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
        #region ValidData // Просто для валидность данных (В одних TextBox разрешить писать только цифры и т.д.)
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
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
        private void PriseValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex NumberRegex = new Regex("[^0-9]");
                e.Handled = NumberRegex.IsMatch(e.Text);
            }
            catch (Exception exPriseValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие PriseValidationTextBox в NewMenuPage:\n\n " +
                        $"{exPriseValidationTextBox.Message}");
            }
        }
        #endregion

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
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
    }
}
