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
                if (idCategory != null)
                {
                    DataContext = idCategory;
                    idCategory = menuCategoryTable.PersonalNumber_MenuCategory;

                    ImageNewIngridientButtonTextBlock1.Visibility = Visibility.Collapsed;
                    ImageNewIngridientButtonTextBlock2.Visibility = Visibility.Visible;
                    TitleNewIngridientButtonTextBlock.Text = "Изменить";
                }
            }
            catch (Exception exNewCategoryPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewCategoryPage в NewCategoryPage:\n\n " +
                        $"{exNewCategoryPage.Message}");
            }
        }
        #region Event
        private void EventAddCategory()
        {
            try
            {
                string messageda = "успешно добавлен";

                IngredientsTable addOrUpdateIngredients = new IngredientsTable()
                {
                    Name_Ingredients = NameIngridientTextBox.Text
                };

                if (idCategory != null)
                {
                    addOrUpdateIngredients.PersonalNumber_Ingredients = idCategory;
                    messageda = "успешно изменён";
                }

                AppConnectClass.connectDataBase_ACC.IngredientsTable.AddOrUpdate(addOrUpdateIngredients);
                AppConnectClass.connectDataBase_ACC.SaveChanges();

                MessageBoxClass.GoodMessageBox_MBC(textMessage: $"ингредиент {addOrUpdateIngredients.Name_Ingredients} {messageda}");
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListIngridientPage());
            }
            catch (Exception exEventAddEngridi)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventAddEngridi в NewCategoryPage:\n\n " +
                        $"{exEventAddEngridi.Message}");
            }
        }

        private void EventMessageNull()
        {
            try
            {
                if (NameIngridientTextBox.Text == "") messasgeNull += "Поле не должно быть пустым\n\n";
                if (NameIngridientTextBox.Text.Length < 2) messasgeNull += "Название ингредиента не может состоять из 2 и менее букв";
            }
            catch (Exception exEventMessageNull)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие EventMessageNull в NewCategoryPage:\n\n " +
                        $"{exEventMessageNull.Message}");
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
            catch (Exception exDateValidationTextBox)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие DateValidationTextBox в NewCategoryPage:\n\n " +
                        $"{exDateValidationTextBox.Message}");
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
                EventMessageNull();

                if (messasgeNull == "")
                {
                    EventAddCategory();
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
