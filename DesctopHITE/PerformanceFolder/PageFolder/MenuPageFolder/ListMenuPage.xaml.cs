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
    public partial class ListMenuPage : Page
    {
        public ListMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();
                ListMenuListView.ItemsSource = AppConnectClass.DataBase.MenuTable.ToList();
            }
            catch (Exception ex)
            {
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие NewWorkerPage в ListMenuPage:\n\n " +
                        $"{ex.Message}");
            }
        }
    }
}
