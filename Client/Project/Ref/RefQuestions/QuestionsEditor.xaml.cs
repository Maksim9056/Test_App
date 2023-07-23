//using ClassinteractionUsers;
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
using Class_interaction_Users;

namespace Client.Project
{
    public partial class QuestionsEditor : ContentPage
    {
        private QuestionsEditorViewModel viewModel;
        private QuestionManager viewModelManager;

        public QuestionsEditor(Questions questions)
        {
            InitializeComponent();

            viewModel = new QuestionsEditorViewModel
            {
                Id = questions.Id,
                QuestionName = questions.QuestionName,
                AnswerTrue = questions.AnswerTrue,
                Grade = questions.Grade,
            };

            viewModelManager = new QuestionManager();
            BindingContext = viewModel;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the QuestionsEditorViewModel instance
            int id = viewModel.Id;
            string question = viewModel.QuestionName;
            string answerTrue = viewModel.AnswerTrue;
            int grade = viewModel.Grade;

            // Create a new Questions instance or update the existing Questions instance with the retrieved values
            Questions questions = new Questions
            {
                Id = id,
                QuestionName = question,
                AnswerTrue = answerTrue,
                Grade = grade
            };

            // Perform the necessary operations to save the updated or new Questions data
            // Example: Call a method to save the questions data to a database or update an existing record
            viewModelManager.UpdateQuestionData(questions);

            // Display a message to indicate that the questions data has been saved successfully
            DisplayAlert("Изменения сохранены", "", "OK");

            // Close the window after saving
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования вопросов
            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");
            // Закрыть окно без сохранения
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Project.RefQuestionsListPage();
            var navigationPage = new NavigationPage(mainPage);
            Application.Current.MainPage = navigationPage;
        }
    }
}