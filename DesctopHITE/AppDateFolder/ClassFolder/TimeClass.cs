using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public  partial class TimeClass
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

                return TitleToDay;
            }
        }
    }
}
