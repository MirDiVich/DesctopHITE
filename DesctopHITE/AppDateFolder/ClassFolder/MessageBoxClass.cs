///----------------------------------------------------------------------------------------------------------
/// Данный класс нужен для того, чтобы ссылаться на уже готовый MessageBox,
///     но только присваивать ему своё сообщение.
///----------------------------------------------------------------------------------------------------------

using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class MessageBoxClass
    {
        public static void ExceptionMessageBox_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string TopRow = "Error Exception")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void GoodMessageBox_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string TopRow = "Fine")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void FailureMessageBox_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string TopRow = "Неудача")
        {
            MessageBox.Show(
                textMessage, TopRow,
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}