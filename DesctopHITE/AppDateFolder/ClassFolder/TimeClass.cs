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
        public string WhatTimeIsIt
        {
            get
            {
                string TitleToDay = "Не определенно";

                if (ToDay.Hour >= 6 && ToDay.Hour < 12)
                {
                    TitleToDay = "Доброе утро!";
                }
                else if (ToDay.Hour >= 12 && DateTime.Now.Hour < 18)
                {
                    TitleToDay = "Доброе день!";
                }
                else if (ToDay.Hour >= 18 && DateTime.Now.Hour < 23)
                {
                    TitleToDay = "Доброе вечер!";
                }

                return TitleToDay;
            }
        }
    }
}
