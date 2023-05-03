///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код капчи;
/// Текст капчи генерируется рандомно;
/// Свойство текста капчи принимаются из класса;
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class CaptchaWindow : Window
    {
        string getCaptchaText;
        string messageNullBox;
        DispatcherTimer getTimer;

        public CaptchaWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var nameMessageOne = $"Ошибка (CWE - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    
                    RandomGeneratedCaptcha();
                    GetStyleCaptcha();

                    // Свойства для Таймера
                    getTimer = new DispatcherTimer();
                    getTimer.Tick += new EventHandler(GetTimer_Tick);
                    getTimer.Interval = TimeSpan.FromSeconds(5);
                    getTimer.Stop();
                }
                else
                {
                    NewCaptchaButton.IsEnabled = true;
                    getTimer.Stop();
                }
            }
            catch (Exception exVisible)
            {
                var nameMessageVisible = $"Ошибка (CWE - 002)";
                var titleMessageVisible = $"{exVisible.Message}";
                MessageBox.Show(
                    nameMessageVisible, titleMessageVisible,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #region Метод
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                NewCaptchaButton.IsEnabled = true;
                getTimer.Stop();
            }
            catch (Exception exGetTimer)
            {
                var nameMessageGetTimer = $"Ошибка (CWE - 003)";
                var titleMessageGetTimer = $"{exGetTimer.Message}";
                MessageBox.Show(
                    nameMessageGetTimer, titleMessageGetTimer,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void ErrorNullBox() // Метод проверки текстового поля на пустоту
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CaptchaTextBox.Text)) messageNullBox += "Поле 'Капча' пустое";
            }
            catch (Exception exErrorNullBox)
            {
                var nameMessageErrorNullBox = $"Ошибка (CWE - 004)";
                var titleMessageErrorNullBox = $"{exErrorNullBox.Message}";
                MessageBox.Show(
                    nameMessageErrorNullBox, titleMessageErrorNullBox,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void GetEnter() // Вызываемый метод для проверки введённой капчи
        {
            try
            {
                ErrorNullBox();

                if (messageNullBox == null)
                {
                    if (CaptchaTextBox.Text == getCaptchaText)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "То, что вы ввели, не совпадает с Капчей", "Капча",
                            MessageBoxButton.OK, MessageBoxImage.Warning);

                        CaptchaTextBox.Text = "";

                        
                        RandomGeneratedCaptcha();
                        GetStyleCaptcha();
                    }
                }
                else
                {
                    MessageBox.Show(
                        messageNullBox, "Капча",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    messageNullBox = null;
                }
            }
            catch (Exception exGetEnter)
            {
                var nameMessageGetEnter = $"Ошибка (CWE - 005)";
                var titleMessageGetEnter = $"{exGetEnter.Message}";
                MessageBox.Show(
                    nameMessageGetEnter, titleMessageGetEnter,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        public void RandomGeneratedCaptcha() // Метод для рандомного содержимого TextCaptcha 
        {
            try
            {
                Random textRandom = new Random();

                // Символы, которые будут присутствовать в капче
                string charText =
                    "1234567890" +
                    "!@#$%^&*()№;:?{}[]<>" +
                    "QWERTYUIOPASDFGHJKLZXCVBNM" +
                    "qwertyuiopasdfghjklzxcvbnm";

                // Генерируем длину капчу от 5 до 10 символов
                int lengthCaptcha = textRandom.Next(5, 10);

                // Генератор самой капчи
                string CaptchaText = new string(Enumerable.Repeat(charText, lengthCaptcha).Select(s => s[textRandom.Next(s.Length)]).ToArray());

                getCaptchaText = CaptchaText;
                TextCaptchaTextBlock.Text = getCaptchaText;
            }
            catch (Exception exRandomGeneratedCaptcha)
            {
                var nameMessageRandomGeneratedCaptcha = $"Ошибка (CWE - 006)";
                var titleMessageRandomGeneratedCaptcha = $"{exRandomGeneratedCaptcha.Message}";
                MessageBox.Show(
                    nameMessageRandomGeneratedCaptcha, titleMessageRandomGeneratedCaptcha,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void GetStyleCaptcha() // Метод для рандомного свойства TextCaptcha 
        {
            try
            {
                // Обращение к классу
                var styleText = CaptchaClass.GetStyle();

                // Присваивание TextCaptchaTextBlock определённых свойст из класса
                TextCaptchaTextBlock.Opacity = styleText.GetOpacityText;
                TextCaptchaTextBlock.Foreground = styleText.GetColorText;
                TextCaptchaTextBlock.FontSize = styleText.GetFontSizeText;
                TextCaptchaTextBlock.RenderTransform = new RotateTransform(styleText.GetRotationText);
                TextCaptchaTextBlock.RenderTransform = new SkewTransform(0, Math.Sin(DateTime.Now.Millisecond / styleText.GetFrequencyText) * styleText.GetAmplitudeText);
                TextCaptchaTextBlock.FontWeight = styleText.GetFontWeightText;
                TextCaptchaTextBlock.FontStyle = styleText.GetFontStyleText;
                TextCaptchaTextBlock.TextDecorations = styleText.GetTextDecorationText;
            }
            catch (Exception exGetStyleCaptcha)
            {
                var nameMessageGetStyleCaptcha = $"Ошибка (CWE - 007)";
                var titleMessageGetStyleCaptcha = $"{exGetStyleCaptcha.Message}";
                MessageBox.Show(
                    nameMessageGetStyleCaptcha, titleMessageGetStyleCaptcha,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }   
        #endregion
        #region Click
        private void NewCaptchaButton_Click(object sender, RoutedEventArgs e) // Сгенерировать новую капчу
        {
            try
            {
                RandomGeneratedCaptcha();
                GetStyleCaptcha();

                // Отключение кнопки, чтоб пользователь не "спамил"
                NewCaptchaButton.IsEnabled = false;
                getTimer.Start();
            }
            catch (Exception exNewCaptcha)
            {
                var nameMessageNewCaptcha = $"Ошибка (CWE - 008)";
                var titleMessageNewCaptcha = $"{exNewCaptcha.Message}";
                MessageBox.Show(
                    nameMessageNewCaptcha, titleMessageNewCaptcha,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void EnterCaptchaButton_Click(object sender, RoutedEventArgs e) // Нажатие кнопка "ПРОДОЛЖИТЬ"
        {
            try
            {
                GetEnter();
            }
            catch (Exception exEnterCaptcha)
            {
                var nameMessageEnterCaptcha = $"Ошибка (CWE - 009)";
                var titleMessageEnterCaptcha = $"{exEnterCaptcha.Message}";
                MessageBox.Show(
                    nameMessageEnterCaptcha, titleMessageEnterCaptcha,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void CaptchaTextBox_KeyDown(object sender, KeyEventArgs e) // Нажатие Enter в TextBox
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    GetEnter();
                }
            }
            catch (Exception exCaptchaTextBox)
            {
                var nameMessageCaptchaTextBox = $"Ошибка (CWE - 010)";
                var titleMessageCaptchaTextBox = $"{exCaptchaTextBox.Message}";
                MessageBox.Show(
                    nameMessageCaptchaTextBox, titleMessageCaptchaTextBox,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
        #region Показать\Скрыть текстовую подсказку
        private void CaptchaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (CaptchaTextBox.Text.Length > 0)
                {
                    HintCaptchaTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    HintCaptchaTextBlock.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exTextChanged)
            {
                var nameMessageTextChanged = $"Ошибка (CWE - 011)";
                var titleMessageTextChanged = $"{exTextChanged.Message}";
                MessageBox.Show(
                    nameMessageTextChanged, titleMessageTextChanged,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
