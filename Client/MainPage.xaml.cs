using Class_interaction_Users;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text;
using System.Xml;

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
        private void CounterLog_Clicked(object sender, EventArgs e)
        {
            if (Password == null)
            {

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
                    //Ответ с сервера получаем 
                    var regis_Users = command.Travel_logout;
                    //Значение почты пользователя  присваеваем по умолчанию почту для следущего входа пользователей
                    Mail = null;
                    //Значение пароля пользователя  присваеваем по умолчанию пароль для следущего входа пользователей 
                    Password = null;
                }  
            }
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CounterBtn_Clicked_1(object sender, EventArgs e)
        {
            Вход_в_учетную_запись вход_В_Учетную_Запись =new();

            вход_В_Учетную_Запись.GetVisualElementWindow().Content.CaptureAsync();
           //Открывает
           //  вход_В_Учетную_Запись.DisplayAlert(Title,"Открывает","");
        }

        private void nameEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Mail = nameEntry.Text;
        }
    }
}
