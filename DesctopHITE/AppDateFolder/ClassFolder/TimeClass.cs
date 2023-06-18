//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном классе идёт работа с системным временем
/// В зависимости от времени, в переменные записывается определённый текст.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class TimeClass
    {
        public DateTime timeDay;

        public string Event_WhatTimeIsIt_TC /// В зависимости от текущего времени, выводим приветствие (Смотрим, какой сейчас час)
        {
            get
            {
                var dataUser = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(AppConnectClass.receiveConnectUser_ACC);

                string titleNowHour = "Время не определенно";

                if (timeDay.Hour >= 0 && DateTime.Now.Hour <= 5)
                {
                    titleNowHour = $"Доброй ночи \n " +
                        $"{dataUser.PassportTable.Surname_Passport} " +
                        $"{dataUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 6 && timeDay.Hour <= 11)
                {
                    titleNowHour = $"Доброе утро \n " +
                        $"{dataUser.PassportTable.Surname_Passport} " +
                        $"{dataUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 12 && DateTime.Now.Hour <=17)
                {
                    titleNowHour = $"Добрый день \n " +
                        $"{dataUser.PassportTable.Surname_Passport} " +
                        $"{dataUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 18 && DateTime.Now.Hour <= 23)
                {
                    titleNowHour = $"Добрый вечер \n " +
                        $"{dataUser.PassportTable.Surname_Passport} " +
                        $"{dataUser.PassportTable.Name_Passport}";
                }
                return titleNowHour;
            }
        }
    }
}
