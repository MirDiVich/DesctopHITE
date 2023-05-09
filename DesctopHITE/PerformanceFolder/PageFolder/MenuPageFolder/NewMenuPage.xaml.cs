///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class NewMenuPage : Page
    {

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
                CategoryMenuComboBox.ItemsSource = AppConnectClass.DataBase.MenuCategoryTable.ToList();
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

        }

        private void NewMenuImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
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
            catch (Exception exNewPhotoButton_Click)
            {
                MessageBoxClass.ExceptionMessage(
                         textMessage: $"Событие NewPhotoButton_Click в NewWorkerPage:\n\n " +
                         $"{exNewPhotoButton_Click.Message}");
            }
        }
        #endregion
    }
}
