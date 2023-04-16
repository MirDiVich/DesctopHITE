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
            InitializeComponent();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                // Вызов методов
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

        #region Метод

        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            NewCaptchaButton.IsEnabled = true;
            getTimer.Stop();
        }

        private void ErrorNullBox() // Метод проверки текстового поля на пустоту
        {
            if (string.IsNullOrWhiteSpace(CaptchaTextBox.Text)) messageNullBox += "Поле 'Капча' пустое";
        }

        private void GetEnter() // Вызываемый метод для проверки введённой капчи
        {
            // Вызов метода
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

                    // Вызов методов
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

        public void RandomGeneratedCaptcha() // Метод для рандомного содержимого TextCaptcha 
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

        private void GetStyleCaptcha() // Метод для рандомного свойства TextCaptcha 
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

        #endregion
        #region Click

        private void NewCaptchaButton_Click(object sender, RoutedEventArgs e) // Сгенерировать новую капчу
        {
            // Вызов методов
            RandomGeneratedCaptcha();
            GetStyleCaptcha();

            // Отключение кнопки, чтоб пользователь не "спамил"
            NewCaptchaButton.IsEnabled = false; 
            getTimer.Start();
        }

        private void EnterCaptchaButton_Click(object sender, RoutedEventArgs e) // Нажатие кнопка "ПРОДОЛЖИТЬ"
        {
            // Вызов метода
            GetEnter();
        }

        private void CaptchaTextBox_KeyDown(object sender, KeyEventArgs e) // Нажатие Enter в TextBox
        {
            if (e.Key == Key.Enter)
            {
                // Вызов метода
                GetEnter();
            }
        }

        #endregion
        #region Показать\Скрыть текстовую подсказку

        private void CaptchaTextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        #endregion
    }
}
