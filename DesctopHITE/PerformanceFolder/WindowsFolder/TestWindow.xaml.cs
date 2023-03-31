using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
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
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities();
            TestList.ItemsSource = AppConnectClass.DataBase.GenderTable.ToList();
        }

        private void DelitButton_Click(object sender, RoutedEventArgs e)
        {
            GenderTable Gender = (GenderTable)TestList.SelectedItem; // Получаем выбранного сотрудника

            if (Gender == null)
            {
                // Перед удалением проверяем, что сотрудник выбран
                MessageBox.Show(
                    "Гендер не выбран", "Ошибка - E002",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try // помешаем рабочий код в "безопасную каробку"
                {
                    string SurnameNameWorker = Gender.PersonalNumber_Gender + " " + Gender.Title_Gender; ; // Получаем Фамилия и Имя для уведомления

                    // Если пользователь подтверждает удаление сотрудника
                    string MessageTitle = "Вы действительно хотите удалить: " + SurnameNameWorker + " ?";
                    if (MessageBox.Show(
                        MessageTitle, "Удаление",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        // Выполняем удаление
                        AppConnectClass.DataBase.GenderTable.Remove(Gender);

                        // Сохраняем изменения
                        AppConnectClass.DataBase.SaveChanges();

                        // Выводим уведомление с переменными выше
                        string MessageTitleDelit = "" + SurnameNameWorker + " удалён";
                        MessageBox.Show(
                            MessageTitleDelit, "Удаление",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    // Если пользователь отменил действие "Удалить"
                    else
                    {
                        Gender = null;
                        //DeliteButton.IsEnabled = false;
                        //EditButton.IsEnabled = false;
                    }
                }
                // Если произошла ошибка в коде сверху, обрабатываем эту ошибку
                catch (Exception Ex)
                {
                    MessageBox.Show(
                        Ex.Message.ToString(), "Ошибка - E003",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // Действие после удачного или неудачного выполнения работы кода
                finally
                {
                    //WorkerDelit = null;
                    //DeliteButton.IsEnabled = false;
                    //EditButton.IsEnabled = false;
                }
            }
        }
    }
}
