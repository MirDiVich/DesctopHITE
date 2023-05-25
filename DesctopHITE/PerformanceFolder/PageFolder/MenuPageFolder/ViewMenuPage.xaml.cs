using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class ViewMenuPage : Page
    {
        public ViewMenuPage(MenuTable menuTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                if (menuTable != null)
                {
                    DataContext = menuTable;
                }
            }
            catch (Exception exViewMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие ViewMenuPage в ViewMenuPage:\n\n " +
                        $"{exViewMenuPage.Message}");
            }
        }
    }
}
