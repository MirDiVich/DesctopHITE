///----------------------------------------------------------------------------------------------------------
/// На данной странице реализован код для добавления сотрудника или
///     изменение информации об сотруднике, если тот уже существует в базе данных;
/// На данной странице реализован код для проверки полей на пустоту и валидность данных,
///     так же реализован код для возможности в текстовые поля писать определённый набор символов;
/// Запрет в некоторые текстовые поля комбинации клавиш: ctrl + v.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using Microsoft.Win32;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class NewWorkerPage : Page
    {
        // Переменная, которая нужна для того, чтоб понять, идёт добавление пользователя или его редактирование
        int personalNumber = 0;

        byte[] imageData;
        string pathImage = "";
        string messagePassportNull;
        string messagePlaceResidenceNull;
        string messageMedicalBookNull;
        string messageSnilsNull;
        string messageINNNull;
        string messageSalaryCardNull;
        string messageGeneralDataNull;
        string messageValidData;
        string randomPassword = "";

        public NewWorkerPage(WorkerTable workerTable)
        {
            try
            {
                InitializeComponent();

                if (workerTable != null)
                {
                    DataContext = workerTable;
                    personalNumber = workerTable.PersonalNumber_Worker;

                    TitleIconNewWorkerTextBlock1.Visibility = Visibility.Collapsed;
                    TitleIconNewWorkerTextBlock2.Visibility = Visibility.Visible;
                    TitleTextNewWorkerTextBlock.Text = "Сохранить изменения";
                }
                else
                {
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute)); // Вывод стандартного фото
                    UserPhotoImage.Source = userImage;
                }

                AppConnectClass.DataBase = new DesctopHiteEntities(); // Даём взаимодействовать этой странице с базой данных

                pnGenderComboBox.ItemsSource = AppConnectClass.DataBase.GenderTable.ToList(); // Выгружаем список Гендера в pnGenderComboBox    
                pnRoleWorkerComboBox.ItemsSource = AppConnectClass.DataBase.RoleTable.ToList(); // Выгружаем список Гендера в pnRoleWorkerComboBox    
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Ошибка (NewWorkerPage - E-001)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
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
        SolidColorBrush redColor = new SolidColorBrush(Color.FromRgb(255, 7, 58));
        SolidColorBrush greenColor = new SolidColorBrush(Color.FromRgb(57, 255, 20));
        SolidColorBrush standardColor = new SolidColorBrush(Color.FromRgb(32, 32, 32));

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
                messagePassportNull = "";
                messagePlaceResidenceNull = "";
                messageMedicalBookNull = "";
                messageSnilsNull = "";
                messageINNNull = "";
                messageSalaryCardNull = "";
                messageGeneralDataNull = "";
                messageValidData = "";

                // Вызов метода
                MessageNull();

                if (messagePassportNull != "" ||
                    messagePlaceResidenceNull != "" ||
                    messageMedicalBookNull != "" ||
                    messageSnilsNull != "" ||
                    messageINNNull != "" ||
                    messageSalaryCardNull != "" ||
                    messageGeneralDataNull != "") // Проверка на пустые поля
                {
                    string messagePassport =
                        messagePassportNull +
                        messagePlaceResidenceNull +
                        messageMedicalBookNull +
                        messageSnilsNull +
                        messageINNNull +
                        messageSalaryCardNull +
                        messageGeneralDataNull;

                    MessageBox.Show(
                        messagePassport, "Ошибка добавления нового сотрудника (NewWorkerPage - E-003)",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (messageValidData != "") // Проверка на правильную валидность данных
                    {
                        MessageBox.Show(
                            messageValidData, "Ошибка добавления нового сотрудника (NewWorkerPage - E-005)",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (personalNumber == 0)
                        {
                            if (AppConnectClass.DataBase.WorkerTable.Count(Log =>
                                Log.Login_Worker == LoginWorkerTextBox.Text &&
                                Log.Email_Worker == EmailWorkerTextBox.Text &&
                                Log.SeriesPassport_Worker == SeriesPassportTextBox.Text || Log.NumberPassport_Worker == NumberPassportTextBox.Text &&
                                Log.pnMedicalBook_Worker == PersonalNumberMedicalBookTextBox.Text &&
                                Log.pnSalaryCard_Worker == PersonalNumberSalaryCardTextBox.Text &&
                                Log.pnINN_Worker == PersonalNumberINNTextBox.Text &&
                                Log.pnSnils_Worker == PersonalNumberSnilsTextBox.Text) > 0)
                            {
                                MessageBox.Show(
                                   "Сотрудник с такими данными уже существует", "Ошибка добавления нового сотрудника (NewWorkerPage - E-007)",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            // Вызов метода
                            AddDataDatabase();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Ошибка добавления (NewWorkerPage - E-004)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewPhotoButton_Click(object sender, RoutedEventArgs e) // При нажатии на кнопку открываем FileDialog и получаем путь к картинке
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; // Выбираем в OpenFileDialog формат файла

            if (openFileDialog.ShowDialog() == true) // Если пользователь выбрал содержимое
            {
                pathImage = openFileDialog.FileName; // Получение пути к выбранному файлу и записываем в переменную
                UserPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName)); // Вставить фото в пользовательский элемент управления
            }
        }

        #endregion
        #region Метод

        private int RandomTextSender() // Метод, который генерирует рандомное число для подтверждения регистрации
        {
            Random random = new Random();
            return random.Next(1000000000);
        }

        private void AddDataDatabase() // Метод для добавления нового сотрудника в баз данных
        {
            try
            {
                PassportTable addPassport = new PassportTable()
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

                ImagePassportTable addImagePassport = new ImagePassportTable();
                if (pathImage != "")
                {
                    // Конвертация изображения в байты
                    using (FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }

                    addImagePassport.PersonalNumber_ImagePassport = addPassport.Series_Passport + addPassport.Number_Passport;
                    addImagePassport.Name_ImagePassport = $"{addPassport.Surname_Passport} {addPassport.Name_Passport}";
                    addImagePassport.Image_ImagePassport = imageData;

                    if (personalNumber != 0)
                    {
                        AppConnectClass.DataBase.ImagePassportTable.AddOrUpdate(addImagePassport);
                    }
                    else
                    {
                        AppConnectClass.DataBase.ImagePassportTable.Add(addImagePassport);
                    }
                }

                if (personalNumber != 0)
                {
                    if (pathImage != "")
                    {
                        addPassport.pnImage_Passport = addImagePassport.PersonalNumber_ImagePassport;
                    }
                    else
                    {
                        addPassport.pnImage_Passport = "0         ";
                    }

                    AppConnectClass.DataBase.PassportTable.AddOrUpdate(addPassport);
                }
                else
                {
                    if (pathImage != "")
                    {
                        addPassport.pnImage_Passport = addImagePassport.PersonalNumber_ImagePassport;
                    }
                    else
                    {
                        addPassport.pnImage_Passport = "0         ";
                    }
                    AppConnectClass.DataBase.PassportTable.Add(addPassport);
                }

                PlaceResidenceTable addPlaceResidence = new PlaceResidenceTable()
                {
                    PersonalNumber_PlaceResidence = addPassport.Series_Passport + addPassport.Number_Passport,
                    RegistrationDate_PlaceResidence = Convert.ToDateTime(RegistrationDatePlaceResidenceTextBox.Text),
                    Region_PlaceResidence = RegionPlaceResidenceTextBox.Text,
                    District_PlaceResidence = DistrictPlaceResidenceTextBox.Text,
                    Point_PlaceResidence = PointPlaceResidenceTextBox.Text,
                    Street_PlaceResidence = StreetPlaceResidenceTextBox.Text,
                    House_PlaceResidence = HousePlaceResidenceTextBox.Text,
                    Flat_PlaceResidence = FlatPlaceResidenceTextBox.Text
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.PlaceResidenceTable.AddOrUpdate(addPlaceResidence);
                }
                else
                {
                    AppConnectClass.DataBase.PlaceResidenceTable.Add(addPlaceResidence);
                }

                MedicalBookTable addMedicalBook = new MedicalBookTable()
                {
                    PersonalNumber_MedicalBook = PersonalNumberMedicalBookTextBox.Text,
                    Issue_MedicalBook = IssueMedicalBookTextBox.Text,
                    SNMDirector_MedicalBook = SNMDirectorMedicalBookTextBox.Text,
                    DateIssue_MedicalBook = Convert.ToDateTime(DateIssueMedicalBookTextBox.Text),
                    HomeAdress_MedicalBook = HomeAdressMedicalBookTextBox.Text,
                    Role_MedicalBook = RoleMedicalBookTextBox.Text,
                    Organization_MedicalBook = OrganizationMedicalBookTextBox.Text
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.MedicalBookTable.AddOrUpdate(addMedicalBook);
                }
                else
                {
                    AppConnectClass.DataBase.MedicalBookTable.Add(addMedicalBook);
                }

                SnilsTable addSnils = new SnilsTable()
                {
                    PersonalNumber_Snils = PersonalNumberSnilsTextBox.Text,
                    DateRegistration_Snils = Convert.ToDateTime(DateRegistrationSnilsTextBox.Text)
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.SnilsTable.AddOrUpdate(addSnils);
                }
                else
                {
                    AppConnectClass.DataBase.SnilsTable.Add(addSnils);
                }

                INNTable addINN = new INNTable()
                {
                    PersonalNumber_INN = PersonalNumberINNTextBox.Text,
                    TaxAuthority_INN = TaxAuthorityINNTextBox.Text,
                    NumberTaxAuthority_INN = NumberTaxAuthorityINNTextBox.Text,
                    Date_INN = Convert.ToDateTime(DateINNTextBox.Text)
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.INNTable.AddOrUpdate(addINN);
                }
                else
                {
                    AppConnectClass.DataBase.INNTable.Add(addINN);
                }

                SalaryCardTable addSalaryCard = new SalaryCardTable()
                {
                    PersonalNumber_SalaryCard = PersonalNumberSalaryCardTextBox.Text,
                    NameEnd_SalaryCard = NameEndSalaryCardTextBox.Text,
                    SurnameEng_SalaryCard = SurnameEngSalaryCardTextBox.Text,
                    YearEnd_SalaryCard = YearEndSalaryCardTextBox.Text,
                    Month_SalaryCard = MonthSalaryCardTextBox.Text,
                    Code_SalaryCard = CodeSalaryCardTextBox.Text
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.SalaryCardTable.AddOrUpdate(addSalaryCard);
                }
                else
                {
                    AppConnectClass.DataBase.SalaryCardTable.Add(addSalaryCard);
                }

                WorkerTable addWorker = new WorkerTable()
                {
                    Phone_Worker = PhoneWorkerTextBox.Text,
                    Login_Worker = LoginWorkerTextBox.Text,
                    Email_Worker = EmailWorkerTextBox.Text,
                    Password_Worker = PasswordWorkerTextBox.Text,
                    pnRole_Worker = (pnRoleWorkerComboBox.SelectedItem as RoleTable).PersonalNumber_Role,
                    SeriesPassport_Worker = addPassport.Series_Passport,
                    NumberPassport_Worker = addPassport.Number_Passport,
                    pnPlaceResidence_Worker = addPlaceResidence.PersonalNumber_PlaceResidence,
                    pnMedicalBook_Worker = addMedicalBook.PersonalNumber_MedicalBook,
                    pnSalaryCard_Worker = addSalaryCard.PersonalNumber_SalaryCard,
                    DateWord_Worker = DateTime.Now,
                    pnINN_Worker = addINN.PersonalNumber_INN,
                    pnSnils_Worker = addSnils.PersonalNumber_Snils,
                    AddpnWorker_Worker = AppConnectClass.GetUser.PersonalNumber_Worker
                };
                if (personalNumber != 0)
                {
                    AppConnectClass.DataBase.WorkerTable.AddOrUpdate(addWorker);
                }
                else
                {
                    addWorker.pnStatus_Worker = 2;
                    AppConnectClass.DataBase.WorkerTable.Add(addWorker);
                }

                AppConnectClass.DataBase.SaveChanges();

                MessageBox.Show(
                        "Новый сотрудник добавлен в базу данных", "Сохранение",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                // Вызов метода
                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Ошибка добавления (NewWorkerPage - E-002)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MessageNull() // Метод на проверки полей на валидность данных 
        {
            #region messagePassportNull

            if (string.IsNullOrWhiteSpace(SeriesPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Серию' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(NumberPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Номер' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(SurnamePassportTextBox.Text)) messagePassportNull += "Вы не указали 'Фамилию' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(NamePassportTextBox.Text)) messagePassportNull += "Вы не указали 'Имя' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(pnGenderComboBox.Text)) messagePassportNull += "Вы не указали 'Пол' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DateOfBrichPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Дату рождения' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(LocationOfBrichPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Место рождения' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(IssuedPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Кем выдан' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DateIssuedPassportTextBox.Text)) messagePassportNull += "Вы не указали 'Дату выдачи' в 'Паспорт'\n";
            if (string.IsNullOrWhiteSpace(DivisionCodePassportTextBox.Text)) messagePassportNull += "Вы не указали 'Код подразделения' в 'Паспорт'\n";

            #endregion
            #region messagePlaceResidenceNull

            if (string.IsNullOrWhiteSpace(RegistrationDatePlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Дату регистрации' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(RegionPlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Регион' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(DistrictPlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Район' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(PointPlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Пункт' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(StreetPlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Улицу' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(HousePlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Дом' в 'Место жительства'\n";
            if (string.IsNullOrWhiteSpace(HousePlaceResidenceTextBox.Text)) messagePlaceResidenceNull += "Вы не указали 'Квартиру' в 'Место жительства'\n";

            #endregion
            #region messageMedicalBookNull

            if (string.IsNullOrWhiteSpace(PersonalNumberMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Номер' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(IssueMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Личная медицинская книжка выдана' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(SNMDirectorMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'ФИО руководителя' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(DateIssueMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Дату выдачи' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(HomeAdressMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Домашний адрес' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(RoleMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Должность' в 'медицинская книжка'\n";
            if (string.IsNullOrWhiteSpace(OrganizationMedicalBookTextBox.Text)) messageMedicalBookNull += "Вы не указали 'Организацию (индивидуальный предприниматель)' в 'медицинская книжка'\n";

            #endregion
            #region messageSnilsNull

            if (string.IsNullOrWhiteSpace(PersonalNumberSnilsTextBox.Text)) messageSnilsNull += "Вы не указали 'Номер' в 'СНИЛС'\n";
            if (string.IsNullOrWhiteSpace(DateRegistrationSnilsTextBox.Text)) messageSnilsNull += "Вы не указали 'Дату выдачи' в 'СНИЛС'\n";

            #endregion
            #region messageINNNull

            if (string.IsNullOrWhiteSpace(PersonalNumberINNTextBox.Text)) messageINNNull += "Вы не указали 'Номер' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(TaxAuthorityINNTextBox.Text)) messageINNNull += "Вы не указали 'Налоговый орган' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(NumberTaxAuthorityINNTextBox.Text)) messageINNNull += "Вы не указали 'Номер налогового органа' в 'ИНН'\n";
            if (string.IsNullOrWhiteSpace(DateINNTextBox.Text)) messageINNNull += "Вы не указали 'Дату выдачи' в 'ИНН'\n";

            #endregion
            #region messageSalaryCardNull

            if (string.IsNullOrWhiteSpace(PersonalNumberSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Номер' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(NameEndSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Имя (Eng)' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(SurnameEngSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Фамилия (Eng)' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(YearEndSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Год' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(MonthSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Месяц' в 'Заработная карта'\n";
            if (string.IsNullOrWhiteSpace(CodeSalaryCardTextBox.Text)) messageSalaryCardNull += "Вы не указали 'Код' в 'Заработная карта'\n";

            #endregion
            #region messageGeneralDataNull

            if (string.IsNullOrWhiteSpace(PhoneWorkerTextBox.Text)) messageGeneralDataNull += "Вы не указали 'Номер телефона' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(LoginWorkerTextBox.Text)) messageGeneralDataNull += "Вы не указали 'Login' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(EmailWorkerTextBox.Text)) messageGeneralDataNull += "Вы не указали 'Электронную почту' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(PasswordWorkerTextBox.Text)) messageGeneralDataNull += "Вы не указали 'Password' в 'Общие данные'\n";
            if (string.IsNullOrWhiteSpace(pnRoleWorkerComboBox.Text)) messageGeneralDataNull += "Вы не указали 'Должность' в 'Общие данные'\n";

            #endregion
            #region messageValidData

            if (IssuedPassportTextBox.Text.Length <= 5) messageValidData += "'Паспорт выдан' в 'Паспорт' не может быть меньше или быть равным 5 символам\n";
            if (DateIssuedPassportTextBox.Text.Length <= 9) messageValidData += "'Дата выдачи' в 'Паспорт' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (DivisionCodePassportTextBox.Text.Length <= 6) messageValidData += "'Код подразделения' в 'Паспорт' не может быть меньше или быть равным 6 символам\n";
            if (SeriesPassportTextBox.Text.Length <= 3) messageValidData += "'Серия паспорта' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";
            if (NumberPassportTextBox.Text.Length <= 5) messageValidData += "'Номер паспорта' в 'Паспорт' не может быть меньше или быть равным 5 символам\n";
            if (SurnamePassportTextBox.Text.Length <= 3) messageValidData += "'Фамилия' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";
            if (NamePassportTextBox.Text.Length <= 1) messageValidData += "'Имя' в 'Паспорт' не может быть меньше или быть равным 1 символу\n";
            if (DateOfBrichPassportTextBox.Text.Length <= 9) messageValidData += "'Дата рождения' в 'Паспорт' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (LocationOfBrichPassportTextBox.Text.Length <= 3) messageValidData += "'Место рождения' в 'Паспорт' не может быть меньше или быть равным 3 символам\n";

            if (RegistrationDatePlaceResidenceTextBox.Text.Length <= 9) messageValidData += "'Зарегистрирован' в 'Место жительства' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (RegionPlaceResidenceTextBox.Text.Length <= 3) messageValidData += "'Регион' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (DistrictPlaceResidenceTextBox.Text.Length <= 3) messageValidData += "'Район' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (PointPlaceResidenceTextBox.Text.Length <= 3) messageValidData += "'Пункт' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (StreetPlaceResidenceTextBox.Text.Length <= 3) messageValidData += "'Улица' в 'Место жительства' не может быть меньше или быть равным 3 символам\n";
            if (DivisionCodePassportTextBox.Text.Length <= 5) messageValidData += "'Код подразделения' в 'Место жительства' не может быть меньше или быть равным 6 символам\n";
            if (HousePlaceResidenceTextBox.Text.Length <= 1) messageValidData += "'Дом' в 'Место жительства' не может быть меньше или быть равным 1 символу\n";
            if (FlatPlaceResidenceTextBox.Text.Length <= 1) messageValidData += "'Квартира' в 'Место жительства' не может быть меньше или быть равным 1 символу\n";

            if (PersonalNumberMedicalBookTextBox.Text.Length <= 7) messageValidData += "'Номер медицинской книжки' в 'медицинская книжка' не может быть меньше или быть равным 7 символам\n";
            if (IssueMedicalBookTextBox.Text.Length <= 3) messageValidData += "'Личная медицинская книжка выдана' в 'медицинская книжка' не может быть меньше или быть равным 3 символам\n";
            if (DateIssueMedicalBookTextBox.Text.Length <= 9) messageValidData += "'Дата выдачи' в 'медицинская книжка' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";
            if (SNMDirectorMedicalBookTextBox.Text.Length <= 5) messageValidData += "'ФИО руководителя' в 'медицинская книжка' не может быть меньше или быть равным 5 символам\n";
            if (HomeAdressMedicalBookTextBox.Text.Length <= 10) messageValidData += "'Домашний адрес' в 'медицинская книжка' не может быть меньше или быть равным 10 символам\n";
            if (RoleMedicalBookTextBox.Text.Length <= 4) messageValidData += "'Должность' в 'медицинская книжка' не может быть меньше или быть равным 4 символам\n";
            if (OrganizationMedicalBookTextBox.Text.Length <= 1) messageValidData += "'Организация (индивидуальный предприниматель)' в 'медицинская книжка' не может быть меньше или быть равным 1 символу\n";

            if (PersonalNumberSnilsTextBox.Text.Length <= 10) messageValidData += "'Номер' в 'СНИЛС' не может быть меньше или быть равным 10 символам\n";
            if (DateRegistrationSnilsTextBox.Text.Length <= 9) messageValidData += "'Дата выдачи' в 'СНИЛС' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";

            if (PersonalNumberINNTextBox.Text.Length <= 11) messageValidData += "'Номер' в 'ИНН' не может быть меньше или быть равным 11 символам\n";
            if (NumberTaxAuthorityINNTextBox.Text.Length <= 3) messageValidData += "'Номер Налог. орган' в 'ИНН' не может быть меньше или быть равным 3 символам\n";
            if (TaxAuthorityINNTextBox.Text.Length <= 5) messageValidData += "'Налоговый орган' в 'ИНН' не может быть меньше или быть равным 5 символам\n";
            if (DateINNTextBox.Text.Length <= 9) messageValidData += "'Дата выдачи' в 'ИНН' не может быть меньше или быть равным 9 символам (Должно быть 10 символов(xx.xx.xxxx))\n";

            if (PersonalNumberSalaryCardTextBox.Text.Length <= 15) messageValidData += "'Номер' в 'Заработная карта' не может быть меньше или быть равным 15 символам\n";
            if (SurnameEngSalaryCardTextBox.Text.Length <= 3) messageValidData += "'Фамилия (Eng)' в 'Заработная карта' не может быть меньше или быть равным 3 символам\n";
            if (NameEndSalaryCardTextBox.Text.Length <= 1) messageValidData += "'Имя (Eng)' в 'Заработная карта' не может быть меньше или быть равным 1 символу\n";
            if (MonthSalaryCardTextBox.Text.Length <= 1) messageValidData += "'Месяц' в 'Заработная карта' не может быть меньше или быть равным 1 символу (Должно быть 2 символа(xx))\n";
            if (YearEndSalaryCardTextBox.Text.Length <= 3) messageValidData += "'Год' в 'Заработная карта' не может быть меньше или быть равным 3 символам (Должно быть 4 символа(xxxx))\n";
            if (CodeSalaryCardTextBox.Text.Length <= 2) messageValidData += "'Код' в 'Заработная карта' не может быть меньше или быть равным 2 символам (Должно быть 3 символа(xxx))\n";

            int MonthText = Convert.ToInt32(MonthSalaryCardTextBox.Text);
            if (MonthText > 12) messageValidData += "'Месяц' в 'Заработная карта' не может быть больше 12\n";
            if (MonthText < 01) messageValidData += "'Месяц' в 'Заработная карта' не может быть меньше 01\n";

            if (EmailWorkerTextBox.Text.Length <= 5) messageValidData += "'Электронная почта' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";
            if (PhoneWorkerTextBox.Text.Length <= 10) messageValidData += "'Номер телефона' в 'Общая информация' не может быть меньше или быть равным 10 символам\n";
            if (LoginWorkerTextBox.Text.Length <= 5) messageValidData += "'Login' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";
            if (PasswordWorkerTextBox.Text.Length <= 5) messageValidData += "'Password' в 'Общая информация' не может быть меньше или быть равным 5 символам\n";

            string emailWorker = EmailWorkerTextBox.Text;
            bool isValidEmail = Regex.IsMatch(emailWorker, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (isValidEmail) { }
            else
            {
                messageValidData += "'Email' в 'Общая информация' не не корректный";
            }

            #endregion
        }

        private void ClearText() // Очищаем все поля
        {
            try
            {
                FrameNavigationClass.BodyWorker_FNC.Navigate(new NewWorkerPage(null)); // Переоткрытие страницы
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Ошибка добавления (NewWorkerPage - E-009)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
        #region ValidData
        // Просто для валидность данных (В одних TextBox разрешить писать только цифры и т.д.)
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

        private void RepeatPasswordWorkerPasswordBox_LayoutUpdated(object sender, EventArgs e) // Проверка на пароль
        {
            try
            {
                string PasswordText, PasswordPasword;
                PasswordText = Convert.ToString(PasswordWorkerTextBox.Text);
                PasswordPasword = Convert.ToString(RepeatPasswordWorkerPasswordBox.Password);

                if (PasswordText == "")
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = standardColor;
                }
                else if (PasswordPasword != PasswordText)
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = redColor;
                }
                else
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = greenColor;
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

        private void CtrlV_PreviewKeyDown(object sender, KeyEventArgs e) // Запретить использовать Ctrl + v в некоторых TextBox
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

            if (GetRoleWorker != 1 && GetRoleWorker != 2 && GetRoleWorker != 5 && personalNumber == 0)
            {
                randomPassword = RandomTextSender().ToString("D6");

                PasswordWorkerTextBox.Text = randomPassword;
                RepeatPasswordWorkerPasswordBox.Password = randomPassword;
                PasswordWorkerTextBox.IsEnabled = false;
                RepeatPasswordWorkerPasswordBox.IsEnabled = false;
                LoginWorkerTextBox.Text = randomPassword;
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
