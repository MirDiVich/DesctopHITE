using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.WindowsFolder;
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

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class ListMenuCashPage : Page
    {
        int personalNumberCategory;

        public ListMenuCashPage(MenuCategoryTable menuCategoryTable)
        {
            try
            {
                InitializeComponent();
                personalNumberCategory = menuCategoryTable.PersonalNumber_MenuCategory;
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exMenuCashPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие ListMenuCashPage в ListMenuCashPage:\n\n " +
                    $"{exMenuCashPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var listMenuCategory = AppConnectClass.connectDataBase_ACC.MenuTable.Where(dataMenu => dataMenu.pnMenuCategory_Menu == personalNumberCategory);
                ListMenuListView.ItemsSource = listMenuCategory.ToList();
            }
            catch (Exception exMenuCashPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Page_IsVisibleChanged в ListMenuCashPage:\n\n " +
                    $"{exMenuCashPage.Message}");
            }
        }

        private void ListMenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var menuSelection = ListMenuListView.SelectedItem as MenuTable; 
                InfoMenuCashWindow infoMenuCashWindow = new InfoMenuCashWindow();
                infoMenuCashWindow.ShowDialog();

                menuSelection = null;
                ListMenuListView.SelectedItem = null;
            }
            catch (Exception exMenuCashPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие ListMenuListView_SelectionChanged в ListMenuCashPage:\n\n " +
                    $"{exMenuCashPage.Message}");
            }
        }
    }
}
