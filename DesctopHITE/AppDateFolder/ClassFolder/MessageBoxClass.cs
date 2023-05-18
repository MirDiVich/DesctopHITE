﻿///----------------------------------------------------------------------------------------------------------
/// Данный класс нужен для того, чтобы ссылаться на уже готовый MessageBox,
///     но только присваивать ему своё сообщение.
///----------------------------------------------------------------------------------------------------------

using System.Windows;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class MessageBoxClass
    {
        public static void EventExceptionMessage_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string titleMessage = "Error Exception")
        {
            MessageBox.Show(
                textMessage, titleMessage,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void EventGoodMessage_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string titleMessage = "Error Exception")
        {
            MessageBox.Show(
                textMessage, titleMessage,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void EventFailureMessage_MBC(string textMessage = "Разработчик (программист) не присвоил этому значению сообщение", string titleMessage = "Неудача")
        {
            MessageBox.Show(
                textMessage, titleMessage,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}