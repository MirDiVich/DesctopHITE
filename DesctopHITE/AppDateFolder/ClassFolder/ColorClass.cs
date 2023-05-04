///----------------------------------------------------------------------------------------------------------
/// Просто класс с набором цветов, на которые я потом ссылаюсь и всё).
///----------------------------------------------------------------------------------------------------------

using System.Windows.Media;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class ColorClass
    {
        public SolidColorBrush GetRedColor { get; set; }
        public SolidColorBrush GetGreenColor { get; set; }
        public SolidColorBrush GetStandardColor { get; set; }

        public static ColorClass GetColor()
        {
            SolidColorBrush redColor = new SolidColorBrush(Color.FromRgb(255, 7, 58));
            SolidColorBrush greenColor = new SolidColorBrush(Color.FromRgb(57, 255, 20));
            SolidColorBrush standardColor = new SolidColorBrush(Color.FromRgb(32, 32, 32));

            return new ColorClass()
            {
                GetRedColor = redColor,
                GetGreenColor = greenColor,
                GetStandardColor = standardColor
            };
        }
    }
}
