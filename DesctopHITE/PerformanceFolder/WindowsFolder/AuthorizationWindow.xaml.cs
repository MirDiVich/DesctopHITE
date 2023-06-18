//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном окне реализован код авторизации и код для взаимодействия пользователя с окном авторизации;
/// В случае, если пользователь не правильно введёт Login или Password 5 раз, то он обязан пройти капчу;
/// Если у пользователя достаточно прав, которые осуществляются методом "Role", то пользователя
///     пропускает в систему, иначе, пользователь просто не сможет войти;
/// Если пользователь сохранил свои данные и удачно зашёл в систему, то данные для входа в АИС
///     сохраняются на программном уровне.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class AuthorizationWindow : Window
    {
        private List<Key> sequence = new List<Key>(); // Список для хранения последовательности нажатых клавиш

        string messageNullBox;
        int quantityNoInputs = 0;
        DispatcherTimer getTimer;
        private double currentRotationAngle = 0;

        public AuthorizationWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                // Свойства для Таймера
                getTimer = new DispatcherTimer();
                getTimer.Tick += new EventHandler(Event_Timer_Tick);
                getTimer.Interval = TimeSpan.FromMilliseconds(30);

                RememberUserComboBox.SelectedItem = NoRememberItem;

                // Если пользователь в предыдущем заходе сохранил данные для входа
                if (Properties.Settings.Default.MeaningRemember == true)
                {
                    LoginUserTextBox.Text = Properties.Settings.Default.LoginUserRemember;
                    PasswordUserPasswordBox.Password = Properties.Settings.Default.PasswordUserRemember;
                    RememberUserComboBox.SelectedItem = RememberItem;

                    Event_LoginUser();
                }
            }
            catch (Exception exAuthorizationWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие AuthorizationWindow в AuthorizationWindow:\n\n " +
                    $"{exAuthorizationWindow.Message}");
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
            }
            catch (Exception exSpaseBarGrid_MouseDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие SpaseBarGrid_MouseDown в AuthorizationWindow:\n\n " +
                    $"{exSpaseBarGrid_MouseDown.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try { Application.Current.Shutdown(); }
            catch (Exception exCloseButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие CloseButton_Click в AuthorizationWindow:\n\n " +
                     $"{exCloseButton_Click.Message}");
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try { WindowState = WindowState.Minimized; }
            catch (Exception exRollupButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие RollupButton_Click в AuthorizationWindow:\n\n " +
                    $"{exRollupButton_Click.Message}");
            }
        }
        #endregion
        #region _Click
        private void LoginButton_Click(object sender, RoutedEventArgs e) // Действие при нажатии на кнопку "Войти"
        {
            try { Event_LoginUser(); }
            catch (Exception exLoginButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие LoginButton_Click в AuthorizationWindow:\n\n " +
                    $"{exLoginButton_Click.Message}");
            }
        }

        private void PasswordUserPasswordBox_KeyDown(object sender, KeyEventArgs e) // Если пользователь, находясь в PasswordBox нажал на Enter
        {
            try
            {
                if (e.Key == Key.Enter) { Event_LoginUser(); }
            }
            catch (Exception exPasswordUserPasswordBox_KeyDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие PasswordUserPasswordBox_KeyDown в AuthorizationWindow:\n\n " +
                    $"{exPasswordUserPasswordBox_KeyDown.Message}");
            }
        }
        #endregion
        #region Event_
        private void Event_Timer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                RotateTransform loadingAnimation = new RotateTransform();

                // Поворот на 10 градусов
                currentRotationAngle += 10; 

                if (currentRotationAngle >= 360)
                {
                    currentRotationAngle = 0;
                }

                loadingAnimation.Angle = currentRotationAngle;

                LoadingSpinnerTextBlock.RenderTransformOrigin = new Point(0.5, 0.5);
                LoadingSpinnerTextBlock.RenderTransform = loadingAnimation;
            }
            catch (Exception exEvent_Timer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_Timer_Tick в AuthorizationWindow:\n\n " +
                    $"{exEvent_Timer_Tick.Message}");
            }
        }

        private void Event_LoginUser() // Действие для авторизации пользователя
        {
            try
            {
                Event_ErrorNullBox();

                if (quantityNoInputs >= 5)
                {
                    // Если неправильный Login или Password введён не правильно 5 или более раз
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    captchaWindow.ShowDialog();
                    this.Close();

                    quantityNoInputs = 0;
                }
                else
                {
                    if (messageNullBox != null)
                    {
                        MessageBoxClass.FailureMessageBox_MBC(textMessage: $"{messageNullBox}");
                        messageNullBox = null;
                    }
                    else { Event_AuthorizationUser(); }
                }
            }
            catch (Exception exEvent_LoginUser)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_LoginUser в AuthorizationWindow:\n\n " +
                    $"{exEvent_LoginUser.Message}");
            }
        }

        private void Event_ErrorNullBox() // Event_ проверки текстовых полей на пустоту
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LoginUserTextBox.Text)) messageNullBox += "Поле Login пустое\n";
                if (string.IsNullOrWhiteSpace(PasswordUserPasswordBox.Password)) messageNullBox += "Поле Password пустое";
            }
            catch (Exception exEvent_ErrorNullBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_ErrorNullBox в AuthorizationWindow:\n\n " +
                    $"{exEvent_ErrorNullBox.Message}");
            }
        }

        private async void Event_AuthorizationUser() // Event_ авторизации пользователя
        {
            try
            {
                // Отключение кнопки
                LoginButton.IsEnabled = false;
                CloseButton.IsEnabled = false;
                RollupButton.IsEnabled = false;

                // Запуск анимации загрузки
                StandardTextInTheButton.Visibility = Visibility.Collapsed;
                LoadingSpinnerTextBlock.Visibility = Visibility.Visible;
                getTimer.Start();

                // Стринговые переменные, потому что без этого код не работает (всё из-за 2-го потока)
                string receiveLogin = LoginUserTextBox.Text;
                string receivePassword = PasswordUserPasswordBox.Password;

                // Переменная, которая содержит в себе информацию о пользователе
                var logInUser = await AppConnectClass.connectDataBase_ACC.WorkerTable.FirstOrDefaultAsync(DataUser => 
                        DataUser.Login_Worker == receiveLogin && DataUser.Password_Worker == receivePassword);

                // Если данные которые ввел пользователь, существуют в базе данных
                if (logInUser != null)
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();
                    MainCashWindow mainCashWindow = new MainCashWindow();
                    WaitingForANewOrderWindow waitingForANewOrderWindow = new WaitingForANewOrderWindow();

                    switch (logInUser.pnRole_Worker) // Проверяем должность пользователя
                    {
                        case 1: // Программист
                            SaveSettings();
                            AppConnectClass.receiveConnectUser_ACC = logInUser.PersonalNumber_Worker;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 2: // Администратор
                            SaveSettings();
                            AppConnectClass.receiveConnectUser_ACC = logInUser.PersonalNumber_Worker;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 3: // Кассир
                            AppConnectClass.receiveConnectUser_ACC = logInUser.PersonalNumber_Worker;
                            mainCashWindow.Show();
                            waitingForANewOrderWindow.ShowDialog();
                            this.Close();
                            break;

                        case 5: // Директор
                            SaveSettings();
                            AppConnectClass.receiveConnectUser_ACC = logInUser.PersonalNumber_Worker;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 6: // Самообслуживание
                            AppConnectClass.receiveConnectUser_ACC = logInUser.PersonalNumber_Worker;
                            mainCashWindow.Show();
                            waitingForANewOrderWindow.ShowDialog();
                            this.Close();
                            break;

                        // Для всех остальных должностей
                        default:
                            string messageDefault =
                                $"Извините {logInUser.PassportTable.Surname_Passport + " " + logInUser.PassportTable.Name_Passport} " +
                                "но для вас доступ в АИС закрыт!";
                            MessageBoxClass.FailureMessageBox_MBC(textMessage: $"{messageDefault}");
                            break;
                    }
                }
                else
                {
                    // Если данные которые ввел пользователь, не существуют в базе данных
                    string messageError = $"Извините, но пользователя с:\n\n" +
                        $"Login: {LoginUserTextBox.Text}\n" +
                        $"Password: {PasswordUserPasswordBox.Password}\n\n" +
                        $"не нашлось в нашей базе данных";

                    MessageBoxClass.FailureMessageBox_MBC(textMessage: $"{messageError}");

                    quantityNoInputs++;
                }
            }
            catch (Exception exEvent_AuthorizationUser)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_AuthorizationUser в AuthorizationWindow:\n\n " +
                    $"{exEvent_AuthorizationUser.Message}");
            }
            finally
            {
                // Остановка анимации загрузки
                StandardTextInTheButton.Visibility = Visibility.Visible;
                LoadingSpinnerTextBlock.Visibility = Visibility.Collapsed;
                getTimer.Stop();

                // Включение кнопки
                LoginButton.IsEnabled = true;
                CloseButton.IsEnabled = true;
                RollupButton.IsEnabled = true;
            }

        }

        private void Event_CapsLock() // Event_, который реагирует на нажатый CapsLock
        {
            try
            {
                bool isCapsLockOn = Console.CapsLock;

                if (isCapsLockOn)
                {
                    CapsLockTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    CapsLockTextBlock.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception exEvent_CapsLock)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_CapsLock в AuthorizationWindow:\n\n " +
                    $"{exEvent_CapsLock.Message}");
            }
        }

        public void SaveSettings() // Сохранение пользовательской информации для входа
        {
            try
            {
                if (RememberUserComboBox.SelectedItem == RememberItem)
                {
                    Properties.Settings.Default.MeaningRemember = true;
                    Properties.Settings.Default.LoginUserRemember = LoginUserTextBox.Text;
                    Properties.Settings.Default.PasswordUserRemember = PasswordUserPasswordBox.Password;

                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.MeaningRemember = false;
                    Properties.Settings.Default.LoginUserRemember = null;
                    Properties.Settings.Default.PasswordUserRemember = null;

                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception exSaveSettings)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие SaveSettings в AuthorizationWindow:\n\n " +
                     $"{exSaveSettings.Message}");
            }
        }
        #endregion
        #region Показать \ Скрыть пароль
        private void VisiblePasswordUserButton_PreviewMouseDown(object sender, MouseButtonEventArgs e) // Когда кнопка нажата
        {
            try
            {
                // Получаем содержимое PasswordBox и применяем к TextBox
                string passwordUser = Convert.ToString(PasswordUserPasswordBox.Password);
                PasswordUserTextBox.Text = passwordUser;

                PasswordPasswordGrid.Visibility = Visibility.Collapsed;
                TextPasswordGrid.Visibility = Visibility.Visible;
            }
            catch (Exception exVisiblePasswordUserButton_PreviewMouseDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие VisiblePasswordUserButton_PreviewMouseDown в AuthorizationWindow:\n\n " +
                     $"{exVisiblePasswordUserButton_PreviewMouseDown.Message}");
            }
        }

        private void VisiblePasswordUserButton_PreviewMouseUp(object sender, MouseButtonEventArgs e) // Когда кнопка отпущена
        {
            try
            {
                // Получаем содержимое TextBox и применяем к PasswordBox
                string passwordUser = Convert.ToString(PasswordUserTextBox.Text);
                PasswordUserPasswordBox.Password = passwordUser;

                PasswordPasswordGrid.Visibility = Visibility.Visible;
                TextPasswordGrid.Visibility = Visibility.Collapsed;
            }
            catch (Exception exVisiblePasswordUserButton_PreviewMouseUp)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"$Событие VisiblePasswordUserButton_PreviewMouseUp в AuthorizationWindow:\n\n " +
                     $"{exVisiblePasswordUserButton_PreviewMouseUp.Message}");
            }
        }
        #endregion
        #region Показать\Скрыть текстовае подсказки
        private void LoginUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Если в текстовом поле есть какие то символы
                if (LoginUserTextBox.Text.Length > 0)
                {
                    HintLoginTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HintLoginTextBlock.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exLoginUserTextBox_TextChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие LoginUserTextBox_TextChanged в AuthorizationWindow:\n\n " +
                     $"{exLoginUserTextBox_TextChanged.Message}");
            }
        }

        private void PasswordUserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                // Если в текстовом поле есть какие то символы
                if (PasswordUserPasswordBox.Password.Length > 0)
                {
                    HintTextPasswordTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HintTextPasswordTextBlock.Visibility = Visibility.Visible;
                }
                Event_CapsLock();
            }
            catch (Exception exPasswordUserPasswordBox_PasswordChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие PasswordUserPasswordBox_PasswordChanged в AuthorizationWindow:\n\n " +
                     $"{exPasswordUserPasswordBox_PasswordChanged.Message}");
            }
        }

        private void PasswordUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Если в текстовом поле есть какие то символы
                if (PasswordUserTextBox.Text.Length > 0)
                {
                    HintPasswordPasswordTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HintPasswordPasswordTextBlock.Visibility = Visibility.Visible;
                }
                Event_CapsLock();
            }
            catch (Exception exPasswordUserTextBox_TextChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие PasswordUserTextBox_TextChanged в AuthorizationWindow:\n\n " +
                     $"{exPasswordUserTextBox_TextChanged.Message}");
            }
        }
        #endregion
    }
}
