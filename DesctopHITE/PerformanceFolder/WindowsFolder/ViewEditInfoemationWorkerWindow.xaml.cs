///----------------------------------------------------------------------------------------------------------
/// Данное окно вызывается для того, чтобы продемонстрировать информацию о сотруднике
///     или дать возможность изменить эту самую информацию.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class ViewEditInfoemationWorkerWindow : Window
    {
        public ViewEditInfoemationWorkerWindow()
        {
            try
            {
                InitializeComponent();
                FrameNavigationClass.ViewEditInformationWorker_FNC = ViewEditWorkerInformationFrame;
            }
            catch (Exception ex)
            {
                var nameMessageOne = $"Ошибка (ViewEditInfoemationWorkerWindowError - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception exSpaseBar)
            {
                var nameMessageSpaseBar = $"Ошибка (ViewEditInfoemationWorkerWindowError - 002)";
                var titleMessageSpaseBar = $"{exSpaseBar.Message}";
                MessageBox.Show(
                    nameMessageSpaseBar, titleMessageSpaseBar,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception exClose)
            {
                var nameMessageClose = $"Ошибка (ViewEditInfoemationWorkerWindowError - 003)";
                var titleMessageClose = $"{exClose.Message}";
                MessageBox.Show(
                    nameMessageClose, titleMessageClose,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception exRollup)
            {
                var nameMessageRollup = $"Ошибка (ViewEditInfoemationWorkerWindowError - 004)";
                var titleMessageRollup = $"{exRollup.Message}";
                MessageBox.Show(
                    nameMessageRollup, titleMessageRollup,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
