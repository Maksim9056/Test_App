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
    public partial class UserCreate : ContentPage, INotifyPropertyChanged
    {
        private UserEditorViewModel viewModel;

        public UserCreate()
        {
            InitializeComponent();

            viewModel = new UserEditorViewModel();
            BindingContext = viewModel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Call the appropriate method to save the user data
            viewModel.SaveUser();

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

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Project.RefUserListPage();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }

    }
}