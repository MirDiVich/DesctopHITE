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
    public partial class NewIngredientsPage : Page
    {
        string messasgeNull;
        int idIngredient;

        public NewIngredientsPage(IngredientsTable ingredientsTable)
        {
            try
            {
                InitializeComponent();
                AppConnectClass.connectDataBase_ACC = new DesctopHiteEntities();

                if (ingredientsTable != null )
                {
                    DataContext = ingredientsTable;
                    idIngredient = ingredientsTable.PersonalNumber_Ingredients;

                    ImageNewIngridientButtonTextBlock1.Visibility = Visibility.Collapsed; 
                    ImageNewIngridientButtonTextBlock2.Visibility = Visibility.Visible; 
                    TitleNewIngridientButtonTextBlock.Text = "Изменить"; 
                }
            }
            catch (Exception exNewIngredientsPage)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewIngredientsPage в NewIngredientsPage:\n\n " +
                        $"{exNewIngredientsPage.Message}");
            }
        }
        #region Event
        private void EventAddIngridient()
        {
            try
            {
                string messageda = "успешно добавлен";

                IngredientsTable addOrUpdateIngredients  = new IngredientsTable()
                {
                    Name_Ingredients = NameIngridientTextBox.Text
                };

                if (idIngredient != null )
                {
                    addOrUpdateIngredients.PersonalNumber_Ingredients = idIngredient;
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
                        textMessage: $"Событие EventAddEngridi в NewIngredientsPage:\n\n " +
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
                        textMessage: $"Событие EventMessageNull в NewIngredientsPage:\n\n " +
                        $"{exEventMessageNull.Message}");
            }
        }
        #endregion

        private void NewIngridientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                messasgeNull = "";
                EventMessageNull();

                if (messasgeNull == "")
                {
                    EventAddIngridient();
                }
                else
                {
                    MessageBoxClass.FailureMessageBox_MBC(textMessage: messasgeNull);
                }
            }
            catch (Exception exNewIngridientButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие NewIngridientButton_Click в NewIngredientsPage:\n\n " +
                        $"{exNewIngridientButton_Click.Message}");
            }
        }

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
                        textMessage: $"Событие TextValidationTextBox в NewWorkerPage:\n\n " +
                        $"{exTextValidationTextBox.Message}");
            }
        }
        #endregion

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FrameNavigationClass.bodyMenu_FNC.Navigate(new ListIngridientPage());
            }
            catch (Exception exButton_Click)
            {
                MessageBoxClass.ExceptionMessageBox_MBC(
                        textMessage: $"Событие Button_Click в NewIngredientsPage:\n\n " +
                        $"{exButton_Click.Message}");
            }
        }
    }
}
