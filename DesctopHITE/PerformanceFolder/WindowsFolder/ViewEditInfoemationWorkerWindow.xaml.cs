///----------------------------------------------------------------------------------------------------------
/// Данное окно вызывается для того, чтобы продимонстрировать информацию о сотруднике
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
            InitializeComponent();
            FrameNavigationClass.ViewEditInformationWorker_FNC = ViewEditWorkerInformationFrame;
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU001 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU002 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try
            {
                WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(), "REBU003 - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
