//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном классе прописываются методы для взаимодействия с базой данных
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    internal class AppConnectClass
    {
        // Строка подключения к базе данных
        public static DesctopHiteEntities connectDataBase_ACC;

        // Содержит в себе информацию об авторизированном пользователе
        public static int receiveConnectUser_ACC;

        // Содержит в себе информацию о выбранной категории
        public static int rememberTheSelectedCategory_ACC;

        // Содержит в себе информацию о созданном чеке
        public static int theNumberOfTheCreatedReceipt = 0; 
    }
}
