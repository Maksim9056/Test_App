using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;
using System.Collections.ObjectModel;
using Client.Main;
using static Class_interaction_Users.CommandCL;

namespace Client.Project.Main;

    public partial class Type_of_resverve_copy : ContentPage
    {

        public CommandCL command = new CommandCL();

    public Working_with_a_backup working_With_A_Backup   = new Working_with_a_backup();
        private UserEditorViewModel viewModel;
        public Class_interaction_Users.User vSelectedItem { get; set; }
    
    public List<string > UserNames { get; set; }
        public Type_of_resverve_copy()
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
            var Data =   working_With_A_Backup.CatalogView();
            if (Data == null)
            {

            }
            else
            {
                for (int i = 0; i < Data.Length; i++)
                {
                    var Ref = new RefUser { User = Data[i], EditCommand = new Command(EditUser) };
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

            //var selectedUser = (RefUser)e.SelectedItem;
            //((ListView)sender).SelectedItem = null;






            // Закройте форму RefQuestionsListPage
            // Исключается для выбора ответа
#pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
            // Navigation.PopModalAsync();
#pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен

        }

        // Метод для редактирования вопроса
        private  void EditUser(object question)
        {
          var B = (RefUser)question;
       
        string[] Fales = new string[1];

        for(int i=0;i< Fales.Length; i++)
        {
          Fales[i] = B.User;
        }
       Backap backap = new Backap(Fales);


        working_With_A_Backup.Restoring_a_backup(backap);

         DisplayAlert("Уведомление", "Востановление успешно !", "OK");



        // Например, откройте страницу редактирования с передачей выбранного пользователя в качестве параметра
        //   await Navigation.PushAsync(new UserEditor(selectedUser.User));

        // Пример использования DisplayAlert для отображения сообщения
    }

    // Метод для выбора вопроса
    //private void DelUser(object question)
    //{
    //    var selectedUser = (RefUser)question;

    //    viewModel.DelUserData(selectedUser.User);

    //    // Выполните здесь необходимые действия при нажатии кнопки "Удалить"
    //    // Например, передайте выбранный вопрос обратно на предыдущую страницу или выполните другую логику
    //    DisplayAlert("Удаляется пользователь", selectedUser.User.Name_Employee, "OK");
    //    UpdateForm();
    //}

    private async void GoBack(object sender, EventArgs e)
        {
            // await Shell.Current.Navigation.PopAsync();
            //await Navigation.PushAsync(new Admin());
            await Navigation.PopAsync();
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
            public string  User { get; set; }
            public Command EditCommand { get; set; }
        }

        private async void CreateButtonClicked(object sender, EventArgs e)
        {
           working_With_A_Backup.DBackup();
           await DisplayAlert("Уведомление", "Резевная копия создалась !", "OK");
         UpdateForm();

        }

    public void SettingsButtonClicked()
        {

        }

    }
