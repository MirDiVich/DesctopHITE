using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class GeneralInformationMenuPage : Page
    {
        public GeneralInformationMenuPage()
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                EventMenuCount();
                EventCategoryCount();
                EventIngridientCount();
                EventMinimazePeise();
                EventAveragePeise();
                EventMaxsimazePeise();
                EventGeneralPeise();
                //ViewMenuCategoryListView.ItemsSource = AppConnectClass.connectDataBase_ACC.ViewMenuCategory.ToList();
                //ViewMenuIngridientListView.ItemsSource = AppConnectClass.connectDataBase_ACC.ViewIngridientMenu.ToList();
            }
            catch (Exception exGeneralInformationMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GeneralInformationMenuPage в GeneralInformationMenuPage:\n\n " +
                        $"{exGeneralInformationMenuPage.Message}");
            }
        }
        #region Event
        private void EventMenuCount() // Подсчет общего количества меню
        {
            try
            {
                var countMenuData = AppConnectClass.connectDataBase_ACC.MenuTable.Count();

                if (countMenuData == 1)
                {
                    MenuCountTextBlock.Text = $"{countMenuData} позиция";
                }
                if (countMenuData >= 2)
                {
                    MenuCountTextBlock.Text = $"{countMenuData} позиции";
                }
                if (countMenuData >= 5)
                {
                    MenuCountTextBlock.Text = $"{countMenuData} позиций";
                }
            }
            catch (Exception exEventMenuCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventMenuCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEventMenuCount.Message}");
            }
        }

        private void EventCategoryCount() // Подсчет общего количества категории
        {
            try
            {
                var countCategoryData = AppConnectClass.connectDataBase_ACC.MenuCategoryTable.Count();

                if (countCategoryData == 1)
                {
                    CategoryCountTextBlock.Text = $"{countCategoryData} категория";
                }
                if (countCategoryData >= 2)
                {
                    CategoryCountTextBlock.Text = $"{countCategoryData} категории";
                }
                if (countCategoryData >= 5)
                {
                    CategoryCountTextBlock.Text = $"{countCategoryData} категорий";
                }
            }
            catch (Exception exEventCategoryCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventCategoryCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEventCategoryCount.Message}");
            }
        }

        private void EventIngridientCount() // Подсчет общего количества ингредиентов
        {
            try
            {
                var countIngridientData = AppConnectClass.connectDataBase_ACC.IngredientsTable.Count();

                if (countIngridientData == 1)
                {
                    IngridientCountTextBlock.Text = $"{countIngridientData} ингредиент";
                }
                if (countIngridientData >= 2)
                {
                    IngridientCountTextBlock.Text = $"{countIngridientData} ингредиента";
                }
                if (countIngridientData >= 5)
                {
                    IngridientCountTextBlock.Text = $"{countIngridientData} ингредиентов";
                }
            }
            catch (Exception exEventIngridientCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventIngridientCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEventIngridientCount.Message}");
            }
        }

        private void EventMinimazePeise() // Получение минимальной цены блюда
        {
            try
            {
                var minimazePrise = AppConnectClass.connectDataBase_ACC.MenuTable.OrderBy(miniData => miniData.Prise_Menu).FirstOrDefault();
                MinPriseTextBlock.Text = $"{minimazePrise.Prise_Menu}₽ ({minimazePrise.Name_Menu} '{minimazePrise.MenuCategoryTable.Title_MenuCategory}')";
            }
            catch (Exception exEventMinimazePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventMinimazePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEventMinimazePeise.Message}");
            }
        }

        private void EventAveragePeise() // Получение среднего значения цены
        {
            try
            {
                var generalCount = AppConnectClass.connectDataBase_ACC.MenuTable.Count();
                var generalPrise = AppConnectClass.connectDataBase_ACC.MenuTable.Sum(generData => generData.Prise_Menu);

                AveragePriseCountTextBlock.Text = $"{Math.Round(generalPrise / generalCount, 2)}₽";
            }
            catch (Exception exEventAveragePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventAveragePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEventAveragePeise.Message}");
            }
        }

        private void EventMaxsimazePeise() // Получение максимальной цены блюда
        {
            try
            {
                var maxsimazePrise = AppConnectClass.connectDataBase_ACC.MenuTable.OrderByDescending(maxData => maxData.Prise_Menu).FirstOrDefault();
                MaxPriseCountTextBlock.Text = $"{maxsimazePrise.Prise_Menu}₽ ({maxsimazePrise.Name_Menu} '{maxsimazePrise.MenuCategoryTable.Title_MenuCategory}')";
            }
            catch (Exception exEventMaxsimazePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventMaxsimazePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEventMaxsimazePeise.Message}");
            }
        }

        private void EventGeneralPeise() // Получение общей цены блюд
        {
            try
            {
                var generalPrise = AppConnectClass.connectDataBase_ACC.MenuTable.Sum(generData => generData.Prise_Menu);
                GeneralPriseTextBlock.Text = $"{generalPrise}₽";
            }
            catch (Exception exEventGeneralPeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
               textMessage: $"Событие EventGeneralPeise в GeneralInformationMenuPage:\n\n " +
               $"{exEventGeneralPeise.Message}");
            }
        }
        #endregion
    }
}
