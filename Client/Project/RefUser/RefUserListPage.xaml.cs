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

        public List<RefUser> Пользователи_для_теста = new List<RefUser>();
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


        // Метод для получения списка вопросов
        private List<RefUser> GetUser()
        {

            Task.Run(async () => await command.GetUserList(Ip_adress.Ip_adresss, "", "016")).Wait();

            if (CommandCL.UserListGet == null)
            {

            }
            else
            {
                //string[] strings = new string[CommandCL.UserListGet.ListUser.Count];
                //for (int i = 0; i < strings.Length; i++)
                //{
                //    strings[i] = CommandCL.UserListGet.ListUser[i].Name_Employee;
                //}


                for (int i = 0; i < CommandCL.UserListGet.ListUser.Count; i++)
                {
                     var Ref = new RefUser { User = CommandCL.UserListGet.ListUser[i], EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) };
                     Пользователи_для_теста.Add(Ref);

                }

                //UserList.ItemsSource = Пользователи_для_теста;
            }

            // Здесь вы можете получить список вопросов из вашего источника данных
            // Возвращаем примерный список вопросов для демонстрации
            return Пользователи_для_теста;


            //return new List<RefUser>
            //{
            //new RefUser { User = "Пользователь 1", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
            //new RefUser { User = "Пользователь 3", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) }

            //};
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
        private void SelectUser(object question)
        {
            var selectedUser = (RefUser)question;
            // Выполните здесь необходимые действия при нажатии кнопки "Выбрать"
            // Например, передайте выбранный вопрос обратно на предыдущую страницу или выполните другую логику
            DisplayAlert("Выбирается пользователь", selectedUser.User.Name_Employee, "OK");
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Администратор();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }

        public class RefUser
        {
            public User User { get; set; }
            public Command EditCommand { get; set; }
            public Command SelectCommand { get; set; }
        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserCreate());
        }
    }
}
