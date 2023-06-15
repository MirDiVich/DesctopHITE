using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class InfoMenuCashWindow : Window
    {
        int decreaseIncrease = 1;
        int numberOfTheSelectedMenu;
        int priseSelectedMenu;

        public InfoMenuCashWindow(MenuTable menuTable)
        {
            try
            {
                InitializeComponent();
                DataContext = menuTable;
                priseSelectedMenu = Convert.ToInt32(menuTable.Prise_Menu);
                numberOfTheSelectedMenu = menuTable.PersonalNumber_Menu;

                EventListIngridient();
                IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
            }
            catch (Exception exInfoMenuCashWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие InfoMenuCashWindow в InfoMenuCashWindow:\n\n " +
                        $"{exInfoMenuCashWindow.Message}");
            }
        }

        #region _Click
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            decreaseIncrease--;
            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();

            PriseMenuTextBlock.Text = $"{priseSelectedMenu * decreaseIncrease}";
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            decreaseIncrease++;
            IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();

            PriseMenuTextBlock.Text = $"{priseSelectedMenu * decreaseIncrease}";
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Event
        private void EventListIngridient()
        {
            AppConnectClass.connectDataBase_ACC.MenuTable.Include(ingredients => ingredients.IngredientsTable).Load();
            var ingredientsMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(numberOfTheSelectedMenu).IngredientsTable;

            ListIngridientListView.Items.Refresh();
            ListIngridientListView.ItemsSource = ingredientsMenu.ToList();
        }
        #endregion
        #region _TextChanged
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
        #endregion
    }
}
