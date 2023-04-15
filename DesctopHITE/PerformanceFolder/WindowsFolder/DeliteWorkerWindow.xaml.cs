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
using System.Windows.Shapes;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class DeliteWorkerWindow : Window
    {
        public DeliteWorkerWindow(WorkerTabe workerTabe)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.DataBase = new DesctopHiteEntities();
                if (workerTabe != null )
                {
                    DataContext = workerTabe;
                    var addedWhomWorker = workerTabe.AddpnWorker_Worker;
                    var informationAddedWhomWorker = AppConnectClass.DataBase.WorkerTabe.Find(addedWhomWorker);
                    SNMAddedWhomWorkerTextBlock.Text =
                        $"{informationAddedWhomWorker.PassportTable.Surname_Passport} " +
                        $"{informationAddedWhomWorker.PassportTable.Name_Passport} " +
                        $"{informationAddedWhomWorker.PassportTable.Middlename_Passport}";
                    RoleAddedWhomWorkerTextBlock.Text =
                        $"({informationAddedWhomWorker.RoleTable.Name_Role})";
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    ex.Message, "Ошибка (NewWorkerPage - E-001)",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
