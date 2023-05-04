///----------------------------------------------------------------------------------------------------------
/// Просто главное окно, которое нужно для того, чтоб туда выгружать страницы, с
///     которыми уже и взаимодействует пользователь.
/// На данный момент, окно представляет из себя пустышку, с 2 "Frame" и 3 кнопками, 
///     для управления данным окном.
///----------------------------------------------------------------------------------------------------------

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;
using System;
using System.Windows;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class MainUserWindow : Window
    {
        public MainUserWindow()
        {
            try
            {
                InitializeComponent();
                FrameNavigationClass.MunuUser_FNC = MenuFrame;
                FrameNavigationClass.MainUser_FNC = MainFrame;
            }
            catch (Exception ex)
            {
                var nameMessageOne = $"Ошибка (MainUserWindowError - 001)";
                var titleMessageOne = $"{ex.Message}";
                MessageBox.Show(
                    nameMessageOne, titleMessageOne,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.MunuUser_FNC.Navigate(new MenuUserPage());
                }
            }
            catch (Exception exVisible)
            {
                var nameMessageVisible = $"Ошибка (MainUserWindowError - 002)";
                var titleMessageVisible = $"{exVisible.Message}";
                MessageBox.Show(
                    nameMessageVisible, titleMessageVisible,
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
                var nameMessageSpaseBar = $"Ошибка (MainUserWindowError - 003)";
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
                var nameMessageClose = $"Ошибка (MainUserWindowError - 004)";
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
                var nameMessageRollup = $"Ошибка (MainUserWindowError - 005)";
                var titleMessageRollup = $"{exRollup.Message}";
                MessageBox.Show(
                    nameMessageRollup, titleMessageRollup,
                    MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
