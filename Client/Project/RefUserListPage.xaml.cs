//namespace Client.Project;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Forms;

namespace Client.Project
{
    public partial class RefUserListPage : ContentPage
    {
        //public Command EditCommand { get; set; }
        //public Command SelectCommand { get; set; }
        public RefUserListPage()
        {
            InitializeComponent();
            UserList.ItemsSource = GetUser();
            //EditCommand = new Command(EditQuestion);
            //SelectCommand = new Command(SelectQuestion);
        }

        // ����� ��� ��������� ������ ��������
        private List<RefUser> GetUser()
        {
            // ����� �� ������ �������� ������ �������� �� ������ ��������� ������
            // ���������� ��������� ������ �������� ��� ������������
            return new List<RefUser>
            {
                new RefUser { User = "������������ 1", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "������������ 3", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) }

            };
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
