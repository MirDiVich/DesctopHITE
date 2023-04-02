///----------------------------------------------------------------------------------------------------------
/// В данном классе реализован метод по генерации рандомных свойств для текста
/// Данный класс срабатывает каждый раз, когда его вызывают
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
            Random RandomStyle = new Random();

            // Выставляем "жирность" текста в зависимости от случайного числа
            FontWeight[] AskFontWeights =
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
            FontStyle[] AskFontStyle =
            {
                FontStyles.Italic,
                FontStyles.Oblique,
                FontStyles.Normal
            };

            // Выставляем "Декорацию" текста в зависимости от случайного числа
            TextDecorationCollection[] AskTextDecorations =
            {
                TextDecorations.Baseline,
                TextDecorations.OverLine,
                TextDecorations.Strikethrough,
                TextDecorations.Underline,
            };

            // генерация рандомной "Жирности текста"
            var FontWeightText = AskFontWeights[RandomStyle.Next(0, AskFontWeights.Length)];

            // генерация рандомной "Стиля текста"
            var FontStyleText = AskFontStyle[RandomStyle.Next(0, AskFontStyle.Length)];

            // генерация рандомной "Декорации текста"
            var FontDecorationsText = AskTextDecorations[RandomStyle.Next(0, AskTextDecorations.Length)];

            // генерация рандомной амплитуды и частоты волны
            var AmplitudeText = RandomStyle.Next(-20, 20); // Амплитуда
            var FrequencyText = RandomStyle.Next(-40, 40); // Частота

            // генерация рандомного угла наклона
            var RotationText = RandomStyle.Next(-15, 15);

            // Получаем рандомный цвет
            var RandomRgbColor = new SolidColorBrush(Color.FromRgb((byte)RandomStyle.Next(256), (byte)RandomStyle.Next(256), (byte)RandomStyle.Next(256)));

            // Получаем рандомную прозрачность
            var OpacityText = RandomStyle.NextDouble() * (0.7 - 0.3) + 0.3;

            // Получаем рандомный размер текста
            var FontSizeText = RandomStyle.Next(20, 32);

            // Вызываемым переменным присваиваем полученные свойства
            return new CaptchaClass
            {
                GetFontWeightText = FontWeightText,
                GetAmplitudeText = AmplitudeText,
                GetFrequencyText = FrequencyText,
                GetRotationText = RotationText,
                GetColorText = RandomRgbColor,
                GetOpacityText = OpacityText,
                GetFontSizeText = FontSizeText,
                GetFontStyleText = FontStyleText,
                GetTextDecorationText = FontDecorationsText
            };
        }
    }
}
