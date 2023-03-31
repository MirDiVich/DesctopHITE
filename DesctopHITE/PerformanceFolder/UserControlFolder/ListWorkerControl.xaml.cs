using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.PerformanceFolder.UserControlFolder
{
    public partial class ListWorkerControl : UserControl
    {
        public ListWorkerControl()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities();
        }
        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PassportTable passportTable = new PassportTable();

                if (passportTable.Image_Passport == null)
                {
                    ImageSource userImage = new BitmapImage(new Uri("/ContentFolder/ImageFolder/NoImage.png", UriKind.RelativeOrAbsolute)); // Вывод стандартного фото
                    UserImage.Source = userImage;
                }
            }
        }
    }
}
