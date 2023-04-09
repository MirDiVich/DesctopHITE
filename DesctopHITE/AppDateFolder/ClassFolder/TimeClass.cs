///----------------------------------------------------------------------------------------------------------
/// В данном классе идёт работа с системным временем
/// В зависимости от времени, в переменные засовывается определённый текст.
/// Переменные в последствии вызываются
///----------------------------------------------------------------------------------------------------------

using System;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class TimeClass
    {
        DateTime TimeDay = DateTime.Now;
        public string WhatTimeIsIt // В зависимости от текущего времени, выводим приветствие (Смотрим, какой сейчас час)
        {
            get
            {
                string TitleNowHour = "Время не определенно";
                if (TimeDay.Hour >= 0 && DateTime.Now.Hour <= 5)
                {
                    TitleNowHour = $"Доброй ночи \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (TimeDay.Hour >= 6 && TimeDay.Hour <= 11)
                {
                    TitleNowHour = $"Доброе утро \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (TimeDay.Hour >= 12 && DateTime.Now.Hour <=17)
                {
                    TitleNowHour = $"Доброе день \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                else if (TimeDay.Hour >= 18 && DateTime.Now.Hour <= 23)
                {
                    TitleNowHour = $"Доброе вечер \n " +
                        $"{AppConnectClass.GetUser.PassportTable.Surname_Passport} " +
                        $"{AppConnectClass.GetUser.PassportTable.Name_Passport}";
                }
                return TitleNowHour;
            }
        }
    }
}
