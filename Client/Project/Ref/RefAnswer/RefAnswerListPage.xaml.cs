using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;
using System.Collections.ObjectModel;

namespace Client.Project
{
    public partial class RefAnswerListPage : ContentPage
    {
        public CommandCL command = new CommandCL();
        private AnswerEditorViewModel viewModel;
        private AnswerManager viewModelManager;
        public Class_interaction_Users.Answer vSelectedItem { get; set; }
        public RefAnswerListPage()
        {
            InitializeComponent();
            viewModel = new AnswerEditorViewModel();
            viewModelManager = new AnswerManager();
            AnswerList1.ItemsSource = GetAnswers();
        }

        private void UpdateForm()
        {
            AnswerList1.ItemsSource = GetAnswers();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            // Your code here
            UpdateForm();
        }

        private List<Answer> GetAnswers()
        {
            List<Answer> answerList = new List<Answer>();

            CommandCL.AnswerListGet = null;
            viewModelManager.GetAnswerList();

            if (CommandCL.AnswerListGet == null)
            {
                // Handle the case when the questions list is null
            }
            else
            {
                for (int i = 0; i < CommandCL.AnswerListGet.ListAnswer.Count; i++)
                {
                    var answer = new Answer { Answers = CommandCL.AnswerListGet.ListAnswer[i], EditCommand = new Command(Edit), DelCommand = new Command(Del) };
                    answerList.Add(answer);
                }
            }

            return answerList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedAnswer = (Answer)e.SelectedItem;
            await DisplayAlert("Выбранный вопрос", selectedAnswer.Answers.AnswerOptions, "OK");
            //await Navigation.PushAsync(new DocQuestionAnswerListPage(selectedAnswer.Answers));

            ((ListView)sender).SelectedItem = null;
        }

        private void Edit(object answer)
        {
            var selectedAnswer = (Answer)answer;
            //Navigation.PushAsync(new AnswerEditor(selectedAnswer.Question));
        }

        private void Del(object answer)
        {
            var selectedAnswer = (Answer)answer;

            viewModelManager.DeleteAnswerData(selectedAnswer.Answers);

            DisplayAlert("Удаляется вопрос", selectedAnswer.Answers.AnswerOptions, "OK");
            UpdateForm();
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Администратор();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }

        public class Answer
        {
            public Class_interaction_Users.Answer Answers { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AnswerCreate());
        }
    }
}