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
            // Обработчик для кнопки "Сохранить"
            // В этом методе вы можете выполнить сохранение данных пользователя
            // Например, можно использовать значения из свойств класса User
            // user.Id, user.Name_Employee, user.Password, user.DataMess, user.Id_roles_users, user.Employee_Mail

            // Пример использования DisplayAlert для отображения сообщения
            DisplayAlert("Сохранил пользователя", "" , "OK");

            // Закрыть окно после сохранения
            Navigation.PopModalAsync();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Обработчик для кнопки "Отмена"
            // В этом методе вы можете выполнить действия при отмене редактирования пользователя

            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Закрыл без сохранения", "", "OK");

            // Закрыть окно без сохранения
            Navigation.PopModalAsync();

            var mainPage = new Project.RefUserListPage();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;

        }
    }
}
