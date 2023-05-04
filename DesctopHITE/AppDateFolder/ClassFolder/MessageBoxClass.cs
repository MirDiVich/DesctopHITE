using System.Windows;

namespace DesctopHITE.AppDateFolder.ClassFolder
{
    public class MessageBoxClass
    {
        public static void ExceptionMessage(string textMessage = "textMessage", string titleMessage = "Error Exception")
        {
            MessageBox.Show(
                textMessage, titleMessage,
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}