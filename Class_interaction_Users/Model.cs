using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Class_interaction_Users
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

            public void SaveUser()
            {

            }

    }
}
