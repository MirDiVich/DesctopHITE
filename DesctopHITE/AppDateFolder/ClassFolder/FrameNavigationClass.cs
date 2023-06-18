//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном классе реализован метод для ссылки на страницы из разных мест
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows.Controls;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    internal class FrameNavigationClass
    {
        // Элементы управления пользователя
        public static Frame munuUser_FNC;
        public static Frame mainUser_FNC;

        // Frame для настроек
        public static Frame munuSettings_FNC;
        public static Frame bodySettings_FNC;

        // Frame для сотрудников 
        public static Frame munuWorker_FNC;
        public static Frame bodyWorker_FNC;

        // Frame для отдельного окна по редактированию и просмотру информации о сотруднике
        public static Frame viewEditInformationWorker_FNC;
        /// <!--
        /// Не знаю, какая меня муха укусила, так делать нельзя, может потом если останется время или желание, исправлю.
        /// А вообще, если бы мне за это платили бы, я бы это исправил бы
        /// -->

        // Frame для меню 
        public static Frame munuMenu_FNC;
        public static Frame bodyMenu_FNC;

        // Frame для кассы 
        public static Frame munuCash_FNC;
        public static Frame bodyCash_FNC;
    }
}
