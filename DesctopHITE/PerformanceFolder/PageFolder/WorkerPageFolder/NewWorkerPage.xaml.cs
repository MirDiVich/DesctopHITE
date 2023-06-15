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

        WorkerTable workerInformation = null;

        public NewWorkerPage(WorkerTable workerTable)
        {
            try
            {
                InitializeComponent();

                // Даём взаимодействовать этой странице с базой данных
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                // Выгрузка данных из таблицы в ComboBox
                pnGenderComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.GenderTable.ToList();
                pnRoleWorkerComboBox.ItemsSource = AppConnectClass.connectDataBase_ACC.RoleTable.ToList();

                if (workerTable != null)
                {
                    DataContext = workerTable;
                    workerInformation = workerTable;

                    TitleIconNewWorkerTextBlock1.Visibility = Visibility.Collapsed;
                    TitleIconNewWorkerTextBlock2.Visibility = Visibility.Visible;
                    TitleTextNewWorkerTextBlock.Text = "Сохранить";
                }
                else
                {
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute)); // Вывод стандартного фото
                    UserPhotoImage.Source = userImage;
                }
            }
            catch (Exception exNewWorkerPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewWorkerPage в NewWorkerPage:\n\n " +
                        $"{exNewWorkerPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // Если страница видна
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    PassportToggleButton.IsChecked = true;
                    PassportBorder.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в NewWorkerPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }
        #region _Click
        #region Показать или скрыть Border
        // Так как код очень простой и короткий, было принято решение написать его в "длину"
        private void PassportToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassportToggleButton.IsChecked == true) { PassportBorder.Visibility = Visibility.Visible; }
            else { PassportBorder.Visibility = Visibility.Collapsed; }
        }

        private void PlaceResidenceToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceResidenceToggleButton.IsChecked == true) { PlaceResidenceBorder.Visibility = Visibility.Visible; }
            else { PlaceResidenceBorder.Visibility = Visibility.Collapsed; }
        }

        private void MedicalBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalBookToggleButton.IsChecked == true) { MedicalBookBorder.Visibility = Visibility.Visible; }
            else { MedicalBookBorder.Visibility = Visibility.Collapsed; }
        }

        private void SnilsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SnilsToggleButton.IsChecked == true) { SnilsBorder.Visibility = Visibility.Visible; }
            else { SnilsBorder.Visibility = Visibility.Collapsed; }
        }

        private void INNToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (INNToggleButton.IsChecked == true) { INNBorder.Visibility = Visibility.Visible; }
            else { INNBorder.Visibility = Visibility.Collapsed; }
        }

        private void SalaryCardToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SalaryCardToggleButton.IsChecked == true) { SalaryCardBorder.Visibility = Visibility.Visible; }
            else { SalaryCardBorder.Visibility = Visibility.Collapsed; }
        }

        private void GeneralDataToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (GeneralDataToggleButton.IsChecked == true) { GeneralDataBorder.Visibility = Visibility.Visible; }
            else { GeneralDataBorder.Visibility = Visibility.Collapsed; }
        }
        #endregion
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());
            }
            catch (Exception exGoBackButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие GoBackButton_Click в NewWorkerPage:\n\n " +
                         $"{exGoBackButton_Click.Message}");
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

                Event_MessageNull();

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
                        if (workerInformation == null)
                        {
                            if (AppConnectClass.connectDataBase_ACC.WorkerTable.Count(Log =>
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
                            else
                            {
                                Event_AddDataWorker();
                            }
                        }
                        else
                        {
                            Event_AddDataWorker();
                        }
                    }
                }
            }
            catch (Exception exNewWorkerButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие NewWorkerButton_Click в NewWorkerPage:\n\n " +
                         $"{exNewWorkerButton_Click.Message}");
            }
        }

        private void NewPhotoButton_Click(object sender, RoutedEventArgs e) // При нажатии на кнопку открываем FileDialog и получаем путь к картинке
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; // Выбираем в OpenFileDialog формат файла

                if (openFileDialog.ShowDialog() == true)
                {
                    pathImage = openFileDialog.FileName;
                    UserPhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName)); // Вставить фото в пользовательский элемент управления
                }
            }
            catch (Exception exNewPhotoButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие NewPhotoButton_Click в NewWorkerPage:\n\n " +
                         $"{exNewPhotoButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
        private void Event_MessageNull() // Event_ на проверки полей на валидность данных 
        {
            try
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
            catch (Exception exEvent_MessageNull)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MessageNull в NewWorkerPage:\n\n " +
                        $"{exEvent_MessageNull.Message}");
            }
        }

        private int Event_RandomTextSender() // Метод, который генерирует рандомное число для подтверждения регистрации
        {
            Random random = new Random();
            return random.Next(1000000000);
        }

        private void Event_AddDataWorker() // Метод для добавления нового сотрудника в баз данных
        {
            // Самый важный прикол. Здесь реализовано добавление в 2 таблицы "PassportTable" и "ImagePassportTable",
            // данные таблицы связанны между собой, но таблице "ImagePassportTable" нужны данные из таблицы "PassportTable", но при этом
            // таблица "PassportTable" не может добавить в себя данные, пока не узнает, есть ли подходящие данные в таблице "ImagePassportTable", которая не 
            // может жить без таблицы "PassportTable", так и получается круговорот моего бреда между таблицами, данными и программой.
            // А так же, другие таблицы на прямую не взаимодействуют с таблицей "PassportTable", но берут от неё определённые данные, к примеру, в некоторых таблицах
            // PersonalNumber_ИмяТаблицы - является серия и номер паспорта (слитно), поэтому перед добавление других данных, нужно сохранить данные в таблице "PassportTable",
            // так т получается, что у меня данные сохраняются 2 раза.
            // P.s. Да, я знаю, что я с "Дуба упал", но что поделать, такова моя задумка)

            try
            {
                // Объявляем таблицы
                var addPassport = new PassportTable();
                var addImagePassport = new ImagePassportTable();
                var addPlaceResidence = new PlaceResidenceTable();
                var addMedicalBook = new MedicalBookTable();
                var addSnils = new SnilsTable();
                var addINN = new INNTable();
                var addSalaryCard = new SalaryCardTable();
                var addWorker = new WorkerTable();

                // Работа с паспортом
                addPassport.Series_Passport = SeriesPassportTextBox.Text;
                addPassport.Number_Passport = NumberPassportTextBox.Text;
                addPassport.Surname_Passport = SurnamePassportTextBox.Text;
                addPassport.Name_Passport = NamePassportTextBox.Text;
                addPassport.Middlename_Passport = MiddlenamePassportTextBox.Text;
                addPassport.pnGender_Passport = (pnGenderComboBox.SelectedItem as GenderTable).PersonalNumber_Gender;
                addPassport.DateOfBrich_Passport = Convert.ToDateTime(DateOfBrichPassportTextBox.Text);
                addPassport.LocationOfBrich_Passport = LocationOfBrichPassportTextBox.Text;
                addPassport.Issued_Passport = IssuedPassportTextBox.Text;
                addPassport.DateIssued_Passport = Convert.ToDateTime(DateIssuedPassportTextBox.Text);
                addPassport.DivisionCode_Passport = DivisionCodePassportTextBox.Text;
                addPassport.pnImage_Passport = addPassport.pnImage_Passport;

                // Работа с фото
                if (pathImage != "")
                {
                    // Конвертация изображения в байты
                    using (FileStream fs = new FileStream(pathImage, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }
                    addImagePassport.PersonalNumber_ImagePassport = $"{SeriesPassportTextBox.Text}{NumberPassportTextBox.Text}";
                    addImagePassport.Name_ImagePassport = $"{SurnamePassportTextBox.Text} {NamePassportTextBox.Text}";
                    addImagePassport.Image_ImagePassport = imageData;

                    addPassport.pnImage_Passport = $"{SeriesPassportTextBox.Text}{NumberPassportTextBox.Text}";

                    AppConnectClass.connectDataBase_ACC.ImagePassportTable.AddOrUpdate(addImagePassport);
                }

                if (workerInformation == null)
                {
                    if (pathImage == "")
                    {
                        addPassport.pnImage_Passport = "0";
                    }
                }
                else
                {
                    if (pathImage == "")
                    {
                        addPassport.pnImage_Passport = workerInformation.PassportTable.pnImage_Passport;
                    }
                }

                AppConnectClass.connectDataBase_ACC.PassportTable.AddOrUpdate(addPassport);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                // Работа с пропиской
                addPlaceResidence.PersonalNumber_PlaceResidence = addPassport.Series_Passport + addPassport.Number_Passport;
                addPlaceResidence.RegistrationDate_PlaceResidence = Convert.ToDateTime(RegistrationDatePlaceResidenceTextBox.Text);
                addPlaceResidence.Region_PlaceResidence = RegionPlaceResidenceTextBox.Text;
                addPlaceResidence.District_PlaceResidence = DistrictPlaceResidenceTextBox.Text;
                addPlaceResidence.Point_PlaceResidence = PointPlaceResidenceTextBox.Text;
                addPlaceResidence.Street_PlaceResidence = StreetPlaceResidenceTextBox.Text;
                addPlaceResidence.House_PlaceResidence = HousePlaceResidenceTextBox.Text;
                addPlaceResidence.Flat_PlaceResidence = FlatPlaceResidenceTextBox.Text;
                AppConnectClass.connectDataBase_ACC.PlaceResidenceTable.AddOrUpdate(addPlaceResidence);

                // Работа с медицинской книжкой
                addMedicalBook.PersonalNumber_MedicalBook = PersonalNumberMedicalBookTextBox.Text;
                addMedicalBook.Issue_MedicalBook = IssueMedicalBookTextBox.Text;
                addMedicalBook.SNMDirector_MedicalBook = SNMDirectorMedicalBookTextBox.Text;
                addMedicalBook.DateIssue_MedicalBook = Convert.ToDateTime(DateIssueMedicalBookTextBox.Text);
                addMedicalBook.HomeAdress_MedicalBook = HomeAdressMedicalBookTextBox.Text;
                addMedicalBook.Role_MedicalBook = RoleMedicalBookTextBox.Text;
                addMedicalBook.Organization_MedicalBook = OrganizationMedicalBookTextBox.Text;
                AppConnectClass.connectDataBase_ACC.MedicalBookTable.AddOrUpdate(addMedicalBook);

                // Работа с СНИЛС
                addSnils.PersonalNumber_Snils = PersonalNumberSnilsTextBox.Text;
                addSnils.DateRegistration_Snils = Convert.ToDateTime(DateRegistrationSnilsTextBox.Text);
                AppConnectClass.connectDataBase_ACC.SnilsTable.AddOrUpdate(addSnils);

                // Работа с ИНН 
                addINN.PersonalNumber_INN = PersonalNumberINNTextBox.Text;
                addINN.TaxAuthority_INN = TaxAuthorityINNTextBox.Text;
                addINN.NumberTaxAuthority_INN = NumberTaxAuthorityINNTextBox.Text;
                addINN.Date_INN = Convert.ToDateTime(DateINNTextBox.Text);
                AppConnectClass.connectDataBase_ACC.INNTable.AddOrUpdate(addINN);

                // Работа с заработной картой
                addSalaryCard.PersonalNumber_SalaryCard = PersonalNumberSalaryCardTextBox.Text;
                addSalaryCard.NameEnd_SalaryCard = NameEndSalaryCardTextBox.Text;
                addSalaryCard.SurnameEng_SalaryCard = SurnameEngSalaryCardTextBox.Text;
                addSalaryCard.YearEnd_SalaryCard = YearEndSalaryCardTextBox.Text;
                addSalaryCard.Month_SalaryCard = MonthSalaryCardTextBox.Text;
                addSalaryCard.Code_SalaryCard = CodeSalaryCardTextBox.Text;
                AppConnectClass.connectDataBase_ACC.SalaryCardTable.AddOrUpdate(addSalaryCard);

                // Работа с основной таблицей
                addWorker.Phone_Worker = PhoneWorkerTextBox.Text;
                addWorker.Login_Worker = LoginWorkerTextBox.Text;
                addWorker.Email_Worker = EmailWorkerTextBox.Text;
                addWorker.Password_Worker = PasswordWorkerTextBox.Text;
                addWorker.pnRole_Worker = (pnRoleWorkerComboBox.SelectedItem as RoleTable).PersonalNumber_Role;
                addWorker.SeriesPassport_Worker = addPassport.Series_Passport;
                addWorker.NumberPassport_Worker = addPassport.Number_Passport;
                addWorker.pnPlaceResidence_Worker = addPlaceResidence.PersonalNumber_PlaceResidence;
                addWorker.pnMedicalBook_Worker = addMedicalBook.PersonalNumber_MedicalBook;
                addWorker.pnSalaryCard_Worker = addSalaryCard.PersonalNumber_SalaryCard;
                addWorker.DateWord_Worker = DateTime.Now;
                addWorker.pnINN_Worker = addINN.PersonalNumber_INN;
                addWorker.pnSnils_Worker = addSnils.PersonalNumber_Snils;
                addWorker.AddpnWorker_Worker = AppConnectClass.receiveConnectUser_ACC;

                if (workerInformation == null)
                {
                    addWorker.pnStatus_Worker = 2;
                    AppConnectClass.connectDataBase_ACC.WorkerTable.Add(addWorker);
                }
                else
                {
                    addWorker.PersonalNumber_Worker = workerInformation.PersonalNumber_Worker;
                    addWorker.pnStatus_Worker = workerInformation.pnStatus_Worker;
                    AppConnectClass.connectDataBase_ACC.WorkerTable.AddOrUpdate(addWorker);
                }

                AppConnectClass.connectDataBase_ACC.SaveChanges();

                string MessadeSaveDataWorker;
                if (workerInformation != null)
                {
                    MessadeSaveDataWorker = $"Данные об сотруднике {addPassport.Surname_Passport} {addPassport.Name_Passport} успешно изменены";
                }
                else
                {
                    MessadeSaveDataWorker = $"Сотрудник {addPassport.Surname_Passport} {addPassport.Name_Passport} добавлен в базу данных";
                }

                MessageBoxClass.GoodMessageBox_MBC(textMessage: MessadeSaveDataWorker);
                Event_ClearText();
            }
            catch (Exception exEvent_AddDataWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_AddDataWorker в NewWorkerPage:\n\n " +
                         $"{exEvent_AddDataWorker.Message}");
            }
        }

        private void Event_ClearText() // Очищаем все поля
        {
            try
            {
                // Переоткрытие страницы
                if (workerInformation == null)
                {
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new NewWorkerPage(null));
                }
                else
                {
                    FrameNavigationClass.bodyWorker_FNC.Navigate(new ListWorkerPage());
                }
            }
            catch (Exception exEvent_ClearText)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие Event_ClearText в NewWorkerPage:\n\n " +
                         $"{exEvent_ClearText.Message}");
            }
        }
        #endregion
        #region ValidData
        // Просто для валидность данных (В одних TextBox разрешить писать только цифры и т.д.)
        private void DateValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex DateRegex = new Regex("[^0-9/.]");
                e.Handled = DateRegex.IsMatch(e.Text);
            }
            catch (Exception exDateValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DateValidationTextBox в NewWorkerPage:\n\n " +
                        $"{exDateValidationTextBox.Message}");
            }
        }
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
                        textMessage: $"Событие DateValidationTextBox в NewWorkerPage:\n\n " +
                        $"{exNumberValidationTextBox.Message}");
            }
        }
        private void DivisionCodeValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            
            try
            {
                Regex DivisionCodeRegex = new Regex("[^0-9-]");
                e.Handled = DivisionCodeRegex.IsMatch(e.Text);
            }
            catch (Exception exDivisionCodeValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DivisionCodeValidationTextBox в NewWorkerPage:\n\n " +
                        $"{exDivisionCodeValidationTextBox.Message}");
            }
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
                    RepeatPasswordWorkerPasswordBox.BorderBrush = ColorClass.GetColor().GetStandardColor_CC;
                }
                else if (PasswordPasword != PasswordText)
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = ColorClass.GetColor().GetRedColor_CC;
                }
                else
                {
                    RepeatPasswordWorkerPasswordBox.BorderBrush = ColorClass.GetColor().GetGreenColor_CC;
                    NewWorkerButton.IsEnabled = true;
                }

                NewWorkerButton.IsEnabled = !(PasswordText == "" || PasswordPasword != PasswordText);
            }
            catch (Exception exRepeatPasswordWorkerPasswordBox_LayoutUpdated)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие RepeatPasswordWorkerPasswordBox_LayoutUpdated в NewWorkerPage:\n\n " +
                         $"{exRepeatPasswordWorkerPasswordBox_LayoutUpdated.Message}");
            }
        }
        #endregion
        #region PreviewKeyDown
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
                         textMessage: $"Событие CtrlV_PreviewKeyDown в NewWorkerPage:\n\n " +
                         $"{exCtrlV_PreviewKeyDown.Message}");
            }
        }
        #endregion
        #region SelectionChanged
        private void pnRoleWorkerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int GetRoleWorker = Convert.ToInt32(pnRoleWorkerComboBox.SelectedValue);

                if (GetRoleWorker != 1 && GetRoleWorker != 2 && GetRoleWorker != 5 && workerInformation == null)
                {
                    randomPassword = Event_RandomTextSender().ToString("D6");

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
            catch (Exception expnRoleWorkerComboBox_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                         textMessage: $"Событие pnRoleWorkerComboBox_SelectionChanged в NewWorkerPage:\n\n " +
                         $"{expnRoleWorkerComboBox_SelectionChanged.Message}");
            }
        }
        #endregion
    }
}
