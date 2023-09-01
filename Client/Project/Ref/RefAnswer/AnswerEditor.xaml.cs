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
    public partial class AnswerEditor : ContentPage
    {
        private AnswerEditorViewModel viewModel;
        private AnswerManager viewModelManager;

        public AnswerEditor(Class_interaction_Users.Answer answer)
        {
            try
            {
                InitializeComponent();

                viewModel = new AnswerEditorViewModel
                {
                    Id = answer.Id,
                    AnswerOptions = answer.AnswerOptions,
                    CorrectAnswers = answer.CorrectAnswers
                };

                viewModelManager = new AnswerManager();
                BindingContext = viewModel;
            }catch (Exception ex)
            {
               DisplayAlert("Ошибка ответ!",ex.Message ,"ОК");
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the AnswerEditorViewModel instance
            int id = viewModel.Id;
            string answerOptions = viewModel.AnswerOptions;
            bool correctAnswers = viewModel.CorrectAnswers;

            // Create a new Answer instance or update the existing Answer instance with the retrieved values
            Class_interaction_Users.Answer answer = new Class_interaction_Users.Answer
            {
                Id = id,
                AnswerOptions = answerOptions,
                CorrectAnswers = correctAnswers
            };

            // Perform the necessary operations to save the updated or new Answer data
            // Example: Call a method to save the answer data to a database or update an existing record
            viewModelManager.UpdateAnswerData(answer);

            // Display a message to indicate that the answer data has been saved successfully
            DisplayAlert("Изменения сохранены", "", "OK");

            // Close the window after saving
            //Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования теста
            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");
            // Закрыть окно без сохранения
            //Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        //private void GoBack(object sender, EventArgs e)
        //{        //    var mainPage = new Project.RefExamsListPage();
        //    var navigationPage = new NavigationPage(mainPage);        //    Application.Current.MainPage = navigationPage;
        //}

        private async void GoBack(object sender, EventArgs e)
        {
            //if (Application.Current.MainPage is NavigationPage navigationPage)
            //{
            //    navigationPage.Navigation.PopAsync();
            //}
            await Navigation.PopAsync();

        }
    }
}