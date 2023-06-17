using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder;
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
            try
            {
                var selectedCategory = (ListMenuListView.SelectedItem as MenuCategoryTable).PersonalNumber_MenuCategory;
                AppConnectClass.rememberTheSelectedCategory_ACC = selectedCategory;

                FrameNavigationClass.bodyCash_FNC.Navigate(new ListMenuCashPage());
            }
            catch (Exception exListMenuListView_SelectionChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие ListMenuListView_SelectionChanged в MenuCashPage:\n\n " +
                    $"{exListMenuListView_SelectionChanged.Message}");
            }
        }
    }
}
