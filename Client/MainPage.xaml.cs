using Class_interaction_Users;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
           
        }
        /// <summary>
        /// Экземпляр класса CommandCL
        /// </summary>
        public CommandCL command = new CommandCL();


        /// <summary>
        ///Почта пользователя
        /// </summary>
        public string Mail { get; set; }


        /// <summary>
        ///Пароль пользователя
        /// </summary>
        public string Password { get; set; }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            //Entry entry = new Entry
            //{
            //    Placeholder = "Введите Email",
            //    //FontFamily = "Helvetica",
            //    FontSize = 22,
            //    MaxLength = 20,
            //    Margin = 20,
            //    Keyboard = Keyboard.Text
            //};

            //Entry entry1 = new Entry
            //{
            //    Placeholder = "Введите пароль",
            //    //FontFamily = "Helvetica",
            //    FontSize = 22,
            //    MaxLength = 20,
            //    Margin = 20,

            //    Keyboard = Keyboard.Text
            //};
            //Button button = new Button
            //{
            //    Text = "Регестрация",
            //      Margin =30,
            //        FontSize = 22,
            //        BorderWidth = 1,
            //        BackgroundColor = Colors.LightPink,
            //        TextColor = Colors.DarkRed,
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center
            //    };
            //button.Clicked += OnButtonClicked;
            //Content = new StackLayout
            //{
            //    Children = { entry, entry1, button }
            //};
        }

    

        private void OnButtonClicked(object sender, EventArgs e)
        {

        }

      /// <summary>
      /// Почта 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
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
                                                            await DisplayAlert("Уведомление", "Пользователь Авторизовался!", "ОK");
                                                            await Navigation.PushAsync(new Главная_страница());
                                                            break;
                                                        case 1:
                                                            await DisplayAlert("Уведомление", "Администратор Авторизовался!", "ОK");
                                                            await Navigation.PushAsync(new Администратор());
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
        private async  void CounterBtn_Clicked_1(object sender, EventArgs e)
        {
           //  вход_В_Учетную_Запись =new();
            await Navigation.PushAsync(new Вход_в_учетную_запись());
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
    }
}
