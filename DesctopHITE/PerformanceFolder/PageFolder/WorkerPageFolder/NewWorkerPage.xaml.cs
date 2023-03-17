using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class NewWorkerPage : Page
    {
        string PathImage = "\\ContentFolder\\ImageFolder\\NoImage.png"; // Путь к стандартному фото
        public NewWorkerPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities(); // Даём взаиможействовать этой странице с базой данных
                pnGenderComboBox.ItemsSource = AppConnectClass.DataBase.GenderTable.ToList(); // Выгружаем список Гендера в pnGenderComboBox    
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка (Error - E-001)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // Еслм страница видна
        {
            if (Visibility == Visibility.Visible)
            {
                PassportToggleButton.IsChecked = true;
                PassportBorder.Visibility = Visibility.Visible;
            }
        }

        #region Click
        private void PassportToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassportToggleButton.IsChecked == true)
            {
                PassportBorder.Visibility = Visibility.Visible;
            }
            else
            {
                PassportBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void PlaceResidenceToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceResidenceToggleButton.IsChecked == true)
            {
                PlaceResidenceBorder.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceResidenceBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void MedicalBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalBookToggleButton.IsChecked == true)
            {
                MedicalBookBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MedicalBookBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void SnilsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SnilsToggleButton.IsChecked == true)
            {
                SnilsBorder.Visibility = Visibility.Visible;
            }
            else
            {
                SnilsBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void INNToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (INNToggleButton.IsChecked == true)
            {
                INNBorder.Visibility = Visibility.Visible;
            }
            else
            {
                INNBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void SalaryCardToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryCardToggleButton.IsChecked == true)
            {
                SalaryCardBorder.Visibility = Visibility.Visible;
            }
            else
            {
                SalaryCardBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void GeneralDataToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (GeneralDataToggleButton.IsChecked == true)
            {
                GeneralDataBorder.Visibility = Visibility.Visible;
            }
            else
            {
                GeneralDataBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e) // Выполняем ряд действий, после чего добавляем нового сотрудника в базу данных
        {

        }

        private void NewPhotoButton_Click(object sender, RoutedEventArgs e) // При нажатии на кнопку открываем FileDialog и получаем путь к картинке
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; // Выбираем в OpenFileDialog формат файла
            if (openFileDialog.ShowDialog() == true) // Если пользователь выбрал содержимое
            {
                PathImage = openFileDialog.FileName; // Получение пути к выбранному файлу и записываем в переменную
                UserPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName)); ; // Вставить фото в пользовательский элемент управления
            }
        }
        #endregion
        #region Действие
        private void AddDataDatabase() // Метод для добавления нового сотрудника в базу данных
        {
            try
            {
                PassportTable AddPassport = new PassportTable()
                {

                };
                AppConnectClass.DataBase.PassportTable.Add(AddPassport);

                PlaceResidenceTable AddPlaceResidence = new PlaceResidenceTable()
                {

                };
                AppConnectClass.DataBase.PlaceResidenceTable.Add(AddPlaceResidence);

                MedicalBookTable AddMedicalBook = new MedicalBookTable()
                {

                };
                AppConnectClass.DataBase.MedicalBookTable.Add(AddMedicalBook);

                SnilsTable AddSnils = new SnilsTable()
                {

                };
                AppConnectClass.DataBase.SnilsTable.Add(AddSnils);

                INNTable AddINN = new INNTable()
                {

                };
                AppConnectClass.DataBase.INNTable.Add(AddINN);

                SalaryCardTable AddSalaryCard = new SalaryCardTable()
                {

                };
                AppConnectClass.DataBase.SalaryCardTable.Add(AddSalaryCard);

                AppConnectClass.DataBase.SaveChanges();
                MessageBox.Show(
                    "Новый сотрудник добавлен в базу данных",
                    "Сохранение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка добавления (Error - E-002)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
