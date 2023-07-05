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

        void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mail = nameEntry.Text;
        }

        private void CounterBtn_Clicked(object sender, EventArgs e)
        {
            

        }

        private void nameEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = nameEntry1.Text;
        }

        private void CounterLog_Clicked(object sender, EventArgs e)
        {
            if (Password == null)
            {

            }
            else
            {
                string FileFS = "";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CheckMail_and_Password ss = new CheckMail_and_Password(Password, Mail);
                    JsonSerializer.Serialize<CheckMail_and_Password>(memoryStream, ss);
                    //Декодировали в строку  MemoryStream fs   
                    FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                    Task.Run(async () => await command.Check_User_Possword(Ip_adress.Ip_adresss, FileFS, "003")).Wait();




                    var regis_Users = command.Travel_logout;
                    
                }
               
            }
        }
    }
}
