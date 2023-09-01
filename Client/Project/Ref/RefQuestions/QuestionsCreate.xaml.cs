using Class_interaction_Users;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Client.Project
{
    //XamlCompilation(XamlCompilationOptions.Compile)
    public partial class QuestionsCreate : ContentPage, INotifyPropertyChanged
    {
        private QuestionsEditorViewModel viewModel;
        private QuestionManager viewModelManager;

        public QuestionsCreate()
        {
            InitializeComponent();
            viewModel = new QuestionsEditorViewModel();
            viewModelManager = new QuestionManager();
            BindingContext = viewModel;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the UserEditorViewModel instance
            // int id = viewModel.Id;
            string question1 = viewModel.QuestionName;
            string answerTrue = viewModel.AnswerTrue;
            int grade = viewModel.Grade;

            // Create a new Questions instance or update the existing Questions instance with the retrieved values
            Questions question = new Questions
            {
                // Id = id,
                QuestionName = question1,
                AnswerTrue = answerTrue,
                Grade = grade,
                // Set other properties of the Questions class accordingly
            };

            // Call the appropriate method to save the question data
            viewModelManager.CreateQuestionData(question);

            // Close the user editor page
            //Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            // Close the user editor page without saving any changes
            //Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        //private void GoBack(object sender, EventArgs e)
        //{
        //    var mainPage = new Project.RefQuestionsListPage();
        //    var navigationPage = new NavigationPage(mainPage);
        //    Application.Current.MainPage = navigationPage;
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