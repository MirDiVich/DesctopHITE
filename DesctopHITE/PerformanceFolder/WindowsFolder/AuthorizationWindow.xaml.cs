///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код авторизации и код для взаимодействия пользователя с окном авторизации;
/// В случае, если пользователь не правильно введёт Login или Password 5 раз, то он обязан пройти капчу;
/// Если у пользователя достаточно прав, которые осуществляются методом "Role", то пользователя
///     пропускает в систему, иначе, пользователь просто не сможет войти;
/// Если пользователь сохранил свои данные и удачно зашёл в систему, то данные для входа в АИС
///     сохраняются на программном уровне.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class AuthorizationWindow : Window
    {
        string messageNullBox;
        int quantityNoInputs = 0;
        DispatcherTimer getTimer;
        private double currentRotationAngle = 0;

        public AuthorizationWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();

                // Свойства для Таймера
                getTimer = new DispatcherTimer();
                getTimer.Tick += new EventHandler(GetTimer_Tick);
                getTimer.Interval = TimeSpan.FromMilliseconds(30);

                RememberUserComboBox.SelectedItem = NoRememberItem;

                // Если пользователь в предыдущем заходе сохранил данные для входа
                if (Properties.Settings.Default.MeaningRemember == true)
                {
                    LoginUserTextBox.Text = Properties.Settings.Default.LoginUserRemember;
                    PasswordUserPasswordBox.Password = Properties.Settings.Default.PasswordUserRemember;
                    RememberUserComboBox.SelectedItem = RememberItem;

                    
                    LoginUser();
                }
            }
            catch (Exception ex)
            {
               var nameMessageOne = $"Ошибка (AuthorizationWindowError - 001)";
               var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception exSpaseBar)
            {
                var nameMessageSpaseBar = $"Ошибка (AuthorizationWindowError - 002)";
                var titleMessageSpaseBar = $"{exSpaseBar.Message}";
                MessageBox.Show(
                    nameMessageSpaseBar, titleMessageSpaseBar,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception exClose)
            {
                var nameMessageClose = $"Ошибка (AuthorizationWindowError - 003)";
                var titleMessageClose = $"{exClose.Message}";
                MessageBox.Show(
                    nameMessageClose, titleMessageClose,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception exRollup)
            {
                var nameMessageRollup = $"Ошибка (AuthorizationWindowError - 004)";
                var titleMessageRollup = $"{exRollup.Message}";
                MessageBox.Show(
                    nameMessageRollup, titleMessageRollup,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Click
        private void LoginButton_Click(object sender, RoutedEventArgs e) // Действие при нажатии на кнопку "Войти"
        {
            try
            {
                LoginUser();
            }
            catch (Exception exLogin0)
            {
                var nameMessageLogin0 = $"Ошибка (AuthorizationWindowError - 005)";
                var titleMessageLogin0 = $"{exLogin0.Message}";
                MessageBox.Show(
                    nameMessageLogin0, titleMessageLogin0,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }   
        }

        private void PasswordUserPasswordBox_KeyDown(object sender, KeyEventArgs e) // Если пользователь, находясь в PasswordBox нажал на Enter
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    LoginUser();
                }
                catch (Exception exLogin1)
                {
                    var nameMessageLogin1 = $"Ошибка (AuthorizationWindowError - 006)";
                    var titleMessageLogin1 = $"{exLogin1.Message}";
                    MessageBox.Show(
                        nameMessageLogin1, titleMessageLogin1,
                        MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
        }
        #endregion
        #region Метод
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
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
            catch (Exception exGetTimer)
            {
                var nameMessageGetTimer = $"Ошибка (AuthorizationWindowError - 007)";
                var titleMessageGetTimer = $"{exGetTimer.Message}";
                MessageBox.Show(
                    nameMessageGetTimer, titleMessageGetTimer,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void LoginUser() // Действие для авторизации пользователя
        {
            try
            {
                ErrorNullBox();

                if (quantityNoInputs >= 5)
                {
                    // Если неправильный Login или Password введён не правильно 5 или более раз
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    captchaWindow.ShowDialog();

                    quantityNoInputs = 0;
                }
                else
                {
                    if (messageNullBox != null)
                    {
                        MessageBox.Show(
                            messageNullBox, "Авторизация",
                            MessageBoxButton.OK, MessageBoxImage.Warning);

                        messageNullBox = null;
                    }
                    else
                    {
                        
                        DateUser();
                    }
                }
            }
            catch (Exception exLoginUser)
            {
                var nameMessageLoginUser = $"Ошибка (AuthorizationWindowError - 008)";
                var titleMessageLoginUser = $"{exLoginUser.Message}";
                MessageBox.Show(
                    nameMessageLoginUser, titleMessageLoginUser,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void ErrorNullBox() // Метод проверки текстовых полей на пустоту
        {
            try
            {
                if (string.IsNullOrWhiteSpace(LoginUserTextBox.Text)) messageNullBox += "Поле Login пустое\n";
                if (string.IsNullOrWhiteSpace(PasswordUserPasswordBox.Password)) messageNullBox += "Поле Password пустое";
            }
            catch (Exception exErrorNullBox)
            {
                var nameMessageErrorNullBox = $"Ошибка (AuthorizationWindowError - 009)";
                var titleMessageErrorNullBox = $"{exErrorNullBox.Message}";
                MessageBox.Show(
                    nameMessageErrorNullBox, titleMessageErrorNullBox,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private async void DateUser() // Метод авторизации пользователя
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
                var logInUser = await AppConnectClass.DataBase.WorkerTable.FirstOrDefaultAsync(DataUser => 
                        DataUser.Login_Worker == receiveLogin && DataUser.Password_Worker == receivePassword);

                // Если данные которые ввел пользователь, существуют в базе данных
                if (logInUser != null)
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();

                    switch (logInUser.pnRole_Worker) // Проверяем должность пользователя
                    {
                        case 1:
                            SaveSettings();
                            AppConnectClass.GetUser = logInUser;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 2:
                            SaveSettings();
                            AppConnectClass.GetUser = logInUser;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 3:
                            SaveSettings();
                            AppConnectClass.GetUser = logInUser;
                            MessageBox.Show("Для вас ещё не реализован код");
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        case 5:
                            SaveSettings();
                            AppConnectClass.GetUser = logInUser;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        // Если у пользователя должность, которой не разрешён вход
                        default:
                            string messageDefault =
                                $"Извините {logInUser.PassportTable.Surname_Passport + " " + logInUser.PassportTable.Name_Passport}" +
                                " " + "но для вас доступ в АИС закрыт!";
                            MessageBox.Show(
                                messageDefault, "Авторизация",
                                MessageBoxButton.OK, MessageBoxImage.Information);
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

                    MessageBox.Show(
                        messageError, "Авторизация",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    quantityNoInputs++;
                }
            }
            catch (Exception exDateUser)
            {
                var nameMessageDateUser = $"Ошибка (AuthorizationWindowError - 010)";
                var titleMessageDateUser = $"{exDateUser.Message}";
                MessageBox.Show(
                    nameMessageDateUser, titleMessageDateUser,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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

        private void GetCapsLock() // Метод, который реагирует на нажатый CapsLock
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
            catch (Exception exGetCapsLock)
            {
                var nameMessageGetCapsLock = $"Ошибка (AuthorizationWindowError - 011)";
                var titleMessageGetCapsLock = $"{exGetCapsLock.Message}";
                MessageBox.Show(
                    nameMessageGetCapsLock, titleMessageGetCapsLock,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageSaveSettings = $"Ошибка (AuthorizationWindowError - 012)";
                var titleMessageSaveSettings = $"{exSaveSettings.Message}";
                MessageBox.Show(
                    nameMessageSaveSettings, titleMessageSaveSettings,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Показать\Скрыть пароль
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
            catch (Exception exVisiblePasswordUserButton0)
            {
                var nameMessageVisiblePasswordUserButton0 = $"Ошибка (AuthorizationWindowError - 013)";
                var titleMessageVisiblePasswordUserButton0 = $"{exVisiblePasswordUserButton0.Message}";
                MessageBox.Show(
                    nameMessageVisiblePasswordUserButton0, titleMessageVisiblePasswordUserButton0,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
            catch (Exception exVisiblePasswordUserButton1)
            {
                var nameMessageVisiblePasswordUserButton1 = $"Ошибка (AuthorizationWindowError - 014)";
                var titleMessageVisiblePasswordUserButton1 = $"{exVisiblePasswordUserButton1.Message}";
                MessageBox.Show(
                    nameMessageVisiblePasswordUserButton1, titleMessageVisiblePasswordUserButton1,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
            catch (Exception exLoginUserTextBox)
            {
                var nameMessageLoginUserTextBox = $"Ошибка (AuthorizationWindowError - 015)";
                var titleMessageLoginUserTextBox = $"{exLoginUserTextBox.Message}";
                MessageBox.Show(
                    nameMessageLoginUserTextBox, titleMessageLoginUserTextBox,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                GetCapsLock();
            }
            catch (Exception exPasswordUserPasswordBox0)
            {
                var nameMessagePasswordUserPasswordBox0 = $"Ошибка (AuthorizationWindowError - 016)";
                var titleMessagePasswordUserPasswordBox0 = $"{exPasswordUserPasswordBox0.Message}";
                MessageBox.Show(
                    nameMessagePasswordUserPasswordBox0, titleMessagePasswordUserPasswordBox0,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                GetCapsLock();
            }
            catch (Exception exPasswordUserPasswordBox1)
            {
                var nameMessagePasswordUserPasswordBox1 = $"Ошибка (AuthorizationWindowError - 017)";
                var titleMessagePasswordUserPasswordBox1 = $"{exPasswordUserPasswordBox1.Message}";
                MessageBox.Show(
                    nameMessagePasswordUserPasswordBox1, titleMessagePasswordUserPasswordBox1,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
