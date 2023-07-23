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
            // Retrieve the values from the properties of the UserEditorViewModel instance
            //int id = viewModel.Id;
            string name_Employee = viewModel.Name_Employee;
            string password = viewModel.Password;
            //string dataMess = viewModel.DataMess;
            int id_roles_users = viewModel.Id_roles_users;
            string employee_Mail = viewModel.Employee_Mail;

            DateTime dateTime = DateTime.Now;
            var data = $"{dateTime:F}";

            // Create a new User instance or update the existing User instance with the retrieved values
            User user = new User
            {
                //Id = id,
                Name_Employee = name_Employee,
                Password = password,
                DataMess = data,
                Id_roles_users = id_roles_users,
                Employee_Mail = employee_Mail
            };

            // Call the appropriate method to save the user data
            viewModel.CreateUserData(user);

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
        //    var mainPage = new Project.RefUserListPage();
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