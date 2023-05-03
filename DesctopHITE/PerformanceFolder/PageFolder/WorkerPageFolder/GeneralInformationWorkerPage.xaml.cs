///----------------------------------------------------------------------------------------------------------
/// Простая страница пустышка, которая нужна лишь для того, чтоб вывести "общую" информацию о сотрудниках
///     из базы данных и всё.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class GeneralInformationWorkerPage : Page
    {
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

        }

        private void GetTodayBirthdayWorker() // Получаю сотрудников, у которых сегодня день рождение
        {

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
    }
}
