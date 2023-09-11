using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
//using Microsoft.UI.Xaml.Controls;
using System.Text.Json;
using System.Text;
using TextChangedEventArgs = Microsoft.Maui.Controls.TextChangedEventArgs;
using System.Text.RegularExpressions;


namespace Client.Main;

public partial class RegUser : ContentPage
{
    public RegUser()
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

    public async void Reg()
    {
        if (Password1 == null || Password1 == "")
        {
            await DisplayAlert("Уведомление", "Пароль на подтверждение не заполнен!", "ОK");
        }
        else if (Password == null || Password == "")
        {
            await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");
        }
        else if (User_Name == null || User_Name == "")
        {
            await DisplayAlert("Уведомление", "Имя не заполнено", "ОK");
        }
        else if (Rechte == null)
        {
            await DisplayAlert("Уведомление", "Не заполнено разрешение!", "ОK");
        }
        else if (Mail == null || Mail == "")
        {
            await DisplayAlert("Уведомление", "Почта не заполнена!", "ОK");
        }
        else if (!Regex.IsMatch(Mail, "@."))
        {
            await DisplayAlert("Уведомление", "Некорректный адрес электронной почты!", "ОK");
        }
        else
        {
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
                Task.Run(async () => await command.Reg_User(Ip_adress.Ip_adresss, FileFS, "002")).Wait();
                var Message = CommandCL.Travel_Regis_users_message;
                // Остальной код для фильтрации по имени
            }
        }
    }
    /// <summary>
    ///Регестрация и проверки 
    /// </summary>
    private  void Button_Clicked(object sender, EventArgs e)
    {
        Reg();
        //Пароль сравниваем если пароли одинаковые то отправляем на сервер

      
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

    //private async void languagePicker1_SelectedIndexChanged(object sender, EventArgs e)
    //{
      
    //}

   public async void Picker()
    {
        try
        {
            Ip_adress ip_Adress = new Ip_adress();
            ip_Adress.CheckOS();
            Task.Run(async () => await command.Get_Image(ip_Adress.Ip_adressss, "", "006")).Wait();
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


             
                languagePicker1.Items.Add("Пользователь");


         //       await DisplayAlert("Уведомление", "Роль есть", "ОK");
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

        }
    }
    private void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        Picker();
        //Application.Current.MainPage.Window.Width = 413.8d;
        //Application.Current.MainPage.Window.Height = 520.8d;

        //Application.Current.MainPage.Window.MinimumWidth = 413.8d;
        //Application.Current.MainPage.Window.MinimumHeight = 520.8d;

        //Application.Current.MainPage.Window.MaximumWidth = 413.8d;
        //Application.Current.MainPage.Window.MaximumHeight = 520.8d;

    }

    private async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        // Создание NavigationPage с главной страницей
        //var mainPage = new MainPage();
        //var navigationPage = new NavigationPage(mainPage);

        //Application.Current.MainPage = navigationPage;
        await Navigation.PushAsync(new MainPage());

    }

    private void languagePicker1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

