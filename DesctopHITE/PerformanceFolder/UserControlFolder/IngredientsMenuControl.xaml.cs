using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class IngredientsMenuControl : UserControl
    {
        public IngredientsMenuControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exIngredientsMenuControl)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                    textMessage: $"Событие IngredientsMenuControl в IngredientsMenuControl:\n\n " +
                    $"{exIngredientsMenuControl.Message}");
            }
        }
    }
}
