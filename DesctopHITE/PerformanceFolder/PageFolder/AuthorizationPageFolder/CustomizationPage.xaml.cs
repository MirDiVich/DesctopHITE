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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesctopHITE.PerformanceFolder.WindowsFolder;

namespace DesctopHITE.PerformanceFolder.PageFolder.AuthorizationPageFolder
{
    /// <summary>
    /// Логика взаимодействия для CustomizationPage.xaml
    /// </summary>
    public partial class CustomizationPage : Page
    {
        public CustomizationPage()
        {
            InitializeComponent();
        }
        #region Click
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }
        #endregion
        #region Действие
        private void LoginUser()
        {
            MainUserWindow mainUserWindow = new MainUserWindow();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            mainUserWindow.Show();
            authorizationWindow.Close();
        }
        #endregion

        private void VisiblePasswordUserButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void VisiblePasswordUserButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
