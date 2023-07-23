using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Client.Project
{
    public partial class TestEditor : ContentPage
    {
        private TestEditorViewModel viewModel;

        public TestEditor(Class_interaction_Users.Test test)
        {
            InitializeComponent();
            viewModel = new TestEditorViewModel
            {
                Id = test.Id,
                Name_Test = test.Name_Test,
                Options_Id = test.Options_Id,
            };
            BindingContext = viewModel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the TestEditorViewModel instance
            int id = viewModel.Id;
            string name_Test = viewModel.Name_Test;
            int options_Id = viewModel.Options_Id;

            // Create a new Test instance or update the existing Test instance with the retrieved values
            Class_interaction_Users.Test test = new Class_interaction_Users.Test
            {
                Id = id,
                Name_Test = name_Test,
                Options_Id = options_Id
            };

            // Perform the necessary operations to save the updated or new Test data
            // Example: Call a method to save the test data to a database or update an existing record
            viewModel.UpDateTestData(test);

            // Display a message to indicate that the test data has been saved successfully
            DisplayAlert("Изменения сохранены", "", "OK");

            // Close the window after saving
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования теста
            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");

            // Закрыть окно без сохранения
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        //private void GoBack(object sender, EventArgs e)
        //{
        //    var mainPage = new Project.RefTestListPage();
        //    var navigationPage = new NavigationPage(mainPage);
        //    Application.Current.MainPage = navigationPage;
        //}

        private void GoBack(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }

    }
}