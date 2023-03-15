using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;
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

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            FrameNavigationClass.MunuWorker_FNC = MenuWorkerFrame;
            FrameNavigationClass.BodyWorker_FNC = BodyWorkerFrame;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FrameNavigationClass.MunuWorker_FNC.Navigate(new MenuWorkerPage());
            }
        }
    }
}
