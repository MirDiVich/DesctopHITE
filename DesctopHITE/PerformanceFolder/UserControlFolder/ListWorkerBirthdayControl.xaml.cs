using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder;
using System;
using System.Windows;
using System.Linq;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class ListWorkerBirthdayControl : UserControl
    {
        DateTime ToDay = DateTime.Now;
        public ListWorkerBirthdayControl()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible) 
            {
                //var howManyYearsWorker = AppConnectClass.DataBase.PassportTable.ToList();
                //var titleYearsWorker = ToDay.Year - howManyYearsWorker.DateOfBrich_Passport.Year;

                //TurnedYearsOld.Text = $"({titleYearsWorker})";
            }
        }
    }
}
