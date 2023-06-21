using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using DesctopHITE.PerformanceFolder.PageFolder.WorkerPageFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

                Event_MenuCount();
                Event_CategoryCount();
                Event_IngridientCount();
                Event_MinimazePeise();
                Event_AveragePeise();
                Event_MaxsimazePeise();
                Event_GeneralPeise();

                AppConnectClass.connectDataBase_ACC.IngredientsTable.Include(c => c.MenuTable).Load();
                var rr = AppConnectClass.connectDataBase_ACC.IngredientsTable;
                //ViewMenuCategoryListView.ItemsSource = AppConnectClass.connectDataBase_ACC.ViewMenuCategory.ToList();
                //ViewMenuIngridientListView.ItemsSource = AppConnectClass.connectDataBase_ACC.ViewIngridientMenu.ToList();
                ///<!--
                /// Так как я вывожу информацию из связи многие ко многим, представление просто есть, но его нет
                /// -->
            }
            catch (Exception exGeneralInformationMenuPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие GeneralInformationMenuPage в GeneralInformationMenuPage:\n\n " +
                        $"{exGeneralInformationMenuPage.Message}");
            }
        }
        #region Event_
        private void Event_MenuCount() // Подсчет общего количества меню
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
            catch (Exception exEvent_MenuCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MenuCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_MenuCount.Message}");
            }
        }

        private void Event_CategoryCount() // Подсчет общего количества категории
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
            catch (Exception exEvent_CategoryCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_CategoryCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_CategoryCount.Message}");
            }
        }

        private void Event_IngridientCount() // Подсчет общего количества ингредиентов
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
            catch (Exception exEvent_IngridientCount)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_IngridientCount в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_IngridientCount.Message}");
            }
        }

        private void Event_MinimazePeise() // Получение минимальной цены блюда
        {
            try
            {
                var minimazePrise = AppConnectClass.connectDataBase_ACC.MenuTable.OrderBy(miniData => miniData.Prise_Menu).FirstOrDefault();
                MinPriseTextBlock.Text = $"{minimazePrise.Prise_Menu}₽ ({minimazePrise.Name_Menu} '{minimazePrise.MenuCategoryTable.Title_MenuCategory}')";
            }
            catch (Exception exEvent_MinimazePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MinimazePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_MinimazePeise.Message}");
            }
        }

        private void Event_AveragePeise() // Получение среднего значения цены
        {
            try
            {
                var generalCount = AppConnectClass.connectDataBase_ACC.MenuTable.Count();
                var generalPrise = AppConnectClass.connectDataBase_ACC.MenuTable.Sum(generData => generData.Prise_Menu);

                AveragePriseCountTextBlock.Text = $"{generalPrise}₽";
            }
            catch (Exception exEvent_AveragePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_AveragePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_AveragePeise.Message}");
            }
        }

        private void Event_MaxsimazePeise() // Получение максимальной цены блюда
        {
            try
            {
                var maxsimazePrise = AppConnectClass.connectDataBase_ACC.MenuTable.OrderByDescending(maxData => maxData.Prise_Menu).FirstOrDefault();
                MaxPriseCountTextBlock.Text = $"{maxsimazePrise.Prise_Menu}₽ ({maxsimazePrise.Name_Menu} '{maxsimazePrise.MenuCategoryTable.Title_MenuCategory}')";
            }
            catch (Exception exEvent_MaxsimazePeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MaxsimazePeise в GeneralInformationMenuPage:\n\n " +
                        $"{exEvent_MaxsimazePeise.Message}");
            }
        }

        private void Event_GeneralPeise() // Получение общей цены блюд
        {
            try
            {
                var generalPrise = AppConnectClass.connectDataBase_ACC.MenuTable.Sum(generData => generData.Prise_Menu);
                GeneralPriseTextBlock.Text = $"{generalPrise}₽";
            }
            catch (Exception exEvent_GeneralPeise)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
               textMessage: $"Событие Event_GeneralPeise в GeneralInformationMenuPage:\n\n " +
               $"{exEvent_GeneralPeise.Message}");
            }
        }
        #endregion
    }
}
