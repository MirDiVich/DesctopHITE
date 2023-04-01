using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public partial class TimeClass
    {
        DateTime ToDay = DateTime.Now;
        public string WhatTimeIsIt // В зависимости от текущего времени, выводим приветствие
        {
            get
            {
                string TitleNowHour = "Не определенно";

                if (ToDay.Hour >= 6 && ToDay.Hour < 12)
                {
                    TitleNowHour = "Доброе утро!";
                }
                else if (ToDay.Hour >= 12 && DateTime.Now.Hour < 18)
                {
                    TitleNowHour = "Доброе день!";
                }
                else if (ToDay.Hour >= 18 && DateTime.Now.Hour < 23)
                {
                    TitleNowHour = "Доброе вечер!";
                }
                else if (ToDay.Hour >= 12 && DateTime.Now.Hour < 6)
                {
                    TitleNowHour = "Доброй ночи";
                }

                return TitleNowHour;
            }
        }

        public string WhatDayIsIt // В зависимости от текущей даты, выводим приветствие
        {
            get
            {
                string TitleNowDay = "Не определенно";

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
                ////else if (ToDay.Day >= 1 && ToDay.Month == 1)
                ////{
                ////    TitleNowDay = "";
                ////}
                ////else if (ToDay.Day >= 1 && ToDay.Month == 1)
                ////{
                ////    TitleNowDay = "";
                ////}
                return TitleNowDay;
            }
        }
    }
}
