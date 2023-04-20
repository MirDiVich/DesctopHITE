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

                    // Вызов метода
                    LoginUser();
                }
            }
            catch (Exception ex)
            {
                string messageError =
                    $"Вызвало ошибку: {ex.Source}\n" +
                    $"Сообщение ошибки: {ex.Message}\n" +
                    $"Трассировка стека: {ex.StackTrace}";

                MessageBox.Show(
                    messageError, "Ошибка - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU001 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU002 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU003 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
        #region Click

        private void LoginButton_Click(object sender, RoutedEventArgs e) // Действие при нажатии на кнопку "Войти"
        {
            // Вызов метода
            LoginUser();
        }

        private void PasswordUserPasswordBox_KeyDown(object sender, KeyEventArgs e) // Если пользователь, находясь в PasswordBox нажал на Enter
        {
            if (e.Key == Key.Enter)
            {
                // Вызов метода
                LoginUser();
            }
        }

        #endregion
        #region Метод

        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            RotateTransform loadingAnimation = new RotateTransform();
            currentRotationAngle += 10; // Поворот на 10 градусов

            if (currentRotationAngle >= 360)
            {
                currentRotationAngle = 0;
            }

            loadingAnimation.Angle = currentRotationAngle;
            LoadingSpinnerTextBlock.RenderTransformOrigin = new Point(0.5, 0.5);

            LoadingSpinnerTextBlock.RenderTransform = loadingAnimation;
        }

        private void LoginUser() // Действие для авторизации пользователя
        {
            // Вызов метода
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
                    // Вызов метода
                    DateUser();
                }
            }
        }

        private void ErrorNullBox() // Метод проверки текстовых полей на пустоту
        {
            if (string.IsNullOrWhiteSpace(LoginUserTextBox.Text)) messageNullBox += "Поле Login пустое\n";
            if (string.IsNullOrWhiteSpace(PasswordUserPasswordBox.Password)) messageNullBox += "Поле Password пустое";
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
            catch (Exception ex)
            {
                string messageError =
                    $"Сообщение ошибки: {ex.Message}\n" +
                    $"Трассировка стека: {ex.StackTrace}";

                MessageBox.Show(
                    messageError, "Ошибка - E002",
                    MessageBoxButton.OK, MessageBoxImage.Error);
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
        public void SaveSettings() // Сохранение пользовательской информации для входа
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

        #endregion
        #region Показать\Скрыть пароль

        private void VisiblePasswordUserButton_PreviewMouseDown(object sender, MouseButtonEventArgs e) // Когда кнопка нажата
        {
            // Получаем содержимое PasswordBox и применяем к TextBox
            string passwordUser = Convert.ToString(PasswordUserPasswordBox.Password);
            PasswordUserTextBox.Text = passwordUser;

            PasswordPasswordGrid.Visibility = Visibility.Collapsed;
            TextPasswordGrid.Visibility = Visibility.Visible;
        }

        private void VisiblePasswordUserButton_PreviewMouseUp(object sender, MouseButtonEventArgs e) // Когда кнопка отпущена
        {
            // Получаем содержимое TextBox и применяем к PasswordBox
            string passwordUser = Convert.ToString(PasswordUserTextBox.Text);
            PasswordUserPasswordBox.Password = passwordUser;

            PasswordPasswordGrid.Visibility = Visibility.Visible;
            TextPasswordGrid.Visibility = Visibility.Collapsed;
        }

        #endregion
        #region Показать\Скрыть текстовае подсказки

        private void LoginUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void PasswordUserPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
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

            // Вызов метода
            GetCapsLock();
        }

        private void PasswordUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

            // Вызов метода
            GetCapsLock();
        }

        #endregion
    }
}
