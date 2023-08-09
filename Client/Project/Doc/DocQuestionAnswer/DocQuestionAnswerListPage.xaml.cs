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
        private Class_interaction_Users.Questions CurrrentQuestions;

        public DocQuestionAnswerListPage(Class_interaction_Users.Questions questions)
        {
            InitializeComponent();
            viewModel = new QuestionAnswerEditorViewModel();
            viewModelManager = new QuestionAnswerManager();
            CurrrentQuestions = questions;
            QuestionList.ItemsSource = GetQuestionAnswer(questions);
            Title = "Ответы для вопроса: " + questions.QuestionName;
#pragma warning disable CS0618 // Тип или член устарел
            MessagingCenter.Subscribe<DocQuestionAnswerListPage>(this, "UpdateForm", (sender) =>
            {
                // Perform the necessary updates to the form here 
                // For example, update the fields, refresh data, etc. 
                QuestionList.ItemsSource = GetQuestionAnswer(questions);
            });
#pragma warning restore CS0618 // Тип или член устарел
        }

        //void OnUpdateForm(DocQuestionAnswerListPage sender)
        //{
        //    // Выполните необходимые обновления формы здесь
        //    // Например, обновите поля, обновите данные и т. д.
        //    QuestionList.ItemsSource = GetQuestionAnswer(CurrrentTest);
        //}

        //// Подписка на событие
        //DocQuestionAnswerListPage.UpdateForm += OnUpdateForm;

        //// Отписка от события (не забудьте отписаться, когда оно больше не нужно)
        //DocQuestionAnswerListPage.UpdateForm -= OnUpdateForm;

        private void UpdateForm(Class_interaction_Users.Questions test)
        {
            QuestionList.ItemsSource = GetQuestionAnswer(test);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {

            // Your code here 
        }

        private List<RefQuestionAnswer> GetQuestionAnswer(Class_interaction_Users.Questions questions)
        {
            List<RefQuestionAnswer> testQuestionList = new List<RefQuestionAnswer>();

            CommandCL.QuestionAnswerListGet = null;
            viewModelManager.GetQuestionAnswerList(questions);

            if (CommandCL.QuestionAnswerListGet == null)
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
            await DisplayAlert("Выбранный ответ", selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions, "OK");
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

            DisplayAlert("Удаляется ответ", selectedTestQuestion.QuestionAnswer.Questions.QuestionName, "OK");
            UpdateForm(CurrrentQuestions);
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
            var refAnswerListPage = new RefAnswerListPage();
            refAnswerListPage.Disappearing += (s, args) =>
            {
                if (refAnswerListPage.vSelectedItem != null)
                {
                    var selectedItem = refAnswerListPage.vSelectedItem;
                    QuestionAnswer aQuestionQ = new QuestionAnswer();
                    aQuestionQ.Questions = CurrrentQuestions;
                    aQuestionQ.Answer = selectedItem;
                    viewModelManager.CreateQuestionAnswerData(aQuestionQ);

                    // Clear the selected item in RefQuestionsListPage
                    refAnswerListPage.vSelectedItem = null;

                    // Send a message to update the current form
#pragma warning disable CS0618 // Тип или член устарел
                    MessagingCenter.Send(this, "UpdateForm");
#pragma warning restore CS0618 // Тип или член устарел
                }
            };
            Navigation.PushModalAsync(refAnswerListPage);
        }
    } 
}