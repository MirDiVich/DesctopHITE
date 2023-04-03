using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.PerformanceFolder.PageFolder.PanelMenuFolder;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class MainUserWindow : Window
    {
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
                    ex.Message.ToString(),
                    "REBU001 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно 
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU002 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
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
                    ex.Message.ToString(),
                    "REBU003 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private void ExitUserButton_Click(object sender, RoutedEventArgs e) // Для того, чтобы пользователь вышел, но данные для входа в АИС не сохранились
        {
            try
            {
                // Закрытие приложения
                Application.Current.Shutdown();

                // Сохранение сохранения
                Properties.Settings.Default.MeaningRemember = false;

                // Сохранение информации
                Properties.Settings.Default.LoginUserRemember = null;
                Properties.Settings.Default.PasswordUserRemember = null;

                // Сохранение
                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "REBU003 - Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        #endregion
        public MainUserWindow()
        {
            InitializeComponent();
            FrameNavigationClass.MunuUser_FNC = MenuFrame;
            FrameNavigationClass.MainUser_FNC = MainFrame;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FrameNavigationClass.MunuUser_FNC.Navigate(new MenuUserPage());
            }
        }
    }
}
