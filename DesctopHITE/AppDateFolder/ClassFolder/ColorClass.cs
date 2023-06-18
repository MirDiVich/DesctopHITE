//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Просто класс с набором цветов, на которые я потом ссылаюсь и всё).
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows.Media;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class ColorClass
    {

        // Ссылка на цвет
        public SolidColorBrush GetRedColor_CC { get; set; }
        public SolidColorBrush GetGreenColor_CC { get; set; }
        public SolidColorBrush GetStandardColor_CC { get; set; }

        public static ColorClass GetColor() /// Цвета
        {
            // Задаю определённые цвета
            SolidColorBrush redColor = new SolidColorBrush(Color.FromRgb(255, 7, 58));
            SolidColorBrush greenColor = new SolidColorBrush(Color.FromRgb(57, 255, 20));
            SolidColorBrush standardColor = new SolidColorBrush(Color.FromRgb(32, 32, 32));

            // Присвоение этих цветов
            return new ColorClass()
            {
                GetRedColor_CC = redColor,
                GetGreenColor_CC = greenColor,
                GetStandardColor_CC = standardColor
            };
        }
    }
}
