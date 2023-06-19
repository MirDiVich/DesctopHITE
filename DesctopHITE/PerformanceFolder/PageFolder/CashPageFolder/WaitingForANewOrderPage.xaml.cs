//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Обычная страница, которая отображает рекламу. Данная страница вызывается автоматически системой.
/// На данной странице выгружается реклама из БД.
/// Метод выгрузки простой, система рандомно отбирает номер рекламы, 
///     после чего находит данную рекламу и выгружает её. Отбор идёт по ID.
/// Реклама представляет из себя просто картинку, сделанную и загруженную в бд заранее.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.WindowsFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.PageFolder.CashPageFolder
{
    public partial class WaitingForANewOrderPage : Page
    {
        DispatcherTimer dispatcherTimer;
        Random random = new Random();

        int backRandom;

        public WaitingForANewOrderPage()
        {

            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(10);
                dispatcherTimer.Tick += DispatcherTimer_Tick;
            }
            catch (Exception exWaitingForANewOrderPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие WaitingForANewOrderPage в WaitingForANewOrderPage:\n\n " +
                    $"{exWaitingForANewOrderPage.Message}");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
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
            catch (Exception exPage_IsVisibleChanged)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Page_IsVisibleChanged в WaitingForANewOrderPage:\n\n " +
                    $"{exPage_IsVisibleChanged.Message}");
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e) /// Раз в n время выполнять метод
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
                // Добавляем чек
                if (AppConnectClass.theNumberOfTheCreatedReceipt == 0)
                {
                    var chequeTable = new ChequeTable();

                    chequeTable.DataTime_Cheque = DateTime.Now;
                    chequeTable.pnCash_Cheque = Environment.MachineName.ToString();
                    chequeTable.pnWorker_Cheque = 1031;
                    chequeTable.GeneralPrise_Cheque = 0;

                    AppConnectClass.connectDataBase_ACC.ChequeTable.Add(chequeTable);
                    AppConnectClass.connectDataBase_ACC.SaveChanges();
                    AppConnectClass.theNumberOfTheCreatedReceipt = chequeTable.PersonalNumber_Cheque;
                }

                WaitingForANewOrderWindow waitingForANewOrderWindow = new WaitingForANewOrderWindow();
                waitingForANewOrderWindow.Close();
            }
            catch (Exception exEvent_StartAnOrder)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_StartAnOrder в WaitingForANewOrderWindow:\n\n " +
                    $"{exEvent_StartAnOrder.Message}");
            }
        }

        private void Event_RandomImage() /// Метод на вывод рандомного фото
        {
            try
            {
                // Получаем минимальный id рекламы и максимальный
                var minIdAdvertisement = AppConnectClass.connectDataBase_ACC.ThePerfectOfferTable.Min(dataMin => dataMin.PersonalNumber_ThePerfectOffer);
                var maxIdAdvertisement = AppConnectClass.connectDataBase_ACC.ThePerfectOfferTable.Max(dataMax => dataMax.PersonalNumber_ThePerfectOffer);

                // Получаем рандомный ID рекламы из имеющихся
                int personalNumberImage = random.Next(minIdAdvertisement, maxIdAdvertisement);

                // Ищем выбранную рекламу
                var dataImage = AppConnectClass.connectDataBase_ACC.ThePerfectOfferTable.Find(personalNumberImage);

                // Конверт фото
                using (MemoryStream stream = new MemoryStream(dataImage.Image_ThePerfectOffer))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    NewImage.Source = bitmapImage;
                }
            }
            catch (Exception exEvent_RandomImage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                    textMessage: $"Событие Event_RandomImage в WaitingForANewOrderWindow:\n\n " +
                    $"{exEvent_RandomImage.Message}");
            }
            ///<!--
            /// !!! Может не сработать, если допустим Id рекламы идёт не по порядку (1, 2, 3, ...), а в разнобой (5, 10, 26, ...)
            /// Это по идеи можно решить, просто получив список всех Id и уже рандомно из данного списка найти, что следует, что
            ///     мой метод немного не правильный.
            /// -->
        }
        #endregion

        private void NextButton_Click(object sender, RoutedEventArgs e) { Event_StartAnOrder(); }
        private void Page_MouseDown(object sender, MouseButtonEventArgs e) { Event_StartAnOrder(); }
    }
}
