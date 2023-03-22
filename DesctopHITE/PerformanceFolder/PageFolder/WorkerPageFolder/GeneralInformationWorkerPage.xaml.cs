using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                var CountWorker = AppConnectClass.DataBase.WorkerTabe.Count();
                WorkerCountTextBlock.Text = CountWorker.ToString();

                var CountOnline = AppConnectClass.DataBase.WorkerTabe.Count(status => status.pnStatus_Worker == 2);
                TotalOnlineWorkerTextBlock.Text = CountOnline.ToString();
            }
        }
    }
}
