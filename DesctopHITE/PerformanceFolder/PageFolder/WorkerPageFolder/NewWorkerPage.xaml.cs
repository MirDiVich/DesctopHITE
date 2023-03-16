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

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class NewWorkerPage : Page
    {
        public NewWorkerPage()
        {
            InitializeComponent();
        }

        #region Click
        private void PassportToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassportToggleButton.IsChecked == true)
            {
                PassportBorder.Visibility = Visibility.Visible;
            }
            else
            {
                PassportBorder.Visibility = Visibility.Collapsed;
            }
        }
        private void PlaceResidenceToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceResidenceToggleButton.IsChecked == true)
            {
                PlaceResidenceBorder.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceResidenceBorder.Visibility = Visibility.Collapsed;
            }
        }
        private void MedicalBookToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedicalBookToggleButton.IsChecked == true)
            {
                MedicalBookBorder.Visibility = Visibility.Visible;
            }
            else
            {
                MedicalBookBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void SnilsToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (SnilsToggleButton.IsChecked == true)
            {
                SnilsBorder.Visibility = Visibility.Visible;
            }
            else
            {
                SnilsBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void INNToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //if (PassportToggleButton.IsChecked == true)
            //{
            //    PassportBorder.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    PassportBorder.Visibility = Visibility.Collapsed;
            //}
        }

        private void SalaryCardToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //if (PassportToggleButton.IsChecked == true)
            //{
            //    PassportBorder.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    PassportBorder.Visibility = Visibility.Collapsed;
            //}
        }

        private void GeneralDataToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //if (PassportToggleButton.IsChecked == true)
            //{
            //    PassportBorder.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    PassportBorder.Visibility = Visibility.Collapsed;
            //}
        }
        #endregion
    }
}
