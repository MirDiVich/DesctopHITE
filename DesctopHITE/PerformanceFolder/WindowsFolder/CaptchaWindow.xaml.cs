///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код капчи
/// Текст и свойство капчи генерируется рандомно
/// Текст капчи - это один метод
/// Свойство текста капчи - другой метод
///----------------------------------------------------------------------------------------------------------

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
            Random RandomStyle = new Random();

            // генерация рандомной амплитуды и частоты волны
            double AmplitudeText = RandomStyle.Next(-20, 20); // амплитуда
            double FrequencyText = RandomStyle.Next(-40, -40); // частота

            // генерация рандомного угла наклона
            double RotationText = RandomStyle.Next(-15, 15);

            // Получаем рандомный цвет
            Color RandomRgbColor = Color.FromRgb((byte)RandomStyle.Next(256), (byte)RandomStyle.Next(256), (byte)RandomStyle.Next(256));
            SolidColorBrush ColorText = new SolidColorBrush(RandomRgbColor);

            // Получаем рандомную прозрачность
            double OpacityText = RandomStyle.NextDouble() * (0.7 - 0.3) + 0.3;

            // Выставляем "жирность текста" в зависимости от случайного числа
            FontWeight[] GetFontWeights =
                  { FontWeights.Black,
                    FontWeights.Bold,
                    FontWeights.DemiBold,
                    FontWeights.ExtraBlack,
                    FontWeights.ExtraBold,
                    FontWeights.ExtraLight,
                    FontWeights.Heavy,
                    FontWeights.Light,
                    FontWeights.Medium,
                    FontWeights.Normal,
                    FontWeights.Regular,
                    FontWeights.SemiBold,
                    FontWeights.Thin,
                    FontWeights.UltraBlack,
                    FontWeights.UltraBold,
                    FontWeights.UltraLight };
            int RandomFontWeight = RandomStyle.Next(0, GetFontWeights.Length);

            // Присвоение рандомных свойств TextCaptchaTextBlock
            TextCaptchaTextBlock.Opacity = OpacityText;
            TextCaptchaTextBlock.Foreground = ColorText;
            TextCaptchaTextBlock.FontSize = RandomStyle.Next(20, 32);
            TextCaptchaTextBlock.RenderTransform = new RotateTransform(RotationText);
            TextCaptchaTextBlock.RenderTransform = new SkewTransform(0, Math.Sin(DateTime.Now.Millisecond / FrequencyText) * AmplitudeText);
            TextCaptchaTextBlock.FontWeight = GetFontWeights[RandomFontWeight];
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
