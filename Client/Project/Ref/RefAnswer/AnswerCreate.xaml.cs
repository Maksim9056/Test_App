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
    public partial class AnswerCreate : ContentPage, INotifyPropertyChanged
    {
        private AnswerEditorViewModel viewModel;
        private AnswerManager viewModelManager;

        public AnswerCreate()
        {
            InitializeComponent();
            viewModel = new AnswerEditorViewModel();
            viewModelManager = new AnswerManager();
            BindingContext = viewModel;
        }

        private void GoBack(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }


        private void CancelAnswerClick(object sender, EventArgs e)
        {
            // Close the user editor page without saving any changes
            Navigation.PopModalAsync();
            GoBack(sender, e);

        }

        private void SaveAnswerClick(object sender, EventArgs e)
        {
            {
                int id = viewModel.Id;
                string answerOptions = viewModel.AnswerOptions;
                bool correctAnswers = viewModel.CorrectAnswers;
                Questions idQuestions = viewModel.IdQuestions;

                // Create a new AnswerEditorViewModel instance or update the existing instance with the retrieved values
                Answer answer = new Answer
                {
                    Id = id,
                    AnswerOptions = answerOptions,
                    CorrectAnswers = correctAnswers,
                    IdQuestions = idQuestions
                };

                // Call the appropriate method to save the answer data
                viewModelManager.CreateAnswerData(answer);

                // Close the user editor page
                Navigation.PopModalAsync();
                GoBack(sender, e);
            }
        }
    }
}