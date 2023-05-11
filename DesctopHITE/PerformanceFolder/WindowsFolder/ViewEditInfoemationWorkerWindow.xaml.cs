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
                FrameNavigationClass.viewEditInformationWorker_FNC = ViewEditWorkerInformationFrame;
            }
            catch (Exception exViewEditInfoemationWorkerWindow)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие ViewEditInfoemationWorkerWindow в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exViewEditInfoemationWorkerWindow.Message}");
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
            catch (Exception exSpaseBarGrid_MouseDown)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие SpaseBarGrid_MouseDown в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exSpaseBarGrid_MouseDown.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                this.Close();
            }
            catch (Exception exCloseButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие CloseButton_Click в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exCloseButton_Click.Message}");
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception exRollupButton_Click)
            {
                MessageBoxClass.EventExceptionMessage_MBC(
                        textMessage: $"Событие RollupButton_Click в ViewEditInfoemationWorkerWindow:\n\n " +
                        $"{exRollupButton_Click.Message}");
            }
        }
        #endregion
    }
}
