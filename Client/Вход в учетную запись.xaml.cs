using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
//using Microsoft.UI.Xaml.Controls;
using System.Text.Json;
using System.Text;
using TextChangedEventArgs = Microsoft.Maui.Controls.TextChangedEventArgs;
using System.Text.RegularExpressions;


namespace Client;

public partial class Вход_в_учетную_запись : ContentPage
{
    public Вход_в_учетную_запись()
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
    ///Имя 
    /// </summary>
    public string User_Name { get; set; }


    /// <summary>
    ///Пароль пользователя
    /// </summary>
    public string Password { get; set; }


    /// <summary>
    ///Пароль пользователя1
    /// </summary>
    public string Password1 { get; set; }


    /// <summary>
    ///Пароль пользователя
    /// </summary>
    public string Rechte { get; set; }


    /// <summary>
    ///Пароль пользователя присываеваем значение
    /// </summary>
    private void nameEntry1_TextChanged(object sender, TextChangedEventArgs e)
    {
        Password = nameEntry1.Text;

    }


    /// <summary>
    ///Почту пользователя присваеваем значение
    /// </summary>
    private void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
   
        Mail = nameEntry.Text;
    }

    /// <summary>
    ///Пароль подтвердеждения пользователя присываеваем значение
    /// </summary>
    private void nameEntry2_TextChanged(object sender, TextChangedEventArgs e)
    {
        Password1 = nameEntry2.Text;
    }

    /// <summary>
    ///Регестрация и проверки 
    /// </summary>
    private async void Button_Clicked(object sender, EventArgs e)
    {

        //Пароль сравниваем если пароли одинаковые то отправляем на сервер
   
        if (Password == Password1)
        {

            if (string.IsNullOrEmpty(Password1))
            {
                await DisplayAlert("Уведомление", "Пароль на подтверждения не заполнен!", "ОK");
            }
            else
            {

                //Проверяет пароль   пустой ли или значение есть з
                if (string.IsNullOrEmpty(Password))
                {
                    await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");

                }
                else
                {
                    //Проверяет пароль  пустой или полный и пароль подтверждения пустой ли или значение есть

                    if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(Password1))
                    {
                        await DisplayAlert("Уведомление", "Пароль и пароль  подтверждения не заполнен!", "ОK");
                    }
                    else 
                    {
                        //Проверяет имя пользователя  пустой или есть имя пользователя
                        if (string.IsNullOrEmpty(User_Name))
                        {
                            await DisplayAlert("Уведомление", "Имя не заполнено", "ОK");
                        }
                        else
                        {
                            //Проверяет разрешение на создания тестов
                            if (Rechte == null)
                            {
                                await DisplayAlert("Уведомление", "Не заполнено разрешение!", "ОK");

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
                                    Regex regex =new Regex(patern);
                                    //      MatchCollection matches = regex.Matches(Mail);

                                    //Проверяет в Mail есть ли в строке это @ почту
                                    if (Regex.IsMatch(Mail, patern))
                                    {
                                        //Соберает класс
                                        using (MemoryStream Reg_user_Dispons = new MemoryStream())
                                        {
                                            CommandCL command = new CommandCL();
                                            string FileFS = "";
                                            using (MemoryStream fs = new MemoryStream())
                                            {
                                                Regis_users tom = new Regis_users(0, User_Name, Password, Convert.ToInt32(Rechte), Mail);
                                                JsonSerializer.Serialize<Regis_users>(fs, tom);
                                                FileFS = Encoding.Default.GetString(fs.ToArray());
                                            }
                                            //command.Reg_User(IP_ADRES.Ip_adress, FileFS, "002");

                                            //Отправляет на сервер
                                            Task.Run(async () => await command.Reg_User(Ip_adress.Ip_adresss, FileFS, "002")).Wait();
                                            //Получаем из сервера и фильтруем
                                            var Message = CommandCL.Travel_Regis_users_message;
                                            //Фильтруем по имени 
                                            if (Message.Name_Employee == User_Name)
                                            {
                                                //
                                                await DisplayAlert("Уведомление", "Пользователь зарегистровался!", "ОK");
                                                //Выводим успешная регистрация и закрываем эту страницу и преходи на вход!
                                                await Navigation.PushAsync(new MainPage());
                                             
                                   

                                            }
                                            else
                                            {
                                                //Есть такой Пользователь то выводим что имя занято
                                                await DisplayAlert("Уведомление", "Пользователь такой уже есть!", "ОK");
                                                //обрабатываем  пишем регестрация  не прошла и что он свои данные обратно данные ввел
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
                    }
                }
            }
        }
        else
        {
           
          
         //Выводим что пароль и подтверждающий пароль не одинаковый
         await DisplayAlert("Уведомление", "Пароль и пароль  подтверждения не одинаковые!", "ОK");

            
            //Обрабатываем если пароль не одинаковый
        }
    }

    private void nameEntry1_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }


    /// <summary>
    ///Имя пользователя присываеваем значение
    /// </summary>
    private void nameEntry1_TextChanged_2(object sender, TextChangedEventArgs e)
    {
        User_Name = nameEntry3.Text;
    }

    /// <summary>
    ///Подверждения пользователя пользователя присываеваем значение
    /// </summary>
    private void nameEntry4_TextChanged(object sender, TextChangedEventArgs e)
    {
        //Исправим вместо 1 будет список должностей а затем id получит!
       // Rechte = nameEntry4.Text;
    }

    private  void header_SizeChanged(object sender, EventArgs e)
    {
      
    }

    private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
    {

        
    }

    private  void languagePicker_ParentChanged(object sender, EventArgs e)
    {
    
    }

    private async void languagePicker1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Task.Run(async () => await command.Get_Image(Ip_adress.Ip_adresss, "", "006")).Wait();
        var Client = CommandCL.Roles_Accept_Client;
        if (Client.Test.Count() == 1)
        {
            await DisplayAlert("Уведомление", "Ролей нет!", "ОK");
        }
        else
        {
            string[] strings = new string[CommandCL.Roles_Accept_Client.Test.Count()];
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = CommandCL.Roles_Accept_Client.Test[i].ToString();
            }
            for (int i = 0; i < strings.Length; i++)
            {

                languagePicker1.Items.Add(strings[i]);

            }

            await DisplayAlert("Уведомление", "Роль есть", "ОK");
        }
    }

    private void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {

        Application.Current.MainPage.Window.Width = 413.8d;
        Application.Current.MainPage.Window.Height = 520.8d;

        Application.Current.MainPage.Window.MinimumWidth = 413.8d;
        Application.Current.MainPage.Window.MinimumHeight = 520.8d;

        Application.Current.MainPage.Window.MaximumWidth = 413.8d;
        Application.Current.MainPage.Window.MaximumHeight = 520.8d;

    }

    private void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        // Создание NavigationPage с главной страницей
        var mainPage = new MainPage();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;

    }
}

