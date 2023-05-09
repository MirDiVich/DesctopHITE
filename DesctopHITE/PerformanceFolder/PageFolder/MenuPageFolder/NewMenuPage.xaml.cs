///----------------------------------------------------------------------------------------------------------
///
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Linq;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class NewMenuPage : Page
    {
        public NewMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();
                CategoryMenuComboBox.ItemsSource = AppConnectClass.DataBase.MenuCategoryTable.ToList();
                IngredientsListListView.ItemsSource = AppConnectClass.DataBase.IngredientsTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие NewWorkerPage в NewWorkerPage:\n\n " +
                        $"{ex.Message}");
            }
        }

        private void NewMenuButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void NewMenuImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
