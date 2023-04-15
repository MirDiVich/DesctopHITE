///----------------------------------------------------------------------------------------------------------
/// В данном классе идёт работа с системным временем
/// В зависимости от времени, в переменные записывается определённый текст.
///----------------------------------------------------------------------------------------------------------

using System;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class TimeClass
    {
        DateTime timeDay = DateTime.Now;
        public string WhatTimeIsIt // В зависимости от текущего времени, выводим приветствие (Смотрим, какой сейчас час)
        {
            get
            {
                string titleNowHour = "Время не определенно";
                if (timeDay.Hour >= 0 && DateTime.Now.Hour <= 5)
                {
                    titleNowHour = $"Доброй ночи \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 6 && timeDay.Hour <= 11)
                {
                    titleNowHour = $"Доброе утро \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 12 && DateTime.Now.Hour <=17)
                {
                    titleNowHour = $"Доброе день \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (timeDay.Hour >= 18 && DateTime.Now.Hour <= 23)
                {
                    titleNowHour = $"Доброе вечер \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                return titleNowHour;
            }
        }
    }
}
