using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        DateTime ToDayDate = DateTime.Today; // Получаем сегодняшнюю дату

        public NewWorkerPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities(); // Даём взаиможействовать этой странице с базой данных
                pnGenderComboBox.ItemsSource = AppConnectClass.DataBase.GenderTable.ToList(); // Выгружаем список Гендера в pnGenderComboBox    
                pnRoleWorkerComboBox.ItemsSource = AppConnectClass.DataBase.RoleTable.ToList(); // Выгружаем список Гендера в pnRoleWorkerComboBox    
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
                // Конвертация изображения в байты
                byte[] imageData;
                using (FileStream fs = new FileStream(PathImage, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }

                PassportTable AddPassport = new PassportTable()
                {
                    Series_Passport = SeriesPassportTextBox.Text,
                    Number_Passport = NumberPassportTextBox.Text,
                    Surname_Passport = SurnamePassportTextBox.Text,
                    Name_Passport = NamePassportTextBox.Text,
                    Middlename_Passport = MiddlenamePassportTextBox.Text,
                    pnGender_Passport = (pnGenderComboBox.SelectedItem as GenderTable).PersonalNumber_Gender,
                    Image_Passport = imageData,
                    DateOfBrich_Passport = Convert.ToDateTime(DateOfBrichPassportTextBox.Text),
                    LocationOfBrich_Passport = LocationOfBrichPassportTextBox.Text,
                    Issued_Passport = IssuedPassportTextBox.Text,
                    DateIssued_Passport = Convert.ToDateTime(DateIssuedPassportTextBox.Text),
                    DivisionCode_Passport = DivisionCodePassportTextBox.Text
                };
                AppConnectClass.DataBase.PassportTable.Add(AddPassport);

                PlaceResidenceTable AddPlaceResidence = new PlaceResidenceTable()
                {
                    PersonalNumber_PlaceResidence = SeriesPassportTextBox.Text + NumberPassportTextBox.Text,
                    RegistrationDate_PlaceResidence = Convert.ToDateTime(RegistrationDatePlaceResidenceTextBox.Text),
                    Region_PlaceResidence = RegionPlaceResidenceTextBox.Text,
                    District_PlaceResidence = DistrictPlaceResidenceTextBox.Text,
                    Point_PlaceResidence = PointPlaceResidenceTextBox.Text,
                    Street_PlaceResidence = StreetPlaceResidenceTextBox.Text,
                    House_PlaceResidence = HousePlaceResidenceTextBox.Text,
                    Flat_PlaceResidence = FlatPlaceResidenceTextBox.Text
                };
                AppConnectClass.DataBase.PlaceResidenceTable.Add(AddPlaceResidence);

                MedicalBookTable AddMedicalBook = new MedicalBookTable()
                {
                    PersonalNumber_MedicalBook = PersonalNumberMedicalBookTextBox.Text,
                    Issue_MedicalBook = IssueMedicalBookTextBox.Text,
                    SNMDirector_MedicalBook = SNMDirectorMedicalBookTextBox.Text,
                    DateIssue_MedicalBook = Convert.ToDateTime(DateIssueMedicalBookTextBox.Text),
                    HomeAdress_MedicalBook = HomeAdressMedicalBookTextBox.Text,
                    Role_MedicalBook = RoleMedicalBookTextBox.Text,
                    Organization_MedicalBook = OrganizationMedicalBookTextBox.Text
                };
                AppConnectClass.DataBase.MedicalBookTable.Add(AddMedicalBook);

                SnilsTable AddSnils = new SnilsTable()
                {
                    PersonalNumber_Snils = PersonalNumberSnilsTextBox.Text,
                    DateRegistration_Snils = Convert.ToDateTime(DateRegistrationSnilsTextBox.Text)
                };
                AppConnectClass.DataBase.SnilsTable.Add(AddSnils);

                INNTable AddINN = new INNTable()
                {
                    PersonalNumber_INN = PersonalNumberINNTextBox.Text,
                    TaxAuthority_INN = TaxAuthorityINNTextBox.Text,
                    NumberTaxAuthority_INN = NumberTaxAuthorityINNTextBox.Text,
                    Date_INN = Convert.ToDateTime(DateINNTextBox.Text)
                };
                AppConnectClass.DataBase.INNTable.Add(AddINN);

                SalaryCardTable AddSalaryCard = new SalaryCardTable()
                {
                    PersonalNumber_SalaryCard = PersonalNumberSalaryCardTextBox.Text,
                    NameEnd_SalaryCard = NameEndSalaryCardTextBox.Text,
                    SurnameEng_SalaryCard = SurnameEngSalaryCardTextBox.Text,
                    YearEnd_SalaryCard = YearEndSalaryCardTextBox.Text,
                    Month_SalaryCard = MonthSalaryCardTextBox.Text,
                    Code_SalaryCard = CodeSalaryCardTextBox.Text
                };
                AppConnectClass.DataBase.SalaryCardTable.Add(AddSalaryCard);

                WorkerTabe AddWorker = new WorkerTabe()
                {
                    Phone_Worker = PhoneWorkerTextBox.Text,
                    Login_Worker = LoginWorkerTextBox.Text,
                    Email_Worker = EmailWorkerTextBox.Text,
                    Password_Worker = PasswordWorkerTextBox.Text,
                    pnRole_Worker = (pnRoleWorkerComboBox.SelectedItem as RoleTable).PersonalNumber_Role,
                    SeriesPassport_Worker = AddPassport.Series_Passport,
                    NumberPassport_Worker = AddPassport.Number_Passport,
                    pnPlaceResidence_Worker = AddPlaceResidence.PersonalNumber_PlaceResidence,
                    pnMedicalBook_Worker = AddMedicalBook.PersonalNumber_MedicalBook,
                    pnSalaryCard_Worker = AddSalaryCard.PersonalNumber_SalaryCard,
                    DateWord_Worker = ToDayDate,
                    pnStatus_Worker = 1,
                    pnINN_Worker = AddINN.PersonalNumber_INN,
                    pnSnils_Worker = AddSnils.PersonalNumber_Snils
                };
                AppConnectClass.DataBase.WorkerTabe.Add(AddWorker);

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
