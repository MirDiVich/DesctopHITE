///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код авторизации и код для взаимодействия пользователя с окном авторизации
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class AuthorizationWindow : Window
    {
        string MessageNullBox;
        int QuantityNoInputs = 0;
        DispatcherTimer GetTimer;
        private double СurrentRotationAngle = 0;

        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы окно перетаскивать 
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
                    ex.Message.ToString(),
                    "REBU001 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU002 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Rollup_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU003 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
        public AuthorizationWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();
            }
            catch (Exception ex)
            {
                string MessageError =
                    $"Вызвало ошибку: {ex.Source}\n" +
                    $"Сообщение ошибки: {ex.Message}\n" +
                    $"Трассировка стека: {ex.StackTrace}";
                MessageBox.Show(
                    MessageError, "Ошибка - E001",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                // Свойства для Таймера
                GetTimer = new DispatcherTimer();
                GetTimer.Tick += new EventHandler(GetTimer_Tick);
                GetTimer.Interval = TimeSpan.FromMilliseconds(30);
            }
            else
            {
                GetTimer.Stop();
            }
        }
        #region Click

        // Действие при нажатии на кнопку "Войти"
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        // Если пользователь, находясь в PasswordBox нажал на Enter
        private void PasswordUserPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginUser();
            }
        }
        #endregion
        #region Метод
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            RotateTransform LoadingAnimation = new RotateTransform();
            СurrentRotationAngle += 10; // Поворот на 10 градусов

            if (СurrentRotationAngle >= 360)
            {
                СurrentRotationAngle = 0;
            }

            LoadingAnimation.Angle = СurrentRotationAngle;
            LoadingSpinnerTextBlock.RenderTransformOrigin = new Point(0.5, 0.5);

            LoadingSpinnerTextBlock.RenderTransform = LoadingAnimation;
        }
        private void LoginUser() // Действие для авторизации пользователя
        {
            ErrorNullBox(); // Вызываем метод проверки текстовых полей на пустоту

            if (QuantityNoInputs >= 5)
            {
                CaptchaWindow captchaWindow = new CaptchaWindow();
                captchaWindow.ShowDialog();
                QuantityNoInputs = 0;
            }
            else
            {
                if (MessageNullBox != null)
                {
                    MessageBox.Show(
                        MessageNullBox, "Авторизация",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    MessageNullBox = null;
                }
                else
                {
                    DateUser();
                }
            }
        }
        private void ErrorNullBox() // Метод проверки текстовых полей на пустоту
        {
            if (string.IsNullOrWhiteSpace(LoginUserTextBox.Text)) MessageNullBox += "Поле Login пустое\n";
            if (string.IsNullOrWhiteSpace(PasswordUserPasswordBox.Password)) MessageNullBox += "Поле Password пустое";
        }
        private async void DateUser() // Метод авторизации пользователя
        {
            try
            {
                // Отключение кнопки
                LoginButton.IsEnabled = false;

                // Запуск анимации загрузки
                StandardTextInTheButton.Visibility = Visibility.Collapsed;
                LoadingSpinnerTextBlock.Visibility = Visibility.Visible;
                GetTimer.Start();

                // Стринговые переменные, потому что без этого код не работает (всё из-за 2-го потока)
                string ReceiveLogin = LoginUserTextBox.Text;
                string ReceivePassword = PasswordUserPasswordBox.Password;

                // Переменная, которая содержит в себе информацию о пользователе
                var LogInUser = await AppConnectClass.DataBase.WorkerTabe.FirstOrDefaultAsync(
                    DataUser => DataUser.Login_Worker == ReceiveLogin && DataUser.Password_Worker == ReceivePassword);

                // Если данные которые ввел пользователь, существуют в базе данных
                if (LogInUser != null)
                {
                    MainUserWindow mainUserWindow = new MainUserWindow();

                    switch (LogInUser.pnRole_Worker) // Проверяем должность пользователя
                    {
                        case 1:
                            mainUserWindow.Show();
                            AppConnectClass.GetUser = LogInUser;
                            this.Close();
                            break;
                        case 2:
                            AppConnectClass.GetUser = LogInUser;
                            mainUserWindow.Show();
                            this.Close();
                            break;
                        case 3:
                            MessageBox.Show("Для вас ещё не реализован код");
                            mainUserWindow.Show();
                            this.Close();
                            break;
                        case 5:
                            AppConnectClass.GetUser = LogInUser;
                            mainUserWindow.Show();
                            this.Close();
                            break;

                        // Если у пользователя должность, которой не разрешён вход
                        default:
                            string MessageDefault =
                                $"Извините {LogInUser.PassportTable.Surname_Passport + " " + LogInUser.PassportTable.Name_Passport}" +
                                " " + "но для вас доступ в АИС закрыт!";
                            MessageBox.Show(
                                MessageDefault, "Авторизация",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }
                }
                // Если данные которые ввел пользователь, не существуют в базе данных
                else
                {
                    string MessageError = $"Извините, но пользователя с:\n\n" +
                        $"Login: {LoginUserTextBox.Text}\n" +
                        $"Password: {PasswordUserPasswordBox.Password}\n\n" +
                        $"не нашлось в нашей базе данных";
                    MessageBox.Show(
                        MessageError, "Авторизация",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    QuantityNoInputs++;
                }
            }
            catch (Exception ex)
            {
                string MessageError =
                    $"Вызвало ошибку: {ex.Source}\n" +
                    $"Сообщение ошибки: {ex.Message}\n" +
                    $"Трассировка стека: {ex.StackTrace}";
                MessageBox.Show(
                    MessageError, "Ошибка - E002",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Остановка анимации загрузки
                StandardTextInTheButton.Visibility = Visibility.Visible;
                LoadingSpinnerTextBlock.Visibility = Visibility.Collapsed;
                GetTimer.Stop();

                // Включение кнопки
                LoginButton.IsEnabled = true;
            }
          
        }
        private void GetCapsLock() // Метод, который реагирует на нажатый CapsLock
        {
            bool IsCapsLockOn = Console.CapsLock;

            if (IsCapsLockOn)
            {
                CapsLockTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                CapsLockTextBlock.Visibility = Visibility.Collapsed;
            }
        }
        #endregion
        #region Показать\Скрыть пароль

        // Когда кнопка нажата
        private void VisiblePasswordUserButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Получаем содержимое PasswordBox и применяем к TextBox
            string PasswordUser = Convert.ToString(PasswordUserPasswordBox.Password);
            PasswordUserTextBox.Text = PasswordUser;

            PasswordPasswordGrid.Visibility = Visibility.Collapsed;
            TextPasswordGrid.Visibility = Visibility.Visible;
        }

        // Когда кнопка отпущена
        private void VisiblePasswordUserButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            // Получаем содержимое TextBox и применяем к PasswordBox
            string PasswordUser = Convert.ToString(PasswordUserTextBox.Text);
            PasswordUserPasswordBox.Password = PasswordUser;

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

            // Проверка на CapsLock
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

            // Проверка на CapsLock
            GetCapsLock();
        }
        #endregion
    }
}
