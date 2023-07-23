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
    public partial class DocTestQuestionListPage : ContentPage
    {
        public CommandCL command = new CommandCL();
        private TestQuestionEditorViewModel viewModel;
        private TestQuestionManager viewModelManager;
        private Class_interaction_Users.Test CurrrentTest;

        public DocTestQuestionListPage(Class_interaction_Users.Test test)
        {
            InitializeComponent();
            viewModel = new TestQuestionEditorViewModel();
            viewModelManager = new TestQuestionManager();
            CurrrentTest = test;
            QuestionList1.ItemsSource = GetTestQuestions(test);
            Title = "������� ��� �����: "+ test.Name_Test;
        }

        private void UpdateForm(Class_interaction_Users.Test test)
        {
            QuestionList1.ItemsSource = GetTestQuestions(test);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            // Your code here
        }

        private List<RefTestQuestion> GetTestQuestions(Class_interaction_Users.Test test)
        {
            List<RefTestQuestion> testQuestionList = new List<RefTestQuestion>();

            CommandCL.ExamsListGet = null;
            viewModelManager.GetTestQuestionList(test);

            if (CommandCL.TestQuestionListGet == null)
            {
                // Handle the case when the test list is null
            }
            else
            {
                for (int i = 0; i < CommandCL.TestQuestionListGet.ListTestQuestion.Count; i++)
                {
                    var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i], EditCommand = new Command(EditTestQuestion), DelCommand = new Command(DelTestQuestion) };
                    testQuestionList.Add(refTestQuestion);
                }
            }

            return testQuestionList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedTestQuestion = (RefTestQuestion)e.SelectedItem;
            await DisplayAlert("��������� ������", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void EditTestQuestion(object testQuestion)
        {
            var selectedTestQuestion = (RefTestQuestion)testQuestion;
            Navigation.PushAsync(new QuestionsEditor(selectedTestQuestion.TestQuestion.IdQuestions));
        }

        private void DelTestQuestion(object testQuestion)
        {
            var selectedTestQuestion = (RefTestQuestion)testQuestion;

            //viewModelManager.DeleteTestQuestionData(selectedTestQuestion.TestQuestion.Test);

            DisplayAlert("��������� ������", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
            UpdateForm(CurrrentTest);
        }

        private void GoBack(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }

        public class RefTestQuestion
        {
            public Class_interaction_Users.TestQuestion TestQuestion { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private async void CreateButtonClicked(object sender, EventArgs e)
        {
            var refQuestionsListPage = new RefQuestionsListPage();
            refQuestionsListPage.Disappearing += (s, args) =>
            {
                if (refQuestionsListPage.vSelectedItem != null)
                {
                    // �������� ��������� ������� �� RefQuestionsListPage
                    var selectedItem = refQuestionsListPage.vSelectedItem;

                    // ������� ���-�� � ��������� ��������� �����
                    // ��������, ���������� ��� �������� � ��������� ���� �� ������� �����
                    //MyTextField.Text = selectedItem;

                    // �������� ��������� ������� � RefQuestionsListPage
                    refQuestionsListPage.vSelectedItem = null;
                }
            };

            await Navigation.PushModalAsync(refQuestionsListPage);
        }

        private void ContentPageLoaded(object sender, EventArgs e)
        {

        }
    }
}