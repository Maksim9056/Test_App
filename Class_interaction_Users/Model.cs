using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace Class_interaction_Users
{

    public class UserEditorViewModel : INotifyPropertyChanged
        {
            public CommandCL command = new CommandCL();

            public ObservableCollection<User> Users { get; set; }

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

        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void CreateUserData(User user)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JsonSerializer.Serialize<User>(memoryStream, user);
                    Task.Run(async () => await command.CreateUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "018")).Wait();
                }

            }

            public void UpDateUserData(User user)
            {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // UpDateUser(user);

            using (MemoryStream memoryStream = new MemoryStream())
                {
                    JsonSerializer.Serialize<User>(memoryStream, user);
                    Task.Run(async () => await command.UpdateUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "017")).Wait();
                }
            }

            public void DelUserData(User user)
            {
                // Implement the logic to save the user data
                // Example: Call a service or repository method to save the user data
                // DelUser(user);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JsonSerializer.Serialize<User>(memoryStream, user);
                    Task.Run(async () => await command.DelUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "019")).Wait();
                }
            }


    }


}
