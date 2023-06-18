//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Данное окно представляет из себя окно ожидания.
/// Когда сотрудник или клиент ничего не делает на экране, то система встаёт в режим ожидания (появляется данное окно)
///     после чего, если таймер закончится или не нажали на продолжить, или нажали на отменить,
///     то созданные чек удалится, и система будет готова к созданию нового заказа
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Windows;
using System.Windows.Threading;

namespace DesctopHITE.PerformanceFolder.WindowsFolder
{
    public partial class WaitingTimerWindow : Window
    {
        DispatcherTimer dispatcher;
        TimeSpan timeSpan;

        public WaitingTimerWindow()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                dispatcher = new DispatcherTimer();
                dispatcher.Interval = TimeSpan.FromSeconds(1);
                dispatcher.Tick += Dispatcher_Tick;

                timeSpan = TimeSpan.FromSeconds(10);

                dispatcher.Start();
            }
            catch (Exception exWaitingTimerWindow)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие WaitingTimerWindow в WaitingTimerWindow:\n\n " +
                        $"{exWaitingTimerWindow.Message}");
            }
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timeSpan == TimeSpan.Zero)
                {
                    Event_TimerClose();
                }
                else
                {
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                    TimeTextBlock.Text = timeSpan.ToString("ss");
                }
            }
            catch (Exception exDispatcher_Tick)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Dispatcher_Tick в WaitingTimerWindow:\n\n " +
                        $"{exDispatcher_Tick.Message}");
            }
        }

        #region
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dispatcher.Stop();
                this.Close();
            }
            catch (Exception exNextButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NextButton_Click в WaitingTimerWindow:\n\n " +
                        $"{exNextButton_Click.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) { Event_TimerClose(); }
        #endregion
        #region Event_
        private void Event_TimerClose() /// Если таймер закончился или отменили заказ, то удаляется чек из базы данных, содержимое корзины и идёт подготовка к новому заказу
        {
            try
            {
                dispatcher.Stop();

                // Удаляем чек
                var checkSearch = AppConnectClass.connectDataBase_ACC.ChequeTable.Find(AppConnectClass.theNumberOfTheCreatedReceipt);
                AppConnectClass.connectDataBase_ACC.ChequeTable.Remove(checkSearch);
                AppConnectClass.connectDataBase_ACC.SaveChanges();
                AppConnectClass.theNumberOfTheCreatedReceipt = 0;

                this.Close();

                WaitingForANewOrderWindow waitingForANewOrderWindow = new WaitingForANewOrderWindow();
                waitingForANewOrderWindow.ShowDialog();
            }
            catch (Exception exEvent_TimerClose)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_TimerClose в WaitingTimerWindow:\n\n " +
                        $"{exEvent_TimerClose.Message}");
            }
        }
        #endregion
    }
}
