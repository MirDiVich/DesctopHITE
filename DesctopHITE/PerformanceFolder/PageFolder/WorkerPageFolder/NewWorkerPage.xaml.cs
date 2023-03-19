using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class NewWorkerPage : Page
    {
        string PathImage = "";
        DateTime ToDayDate = DateTime.Today; // Получаем сегодняшнюю дату

        string MessagePassportNull;
        string MessagePlaceResidenceNull;
        string MessageMedicalBookNull;
        string MessageSnilsNull;
        string MessageINNNull;
        string MessageSalaryCardNull;
        string MessageGeneralDataNull;
        string MessageValidData;
        string RandomPassword = null;
        string EmailWorker = "";

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
                    "Ошибка (NewWorkerPage - E-001)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // Если страница видна
        {
            if (Visibility == Visibility.Visible)
            {
                PassportToggleButton.IsChecked = true;
                PassportBorder.Visibility = Visibility.Visible;
            }
        }
        #region Color
        // Задал цвета, для того, что бы проще обращяться к ним, и менять их
        SolidColorBrush RedColor = new SolidColorBrush(Color.FromRgb(255, 7, 58));
        SolidColorBrush GreenColor = new SolidColorBrush(Color.FromRgb(57, 255, 20));
        SolidColorBrush StandardColor = new SolidColorBrush(Color.FromRgb(32, 32, 32));
        #endregion
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
            try
            {
                MessagePassportNull = "";
                MessagePlaceResidenceNull = "";
                MessageMedicalBookNull = "";
                MessageSnilsNull = "";
                MessageINNNull = "";
                MessageSalaryCardNull = "";
                MessageGeneralDataNull = "";
                MessageValidData = "";

                MessageNull(); // Вызываем метод по проверки на ошибки

                if (MessagePassportNull != "" || MessagePlaceResidenceNull != "" || MessageMedicalBookNull != "" || MessageSnilsNull != "" || MessageINNNull != "" || MessageSalaryCardNull != "" || MessageGeneralDataNull != "") // Проверка на пустые поля
                {
                    MessageBox.Show(
                        MessagePassportNull + MessagePlaceResidenceNull + MessageMedicalBookNull + MessageSnilsNull + MessageINNNull + MessageSalaryCardNull + MessageGeneralDataNull,
                        "Ошибка добавления нового сотрудника (NewWorkerPage - E-003)",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    if (MessageValidData != "") // Проверка на правилььную валлидность данных
                    {
                        MessageBox.Show(
                            MessageValidData,
                            "Ошибка добавления нового сотрудника (NewWorkerPage - E-005)",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        if (AppConnectClass.DataBase.WorkerTabe.Count(Log => Log.Login_Worker == LoginWorkerTextBox.Text) > 0) // Проверка на существующий Login в Базе данных
                        {
                            MessageBox.Show(
                               "Сотрудник с данным Login уже существует",
                               "Ошибка добавления нового сотрудника (NewWorkerPage - E-007)",
                               MessageBoxButton.OK,
                               MessageBoxImage.Error);
                        }
                        else
                        {
                            EmailWorker = EmailWorkerTextBox.Text;
                            bool isValidEmail = Regex.IsMatch(EmailWorker, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

                            if (isValidEmail)
                            {
                                AddDataDatabase();
                                ClearText();
                            }
                            else
                            {
                                MessageBox.Show(
                                   "Введите корректную электронную почту",
                                   "Ошибка добавления нового сотрудника (NewWorkerPage - E-011)",
                                   MessageBoxButton.OK,
                                   MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка добавления (NewWorkerPage - E-004)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
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
        private int RandomTextSender() // Метод, который генерирует рандомное число для подтверждения регистрации
        {
            Random random = new Random();
            return random.Next(1000000000);
        }
        private void AddDataDatabase() // Метод для добавления нового сотрудника в базу данных
        {
            try
            {
                PassportTable AddPassport = new PassportTable()
                {
                    Series_Passport = SeriesPassportTextBox.Text,
                    Number_Passport = NumberPassportTextBox.Text,
                    Surname_Passport = SurnamePassportTextBox.Text,
                    Name_Passport = NamePassportTextBox.Text,
                    Middlename_Passport = MiddlenamePassportTextBox.Text,
                    pnGender_Passport = (pnGenderComboBox.SelectedItem as GenderTable).PersonalNumber_Gender,
                    DateOfBrich_Passport = Convert.ToDateTime(DateOfBrichPassportTextBox.Text),
                    LocationOfBrich_Passport = LocationOfBrichPassportTextBox.Text,
                    Issued_Passport = IssuedPassportTextBox.Text,
                    DateIssued_Passport = Convert.ToDateTime(DateIssuedPassportTextBox.Text),
                    DivisionCode_Passport = DivisionCodePassportTextBox.Text
                };
                if (PathImage == "")
                {
                    AddPassport.Image_Passport = null;
                }
                else
                {
                    // Конвертация изображения в байты
                    byte[] imageData;
                    using (FileStream fs = new FileStream(PathImage, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }

                    AddPassport.Image_Passport = imageData;
                }
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
                    pnStatus_Worker = 2,
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
                    "Ошибка добавления (NewWorkerPage - E-002)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private void MessageNull() // Метод на проверки полей на валлидность данных 
        {
            #region MessagePassportNull
            if (string.IsNullOrWhiteSpace(SeriesPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Серию' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(NumberPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Номер' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(SurnamePassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Фамилию' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(NamePassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Имя' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(pnGenderComboBox.Text)) MessagePassportNull += "Вы не указали 'Пол' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DateOfBrichPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Дату рождения' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(LocationOfBrichPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Место рождения' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(IssuedPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Кем выдан' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DateIssuedPassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Дату выдачи' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DivisionCodePassportTextBox.Text)) MessagePassportNull += "Вы не указали 'Код подразделения' в 'Паспорт'\n";
            #endregion
            #region MessagePlaceResidenceNull
            if (string.IsNullOrWhiteSpace(RegistrationDatePlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Дату регистрации' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(RegionPlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Регион' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(DistrictPlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Район' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(PointPlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Пункт' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(StreetPlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Улицу' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(HousePlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Дом' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(HousePlaceResidenceTextBox.Text)) MessagePlaceResidenceNull += "Вы не указали 'Квартиру' в 'Место жительства'\n";
            #endregion
            #region MessageMedicalBookNull
            if (string.IsNullOrWhiteSpace(PersonalNumberMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Номер' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(IssueMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Личная медецинская книжка выдана' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(SNMDirectorMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'ФИО руководителя' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(DateIssueMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Дату выдачи' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(HomeAdressMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Домашний адресс' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(RoleMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Должность' в 'Медецинская книжка'\n";
            if (string.IsNullOrWhiteSpace(OrganizationMedicalBookTextBox.Text)) MessageMedicalBookNull += "Вы не указали 'Организацию (индивидуальный предприниматель)' в 'Медецинская книжка'\n";
            #endregion
            #region MessageSnilsNull
            if (string.IsNullOrWhiteSpace(PersonalNumberSnilsTextBox.Text)) MessageSnilsNull += "Вы не указали 'Номер' в 'СНИЛС'\n";
            if (string.IsNullOrWhiteSpace(DateRegistrationSnilsTextBox.Text)) MessageSnilsNull += "Вы не указали 'Дату выдачи' в 'СНИЛС'\n";
            #endregion
            #region MessageINNNull
            if (string.IsNullOrWhiteSpace(PersonalNumberINNTextBox.Text)) MessageINNNull += "Вы не указали 'Номер' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(TaxAuthorityINNTextBox.Text)) MessageINNNull += "Вы не указали 'Налоговый огран' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(NumberTaxAuthorityINNTextBox.Text)) MessageINNNull += "Вы не указали 'Номер налогового органа' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(DateINNTextBox.Text)) MessageINNNull += "Вы не указали 'Дату выдачи' в 'ИНН'\n";
            #endregion
            #region MessageSalaryCardNull
            if (string.IsNullOrWhiteSpace(PersonalNumberSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Номер' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(NameEndSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Имя (Eng)' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(SurnameEngSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Фамилия (Eng)' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(YearEndSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Год' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(MonthSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Месяц' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(CodeSalaryCardTextBox.Text)) MessageSalaryCardNull += "Вы не указали 'Код' в 'Заработная карта'\n";
            #endregion
            #region MessageGeneralDataNull
            if (string.IsNullOrWhiteSpace(PhoneWorkerTextBox.Text)) MessageGeneralDataNull += "Вы не указали 'Номер телефона' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(LoginWorkerTextBox.Text)) MessageGeneralDataNull += "Вы не указали 'Login' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(EmailWorkerTextBox.Text)) MessageGeneralDataNull += "Вы не указали 'Электронную почту' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(PasswordWorkerTextBox.Text)) MessageGeneralDataNull += "Вы не указали 'Password' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(pnRoleWorkerComboBox.Text)) MessageGeneralDataNull += "Вы не указали 'Должность' в 'Общие данные'\n";
            #endregion
            #region MessageValidData
            if (IssuedPassportTextBox.Text.Length <= 5) MessageValidData += "'Паспорт выдан' в 'Паспорт' не может быть меньше или быть равным 5 символам\n";
            if (DateIssuedPassportTextBox.Text.Length <= 9) MessageValidData += "'Дата выдачи' в 'Паспорт' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (DivisionCodePassportTextBox.Text.Length <= 6) MessageValidData += "'Код подразделения' в 'Паспорт' не может быть меньше или быть равным 6 символам\n";
            if (SeriesPassportTextBox.Text.Length <= 3) MessageValidData += "'Серия паспорта' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";
            if (NumberPassportTextBox.Text.Length <= 5) MessageValidData += "'Номер паспорта' в 'Паспорт' не может быть меньше или быть равным 5 символам\n";
            if (SurnamePassportTextBox.Text.Length <= 3) MessageValidData += "'Фамилия' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";
            if (NamePassportTextBox.Text.Length <= 1) MessageValidData += "'Имя' в 'Паспорт' не может быть меньше или быть равным 1 символу\n";
            if (DateOfBrichPassportTextBox.Text.Length <= 9) MessageValidData += "'Дата рождения' в 'Паспорт' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (LocationOfBrichPassportTextBox.Text.Length <= 3) MessageValidData += "'Место рождеия' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";

            if (RegistrationDatePlaceResidenceTextBox.Text.Length <= 9) MessageValidData += "'Зарегистрирован' в 'Место жительства' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (RegionPlaceResidenceTextBox.Text.Length <= 3) MessageValidData += "'Регион' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (DistrictPlaceResidenceTextBox.Text.Length <= 3) MessageValidData += "'Район' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (PointPlaceResidenceTextBox.Text.Length <= 3) MessageValidData += "'Рункт' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (StreetPlaceResidenceTextBox.Text.Length <= 3) MessageValidData += "'Улица' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (DivisionCodePassportTextBox.Text.Length <= 5) MessageValidData += "'Код подразделения' в 'Место жительства' не может быть меньше или быть равным 6 символам\n";
            if (HousePlaceResidenceTextBox.Text.Length <= 1) MessageValidData += "'Дом' в 'Место жительства' не может быть меньше или быть равным 1 символу\n";
            if (FlatPlaceResidenceTextBox.Text.Length <= 1) MessageValidData += "'Квартира' в 'Место жительства' не может быть меньше или быть равным 1 символу\n";

            if (PersonalNumberMedicalBookTextBox.Text.Length <= 7) MessageValidData += "'Номер медецинской книжки' в 'Медецинская книжка' не может быть меньше или быть равным 7 символам\n";
            if (IssueMedicalBookTextBox.Text.Length <= 3) MessageValidData += "'Личная медецинская книжка выдана' в 'Медецинская книжка' не может быть меньше или быть равным 3 символам\n";
            if (DateIssueMedicalBookTextBox.Text.Length <= 9) MessageValidData += "'Дата выдачи' в 'Медецинская книжка' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (SNMDirectorMedicalBookTextBox.Text.Length <= 5) MessageValidData += "'ФИО руководителя' в 'Медецинская книжка' не может быть меньше или быть равным 5 символам\n";
            if (HomeAdressMedicalBookTextBox.Text.Length <= 10) MessageValidData += "'Домашний адресс' в 'Медецинская книжка' не может быть меньше или быть равным 10 символам\n";
            if (RoleMedicalBookTextBox.Text.Length <= 4) MessageValidData += "'Должность' в 'Медецинская книжка' не может быть меньше или быть равным 4 символам\n";
            if (OrganizationMedicalBookTextBox.Text.Length <= 1) MessageValidData += "'Огранизация (индивидуальный предприниматель)' в 'Медецинская книжка' не может быть меньше или быть равным 1 символу\n";

            if (PersonalNumberSnilsTextBox.Text.Length <= 10) MessageValidData += "'Номер' в 'СНИЛС' не может быть меньше или быть равным 10 символам\n";
            if (DateRegistrationSnilsTextBox.Text.Length <= 9) MessageValidData += "'Дата выдачи' в 'СНИЛС' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";

            if (PersonalNumberINNTextBox.Text.Length <= 11) MessageValidData += "'Номер' в 'ИНН' не может быть меньше или быть равным 11 символам\n";
            if (NumberTaxAuthorityINNTextBox.Text.Length <= 3) MessageValidData += "'Номер Налог. орган' в 'ИНН' не может быть меньше или быть равным 3 символам\n";
            if (TaxAuthorityINNTextBox.Text.Length <= 5) MessageValidData += "'Налоговый огран' в 'ИНН' не может быть меньше или быть равным 5 символам\n";
            if (DateINNTextBox.Text.Length <= 9) MessageValidData += "'Дата выдачи' в 'ИНН' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";

            if (PersonalNumberSalaryCardTextBox.Text.Length <= 15) MessageValidData += "'Номер' в 'Заработная карта' не может быть меньше или быть равным 15 символам\n";
            if (SurnameEngSalaryCardTextBox.Text.Length <= 3) MessageValidData += "'Фимилия (Eng)' в 'Заработная карта' не может быть меньше или быть равным 3 символам\n";
            if (NameEndSalaryCardTextBox.Text.Length <= 1) MessageValidData += "'Имя (Eng)' в 'Заработная карта' не может быть меньше или быть равным 1 символу\n";
            if (MonthSalaryCardTextBox.Text.Length <= 1) MessageValidData += "'Месяц' в 'Заработная карта' не может быть меньше или быть равным 1 символу (Должно быть 2 символа(xx))\n";
            if (YearEndSalaryCardTextBox.Text.Length <= 3) MessageValidData += "'Год' в 'Заработная карта' не может быть меньше или быть равным 3 символам (Должно быть 4 символа(xxxx))\n";
            if (CodeSalaryCardTextBox.Text.Length <= 2) MessageValidData += "'Код' в 'Заработная карта' не может быть меньше или быть равным 2 символам (Должно быть 3 символа(xxx))\n";
            int MonthText = Convert.ToInt32(MonthSalaryCardTextBox.Text);
            if (MonthText > 12) MessageValidData += "'Месяц' в 'Заработная карта' не может быть больше 12\n";
            if (MonthText < 01) MessageValidData += "'Месяц' в 'Заработная карта' не может быть меньше 01\n";

            if (EmailWorkerTextBox.Text.Length <= 5) MessageValidData += "'Электронная почта' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";
            if (PhoneWorkerTextBox.Text.Length <= 10) MessageValidData += "'Номер телефона' в 'Общая информация' не может быть меньше или быть равным 10 символам\n";
            if (LoginWorkerTextBox.Text.Length <= 5) MessageValidData += "'Login' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";
            if (PasswordWorkerTextBox.Text.Length <= 5) MessageValidData += "'Password' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";
            #endregion
        }
        private void ClearText() // Очищаем все поля
        {
            try
            {
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage()); // Я решил просто переоткрывать страницу, нечиго в неё не передовая, так она должна очищаться
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка добавления (NewWorkerPage - E-009)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
        #region ValidData
        // Просто для валлидность данных (В одних TextBox разрешить писать только цифры и т.д.)
        private void DateValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex DateRegex = new Regex("[^0-9/.]");
            e.Handled = DateRegex.IsMatch(e.Text);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex NumberRegex = new Regex("[^0-9]");
            e.Handled = NumberRegex.IsMatch(e.Text);
        }
        private void DivisionCodeValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex DivisionCodeRegex = new Regex("[^0-9-]");
            e.Handled = DivisionCodeRegex.IsMatch(e.Text);
        }
        #endregion
        #region LayoutUpdated
        // Проверка на пароль
        private void RepeatPasswordWorkerPasswordBox_LayoutUpdated(object sender, EventArgs e)
        {
            try
            {
                string PasswordText, PasswordPasword;
                PasswordText = Convert.ToString(PasswordWorkerTextBox.Text);
                PasswordPasword = Convert.ToString(RepeatPasswordWorkerPasswordBox.Password);

                if (PasswordText == "")
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = StandardColor;
                }
                else if (PasswordPasword != PasswordText)
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = RedColor;
                }
                else
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = GreenColor;
                    NewWorkerButton.IsEnabled = true;
                }

                NewWorkerButton.IsEnabled = !(PasswordText == "" || PasswordPasword != PasswordText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "Ошибка добавления (NewWorkerPage - E-008)",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
        #region PreviewKeyDown
        // Запретить использовать Ctrl + v в некоторых TextBox
        private void CtrlV_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
            }
        }
        #endregion
        #region SelectionChanged
        private void pnRoleWorkerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int GetRoleWorker = Convert.ToInt32(pnRoleWorkerComboBox.SelectedValue);
            if (GetRoleWorker != 1 && GetRoleWorker != 2 && GetRoleWorker != 5)
            {
                RandomPassword = RandomTextSender().ToString("D6");

                PasswordWorkerTextBox.Text = RandomPassword;
                RepeatPasswordWorkerPasswordBox.Password = RandomPassword;
                PasswordWorkerTextBox.IsEnabled = false;
                RepeatPasswordWorkerPasswordBox.IsEnabled = false;
                LoginWorkerTextBox.Text = RandomPassword;
                LoginWorkerTextBox.IsEnabled = false;
            }
            else
            {
                PasswordWorkerTextBox.IsEnabled = true;
                RepeatPasswordWorkerPasswordBox.IsEnabled = true;
                LoginWorkerTextBox.IsEnabled = true;
            }
        }
        #endregion
    }
}
