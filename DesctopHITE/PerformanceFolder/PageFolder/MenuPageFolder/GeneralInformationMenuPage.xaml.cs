using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
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
    public partial class GeneralInformationMenuPage : Page
    {
        public GeneralInformationMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                EventMenuCount();
            }
            catch (Exception exGeneralInformationMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GeneralInformationMenuPage в GeneralInformationMenuPage:\n\n " +
                        $"{exGeneralInformationMenuPage.Message}");
            }
        }
        #region Event
        private void EventMenuCount()
        {
            var countData = AppConnectClass.connectDataBase_ACC.MenuTable.Count();

            
            if (countData == 1)
            {
                MenuCountTextBlock.Text = $"{countData} позиция";
            }

            if (countData >= 2)
            {
                MenuCountTextBlock.Text = $"{countData} позиции";
            }
            if (countData >= 5)
            {
                MenuCountTextBlock.Text = $"{countData} позиций";
            }
        }
        #endregion
    }
}
