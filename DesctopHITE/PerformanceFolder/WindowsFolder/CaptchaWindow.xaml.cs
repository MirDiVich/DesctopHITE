//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном окне реализован код капчи;
/// Текст капчи генерируется рандомно;
/// Свойство текста капчи принимаются из класса;
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            try { InitializeComponent(); }
            catch (Exception exCaptchaWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие CaptchaWindow в CaptchaWindow:\n\n " +
                    $"{exCaptchaWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {

                    Event_RandomGeneratedCaptcha();
                    Event_StyleCaptcha();

                    // Свойства для Таймера
                    getTimer = new DispatcherTimer();
                    getTimer.Tick += new EventHandler(Event_Timer_Tick);
                    getTimer.Interval = TimeSpan.FromSeconds(5);
                    getTimer.Stop();
                }
                else
                {
                    NewCaptchaButton.IsEnabled = true;
                    getTimer.Stop();
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие Window_IsVisibleChanged в CaptchaWindow:\n\n " +
                     $"{exWindow_IsVisibleChanged.Message}");
            }
        }
        #region Event_
        private void Event_Timer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            try
            {
                NewCaptchaButton.IsEnabled = true;
                getTimer.Stop();
            }
            catch (Exception exEvent_Timer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие Event_Timer_Tick в CaptchaWindow:\n\n " +
                     $"{exEvent_Timer_Tick.Message}");
            }
        }

        private void Event_ErrorNullBox() // Event_ проверки текстового поля на пустоту
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CaptchaTextBox.Text)) messageNullBox += "Поле 'Капча' пустое";
            }
            catch (Exception exEvent_ErrorNullBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                     textMessage: $"Событие Event_ErrorNullBox в CaptchaWindow:\n\n " +
                     $"{exEvent_ErrorNullBox.Message}");
            }
        }

        private void Event_Enter() // Вызываемый Event_ для проверки введённой капчи
        {
            try
            {
                Event_ErrorNullBox();

                if (messageNullBox == null)
                {
                    if (CaptchaTextBox.Text == getCaptchaText) { this.Close(); }
                    else
                    {
                        MessageBoxClass.FailureMessageBox_MBC(textMessage: "То, что вы ввели, не совпадает с Капчей");
                        CaptchaTextBox.Text = "";

                        Event_RandomGeneratedCaptcha();
                        Event_StyleCaptcha();
                    }
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: messageNullBox);
                    messageNullBox = null;
                }
            }
            catch (Exception exEvent_Enter)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                      textMessage: $"Событие Event_Enter в CaptchaWindow:\n\n " +
                      $"{exEvent_Enter.Message}");
            }
        }

        public void Event_RandomGeneratedCaptcha() // Event_ для рандомного содержимого TextCaptcha 
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
                string CaptchaText = new string(
                    Enumerable.Repeat(charText, lengthCaptcha).Select(s => s[textRandom.Next(s.Length)]).ToArray());

                getCaptchaText = CaptchaText;
                TextCaptchaTextBlock.Text = getCaptchaText;
            }
            catch (Exception exEvent_RandomGeneratedCaptcha)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_RandomGeneratedCaptcha в CaptchaWindow:\n\n " +
                       $"{exEvent_RandomGeneratedCaptcha.Message}");
            }
        }

        private void Event_StyleCaptcha() // Event_ для рандомного свойства TextCaptcha 
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
            catch (Exception exEvent_StyleCaptcha)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие Event_StyleCaptcha в CaptchaWindow:\n\n " +
                       $"{exEvent_StyleCaptcha.Message}");
            }
        }   
        #endregion
        #region _Click
        private void NewCaptchaButton_Click(object sender, RoutedEventArgs e) // Сгенерировать новую капчу
        {
            try
            {
                Event_RandomGeneratedCaptcha();
                Event_StyleCaptcha();

                // Отключение кнопки, чтоб пользователь не "спамил"
                NewCaptchaButton.IsEnabled = false;
                getTimer.Start();
            }
            catch (Exception exNewCaptchaButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCaptchaButton_Click в CaptchaWindow:\n\n " +
                        $"{exNewCaptchaButton_Click.Message}");
            }
        }

        private void EnterCaptchaButton_Click(object sender, RoutedEventArgs e) // Нажатие кнопка "ПРОДОЛЖИТЬ"
        {
            try { Event_Enter(); }
            catch (Exception exEnterCaptchaButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EnterCaptchaButton_Click в CaptchaWindow:\n\n " +
                        $"{exEnterCaptchaButton_Click.Message}");
            }
        }

        private void CaptchaTextBox_KeyDown(object sender, KeyEventArgs e) // Нажатие Enter в TextBox
        {
            try
            {
                if (e.Key == Key.Enter) { Event_Enter(); }
            }
            catch (Exception exCaptchaTextBox_KeyDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CaptchaTextBox_KeyDown в CaptchaWindow:\n\n " +
                        $"{exCaptchaTextBox_KeyDown.Message}");
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
            catch (Exception exCaptchaTextBox_TextChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CaptchaTextBox_TextChanged в CaptchaWindow:\n\n " +
                        $"{exCaptchaTextBox_TextChanged.Message}");
            }
        }
        #endregion
    }
}
