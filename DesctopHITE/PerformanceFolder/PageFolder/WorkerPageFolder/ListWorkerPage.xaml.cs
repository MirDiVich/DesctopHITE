using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;

namespace DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder
{
    public partial class ListWorkerPage : Page
    {
        public ListWorkerPage()
        {
            InitializeComponent();
            AppConnectClass.DataBase = new DesctopHiteEntities();
            ListWorkerListBox.ItemsSource = AppConnectClass.DataBase.WorkerTabe.ToList();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                EditButton.IsEnabled = false;
                DeliteButton.IsEnabled = false;
            }
        }
        #region Click
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeliteButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        #region SelectionChanged_MouseDoubleClick
        private void ListWorkerListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void ListWorkerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditButton.IsEnabled = true;
            DeliteButton.IsEnabled = true;
        }
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                HintSearchTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                HintSearchTextBlock.Visibility = Visibility.Collapsed;
                //var Sweep = AppConnectClass.DataBase.PassportTable.Include(Blood => Blood.WorkerTabe).ToList();
                //Sweep = Sweep.Where(Cookie =>
                //Cookie.PassportTable.Surname_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                //Cookie.PassportTable.Name_Passport.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                //Cookie.PassportTable.Middlename_Passport.ToLower().Contains(SearchTextBox.Text.ToLower())) .ToList();

                //ListWorkerListBox.ItemsSource = Sweep.ToList();
            }
        }
        #endregion
    }
}
