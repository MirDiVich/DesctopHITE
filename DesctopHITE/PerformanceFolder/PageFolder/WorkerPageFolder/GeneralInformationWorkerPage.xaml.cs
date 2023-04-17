///----------------------------------------------------------------------------------------------------------
/// 
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
                var CountWorker = AppConnectClass.DataBase.WorkerTable.Count();
                WorkerCountTextBlock.Text = CountWorker.ToString();

                var CountOnline = AppConnectClass.DataBase.WorkerTable.Count(status => status.pnStatus_Worker == 2);
                TotalOnlineWorkerTextBlock.Text = CountOnline.ToString();
            }
        }
    }
}
