///----------------------------------------------------------------------------------------------------------
/// Данный контрол нужен для того, чтоб просто выгружать в ListView сотрудников, при этом, в самом
///     ListView сократить длину кода, а так же, возможность легко, понятно и быстро изменить
///     отображение сущьностей из таблицы.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class ListWorkerControl : UserControl
    {
        public ListWorkerControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ListWorkerControl в ListWorkerControl:\n\n " +
                        $"{ex.Message}");
            }
        }
    }
}
