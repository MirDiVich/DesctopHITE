///----------------------------------------------------------------------------------------------------------
/// В данном классе прописываются методы для взаимодействия с базой данных
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    internal class AppConnectClass
    {
        public static DesctopHiteEntities connectDataBase_ACC; // Строка подключения к базе данных
        public static int receiveConnectUser_ACC; // Содержит в себе информацию об авторизированном пользователе
    }
}
