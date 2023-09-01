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
    public partial class DocExamTestListPage : ContentPage
    {
        public CommandCL command = new CommandCL();
        private ExamsTestEditorViewModel viewModel;
        private ExamsTestManager viewModelManager;
        private Class_interaction_Users.Exams CurrrentExams;

        public DocExamTestListPage(Class_interaction_Users.Exams exams)
        {
            InitializeComponent();
            viewModel = new ExamsTestEditorViewModel();
            viewModelManager = new ExamsTestManager();
            CurrrentExams = exams;
            TestList.ItemsSource = GetExamsTest(exams);
            Title = "Тесты для экзамена: " + exams.Name_exam;

#pragma warning disable CS0618 // Тип или член устарел
            MessagingCenter.Subscribe<DocExamTestListPage>(this, "UpdateForm", (sender) =>
            {
                // Perform the necessary updates to the form here   
                // For example, update the fields, refresh data, etc.   
                TestList.ItemsSource = GetExamsTest(exams);
            });
#pragma warning restore CS0618 // Тип или член устарел
        }

        private void UpdateForm(Class_interaction_Users.Exams exams)
        {
            TestList.ItemsSource = GetExamsTest(exams);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            // Your code here   
        }


        private List<RefExamsTest> GetExamsTest(Class_interaction_Users.Exams exams)
        {
            List<RefExamsTest> testExamsTestList = new List<RefExamsTest>();

            CommandCL.ExamsTestListGet = null;
            viewModelManager.GetExamsTestList(exams);

            if (CommandCL.ExamsTestListGet == null)
            {
                // Handle the case when the test list is null   
            }
            else
            {
                for (int i = 0; i < CommandCL.ExamsTestListGet.ListExamsTest.Count; i++)
                {
                    var refExamsTest = new RefExamsTest { ExamsTest = CommandCL.ExamsTestListGet.ListExamsTest[i], EditCommand = new  (Edit), DelCommand = new Command(Del) };
                    testExamsTestList.Add(refExamsTest);
                }
            }
            return testExamsTestList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedExamsTest = (RefExamsTest)e.SelectedItem;
            await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private void Edit(object examsTest)
        {
            var selectedExamsTest = (RefExamsTest)examsTest;
            Navigation.PushAsync(new ExamsEditor(selectedExamsTest.ExamsTest.Exams));
        }

        private void Del(object examsTest)
        {
            var selectedExamsTest = (RefExamsTest)examsTest;

            viewModelManager.DeleteExamsTestData(selectedExamsTest.ExamsTest);

            DisplayAlert("Удаляется тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
            UpdateForm(CurrrentExams);
        }

        private async void GoBack(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RefExamsListPage());

            //if (Application.Current.MainPage is NavigationPage navigationPage)
            //{
            //    navigationPage.Navigation.PopAsync();
            //}
            //await Shell.Current.Navigation.PopAsync();
            await Navigation.PopAsync();

        }

        public class RefExamsTest
        {
            public Class_interaction_Users.ExamsTest ExamsTest { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private void ContentPageLoaded(object sender, EventArgs e)
        {

        }

        private async void CreateButtonClicked(object sender, EventArgs e)
        {
            var refTestListPage = new RefTestListPage();
            refTestListPage.Mode = 1;
            refTestListPage.Disappearing += (s, args) =>
            {
                if (refTestListPage.vSelectedItem != null)
                {
                    var selectedItem = refTestListPage.vSelectedItem;
                    ExamsTest aQuestionQ = new ExamsTest();
                    aQuestionQ.Exams = CurrrentExams;
                    aQuestionQ.Test = selectedItem;
                    viewModelManager.CreateExamsTestData(aQuestionQ);

                    // Clear the selected item in RefQuestionsListPage
                    refTestListPage.vSelectedItem = null;

                    // Send a message to update the current form
#pragma warning disable CS0618 // Тип или член устарел
                    MessagingCenter.Send(this, "UpdateForm");
#pragma warning restore CS0618 // Тип или член устарел
                }
            };
            await Navigation.PushModalAsync(refTestListPage);
            //var refExamsListPage = new RefExamsListPage();
        }
    }
}