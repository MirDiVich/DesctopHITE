//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// В данном классе идёт работа с системной датой
/// В зависимости от даты, в переменные записывается определённый текст.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class HolidayClass
    {
        public DateTime toDay;

        public string Event_WhatDayIsIt_HC /// В зависимости от текущей даты, выводим приветствие (Смотрим, какой сегодня праздник)
        {
            get
            {
                string titleNowDay = "Сегодня нет праздников";

                if ((toDay.Day == 1 || toDay.Day <= 6) && toDay.Month == 1)
                {
                    titleNowDay = "C новым " + toDay.Year.ToString() + " годом!";
                }
                else if (toDay.Day == 7 && toDay.Month == 1)
                {
                    titleNowDay = "С Рождеством Христова!";
                }
                else if (toDay.Day == 14 && toDay.Month == 1)
                {
                    titleNowDay = "Со Старым Новым годом!";
                }
                else if (toDay.Day == 14 && toDay.Month == 2)
                {
                    titleNowDay = "С днем Святого Валентина!";
                }
                else if (toDay.Day == 23 && toDay.Month == 2)
                {
                    titleNowDay = "С днём защитника отечества!";
                }
                else if (toDay.Day == 8 && toDay.Month == 3)
                {
                    titleNowDay = "С Восьмым марта!";
                }
                else if (toDay.Day == 1 && toDay.Month == 4)
                {
                    titleNowDay = "С днём смеха!";
                }
                else if (toDay.Day == 12 && toDay.Month == 4)
                {
                    titleNowDay = "С днём космонавтики!";
                }
                else if (toDay.Day == 1 && toDay.Month == 5)
                {
                    titleNowDay = "С Праздником Весны и Труда";
                }
                else if (toDay.Day == 9 && toDay.Month == 5)
                {
                    titleNowDay = "С Днём Победы";
                }
                else if (toDay.Day == 1 && toDay.Month == 6)
                {
                    titleNowDay = "С Международным днём защиты детей!";
                }
                else if (toDay.Day == 12 && toDay.Month == 6)
                {
                    titleNowDay = "С днем России!";
                }
                else if (toDay.Day == 1 && toDay.Month == 9)
                {
                    titleNowDay = "С днем Знаний!";
                }
                else if (toDay.Day == 4 && toDay.Month == 11)
                {
                    titleNowDay = "С днем народного единства!";
                }
                return titleNowDay;
            }
        }

        public string Event_HappyBirthdayGreetings_HC /// Поздравление пользователя, если у него день рождения
        {
            get
            {
                var happyBirthdayUser = AppConnectClass.connectDataBase_ACC.WorkerTable.Find(AppConnectClass.receiveConnectUser_ACC);

                string titleHappyBirthday = "";
                DateTime titleDateOfBrich = happyBirthdayUser.PassportTable.DateOfBrich_Passport;

                if (toDay.Day == titleDateOfBrich.Day && toDay.Month == titleDateOfBrich.Month)
                {
                    titleHappyBirthday = "С днём рождения!";
                }
                return titleHappyBirthday;
            }
        }
    }
}
