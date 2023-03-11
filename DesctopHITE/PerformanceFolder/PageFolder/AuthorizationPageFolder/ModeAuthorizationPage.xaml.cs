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

namespace DesctopHITE.PerformanceFolder.PageFolder.AuthorizationPageFolder
{
    public partial class ModeAuthorizationPage : Page
    {
        public ModeAuthorizationPage()
        {
            InitializeComponent();
        }

        private void Customization_ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsChecked_False();
            IsEnabled_True();
            Customization_ToggleButton.IsChecked = true;
            Customization_ToggleButton.IsEnabled = false;
        }

        private void Kassa_ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            IsChecked_False();
            IsEnabled_True();
            Kassa_ToggleButton.IsChecked = true;
            Kassa_ToggleButton.IsEnabled = false;
        }

        private void IsChecked_False()
        {
            Customization_ToggleButton.IsChecked = false;
            Kassa_ToggleButton.IsChecked = false;
        }

        private void IsEnabled_True()
        {
            Customization_ToggleButton.IsEnabled = true;
            Kassa_ToggleButton.IsEnabled = true;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible) 
            {
                Kassa_ToggleButton.IsChecked =  true;
            }
        }
    }
}
