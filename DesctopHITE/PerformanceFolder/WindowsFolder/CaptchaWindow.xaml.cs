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
                MessageBoxClass.EventExceptionMessage_MBC(
                    textMessage: $"Событие CaptchaWindow в CaptchaWindow:\n\n " +
                    $"{ex.Message}");
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
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие Window_IsVisibleChanged в CaptchaWindow:\n\n " +
                     $"{exVisible.Message}");
            }
        }
        #region Event
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                NewCaptchaButton.IsEnabled = true;
                getTimer.Stop();
            }
            catch (Exception exGetTimer)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие GetTimer_Tick в CaptchaWindow:\n\n " +
                     $"{exGetTimer.Message}");
            }
        }

        private void ErrorNullBox() // Event проверки текстового поля на пустоту
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CaptchaTextBox.Text)) messageNullBox += "Поле 'Капча' пустое";
            }
            catch (Exception exErrorNullBox)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                     textMessage: $"Событие ErrorNullBox в CaptchaWindow:\n\n " +
                     $"{exErrorNullBox.Message}");
            }
        }

        private void GetEnter() // Вызываемый Event для проверки введённой капчи
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
                MessageBoxClass.EventExceptionMessage_MBC(
                      textMessage: $"Событие GetEnter в CaptchaWindow:\n\n " +
                      $"{exGetEnter.Message}");
            }
        }

        public void RandomGeneratedCaptcha() // Event для рандомного содержимого TextCaptcha 
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
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие RandomGeneratedCaptcha в CaptchaWindow:\n\n " +
                       $"{exRandomGeneratedCaptcha.Message}");
            }
        }

        private void GetStyleCaptcha() // Event для рандомного свойства TextCaptcha 
        {
            try
            {
                // Обращение к классу
                var styleText = CaptchaClass.GetStyle();

                // Присваивание TextCaptchaTextBlock определённых свойст из класса
                TextCaptchaTextBlock.Opacity = styleText.GetOpacityText_CC;
                TextCaptchaTextBlock.Foreground = styleText.GetColorText_CC;
                TextCaptchaTextBlock.FontSize = styleText.GetFontSizeText_CC;
                TextCaptchaTextBlock.RenderTransform = new RotateTransform(styleText.GetRotationText_CC);
                TextCaptchaTextBlock.RenderTransform = new SkewTransform(0, Math.Sin(DateTime.Now.Millisecond / styleText.GetFrequencyText_CC) * styleText.GetAmplitudeText_CC);
                TextCaptchaTextBlock.FontWeight = styleText.GetFontWeightText_CC;
                TextCaptchaTextBlock.FontStyle = styleText.GetFontStyleText_CC;
                TextCaptchaTextBlock.TextDecorations = styleText.GetTextDecorationText_CC;
            }
            catch (Exception exGetStyleCaptcha)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                       textMessage: $"Событие GetStyleCaptcha в CaptchaWindow:\n\n " +
                       $"{exGetStyleCaptcha.Message}");
            }
        }   
        #endregion
        #region _Click
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
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие NewCaptchaButton_Click в CaptchaWindow:\n\n " +
                        $"{exNewCaptcha.Message}");
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
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие EnterCaptchaButton_Click в CaptchaWindow:\n\n " +
                        $"{exEnterCaptcha.Message}");
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
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие CaptchaTextBox_KeyDown в CaptchaWindow:\n\n " +
                        $"{exCaptchaTextBox.Message}");
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
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие CaptchaTextBox_TextChanged в CaptchaWindow:\n\n " +
                        $"{exTextChanged.Message}");
            }
        }
        #endregion
    }
}
