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
                FrameNavigationClass.munuUser_FNC = MenuFrame;
                FrameNavigationClass.mainUser_FNC = MainFrame;
            }
            catch (Exception exMainUserWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие MainUserWindow в MainUserWindow:\n\n " +
                        $"{exMainUserWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    FrameNavigationClass.munuUser_FNC.Navigate(new MenuUserPage());
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Window_IsVisibleChanged в MainUserWindow:\n\n " +
                        $"{exWindow_IsVisibleChanged.Message}");
            }
        }
        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы перетаскивать окно  
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
            }
            catch (Exception exSpaseBarGrid_MouseDown)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие SpaseBarGrid_MouseDown в MainUserWindow:\n\n " +
                        $"{exSpaseBarGrid_MouseDown.Message}");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try { Application.Current.Shutdown(); }
            catch (Exception exCloseButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CloseButton_Click в MainUserWindow:\n\n " +
                        $"{exCloseButton_Click.Message}");
            }
        }

        private void RollupButton_Click(object sender, RoutedEventArgs e) // Для того, что бы свернуть окно 
        {
            try { WindowState = WindowState.Minimized; }
            catch (Exception exRollupButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие RollupButton_Click в MainUserWindow:\n\n " +
                       $"{exRollupButton_Click.Message}");
            }
        }

        private void ExitUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Сохранение информации
                Properties.Settings.Default.LoginUserRemember = null;
                Properties.Settings.Default.MeaningRemember = false;
                Properties.Settings.Default.PasswordUserRemember = null;

                Properties.Settings.Default.Save();

                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
            catch (Exception exExitUserButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                       textMessage: $"Событие ExitUserButton_Click в MainUserWindow:\n\n " +
                       $"{exExitUserButton_Click.Message}");
            }
        }
        #endregion
    }
}
