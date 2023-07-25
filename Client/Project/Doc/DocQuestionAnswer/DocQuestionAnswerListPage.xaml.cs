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
    public partial class DocQuestionAnswerListPage : ContentPage
    {
        public CommandCL command = new CommandCL();
        private QuestionAnswerEditorViewModel viewModel;
        private QuestionAnswerManager viewModelManager;
        private Class_interaction_Users.Questions CurrrentTest;

        public DocQuestionAnswerListPage(Class_interaction_Users.Questions questions)
        {
            InitializeComponent();
            viewModel = new QuestionAnswerEditorViewModel();
            viewModelManager = new QuestionAnswerManager();
            CurrrentTest = questions;
            QuestionList.ItemsSource = GetTestQuestions(questions);
            Title = "Вопросы для теста: " + questions.QuestionName;
            MessagingCenter.Subscribe<DocTestQuestionListPage>(this, "UpdateForm", (sender) =>
            {
                // Perform the necessary updates to the form here 
                // For example, update the fields, refresh data, etc. 
                QuestionList.ItemsSource = GetTestQuestions(questions);
            });
        }

        private void UpdateForm(Class_interaction_Users.Questions test)
        {
            QuestionList.ItemsSource = GetTestQuestions(test);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            // Your code here 
        }

        private List<RefQuestionAnswer> GetTestQuestions(Class_interaction_Users.Questions questions)
        {
            List<RefQuestionAnswer> testQuestionList = new List<RefQuestionAnswer>();

            CommandCL.ExamsListGet = null;
            viewModelManager.GetQuestionAnswerList(questions);

            if (CommandCL.TestQuestionListGet == null)
            {
                // Handle the case when the test list is null 
            }
            else
            {
                for (int i = 0; i < CommandCL.QuestionAnswerListGet.ListQuestionAnswer.Count; i++)
                {
                    var refQuestionAnswer = new RefQuestionAnswer { QuestionAnswer = CommandCL.QuestionAnswerListGet.ListQuestionAnswer[i], EditCommand = new Command(Edit), DelCommand = new Command(Del) };
                    testQuestionList.Add(refQuestionAnswer);
                }
            }

            return testQuestionList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedTestQuestion = (RefQuestionAnswer)e.SelectedItem;
            await DisplayAlert("Выбранный вопрос", selectedTestQuestion.QuestionAnswer.Questions.QuestionName, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void Edit(object testQuestion)
        {
            var selectedTestQuestion = (RefQuestionAnswer)testQuestion;
            Navigation.PushAsync(new QuestionsEditor(selectedTestQuestion.QuestionAnswer.Questions));
        }

        private void Del(object testQuestion)
        {
            var selectedTestQuestion = (RefQuestionAnswer)testQuestion;

            viewModelManager.DeleteQuestionAnswerData(selectedTestQuestion.QuestionAnswer);

            DisplayAlert("Удаляется вопрос", selectedTestQuestion.QuestionAnswer.Questions.QuestionName, "OK");
            UpdateForm(CurrrentTest);
        }

        private void GoBack(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }

        public class RefQuestionAnswer
        { 
        public Class_interaction_Users.QuestionAnswer QuestionAnswer { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }

        private void ContentPageLoaded(object sender, EventArgs e)
        {

        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {

        }
    } 
}