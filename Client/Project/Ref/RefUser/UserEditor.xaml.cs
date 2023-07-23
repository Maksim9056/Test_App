using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Client.Project
{

    public partial class UserEditor : ContentPage
    {
        private UserEditorViewModel viewModel;

        public UserEditor(User user)
        {
            InitializeComponent();
            viewModel = new UserEditorViewModel
            {
                Id = user.Id,
                Name_Employee = user.Name_Employee,
                Password = user.Password,
                DataMess = user.DataMess,
                Id_roles_users = user.Id_roles_users,
                Employee_Mail = user.Employee_Mail
            };
            BindingContext = viewModel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the properties of the UserEditorViewModel instance
            int id = viewModel.Id;
            string name_Employee = viewModel.Name_Employee;
            string password = viewModel.Password;
            string dataMess = viewModel.DataMess;
            int id_roles_users = viewModel.Id_roles_users;
            string employee_Mail = viewModel.Employee_Mail;

            // Create a new User instance or update the existing User instance with the retrieved values
            User user = new User
            {
                Id = id,
                Name_Employee = name_Employee,
                Password = password,
                DataMess = dataMess,
                Id_roles_users = id_roles_users,
                Employee_Mail = employee_Mail
            };

            // Perform the necessary operations to save the updated or new User data
            // Example: Call a method to save the user data to a database or update an existing record
            viewModel.UpDateUserData(user);

            // Display a message to indicate that the user data has been saved successfully
            DisplayAlert("Изменения сохранены", "", "OK");

            // Close the window after saving
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования пользователя

            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");

            // Закрыть окно без сохранения
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



