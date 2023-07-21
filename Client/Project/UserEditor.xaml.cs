using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project
{
    public partial class UserEditor : ContentPage
    {
        public UserEditor(User user)
        {
            InitializeComponent();
            BindingContext = user;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // ���������� ��� ������ "���������"
            // � ���� ������ �� ������ ��������� ���������� ������ ������������
            // ��������, ����� ������������ �������� �� ������� ������ User
            // user.Id, user.Name_Employee, user.Password, user.DataMess, user.Id_roles_users, user.Employee_Mail

            // ������ ������������� DisplayAlert ��� ����������� ���������
            DisplayAlert("�������� ������������", "" , "OK");

            // ������� ���� ����� ����������
            Navigation.PopModalAsync();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // ���������� ��� ������ "������"
            // � ���� ������ �� ������ ��������� �������� ��� ������ �������������� ������������

            // ������ ������������� DisplayAlert ��� ����������� ���������
            //DisplayAlert("������ ��� ����������", "", "OK");

            // ������� ���� ��� ����������
            Navigation.PopModalAsync();

            var mainPage = new Project.RefUserListPage();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;

        }
    }
}
