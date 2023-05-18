using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class MenuCashControl : UserControl
    {
        public MenuCashControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exMenuCashControl)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие MenuCashControl в MenuCashControl:\n\n " +
                    $"{exMenuCashControl.Message}");
            }
        }
    }
}
