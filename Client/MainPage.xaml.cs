using Class_interaction_Users;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Platform;
using Client.Main;
using System.Windows.Input;
using System.Web;
//using Microsoft.AspNetCore.Components.Navigation;


namespace Client
{
    public partial class MainPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

        
        //var rt = Shell.Current.CurrentState.Location.OriginalString;
        //var parameters = System.Web.HttpUtility.ParseQueryString(rt);
        //var sellValue = parameters.Get("sell");

    }
        public CommandCL command = new CommandCL();
        public string Mail { get; set; }
        public string Password { get; set; }


        private void OnCounterClicked(object sender, EventArgs e)
        {
        }


        private void OnButtonClicked(object sender, EventArgs e)
        {

        }

        void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void CounterBtn_Clicked(object sender, EventArgs e)
        {
            

        }

        /// <summary>
        /// Пароль 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = nameEntry1.Text;
        }

        /// <summary>
        /// Вход  в учетную запись команда 003
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CounterLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Mail == null)
                {
                    await DisplayAlert("Уведомление", "Почта не пустая!", "ОK");
                }
                else
                {
                    //Проверяет почту пуста или нет
                    if (string.IsNullOrEmpty(Mail))
                    {
                        await DisplayAlert("Уведомление", "Почта не заполнена!", "ОK");
                    }
                    else
                    {
                        //Регеулярное выражение
                        string patern = "@.";
                        //Регулярное выражение
                        Regex regex = new Regex(patern);
                        //Проверяет в Mail есть ли в строке это @ почту
                        if (Regex.IsMatch(Mail, patern))
                        {
                            if (Password == null)
                            {
                                await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(Password))
                                {
                                    await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");
                                }
                                else
                                {
                                    //FileFS обьявляем для отправки на сервер
                                    string FileFS = "";
                                    //Обьявляем MemoryStream 
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        //Заполняем класс CheckMail_and_Password для отправки на сервер
                                        CheckMail_and_Password ss = new CheckMail_and_Password(Password, Mail);
                                        //Серелизуем класс CheckMail_and_Password для отправки на сервер
                                        JsonSerializer.Serialize<CheckMail_and_Password>(memoryStream, ss);
                                        //Декодировали в строку  memoryStream    класс запоаковали в json строку
                                        FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                                        //Отправляем на сервер  команду 003
                                        Task.Run(async () => await command.Check_User_Possword(Ip_adress.Ip_adresss, FileFS, "003")).Wait();
                                        //Значение почты пользователя  присваеваем по умолчанию почту для следущего входа пользователей
                                        Mail = null;
                                        //Значение пароля пользователя  присваеваем по умолчанию пароль для следущего входа пользователей 
                                        Password = null;
                                        nameEntry1.Text = null;
                                        nameEntry9.Text = null;
                                        //Ответ с сервера получаем 
                                        if (command.Travel_logout == null)
                                        {
                                            await DisplayAlert("Уведомление", "Такого пользователя нет!", "ОK");
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(command.Travel_logout.Employee_Mail))
                                            {
                                                await DisplayAlert("Уведомление", "Такого пользователя нет!", "ОK");

                                            }
                                            else
                                            {
                                                if (command.Travel_logout.Id == 0)
                                                {
                                                    await DisplayAlert("Уведомление", "Пароль введен не верно!", "ОK");
                                                }
                                                else
                                                {
                                                    var regis_Users = command.Travel_logout;
                                                    switch (regis_Users.Rechte)
                                                    {
                                                        case 0:
                                                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Пользователь Авторизовался!", "ОK");
                                                            //var mainPage = new Users.Doc.DocExamFromTests.DocExamFromTests();
                                                            //var navigationPage = new NavigationPage(mainPage);
                                                            Client.Users.Doc.DocExamFromTests.DocExamFromTests Name_user = new Client.Users.Doc.DocExamFromTests.DocExamFromTests();
                                                            Name_user.User_NAME(regis_Users);
                                                            await Shell.Current.GoToAsync("user"); // Используйте URI для перехода к пользовательской странице
                                                            break;
                                                        case 1:
                                                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Администратор Авторизовался!", "ОK");
                                                            //var adminPage = new Admin();
                                                            //var navigationPage2 = new NavigationPage(adminPage);
                                                            await Shell.Current.GoToAsync("admin"); // Используйте URI для перехода к административной странице
                                                                                                      //Application.Current.MainPage = navigationPage2;
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Не проходит на почту действетульную
                            await DisplayAlert("Уведомление", "Ввели не почту!", "ОK");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Уведомление", ex.Message, "ОK");
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private   void CounterBtn_Clicked_1(object sender, EventArgs e)
        {
            try
            {

                // Создание NavigationPage с главной страницей
                var mainPage = new RegUser();
                var navigationPage = new NavigationPage(mainPage);

                Application.Current.MainPage = navigationPage;



            }
            catch
            {

            }
            //// Создание NavigationPage с главной страницей
            //var mainPage = new MainPage();
            //var navigationPage = new NavigationPage(mainPage);

            //// Установка NavigationPage в качестве главной страницы приложения

            //  вход_В_Учетную_Запись =new();
            // INavigation navigation = new.Navigation;

            // Переход на предыдущую страницу

            //   await navigation.PopAsync();

            //вход_В_Учетную_Запись.GetVisualElementWindow().Content.CaptureAsync();
            //Открывает
            //  вход_В_Учетную_Запись.DisplayAlert(Title,"Открывает","");
        }

        private void nameEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void nameEntry9_TextChanged(object sender, TextChangedEventArgs e)
        { 
            Mail = nameEntry9.Text;

        }

        private void ContentPage_Loaded(System.Object sender, System.EventArgs e)
        {
            try
            {


                //  Application.Current.MainPage.SetValue(NavigationPage.HasNavigationBarProperty, false);
                //    Application.Current.MainPage.SetValue(NavigationPage.HasBackButtonProperty, false);
                Application.Current.MainPage.Window.Width = 530.8d;
                Application.Current.MainPage.Window.Height = 650.8d;

                Application.Current.MainPage.Window.MinimumWidth = 530.8d;
                Application.Current.MainPage.Window.MinimumHeight = 650.8d;

                Application.Current.MainPage.Window.MaximumWidth = 530.8d;
                Application.Current.MainPage.Window.MaximumHeight = 650.8d;

                //nameEntry9.Text = "maks_nt@list.ru";
                //nameEntry1.Text = "1";
                //nameEntry9.Text = "Admin@Admin.ru";
                //nameEntry1.Text = "Admin";
                if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=admin"))
                {
                    //nameEntry9.Text = "Admin@Admin.ru";
                    //nameEntry1.Text = "Admin";
                    nameEntry9.Text = "maks_nt@list.ru";
                    nameEntry1.Text = "1";
                }
                else if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=user"))
                {
                    // Handle user parameter
                    nameEntry9.Text = "maks_nt@list.ru";
                    nameEntry1.Text = "1";
                }
                else if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=help"))
                {
                    // Handle help parameter
                }

            }
            catch
            {

            }

        }
    }
}
