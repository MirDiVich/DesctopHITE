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
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();
            }
            catch (Exception ex) 
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GeneralInformationWorkerPage в GeneralInformationWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
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
            catch (Exception exVisibility)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие Page_IsVisibleChanged в GeneralInformationWorkerPage:\n\n " +
                        $"{exVisibility.Message}");
            }
        }

        #region Event
        private void GetDataCountWorker() // Считаю количество сотрудников / количество онлайн / оффлайн
        {
            try
            {
                var dataCountWorker = AppConnectClass.DataBase.WorkerTable;

                WorkerCountTextBlock.Text = $"{dataCountWorker.Count()}";
                TotalOnlineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 2)}";
                TotalOfflineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 1)}";
            }
            catch (Exception exGetDataCountWorker)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetDataCountWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exGetDataCountWorker.Message}");
            }
        }

        private void GetBirthdayComingSoonWorker() // Получаю сотрудников, у которых скоро будет день рождение
        {
            try
            {
                var www = toDay.AddDays(-5);

                // Выведи мне в виде списка только тех сотрудников у которых: день рождение в этом месяце, не сегодня,
                BirthdayComingSoonListView.ItemsSource =
                    AppConnectClass.DataBase.PassportTable.Where(dateOfBrith =>
                        dateOfBrith.DateOfBrich_Passport.Month == toDay.Month &&
                        dateOfBrith.DateOfBrich_Passport.Day != toDay.Day &&
                        dateOfBrith.DateOfBrich_Passport <= www).ToList();

                /// Вся проблема заключается в том, что он берёт всех сотрудников, которые
                /// соответствуют условию, а условие следующее:
                /// возьми всех сотрудников и выведи только тех, кто соответствует следующему условию (25.04.2023 - 5 = 20.04.2023) <= 25.04.2023
                /// Результат такой, ок, я выведу тебе сотрудников, у которых дени рождение раньше или попало в следующию дату "20.04.2023",
                /// а я пытаюсь написать условие, на вывод тольел тех, у кого через 5 дней день рождение.

                /// Поэтому это пока что останется тут. Если этот коммент* не пропал, значит, я ещё не исправил свою проблему!
            }
            catch (Exception exGetBirthdayComingSoonWorker)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetBirthdayComingSoonWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exGetBirthdayComingSoonWorker.Message}");
            }
        }

        private void GetTodayBirthdayWorker() // Получаю сотрудников, у которых сегодня день рождение
        {
            try
            {
                TodayBirthdayListView.ItemsSource =
               AppConnectClass.DataBase.PassportTable.Where(toDayBrith =>
                   toDayBrith.DateOfBrich_Passport.Day == toDay.Day &&
                   toDayBrith.DateOfBrich_Passport.Month == toDay.Month).ToList();
            }
            catch (Exception exGetTodayBirthdayWorker)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetTodayBirthdayWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exGetTodayBirthdayWorker.Message}");
            }
        }

        private void GetGenderWorker() // Считаю количество сотрудников мужского \ женского гендера
        {
            try
            {
                var genderWorker = AppConnectClass.DataBase.PassportTable;

                GenderManTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 1)}";
                GenderWomenTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 2)}";
            }
            catch (Exception exGetGenderWorker)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetGenderWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exGetGenderWorker.Message}");
            }
        }

        private void GetNumberEmployeesWithPosition() // Считаю количество сотрудников  по должности
        {
            try
            {
                var numberEmployeesWithPosition = AppConnectClass.DataBase.WorkerTable;

                NumberEmployeesWithPositionProgrammerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 1)}";
                NumberEmployeesWithPositionAdministratorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 2)}";
                NumberEmployeesWithPositionCashierTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 3)}";
                NumberEmployeesWithPositionCleanerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 4)}";
                NumberEmployeesWithPositionDirectorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 5)}";
            }
            catch (Exception exGetNumberEmployeesWithPosition)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие GetNumberEmployeesWithPosition в GeneralInformationWorkerPage:\n\n " +
                        $"{exGetNumberEmployeesWithPosition.Message}");
            }
        }
        #endregion
    }
}
