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

        // Метод для получения списка вопросов
        private List<RefUser> GetUser()
        {
            // Здесь вы можете получить список вопросов из вашего источника данных
            // Возвращаем примерный список вопросов для демонстрации
            return new List<RefUser>
            {
                new RefUser { User = "Пользователь 1", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 2", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) },
                new RefUser { User = "Пользователь 3", EditCommand = new Command(EditUser), SelectCommand = new Command(SelectUser) }

            };
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedUser = (RefUser)e.SelectedItem;
            await DisplayAlert("Выбранный пользователь", selectedUser.User, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        // Метод для редактирования вопроса
        private void EditUser(object question)
        {
            var selectedUser = (RefUser)question;
            // Выполните здесь необходимые действия при нажатии кнопки "Редактировать"
            // Например, откройте страницу редактирования с передачей выбранного вопроса в качестве параметра
            DisplayAlert("Редактируется пользователь", selectedUser.User, "OK");
        }

        // Метод для выбора вопроса
        private void SelectUser(object question)
        {
            var selectedUser = (RefUser)question;
            // Выполните здесь необходимые действия при нажатии кнопки "Выбрать"
            // Например, передайте выбранный вопрос обратно на предыдущую страницу или выполните другую логику
            DisplayAlert("Выбирается пользователь", selectedUser.User, "OK");
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Администратор();
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
