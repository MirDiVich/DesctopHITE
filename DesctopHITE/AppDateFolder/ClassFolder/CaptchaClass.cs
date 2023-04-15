///----------------------------------------------------------------------------------------------------------
/// В данном классе реализован метод по генерации рандомных свойств для текста капчи
///----------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Media;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class CaptchaClass
    {
        // Переменные, которые хранят в себе определённые свойства
        public double GetAmplitudeText { get; set; }
        public double GetFrequencyText { get; set; }
        public double GetRotationText { get; set; }
        public SolidColorBrush GetColorText { get; set; }
        public double GetOpacityText { get; set; }
        public FontWeight GetFontWeightText { get; set; }
        public FontStyle GetFontStyleText { get; set; }
        public TextDecorationCollection GetTextDecorationText { get; set; }
        public int GetFontSizeText { get; set; }

        // Стиль для капчи
        public static CaptchaClass GetStyle()
        {
            Random randomStyle = new Random();

            // Выставляем "жирность" текста в зависимости от случайного числа
            FontWeight[] askFontWeights =
            {
                FontWeights.Black,
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
                FontWeights.UltraLight
            };

            // Выставляем "Стиль" текста в зависимости от случайного числа
            FontStyle[] askFontStyle =
            {
                FontStyles.Italic,
                FontStyles.Oblique,
                FontStyles.Normal
            };

            // Выставляем "Декорацию" текста в зависимости от случайного числа
            TextDecorationCollection[] askTextDecorations =
            {
                TextDecorations.Baseline,
                TextDecorations.OverLine,
                TextDecorations.Strikethrough,
                TextDecorations.Underline,
            };

            // генерация рандомной "Жирности текста"
            var fontWeightText = askFontWeights[randomStyle.Next(0, askFontWeights.Length)];

            // генерация рандомной "Стиля текста"
            var fontStyleText = askFontWeights[randomStyle.Next(0, askFontStyle.Length)];

            // генерация рандомной "Декорации текста"
            var fontDecorationsText = askFontWeights[randomStyle.Next(0, askTextDecorations.Length)];

            // генерация рандомной амплитуды и частоты волны
            var amplitudeText = randomStyle.Next(-20, 20); // Амплитуда
            var frequencyText = randomStyle.Next(-40, 40); // Частота

            // генерация рандомного угла наклона
            var rotationText = randomStyle.Next(-15, 15);

            // Получаем рандомный цвет
            var randomRgbColor = new SolidColorBrush(Color.FromRgb((byte)randomStyle.Next(256), (byte)randomStyle.Next(256), (byte)randomStyle.Next(256)));

            // Получаем рандомную прозрачность
            var opacityText = randomStyle.NextDouble() * (0.7 - 0.3) + 0.3;

            // Получаем рандомный размер текста
            var fontSizeText = randomStyle.Next(20, 32);

            // Вызываемым переменным присваиваем полученные свойства
            return new CaptchaClass
            {
                GetFontWeightText = fontWeightText,
                GetAmplitudeText = amplitudeText,
                GetFrequencyText = frequencyText,
                GetRotationText = rotationText,
                GetColorText = randomRgbColor,
                GetOpacityText = opacityText,
                GetFontSizeText = fontSizeText,
                GetFontStyleText = fontStyleText,
                GetTextDecorationText = fontDecorationsText
            };
        }
    }
}
