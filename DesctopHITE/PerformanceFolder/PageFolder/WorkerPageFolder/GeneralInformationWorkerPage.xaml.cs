///----------------------------------------------------------------------------------------------------------
/// Простая страница пустышка, которая нужна лишь для того, чтоб вывести "общую" информацию о сотрудниках
///     из базы данных и всё;
/// Сначала я создаю переменную "var" в которую записываю определённою строку (данные),
///     а потом обращаюсь к данной переменной и делаю свои дела, это нужно для того,
///     что бы укоротить код.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class GeneralInformationWorkerPage : Page
    {
        DateTime toDay = DateTime.Today;

        public GeneralInformationWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GetDataCountWorker();
                GetBirthdayComingSoonWorker();
                GetTodayBirthdayWorker();
                GetGenderWorker();
                GetNumberEmployeesWithPosition();
            }
        }

        private void GetDataCountWorker() // Считаю количество сотрудников / количество онлайн / оффлайн
        {
            var dataCountWorker = AppConnectClass.DataBase.WorkerTable;

            WorkerCountTextBlock.Text = $"{dataCountWorker.Count()}";
            TotalOnlineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 2)}";
            TotalOfflineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 1)}";
        }

        private void GetBirthdayComingSoonWorker() // Получаю сотрудников, у которых скоро будет день рождение
        {
            var behindDay = toDay.AddDays(- 3);
            var birthdayComingSoon = AppConnectClass.DataBase.PassportTable;

            BirthdayComingSoonListView.ItemsSource = birthdayComingSoon.Where(dateOfBrith =>
               ((dateOfBrith.DateOfBrich_Passport.Day <= behindDay.Day && dateOfBrith.DateOfBrich_Passport.Day != toDay.Day) &&
                 dateOfBrith.DateOfBrich_Passport.Month <= behindDay.Month) &&
                 dateOfBrith.DateOfBrich_Passport.Month == toDay.Month).ToList();
        }

        private void GetTodayBirthdayWorker() // Получаю сотрудников, у которых сегодня день рождение
        {
            var toDayBirthday = AppConnectClass.DataBase.PassportTable;

            TodayBirthdayListView.ItemsSource = toDayBirthday.Where(toDayBrith =>
                toDayBrith.DateOfBrich_Passport.Day == toDay.Day &&
                toDayBrith.DateOfBrich_Passport.Month == toDay.Month).ToList();
        }

        private void GetGenderWorker() // Считаю количество сотрудников мужского \ женского гендера
        {
            var genderWorker = AppConnectClass.DataBase.PassportTable;

            GenderManTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 1)}";
            GenderWomenTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 2)}";
        }

        private void GetNumberEmployeesWithPosition() // Считаю количество сотрудников  по должности
        {
            var numberEmployeesWithPosition = AppConnectClass.DataBase.WorkerTable;

            NumberEmployeesWithPositionProgrammerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 1)}";
            NumberEmployeesWithPositionAdministratorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 2)}";
            NumberEmployeesWithPositionCashierTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 3)}";
            NumberEmployeesWithPositionCleanerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 4)}";
            NumberEmployeesWithPositionDirectorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 5)}";
        }

        private void uhtiur_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            try
            {
                MessageBox.Show(dateTime.Day.ToString());
            }
            catch (Exception ex)
            {
                string tututut = $"{ex.Message}";

                MessageBox.Show(tututut);
            }
        }
    }
}
