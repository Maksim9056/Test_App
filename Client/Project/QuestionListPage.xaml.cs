//namespace Client.Project;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Client.Project
{
    public partial class QuestionListPage : ContentPage
    {
        public QuestionListPage()
        {
            InitializeComponent();
            questionList.ItemsSource = GetQuestionList();
        }

        private List<Question> GetQuestionList()
        {
            return new List<Question>
            {
                new Question { Question1 = "Вопрос 1" },
                new Question { Question1 = "Вопрос 2" },
                new Question { Question1 = "Вопрос 3" }
            };
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedQuestion = (Question)e.SelectedItem;
            await DisplayAlert("Выбранный вопрос", selectedQuestion.Question1, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void GoBack(object sender, EventArgs e)
        {
            // Логика возврата к предыдущему окну
        }

        public class Question
        {
            public string Question1 { get; set; }
        }
    }
}
