﻿///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код авторизации и код для взаимодействия пользователя с окном авторизации
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class AuthorizationWindow : Window
    {
        string MessageNullBox;

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
        private void LoginUser() // Действие для авторизации пользователя
        {
            ErrorNullBox(); // Вызываем метод проверки текстовых полей на пустоту

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
        private void ErrorNullBox() // Метод проверки текстовых полей на пустоту
        {
            if (string.IsNullOrWhiteSpace(LoginUserTextBox.Text)) MessageNullBox += "Поле Login пустое\n";
            if (string.IsNullOrWhiteSpace(PasswordUserPasswordBox.Password)) MessageNullBox += "Поле Password пустое";
        }
        private void DateUser() // Метод авторизации пользователя
        {
            try
            {
                // Переменная, которая содержит в себе информацию о пользователе
                var LogInUser = AppConnectClass.DataBase.WorkerTabe.FirstOrDefault(
                    DataUser => DataUser.Login_Worker == LoginUserTextBox.Text &&
                                DataUser.Password_Worker == PasswordUserPasswordBox.Password);

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
            if (PasswordUserPasswordBox.Password.Length > 0)
            {
                HintTextPasswordTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintTextPasswordTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void PasswordUserTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordUserTextBox.Text.Length > 0)
            {
                HintPasswordPasswordTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                HintPasswordPasswordTextBlock.Visibility = Visibility.Visible;
            }
        }
        #endregion
    }
}
