﻿using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class WaitingForANewOrderWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        Random random = new Random();

        int backRandom;

        public WaitingForANewOrderWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(10);
                dispatcherTimer.Tick += DispatcherTimer_Tick;
            }
            catch (Exception exWaitingForANewOrderWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие WaitingForANewOrderWindow в WaitingForANewOrderWindow:\n\n " +
                    $"{exWaitingForANewOrderWindow.Message}");
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (Visibility == Visibility.Visible)
                {
                    dispatcherTimer.Start();
                    Event_RandomImage();
                }
                else
                {
                    dispatcherTimer.Stop();
                }
            }
            catch (Exception exWindow_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Window_IsVisibleChanged в WaitingForANewOrderWindow:\n\n " +
                    $"{exWindow_IsVisibleChanged.Message}");
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e) /// Метод на вывод рандомного фото
        {
            try
            {
                Event_RandomImage();
            }
            catch (Exception exDispatcherTimer_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие DispatcherTimer_Tick в WaitingForANewOrderWindow:\n\n " +
                    $"{exDispatcherTimer_Tick.Message}");
            }
        }

        #region Event_
        private void Event_StartAnOrder() /// Что бы начать заказ
        {
            try
            {

            }
            catch (Exception exEvent_StartAnOrder)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_StartAnOrder в WaitingForANewOrderWindow:\n\n " +
                    $"{exEvent_StartAnOrder.Message}");
            }
        }

        private void Event_RandomImage()
        {
            try
            {
                // Рандомно получаем фото от 1 до 6
                int personalNumberImage = random.Next(1, 6);

                // Ищем это фото
                var dataImage = AppConnectClass.connectDataBase_ACC.ThePerfectOfferTable.Find(personalNumberImage);

                // Конверт фото
                using (MemoryStream stream = new MemoryStream(dataImage.Image_ThePerfectOffer))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    ImageImage.Source = bitmapImage;
                }
            }
            catch (Exception exEvent_RandomImage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_RandomImage в WaitingForANewOrderWindow:\n\n " +
                    $"{exEvent_RandomImage.Message}");
            }
        }
        #endregion
    }
}