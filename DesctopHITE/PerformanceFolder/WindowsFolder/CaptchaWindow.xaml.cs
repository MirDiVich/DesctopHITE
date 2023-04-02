///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код капчи
/// Текст и свойство капчи генерируется рандомно
/// Текст капчи - это один метод
/// Свойство текста капчи - другой метод
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class CaptchaWindow : Window
    {
        string GetCaptchaText;
        string MessageNullBox;
        public CaptchaWindow()
        {
            InitializeComponent();
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                RandomGeneratedCaptcha();
                GetStyleCaptcha();
            }
        }
        #region Метод
        public void RandomGeneratedCaptcha()
        {
            Random textRandom = new Random();

            // Символы, которые будут присутствовать в капче
            string charText =
                "1234567890" +
                "!@#$%^&*()!№;%:?{}[]<>|/" +
                "QWERTYUIOPASDFGHJKLZXCVBNM" +
                "qwertyuiopasdfghjklzxcvbnm";

            // Генерируем длину капчу от 5 до 10 символов
            int lengthCaptcha = textRandom.Next(5, 10);

            // Генератор самой капчи
            string CaptchaText = new string(Enumerable.Repeat(charText, lengthCaptcha).Select(s => s[textRandom.Next(s.Length)]).ToArray());

            GetCaptchaText = CaptchaText;
            TextCaptchaTextBlock.Text = GetCaptchaText;
        }
        private void ErrorNullBox() // Метод проверки текстового поля на пустоту
        {
            if (string.IsNullOrWhiteSpace(CaptchaTextBox.Text)) MessageNullBox += "Поле 'Капча' пустое\n";
        }
        private void GetEnter() // Вызываемый метод для проверки введённой капчи
        {
            ErrorNullBox();

            if (MessageNullBox == null)
            {
                if (CaptchaTextBox.Text == GetCaptchaText)
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
                    MessageNullBox, "Капча",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                MessageNullBox = null;
            }
        }
        private void GetStyleCaptcha() // Метод для рандомного свойства Text Captcha 
        {
            // Присвоение рандомных свойств TextCaptchaTextBlock
            var StyleText = CaptchaClass.GetStyle(); // Обращение к классу

            TextCaptchaTextBlock.Opacity = StyleText.OpacityText;
            TextCaptchaTextBlock.Foreground = StyleText.ColorText;
            TextCaptchaTextBlock.FontSize = StyleText.FontSizeText;
            TextCaptchaTextBlock.RenderTransform = new RotateTransform(StyleText.RotationText);
            TextCaptchaTextBlock.RenderTransform = new SkewTransform(0, Math.Sin(DateTime.Now.Millisecond / StyleText.FrequencyText) * StyleText.AmplitudeText);
            TextCaptchaTextBlock.FontWeight = StyleText.FontWeightText;
        }
        #endregion
        #region Click

        // Сгенерировать новую капчу
        private void NewCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            RandomGeneratedCaptcha();
            GetStyleCaptcha();
        }

        // Нажатие кнопка "ПРОДОЛЖИТЬ"
        private void EnterCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            GetEnter();
        }

        // Нажатие Enter в TextBox
        private void CaptchaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
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

        /// TODO Капча (головоломка):
        /// Было бы не плохо, добавить несколько простых головоломок,
        /// с которыми пользователь справится легко и быстро.
        /// Головоломки естественно на рандом
    }
}
