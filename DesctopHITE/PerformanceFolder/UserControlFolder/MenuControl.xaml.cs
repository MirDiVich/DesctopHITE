using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exMenuControl)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                    textMessage: $"Событие MenuControl в MenuControl:\n\n " +
                    $"{exMenuControl.Message}");
            }
        }
    }
}
