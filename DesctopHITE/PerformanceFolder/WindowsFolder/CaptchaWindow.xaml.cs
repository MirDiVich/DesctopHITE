///----------------------------------------------------------------------------------------------------------
/// В данном окне реализован код капчи
/// Текст капчи генерируется рандомно
/// Свойство текста капчи принимаются из класса
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
        string GetCaptchaText;
        string MessageNullBox;
        DispatcherTimer GetTimer;

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

                // Свойства для Таймера
                GetTimer = new DispatcherTimer(); 
                GetTimer.Tick += new EventHandler(GetTimer_Tick); 
                GetTimer.Interval = TimeSpan.FromSeconds(5); 
                GetTimer.Stop();
            }
            else
            {
                NewCaptchaButton.IsEnabled = true;
                GetTimer.Stop();
            }
        }
        private void GetTimer_Tick(object sender, EventArgs e) // Действие, которое будет происходит в определённый промежуток времени
        {
            NewCaptchaButton.IsEnabled = true;
            GetTimer.Stop();
        }
        #region Метод
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

            GetCaptchaText = CaptchaText;
            TextCaptchaTextBlock.Text = GetCaptchaText;
        }

        private void GetStyleCaptcha() // Метод для рандомного свойства TextCaptcha 
        {
            // Обращение к классу
            var StyleText = CaptchaClass.GetStyle();

            // Присваивание TextCaptchaTextBlock определённых свойст из класса
            TextCaptchaTextBlock.Opacity = StyleText.GetOpacityText;
            TextCaptchaTextBlock.Foreground = StyleText.GetColorText;
            TextCaptchaTextBlock.FontSize = StyleText.GetFontSizeText;
            TextCaptchaTextBlock.RenderTransform = new RotateTransform(StyleText.GetRotationText);
            TextCaptchaTextBlock.RenderTransform = new SkewTransform(0, Math.Sin(DateTime.Now.Millisecond / StyleText.GetFrequencyText) * StyleText.GetAmplitudeText);
            TextCaptchaTextBlock.FontWeight = StyleText.GetFontWeightText;
            TextCaptchaTextBlock.FontStyle = StyleText.GetFontStyleText;
            TextCaptchaTextBlock.TextDecorations = StyleText.GetTextDecorationText;
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
            GetTimer.Start();
        }

        private void EnterCaptchaButton_Click(object sender, RoutedEventArgs e) // Нажатие кнопка "ПРОДОЛЖИТЬ"
        {
            // Вызов методов
            GetEnter();
        }

        private void CaptchaTextBox_KeyDown(object sender, KeyEventArgs e) // Нажатие Enter в TextBox
        {
            if (e.Key == Key.Enter)
            {
                // Вызов методов
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
