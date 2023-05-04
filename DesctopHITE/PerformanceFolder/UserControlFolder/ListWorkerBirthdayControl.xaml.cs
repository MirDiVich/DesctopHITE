///----------------------------------------------------------------------------------------------------------
/// Данный контрол выгружается в ListView и нужен для того, чтоб выгружать информацию;
/// В моём случае, в данный контрол выгружается информация о сотрудниках, у которых скоро день рождение или
///     день рождение сегодня (да, выгружается в 2 разных ListView, но при этом, код не дублируется,
///     что позволяет сократить код.
///----------------------------------------------------------------------------------------------------------

using System.Windows;
using System;
using System.Windows.Controls;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class ListWorkerBirthdayControl : UserControl
    {
        public ListWorkerBirthdayControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var nameMessageOne = $"Ошибка (LwbCE - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
    }
}
