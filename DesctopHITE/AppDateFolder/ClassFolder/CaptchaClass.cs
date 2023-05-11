///----------------------------------------------------------------------------------------------------------
/// В данном классе реализован Event по генерации рандомных свойств для текста капчи
///----------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Media;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class CaptchaClass
    {
        // Переменные, которые хранят в себе определённые свойства
        public double GetAmplitudeText_CC { get; set; }
        public double GetFrequencyText_CC { get; set; }
        public double GetRotationText_CC { get; set; }
        public SolidColorBrush GetColorText_CC { get; set; }
        public double GetOpacityText_CC { get; set; }
        public FontWeight GetFontWeightText_CC { get; set; }
        public FontStyle GetFontStyleText_CC { get; set; }
        public TextDecorationCollection GetTextDecorationText_CC { get; set; }
        public int GetFontSizeText_CC { get; set; }

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
            var fontStyleText = askFontStyle[randomStyle.Next(0, askFontStyle.Length)];

            // генерация рандомной "Декорации текста"
            var fontDecorationsText = askTextDecorations[randomStyle.Next(0, askTextDecorations.Length)];

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
                GetFontWeightText_CC = fontWeightText,
                GetAmplitudeText_CC = amplitudeText,
                GetFrequencyText_CC = frequencyText,
                GetRotationText_CC = rotationText,
                GetColorText_CC = randomRgbColor,
                GetOpacityText_CC = opacityText,
                GetFontSizeText_CC = fontSizeText,
                GetFontStyleText_CC = fontStyleText,
                GetTextDecorationText_CC = fontDecorationsText
            };
        }
    }
}
