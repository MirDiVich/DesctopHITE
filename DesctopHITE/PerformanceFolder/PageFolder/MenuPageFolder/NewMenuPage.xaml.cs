///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class NewMenuPage : Page
    {
        IngredientsTable ingredientsTable;

        byte[] imageData;
        string pathImage = "";

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
                IngredientsListListView.ItemsSource = AppConnectClass.DataBase.IngredientsTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие NewWorkerPage в NewWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        #region Click
        private void NewMenuButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewDataMenu();
        }

        private void NewMenuImageButton_Click(object sender, System.Windows.RoutedEventArgs e) // При нажатии на кнопку открываем FileDialog и получаем путь к картинке
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
        public void NewDataMenu()
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
                else
                {
                    if (pathImage == "")
                    {
                        addEditMenuTable.pnImageMunu_Menu = addEditMenuTable.pnImageMunu_Menu;
                    }
                }

                AppConnectClass.DataBase.MenuTable.AddOrUpdate(addEditMenuTable);
                AppConnectClass.DataBase.SaveChanges();
                MessageBox.Show("Ок", "200");
            }
            catch (Exception exNewDataMenu)
            {
                MessageBoxClass.ExceptionMessage(
                         textMessage: $"Событие NewDataMenu в NewMenuPage:\n\n " +
                         $"{exNewDataMenu.Message}");
            }
        }

        private void GetSelectedIngredients()
        {

        }
        #endregion

        private void IngredientsListListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ingredientsTable = (IngredientsTable)IngredientsListListView.SelectedItem; // Получаем информацию
            }
            catch (Exception exIngredientsListListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие IngredientsListListView_SelectionChanged в NewMenuPage:\n\n " +
                        $"{exIngredientsListListView_SelectionChanged.Message}");
            }
        }
    }
}
