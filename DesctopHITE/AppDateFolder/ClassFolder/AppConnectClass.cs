///----------------------------------------------------------------------------------------------------------
/// В данном классе прописываются методы для взаимодействия с базой данных
///----------------------------------------------------------------------------------------------------------
using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    internal class AppConnectClass
    {
        public static DesctopHiteEntities DataBase; // Строка подключения к базе данных
        public static WorkerTabe GetUser; // Содержит в себе информацию об авторизированном пользователе
    }
}
