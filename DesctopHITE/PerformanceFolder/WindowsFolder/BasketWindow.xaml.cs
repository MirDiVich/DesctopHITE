﻿//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Обычное окно, которое нужно для вывода корзины пользователя
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class BasketWindow : Window
    {
        public BasketWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();
            }
            catch (Exception exBasketWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие BasketWindow в BasketWindow:\n\n " +
                        $"{exBasketWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) /// Если страница видна
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    Event_PutBasket();
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Window_IsVisibleChanged в BasketWindow:\n\n " +
                        $"{exWindow_IsVisibleChanged.Message}");
            }
        }

        #region Event_
        private void Event_PutBasket() /// Вывод содержимого карзины
        {
            try
            {
                AppConnectClass.connectDataBase_ACC.ChequeTable.Include(basket => basket.BasketTable).Load();
                var dataChack = AppConnectClass.connectDataBase_ACC.ChequeTable.Find(AppConnectClass.theNumberOfTheCreatedReceipt).BasketTable;
                MainBasketListView.ItemsSource = dataChack.ToList();
            }
            catch (Exception exEvent_PutBasket)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_PutBasket в BasketWindow:\n\n " +
                        $"{exEvent_PutBasket.Message}");
            }
        }
        #endregion
    }
}
