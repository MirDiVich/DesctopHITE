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
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;

namespace DesctopHITE.PerformanceFolder.PageFolder.UserPageFolder
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            FrameNavigationClass.MunuSettings_FNC = MenuSettingsFrame;
            FrameNavigationClass.BodySettings_FNC = BodySettingsFrame;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FrameNavigationClass.MunuSettings_FNC.Navigate(new MenuSettingsPage());
            }
        }
    }
}
