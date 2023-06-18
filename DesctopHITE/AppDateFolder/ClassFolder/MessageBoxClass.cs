//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Данный класс нужен для того, чтобы ссылаться на уже готовый MessageBox,
///     но только присваивать ему своё сообщение.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class MessageBoxClass
    {
        public static void ExceptionMessageBox_MBC( /// MessageBox для ошибок try{} catch (Exception ex){}
            string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", 
            string TopRow = "Error Exception")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void GoodMessageBox_MBC( /// MessageBox вывода удачи для пользователя
            string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", 
            string TopRow = "Fine")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void FailureMessageBox_MBC( /// MessageBox для ошибок допущенных пользователем
            string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", 
            string TopRow = "Неудача")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}