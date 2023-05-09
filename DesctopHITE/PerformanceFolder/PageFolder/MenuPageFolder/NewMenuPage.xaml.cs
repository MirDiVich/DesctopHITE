///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.ComponentModel;
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

        public NewMenuPage()
        {
            try
            {
                InitializeComponent();

                if (DataContext != null)
                {
                    
                }
                else
                {
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute)); // Вывод стандартного фото
                    MenuPhotoImage.Source = userImage;
                }

                AppConnectClass.DataBase = new DesctopHiteEntities();
                pnCategoryMenuComboBox.ItemsSource = AppConnectClass.DataBase.MenuCategoryTable.ToList();
                AllIngredientsListListView.ItemsSource = AppConnectClass.DataBase.IngredientsTable.ToList();
                AllIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие NewWorkerPage в NewWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        #region Click
        private void NewMenuButton_Click(object sender, RoutedEventArgs e)
        {
            messageNull = "";
            MessageNull();
            
            if (messageNull != "")
            {
                MessageBox.Show(
                       messageNull, "Ошибка добавления нового блюда",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                messageValidData = "";
                MessageNull();

                if (messageValidData != "")
                {
                    MessageBox.Show(
                           messageValidData, "Ошибка добавления нового блюда",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    NewDataMenu();
                }
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
                MessageBoxClass.ExceptionMessage(
                         textMessage: $"Событие NewMenuImageButton_Click в NewMenuPage:\n\n " +
                         $"{exNewMenuImageButton_Click.Message}");
            }
        }
        #endregion
        #region Метод
        public void NewDataMenu() // Добавление нового меню в базу данных
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
                addEditMenuTable.Prise_Menu = Convert.ToDecimal(PriseMenuTextBox.Text);
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
                    if (DataContext != null) 
                    {
                        addEditImageMenuTable.PersonalNumber_ImageMenu = addEditMenuTable.pnImageMunu_Menu;
                    }

                    addEditImageMenuTable.Name_ImageMenu = $"{NameMenuTextBox.Text}";
                    addEditImageMenuTable.Image_ImageMenu = imageData;
                    AppConnectClass.DataBase.ImageMenuTable.AddOrUpdate(addEditImageMenuTable);

                    addEditMenuTable.pnImageMunu_Menu = addEditImageMenuTable.PersonalNumber_ImageMenu;
                }

                if (DataContext == null)
                {
                    if (pathImage == "")
                    {
                        addEditMenuTable.pnImageMunu_Menu = 404;
                    }
                }

                AppConnectClass.DataBase.MenuTable.AddOrUpdate(addEditMenuTable);
                AppConnectClass.DataBase.SaveChanges();

                personlNumberMenu = addEditMenuTable.PersonalNumber_Menu;

                GetSelectedIngredients();
            }
            catch (Exception exNewDataMenu)
            {
                MessageBoxClass.ExceptionMessage(
                         textMessage: $"Событие NewDataMenu в NewMenuPage:\n\n " +
                         $"{exNewDataMenu.Message}");
            }
}

        private void GetSelectedIngredients() // Добавление списка в связь многие ко многим
        {
            try
            {
                var objectMenu = AppConnectClass.DataBase.MenuTable.Find(personlNumberMenu);

                // Цикл для того, чтоб добавить несколько элементов в таблицу
                foreach (var ingredient in SelectionIngredientsListListView.Items) 
                {
                    var objectListIngredients = ingredient as IngredientsTable;
                    objectMenu.IngredientsTable.Add(objectListIngredients);
                }

                AppConnectClass.DataBase.SaveChanges();

                var nameMenu = AppConnectClass.DataBase.MenuTable.Find(personlNumberMenu);
                MessageBox.Show(
                    $"{nameMenu.Name_Menu} успешно добавленно", "Уведомление о добавлении",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                FrameNavigationClass.BodyMenu_FNC.Navigate(new NewMenuPage());
            }
            catch (Exception exGetSelectedIngredients)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetSelectedIngredients в NewMenuPage:\n\n " +
                        $"{exGetSelectedIngredients.Message}");
            }
        }

        private void MessageNull() // Метод на проверки полей на валидность данных 
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
                if (SelectionIngredientsListListView.Items.Count == 0) messageValidData += "'Ингредиенты' должны быть";
            }
            catch (Exception exMessageNull)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие MessageNull в NewMenuPage:\n\n " +
                        $"{exMessageNull.Message}");
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
            catch (Exception exIngredientsListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие IngredientsListListView_SelectionChanged в NewMenuPage:\n\n " +
                        $"{exIngredientsListListView_SelectionChanged.Message}");
            }
        }

        private void SelectionIngredientsListListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var selectionIngredients = SelectionIngredientsListListView.SelectedItem; // Получаем информацию
                SelectionIngredientsListListView.Items.Remove(selectionIngredients);
                SelectionIngredientsListListView.Items.SortDescriptions.Add(new SortDescription("Name_Ingredients", ListSortDirection.Ascending));
            }
            catch (Exception exIngredientsListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие IngredientsListListView_SelectionChanged в NewMenuPage:\n\n " +
                        $"{exIngredientsListListView_SelectionChanged.Message}");
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
                MessageBoxClass.ExceptionMessage(
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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие DateValidationTextBox в NewMenuPage:\n\n " +
                        $"{exNumberValidationTextBox.Message}");
            }
        }
        private void PriseValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex NumberRegex = new Regex("[^0-9,]");
                e.Handled = NumberRegex.IsMatch(e.Text);
            }
            catch (Exception exNumberValidationTextBox)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие DateValidationTextBox в NewMenuPage:\n\n " +
                        $"{exNumberValidationTextBox.Message}");
            }
        }
        #endregion
    }
}
