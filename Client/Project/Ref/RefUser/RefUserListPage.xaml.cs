using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;
using System.Collections.ObjectModel;

namespace Client.Project
{
    public partial class RefUserListPage : ContentPage
    {

        public CommandCL command = new CommandCL();


        private UserEditorViewModel viewModel;

        public RefUserListPage()
        {
            InitializeComponent();
            viewModel = new UserEditorViewModel();
            UserList.ItemsSource = GetUser();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateForm();
        }

        private void UpdateForm()
        {
            UserList.ItemsSource = GetUser();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            //Application.Current.MainPage.Window.MinimumWidth = 580;
            //Application.Current.MainPage.Window.MinimumHeight = 400;
            //Application.Current.MainPage.Window.MaximumWidth = 590;
            //Application.Current.MainPage.Window.MaximumHeight = 400;
        }

        // Метод для получения списка вопросов
        private List<RefUser> GetUser()
        {
            List<RefUser> aUserList = new List<RefUser>();
            CommandCL.UserListGet = null;
            viewModel.GetUserList();

            if (CommandCL.UserListGet == null)
            {
            }
            else
            {     
                for (int i = 0; i < CommandCL.UserListGet.ListUser.Count; i++)
                {
                    var Ref = new RefUser { User = CommandCL.UserListGet.ListUser[i], EditCommand = new Command(EditUser), DelCommand = new Command(DelUser) };
                    aUserList.Add(Ref);
                }
            }
            // Здесь вы можете получить список вопросов из вашего источника данных
            // Возвращаем примерный список вопросов для демонстрации
            return aUserList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedUser = (RefUser)e.SelectedItem;
            await DisplayAlert("Выбранный пользователь", selectedUser.User.Name_Employee, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        // Метод для редактирования вопроса
        private void EditUser(object question)
        {
            var selectedUser = (RefUser)question;
            // Выполните здесь необходимые действия при нажатии кнопки "Редактировать"
            // Например, откройте страницу редактирования с передачей выбранного пользователя в качестве параметра
            Navigation.PushAsync(new UserEditor(selectedUser.User));

            // Пример использования DisplayAlert для отображения сообщения
            //DisplayAlert("Редактируется пользователь", selectedUser.User, "OK");
        }

        // Метод для выбора вопроса
        private void DelUser(object question)
        {
            var selectedUser = (RefUser)question;

            viewModel.DelUserData(selectedUser.User);

            // Выполните здесь необходимые действия при нажатии кнопки "Удалить"
            // Например, передайте выбранный вопрос обратно на предыдущую страницу или выполните другую логику
            DisplayAlert("Удаляется пользователь", selectedUser.User.Name_Employee, "OK");
            UpdateForm();
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Администратор();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }
        //private void GoBack(object sender, EventArgs e)
        //{
        //    if (Application.Current.MainPage is NavigationPage navigationPage)
        //    {
        //        navigationPage.Navigation.PopAsync();
        //    }
        //}


        public class RefUser
        {
            public User User { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserCreate());
        }
    }
}
