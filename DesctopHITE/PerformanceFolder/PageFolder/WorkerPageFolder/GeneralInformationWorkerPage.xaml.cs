//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Простая страница пустышка, которая нужна лишь для того, чтоб вывести "общую" информацию о сотрудниках
///     из базы данных и всё;
/// Сначала я создаю переменную "var" в которую записываю определённою строку (данные),
///     а потом обращаюсь к данной переменной и делаю свои дела, это нужно для того,
///     что бы укоротить код.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exGeneralInformationWorkerPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GeneralInformationWorkerPage в GeneralInformationWorkerPage:\n\n " +
                        $"{exGeneralInformationWorkerPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    Event_DataCountWorker();
                    Event_BirthdayComingSoonWorker();
                    Event_TodayBirthdayWorker();
                    Event_GenderWorker();
                    Event_NumberEmployeesWithPosition();
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Page_IsVisibleChanged в GeneralInformationWorkerPage:\n\n " +
                        $"{exPage_IsVisibleChanged.Message}");
            }
        }

        #region Event_
        private void Event_DataCountWorker() // Считаю количество сотрудников / количество онлайн / оффлайн
        {
            try
            {
                var dataCountWorker = AppConnectClass.connectDataBase_ACC.WorkerTable;

                WorkerCountTextBlock.Text = $"{dataCountWorker.Count()}";
                TotalOnlineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 2)}";
                TotalOfflineWorkerTextBlock.Text = $"{dataCountWorker.Count(status => status.pnStatus_Worker == 1)}";
            }
            catch (Exception exEvent_DataCountWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_DataCountWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exEvent_DataCountWorker.Message}");
            }
        }

        private void Event_BirthdayComingSoonWorker() // Получаю сотрудников, у которых скоро будет день рождение
        {
            try
            {
                // Получаем текущую дату
                DateTime today = DateTime.Today;

                // Получаем даты дней рождения, через 1, 2 и 3 дня
                DateTime birthdayInOneDay = today.AddDays(1);
                DateTime birthdayInTwoDays = today.AddDays(2);
                DateTime birthdayInThreeDays = today.AddDays(3);

                // Фильтруем сотрудников, у которых дни рождения ожидаются
                var upcomingBirthdays = AppConnectClass.connectDataBase_ACC.PassportTable.Where(dateOfBrith =>
                    dateOfBrith.DateOfBrich_Passport.Month == today.Month && (dateOfBrith.DateOfBrich_Passport.Day == birthdayInOneDay.Day ||
                    dateOfBrith.DateOfBrich_Passport.Day == birthdayInTwoDays.Day || dateOfBrith.DateOfBrich_Passport.Day == birthdayInThreeDays.Day)).ToList();

                // Устанавливаем список сотрудников с ожидаемыми днями рождения в ListBox
                BirthdayComingSoonListView.ItemsSource = upcomingBirthdays;
            }
            catch (Exception exEvent_BirthdayComingSoonWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_BirthdayComingSoonWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exEvent_BirthdayComingSoonWorker.Message}");
            }
        }

        private void Event_TodayBirthdayWorker() // Получаю сотрудников, у которых сегодня день рождение
        {
            try
            {
                TodayBirthdayListView.ItemsSource =
                   AppConnectClass.connectDataBase_ACC.PassportTable.Where(toDayBrith =>
                       toDayBrith.DateOfBrich_Passport.Day == toDay.Day &&
                       toDayBrith.DateOfBrich_Passport.Month == toDay.Month).ToList();
            }
            catch (Exception exEvent_TodayBirthdayWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_TodayBirthdayWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exEvent_TodayBirthdayWorker.Message}");
            }
        }

        private void Event_GenderWorker() // Считаю количество сотрудников мужского \ женского гендера
        {
            try
            {
                var genderWorker = AppConnectClass.connectDataBase_ACC.PassportTable;

                GenderManTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 1)}";
                GenderWomenTextBlock.Text = $"{genderWorker.Count(gender => gender.pnGender_Passport == 2)}";
            }
            catch (Exception exEvent_GenderWorker)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_GenderWorker в GeneralInformationWorkerPage:\n\n " +
                        $"{exEvent_GenderWorker.Message}");
            }
        }

        private void Event_NumberEmployeesWithPosition() // Считаю количество сотрудников  по должности
        {
            try
            {
                var numberEmployeesWithPosition = AppConnectClass.connectDataBase_ACC.WorkerTable;

                NumberEmployeesWithPositionProgrammerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 1)}";
                NumberEmployeesWithPositionAdministratorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 2)}";
                NumberEmployeesWithPositionCashierTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 3)}";
                NumberEmployeesWithPositionCleanerTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 4)}";
                NumberEmployeesWithPositionDirectorTextBlock.Text = $"{numberEmployeesWithPosition.Count(role => role.pnRole_Worker == 5)}";
            }
            catch (Exception exEvent_NumberEmployeesWithPosition)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_NumberEmployeesWithPosition в GeneralInformationWorkerPage:\n\n " +
                        $"{exEvent_NumberEmployeesWithPosition.Message}");
            }
        }
        #endregion
    }
}
