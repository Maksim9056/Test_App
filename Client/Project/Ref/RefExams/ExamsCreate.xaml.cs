using Class_interaction_Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamsCreate : ContentPage, INotifyPropertyChanged
    {
        private ExamsEditorViewModel viewModel;
        private ExamManager viewModelManager;

        public ExamsCreate()
        {
            InitializeComponent();
            viewModel = new ExamsEditorViewModel();
            viewModelManager = new ExamManager();
            BindingContext = viewModel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the UserEditorViewModel instance
            //int id = viewModel.Id;
            string name_Test = viewModel.Name_exam;

            // Create a new Test instance or update the existing Test instance with the retrieved values
            Class_interaction_Users.Exams Exams = new Class_interaction_Users.Exams
            {
                //Id = id,
                Name_exam = name_Test,
            };

            // Call the appropriate method to save the test data
            viewModelManager.CreateExamsData(Exams);

            // Close the user editor page
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the user editor page without saving any changes
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        //private void GoBack(object sender, EventArgs e)
        //{
        //    var mainPage = new Project.RefExamsListPage();
        //    var navigationPage = new NavigationPage(mainPage);
        //    Application.Current.MainPage = navigationPage;
        //}
        private void GoBack(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.Navigation.PopAsync();
            }
        }

    }
}