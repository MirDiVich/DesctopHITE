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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие MainUserWindow в MainUserWindow:\n\n " +
                        $"{ex.Message}");
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
                MessageBoxClass.ExceptionMessage(
                        textMessage: $"Событие Window_IsVisibleChanged в MainUserWindow:\n\n " +
                        $"{exVisible.Message}");
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
                        textMessage: $"Событие SpaseBarGrid_MouseDown в MainUserWindow:\n\n " +
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
                        textMessage: $"Событие CloseButton_Click в MainUserWindow:\n\n " +
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
                       textMessage: $"Событие RollupButton_Click в MainUserWindow:\n\n " +
                       $"{exRollup.Message}");
            }
        }

        private void ExitUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Сохранение сохранения
                Properties.Settings.Default.MeaningRemember = false;

                // Сохранение информации
                Properties.Settings.Default.LoginUserRemember = null;
                Properties.Settings.Default.PasswordUserRemember = null;

                // Сохранение
                Properties.Settings.Default.Save();

                // Закрытие приложения
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();

                Close();
            }
            catch (Exception exExitUser)
            {
                MessageBoxClass.ExceptionMessage(
                       textMessage: $"Событие ExitUserButton_Click в MainUserWindow:\n\n " +
                       $"{exExitUser.Message}");
            }
        }
        #endregion
    }
}
