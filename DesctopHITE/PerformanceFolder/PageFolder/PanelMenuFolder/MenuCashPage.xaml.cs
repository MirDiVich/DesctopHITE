using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder
{
    public partial class MenuCashPage : Page
    {
        public MenuCashPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMenuCashPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие MenuCashPage в MenuCashPage:\n\n " +
                    $"{exMenuCashPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    ListMenuListView.ItemsSource = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.ToList();
                }
            }
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Page_IsVisibleChanged в MenuCashPage:\n\n " +
                    $"{exPage_IsVisibleChanged.Message}");
            }
        }

        private void ListMenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
