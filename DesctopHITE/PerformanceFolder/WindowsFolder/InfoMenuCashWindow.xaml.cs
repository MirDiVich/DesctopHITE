using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            }
            catch (Exception exInfoMenuCashWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие InfoMenuCashWindow в InfoMenuCashWindow:\n\n " +
                        $"{exInfoMenuCashWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    InitializeComponent();
                    Event_ListIngridient();
                    IncreaseDecreaseTextBox.Text = decreaseIncrease.ToString();
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Window_IsVisibleChanged в InfoMenuCashWindow:\n\n " +
                        $"{exWindow_IsVisibleChanged.Message}");
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
        private void Event_ListIngridient() /// Вывести список ингридиентов
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

        private void Event_AddToReceipt()
        {
            try
            {
                // Создаём таблицы
                var chequeTable = new ChequeTable();
                var addToReceipt = new BasketTable();

                // Добавляем чек
                if (AppConnectClass.theNumberOfTheCreatedReceipt == 0)
                {
                    chequeTable.DataTime_Cheque = DateTime.Now;
                    chequeTable.pnCash_Cheque = Environment.MachineName.ToString();
                    chequeTable.pnWorker_Cheque = 1031;
                    chequeTable.GeneralPrise_Cheque = 0;

                    AppConnectClass.connectDataBase_ACC.ChequeTable.Add(chequeTable);
                    AppConnectClass.connectDataBase_ACC.SaveChanges();
                    AppConnectClass.theNumberOfTheCreatedReceipt = chequeTable.PersonalNumber_Cheque;
                }

                // Смотрим, есть ли уже список продуктов
                if (AppConnectClass.connectDataBase_ACC.BasketTable.Where(dataWhere =>
                        dataWhere.pnCheque == AppConnectClass.theNumberOfTheCreatedReceipt).Count() > 0)
                {
                    // Если да, то проверяем, есть ли выбранное меню
                    if (AppConnectClass.connectDataBase_ACC.BasketTable.Where(dataWhereMenu =>
                        dataWhereMenu.pnMenu == numberOfTheSelectedMenu).Count() > 0)
                    {
                        // Если да, то проверяем общее количество
                        var generalCount = addToReceipt.Quantity_MenuCheque + Convert.ToInt32(IncreaseDecreaseTextBox.Text);
                        if (generalCount >= 10)
                        {
                            MessageBoxClass.FailureMessageBox_MBC(textMessage: "К сожилению нельзя добавить больше 10 позиций этого меню");
                        }

                    }
                }
                // Добавляем позиции в этот чек
                addToReceipt.pnCheque = AppConnectClass.theNumberOfTheCreatedReceipt;
                addToReceipt.pnMenu = numberOfTheSelectedMenu;
                addToReceipt.Quantity_MenuCheque = Convert.ToInt32(IncreaseDecreaseTextBox.Text);
                addToReceipt.Prise_MenuCheque = Convert.ToInt32(PriseMenuTextBlock.Text);

                AppConnectClass.connectDataBase_ACC.BasketTable.AddOrUpdate(addToReceipt);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                // Получаем все блюда из корзины
                var getAnItemFromTheShoppingCart = AppConnectClass.connectDataBase_ACC.BasketTable.Where(selectAReceipt =>
                    selectAReceipt.pnCheque == AppConnectClass.theNumberOfTheCreatedReceipt);

                // Считаем общую стоимость
                var calculateTheTotalCostOfTheGoodsFromKarzina = getAnItemFromTheShoppingCart.Sum(calculateTheAmount =>
                    calculateTheAmount.Prise_MenuCheque);

                MessageBox.Show(calculateTheTotalCostOfTheGoodsFromKarzina.ToString());

                chequeTable.GeneralPrise_Cheque = calculateTheTotalCostOfTheGoodsFromKarzina;

                AppConnectClass.connectDataBase_ACC.ChequeTable.AddOrUpdate(chequeTable);
                AppConnectClass.connectDataBase_ACC.SaveChanges();
            }
            catch (Exception exEvent_AddToReceipt)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_AddToReceipt в InfoMenuCashWindow:\n\n " +
                        $"{exEvent_AddToReceipt.Message}");
            }
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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Event_AddToReceipt();
                this.Close();
            }
            catch (Exception exNextButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NextButton_Click в InfoMenuCashWindow:\n\n " +
                        $"{exNextButton_Click.Message}");
            }
        }
    }
}
