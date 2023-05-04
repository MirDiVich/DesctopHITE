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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие ViewEditInfoemationWorkerWindow в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{ex.Message}");
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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие SpaseBarGrid_MouseDown в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exSpaseBar.Message}");
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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие CloseButton_Click в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exClose.Message}");
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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие RollupButton_Click в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exRollup.Message}");
            }
        }
        #endregion
    }
}
