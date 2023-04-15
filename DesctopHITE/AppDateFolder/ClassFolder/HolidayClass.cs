﻿///----------------------------------------------------------------------------------------------------------
/// В данном классе идёт работа с системной датой
/// В зависимости от даты, в переменные засовывается определённый текст.
/// Переменные в последствии вызываются
///----------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class HolidayClass
    {
        DateTime ToDay = DateTime.Now;
        public string WhatDayIsIt // В зависимости от текущей даты, выводим приветствие (Смотрим, какой сегодня праздник)
        {
            get
            {
                string TitleNowDay = "Сегодня нет праздников";

                if ((ToDay.Day == 1 || ToDay.Day <= 6) && ToDay.Month == 1)
                {
                    TitleNowDay = "C новым " + ToDay.Year.ToString() + " годом!";
                }
                else if (ToDay.Day == 7 && ToDay.Month == 1)
                {
                    TitleNowDay = "С Рождеством Христова!";
                }
                else if (ToDay.Day == 14 && ToDay.Month == 1)
                {
                    TitleNowDay = "Со Старым Новым годом!";
                }
                else if (ToDay.Day == 14 && ToDay.Month == 2)
                {
                    TitleNowDay = "С днем Святого Валентина!";
                }
                else if (ToDay.Day == 23 && ToDay.Month == 2)
                {
                    TitleNowDay = "С днём защитника отечества!";
                }
                else if (ToDay.Day == 8 && ToDay.Month == 3)
                {
                    TitleNowDay = "С Восьмым марта!";
                }
                else if (ToDay.Day == 1 && ToDay.Month == 4)
                {
                    TitleNowDay = "С днём смеха!";
                }
                else if (ToDay.Day == 12 && ToDay.Month == 4)
                {
                    TitleNowDay = "С днём космонавтики!";
                }
                else if (ToDay.Day == 1 && ToDay.Month == 5)
                {
                    TitleNowDay = "С Праздником Весны и Труда";
                }
                else if (ToDay.Day == 9 && ToDay.Month == 5)
                {
                    TitleNowDay = "С Днём Победы";
                }
                else if (ToDay.Day == 1 && ToDay.Month == 6)
                {
                    TitleNowDay = "С Международным днём защиты детей!";
                }
                else if (ToDay.Day == 12 && ToDay.Month == 6)
                {
                    TitleNowDay = "С днем России!";
                }
                else if (ToDay.Day == 1 && ToDay.Month == 9)
                {
                    TitleNowDay = "С днем Знаний!";
                }
                else if (ToDay.Day == 4 && ToDay.Month == 11)
                {
                    TitleNowDay = "С днем народного единства!";
                }
                return TitleNowDay;
            }
        }

        public string HappyBirthdayGreetings // Поздравление пользователя, если у него день рождения
        {
            get
            {
                string TitleHappyBirthday = "";
                DateTime TitleDateOfBrich = AppConnectClass.GetUser.PassportTable.DateOfBrich_Passport;

                if (ToDay.Day == TitleDateOfBrich.Day && ToDay.Month == TitleDateOfBrich.Month)
                {
                    TitleHappyBirthday = "С днём рождения!";
                }
                return TitleHappyBirthday;
            }
        }
    }
}