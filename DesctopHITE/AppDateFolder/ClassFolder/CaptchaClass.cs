using System;
using System.Windows;
using System.Windows.Media;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class CaptchaClass
    {
        // Переменые, на которые я ссылаюсь
        public double AmplitudeText { get; set; }
        public double FrequencyText { get; set; }
        public double RotationText { get; set; }
        public SolidColorBrush ColorText { get; set; }
        public double OpacityText { get; set; }
        public FontWeight FontWeightText { get; set; }
        public int FontSizeText { get; set; }

        // Стиль для капчи
        public static CaptchaClass GetStyle()
        {
            Random RandomStyle = new Random();

            // Выставляем "жирность текста" в зависимости от случайного числа
            FontWeight[] GetFontWeights =
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
            var FontWeightText = GetFontWeights[RandomStyle.Next(0, GetFontWeights.Length)];

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


            return new CaptchaClass
            {
                FontWeightText = FontWeightText,
                AmplitudeText = AmplitudeText,
                FrequencyText = FrequencyText,
                RotationText = RotationText,
                ColorText = RandomRgbColor,
                OpacityText = OpacityText,
                FontSizeText = FontSizeText
            };
        }
    }
}
