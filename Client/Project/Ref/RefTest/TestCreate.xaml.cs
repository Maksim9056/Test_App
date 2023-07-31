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
    public partial class TestCreate : ContentPage, INotifyPropertyChanged
    {
        private TestEditorViewModel viewModel;

        public TestCreate()
        {
            InitializeComponent();
            viewModel = new TestEditorViewModel();
            BindingContext = viewModel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the UserEditorViewModel instance
            //int id = viewModel.Id;
            string name_Test = viewModel.Name_Test;
            int options_Id = viewModel.Options_Id;

            // Create a new Test instance or update the existing Test instance with the retrieved values
            Class_interaction_Users.Test test = new Class_interaction_Users.Test
            {
                //Id = id,
                Name_Test = name_Test,
                Options_Id = options_Id
            };

            // Call the appropriate method to save the test data
            viewModel.CreateTestData(test);

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
        //    var mainPage = new Project.RefTestListPage();
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

        /// <summary>
        /// Форма для выборки вопросов и их список для теста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Questing(object sender, EventArgs e)
        {
            var mainPage = new Project.RefTestListPageS();
            var navigationPage = new NavigationPage(mainPage);
            Application.Current.MainPage = navigationPage;
            //Navigation.PopModalAsync();
            //GoBack(sender, e);

            //// Close the user editor page without saving any changes
            //Navigation.PopModalAsync();
            //GoBack(sender, e);
        }

    }
}