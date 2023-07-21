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
    public class UserEditorViewModel : INotifyPropertyChanged
    {
        private int id;
        private string name_Employee;
        private string password;
        private string dataMess;
        private int id_roles_users;
        private string employee_Mail;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name_Employee
        {
            get { return name_Employee; }
            set
            {
                if (name_Employee != value)
                {
                    name_Employee = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DataMess
        {
            get { return dataMess; }
            set
            {
                if (dataMess != value)
                {
                    dataMess = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Id_roles_users
        {
            get { return id_roles_users; }
            set
            {
                if (id_roles_users != value)
                {
                    id_roles_users = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Employee_Mail
        {
            get { return employee_Mail; }
            set
            {
                if (employee_Mail != value)
                {
                    employee_Mail = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class UserEditor : ContentPage
    {
        private UserEditorViewModel viewModel;

        public CommandCL command = new CommandCL();

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
            SaveUserData(user);

            // Display a message to indicate that the user data has been saved successfully
            DisplayAlert("Изменения сохранены", "", "OK");

            // Close the window after saving
            Navigation.PopModalAsync();
            GoBack(sender, e);
        }

        private void SaveUserData(User user)
        {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // SaveUser(user);

            string FileFS = "";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //User questions = new User;
                JsonSerializer.Serialize<User>(memoryStream, user);
                FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                Task.Run(async () => await command.UpdateUser(Ip_adress.Ip_adresss, FileFS, "017")).Wait();
            }
        }

            private void CancelButton_Click(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования пользователя

            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");

            // Закрыть окно без сохранения
            Navigation.PopModalAsync();
            GoBack(sender,e);

        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Project.RefUserListPage();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }

    }
}



