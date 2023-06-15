using DesctopHITE.AppDateFolder.ClassFolder;
using DesctopHITE.AppDateFolder.ModelFolder;
using System;
using System.Data.Entity.Migrations;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DesctopHITE.PerformanceFolder.PageFolder.MenuPageFolder
{
    public partial class NewCategoryPage : Page
    {
        string messasgeNull;
        int idCategory;

        public NewCategoryPage(MenuCategoryTable menuCategoryTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                if (menuCategoryTable != null)
                {
                    DataContext = menuCategoryTable;
                    idCategory = menuCategoryTable.PersonalNumber_MenuCategory;

                    ImageNewCategoryButtonTextBlock1.Visibility = Visibility.Collapsed;
                    ImageNewCategoryButtonTextBlock2.Visibility = Visibility.Visible;
                    TitleNewCategoryButtonTextBlock.Text = "Изменить";
                }
            }
            catch (Exception exNewCategoryPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCategoryPage в NewCategoryPage:\n\n " +
                        $"{exNewCategoryPage.Message}");
            }
        }
        #region Event_
        private void Event_AddCategory()
        {
            try
            {
                string messageda = "успешно добавлен";

                MenuCategoryTable addOrUpdateCategory = new MenuCategoryTable()
                {
                    Title_MenuCategory = NameCategoryTextBox.Text
                };

                if (idCategory != null)
                {
                    addOrUpdateCategory.PersonalNumber_MenuCategory = idCategory;
                    messageda = "успешно изменён";
                }

                AppConnectClass.connectDataBase_ACC.MenuCategoryTable.AddOrUpdate(addOrUpdateCategory);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                MessageBoxClass.GoodMessageBox_MBC(textMessage: $"ингредиент {addOrUpdateCategory.Title_MenuCategory} {messageda}");
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListCategoryPage());
            }
            catch (Exception exEvent_AddEngridi)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_AddEngridi в NewCategoryPage:\n\n " +
                        $"{exEvent_AddEngridi.Message}");
            }
        }

        private void Event_MessageNull()
        {
            try
            {
                if (NameCategoryTextBox.Text == "") messasgeNull += "Поле не должно быть пустым\n\n";
                if (NameCategoryTextBox.Text.Length < 2) messasgeNull += "Название ингредиента не может состоять из 2 и менее букв";
            }
            catch (Exception exEvent_MessageNull)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Event_MessageNull в NewCategoryPage:\n\n " +
                        $"{exEvent_MessageNull.Message}");
            }
        }
        #endregion
        #region ValidData
        // Просто для валидность данных
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex DateRegex = new Regex("[^А-я]");
                e.Handled = DateRegex.IsMatch(e.Text);
            }
            catch (Exception exTextValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие TextValidationTextBox в NewCategoryPage:\n\n " +
                        $"{exTextValidationTextBox.Message}");
            }
        }
        #endregion
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListCategoryPage());
            }
            catch (Exception exButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Button_Click в NewCategoryPage:\n\n " +
                        $"{exButton_Click.Message}");
            }
        }

        private void NewCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                messasgeNull = "";
                Event_MessageNull();

                if (messasgeNull == "")
                {
                    Event_AddCategory();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: messasgeNull);
                }
            }
            catch (Exception exNewCategoryButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCategoryButton_Click в NewCategoryPage:\n\n " +
                        $"{exNewCategoryButton_Click.Message}");
            }
        }
    }
}
