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

        public InfoMenuCashWindow(MenuTable menuTable) /// Событие данного окна
        {
            try
            {
                InitializeComponent();
                DataContext = menuTable;
                priseSelectedMenu = Convert.ToInt32(menuTable.Prise_Menu);
                numberOfTheSelectedMenu = menuTable.PersonalNumber_Menu;

                Event__ListIngridient();
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
        private void DecreaseButton_Click(object sender, RoutedEventArgs e) /// Уменьшить кол-во еды
        {
            try
            {
                decreaseIncrease--;
                IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();

                PriseMenuTextBlock.Text = $"{priseSelectedMenu * decreaseIncrease}";
            }
            catch (Exception exDecreaseButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IncreaseButton_Click в InfoMenuCashWindow:\n\n " +
                        $"{exDecreaseButton_Click.Message}");
            }
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e) /// Увеличить кол-во еды
        {
            try
            {
                decreaseIncrease++;
                IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();

                PriseMenuTextBlock.Text = $"{priseSelectedMenu * decreaseIncrease}";
            }
            catch (Exception exIncreaseButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IncreaseButton_Click в InfoMenuCashWindow:\n\n " +
                        $"{exIncreaseButton_Click.Message}");
            }
        }

        private void CanselButton_Click(object sender, RoutedEventArgs e) /// Просто закрыть это окно
        {
            try
            {
                this.Close();
            }
            catch (Exception exCanselButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие CanselButton_Click в InfoMenuCashWindow:\n\n " +
                        $"{exCanselButton_Click.Message}");
            }
        }
        #endregion
        #region Event_
        private void Event__ListIngridient() /// Вывести список ингридиентов
        {
            try
            {
                AppConnectClass.connectDataBase_ACC.MenuTable.Include(ingredients => ingredients.IngredientsTable).Load();
                var ingredientsMenu = AppConnectClass.connectDataBase_ACC.MenuTable.Find(numberOfTheSelectedMenu).IngredientsTable;

                ListIngridientListView.Items.Refresh();
                ListIngridientListView.ItemsSource = ingredientsMenu.ToList();
            }
            catch (Exception exEvent_ListIngridient)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_ListIngridient в InfoMenuCashWindow:\n\n " +
                        $"{exEvent_ListIngridient.Message}");
            }
        }

        private void Event__AddToReceipt()
        {

        }
        #endregion
        #region _TextChanged
        private void IncreaseDecreaseTextBox_TextChanged(object sender, TextChangedEventArgs e) /// Вывод кол-во еды, и блокировка функций
        {
            try
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
            catch (Exception exIncreaseDecreaseTextBox_TextChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие IncreaseDecreaseTextBox_TextChanged в InfoMenuCashWindow:\n\n " +
                        $"{exIncreaseDecreaseTextBox_TextChanged.Message}");
            }
        }
        #endregion
    }
}
