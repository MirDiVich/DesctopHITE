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

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class InfoMenuCashWindow : Window
    {
        int decreaseIncrease = 1;

        public InfoMenuCashWindow()
        {
            InitializeComponent();
            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
        }

        #region _Click
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            decreaseIncrease--;
            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            decreaseIncrease++;
            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
        }
        #endregion

        private void IncreaseDecreaseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decreaseIncrease >= 10)
            {
                IncreaseButton.IsEnabled = false;
            }
            else
            {
                IncreaseButton.IsEnabled = true;
            }

            if (decreaseIncrease == 1)
            {
                DecreaseButton.IsEnabled = false;
            }
            else
            {
                DecreaseButton.IsEnabled = true;
            }

            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
        }
    }
}
