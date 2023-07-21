//namespace Client.Project;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;
//using Xamarin.Forms;

namespace Client.Project
{
    public partial class RefUserListPage : ContentPage
    {

        public CommandCL command = new CommandCL();

        public List<RefUser> ������������_���_����� = new List<RefUser>();
        //public Command EditCommand { get; set; }
        //public Command SelectCommand { get; set; }
        public RefUserListPage()
        {
            InitializeComponent();
            UserList.ItemsSource = GetUser();
            //EditCommand = new Command(EditQuestion);
            //SelectCommand = new Command(SelectQuestion);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {


            //Application.Current.MainPage.Window.MinimumWidth = 580;
            //Application.Current.MainPage.Window.MinimumHeight = 400;
            //Application.Current.MainPage.Window.MaximumWidth = 590;
            //Application.Current.MainPage.Window.MaximumHeight = 400;

        }


        // ����� ��� ��������� ������ ��������
        private List<RefUser> GetUser()
        {

            Task.Run(async () => await command.From_Friend(Ip_adress.Ip_adresss, "", "015")).Wait();

            if (CommandCL.Regis_Users_Test == null)
            {

            }
            else
            {
                string[] strings = new string[CommandCL.Regis_Users_Test.regis.Length];
                for (int i = 0; i < strings.Length; i++)
                {
                    strings[i] = CommandCL.Regis_Users_Test.regis[i].Name_Employee;
                }


                for (int i = 0; i < strings.Length; i++)
                {
                     var Ref = new RefUser { User = strings[i], EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) };
                     ������������_���_�����.Add(Ref);

                }

                //UserList.ItemsSource = ������������_���_�����;
            }

            // ����� �� ������ �������� ������ �������� �� ������ ��������� ������
            // ���������� ��������� ������ �������� ��� ������������
            return ������������_���_�����;


            //return new List<RefUser>
            //{
            //new RefUser { User = "������������ 1", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "������������ 3", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) }

            //};
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedUser = (RefUser)e.SelectedItem;
            await DisplayAlert("��������� ������������", selectedUser.User, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        // ����� ��� �������������� �������
        private void EditUser(object question)
        {
            var selectedUser = (RefUser)question;
            // ��������� ����� ����������� �������� ��� ������� ������ "�������������"
            // ��������, �������� �������� �������������� � ��������� ���������� ������� � �������� ���������
            DisplayAlert("������������� ������������", selectedUser.User, "OK");
        }

        // ����� ��� ������ �������
        private void SelectUser(object question)
        {
            var selectedUser = (RefUser)question;
            // ��������� ����� ����������� �������� ��� ������� ������ "�������"
            // ��������, ��������� ��������� ������ ������� �� ���������� �������� ��� ��������� ������ ������
            DisplayAlert("���������� ������������", selectedUser.User, "OK");
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new �������������();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }

        public class RefUser
        {
            public string User { get; set; }
            public Command EditCommand { get; set; }
            public Command SelectCommand { get; set; }
        }
    }
}
