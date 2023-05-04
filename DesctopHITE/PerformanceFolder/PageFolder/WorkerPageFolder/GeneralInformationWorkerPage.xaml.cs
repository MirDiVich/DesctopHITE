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
                var nameMessageOne = $"Ошибка (GeneralInformationWorkerPageError - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageVisibility = $"Ошибка (GeneralInformationWorkerPageError - 002)";
                var titleMessageVisibility = $"{exVisibility.Message}";
                MessageBox.Show(
                    nameMessageVisibility, titleMessageVisibility,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        #region Метод
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
                var nameMessageGetDataCountWorker = $"Ошибка (GeneralInformationWorkerPageError - 003)";
                var titleMessageGetDataCountWorker = $"{exGetDataCountWorker.Message}";
                MessageBox.Show(
                    nameMessageGetDataCountWorker, titleMessageGetDataCountWorker,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageGetBirthdayComingSoonWorker = $"Ошибка (GeneralInformationWorkerPageError - 004)";
                var titleMessageGetBirthdayComingSoonWorker = $"{exGetBirthdayComingSoonWorker.Message}";
                MessageBox.Show(
                    nameMessageGetBirthdayComingSoonWorker, titleMessageGetBirthdayComingSoonWorker,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageGetTodayBirthdayWorker = $"Ошибка (GeneralInformationWorkerPageError - 005)";
                var titleMessageGetTodayBirthdayWorker = $"{exGetTodayBirthdayWorker.Message}";
                MessageBox.Show(
                    nameMessageGetTodayBirthdayWorker, titleMessageGetTodayBirthdayWorker,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageGetGenderWorker = $"Ошибка (GeneralInformationWorkerPageError - 006)";
                var titleMessageGetGenderWorker = $"{exGetGenderWorker.Message}";
                MessageBox.Show(
                    nameMessageGetGenderWorker, titleMessageGetGenderWorker,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
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
                var nameMessageetNumberEmployeesWithPosition = $"Ошибка (GeneralInformationWorkerPageError - 007)";
                var titleMessageetNumberEmployeesWithPosition = $"{exGetNumberEmployeesWithPosition.Message}";
                MessageBox.Show(
                    nameMessageetNumberEmployeesWithPosition, titleMessageetNumberEmployeesWithPosition,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
