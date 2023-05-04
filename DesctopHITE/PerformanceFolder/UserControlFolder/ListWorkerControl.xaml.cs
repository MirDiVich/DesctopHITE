///----------------------------------------------------------------------------------------------------------
/// Данный контрол нужен для того, чтоб просто выгружать в ListView сотрудников, при этом, в самом
///     ListView сократить длину кода, а так же, возможность легко, понятно и быстро изменить
///     отображение сущьностей из таблицы.
///----------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
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
                var nameMessageOne = $"Ошибка (ListWorkerControlError - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
