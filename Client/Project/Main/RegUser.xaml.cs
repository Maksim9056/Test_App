using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
//using Microsoft.UI.Xaml.Controls;
using System.Text.Json;
using System.Text;
using TextChangedEventArgs = Microsoft.Maui.Controls.TextChangedEventArgs;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Net;

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


    public CheckPing checkPing = new CheckPing();

    public Roles Roles { get; set; }
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
        try
        {
            Ip_adress ip_Adress = new Ip_adress();
            ip_Adress.CheckOS();
            Галочка галочка = null;
            using (MemoryStream stream = new MemoryStream())
            {
                Галочка галочка1 = new Галочка(1, $"{ip_Adress.Ip_adressss}");
                var Result = checkPing.CheckPingIp(галочка1);
                галочка = Result;
            }
            if (галочка == null)
            {
                await DisplayAlert("Уведомление", "Сервер выключен или недоступен!", "ОK");
                return;
            }
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
            else if (Roles == null)
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
                        Regis_users tom = new Regis_users(0, User_Name, Password, Roles, Mail);
                        JsonSerializer.Serialize<Regis_users>(fs, tom);
                        FileFS = Encoding.Default.GetString(fs.ToArray());
                    }
                    Task.Run(async () => await command.Reg_User(ip_Adress.Ip_adressss, FileFS, "002")).Wait();
                    var Message = CommandCL.Travel_Regis_users_message;
                    // Остальной код для фильтрации по имени
                    if (Message == null)
                    {
                        await DisplayAlert("Уведомление", "Вы не зарегистрировались!", "ОK");
                    }
                    else
                    {
                        await DisplayAlert("Уведомление", "Вы зарегистрировались!", "ОK");


                    }
                    nameEntry3.Text = null;
                    nameEntry.Text = null;
                    nameEntry1.Text = null;
                    nameEntry2.Text = null;
                    await Navigation.PopAsync();
                }
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

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

    private  List<RefExamsTest> Picker()
    {
        try
        {
            List<RefExamsTest> refExamsTests = new List<RefExamsTest>();
            Ip_adress ip_Adress = new Ip_adress();
            ip_Adress.CheckOS();
            Task.Run(async () => await command.Get_Image(ip_Adress.Ip_adressss, "", "006")).Wait();
            Roles Client = CommandCL.roles_Accept_Client;
            //    
            //   Client.
  
            if (Client == null)
            {
                 DisplayAlert("Уведомление", "Ролей нет!", "ОK");
            }
            else
            {
                //string[] strings = new string[CommandCL.Roles_Accept_Client.Test.Count()];
                //for (int i = 0; i < strings.Length; i++)
                //{
                //    strings[i] = CommandCL.Roles_Accept_Client.Test[i].ToString();
                //}

                for (int i = 0; i < 1; i++)
                {
                    var refExamsTest = new RefExamsTest { ExamsTest = Client};
                    refExamsTests.Add(refExamsTest);
                }
                

                
             //   languagePicker1.Items.Add("");


                //       await DisplayAlert("Уведомление", "Роль есть", "ОK");
            }
            return refExamsTests;
        }
        catch(Exception ex)
        {
             DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

        }
        return null;
    }
    private void ContentPage_Loaded(System.Object sender, System.EventArgs e)
    {
        TestList.ItemsSource  = Picker();



        //Application.Current.MainPage.Window.Width = 413.8d;
        //Application.Current.MainPage.Window.Height = 520.8d;

        //Application.Current.MainPage.Window.MinimumWidth = 413.8d;
        //Application.Current.MainPage.Window.MinimumHeight = 520.8d;

        //Application.Current.MainPage.Window.MaximumWidth = 413.8d;
        //Application.Current.MainPage.Window.MaximumHeight = 520.8d;

    }



    public class RefExamsTest
    {
        public Class_interaction_Users.Roles ExamsTest { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
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

    private async void TestList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {


            if (e.SelectedItem == null)
                return;

            var selectedExamsTest = (RefExamsTest)e.SelectedItem;
            await DisplayAlert("Выбранная роль:", selectedExamsTest.ExamsTest.Name_roles, "OK");
            ((ListView)sender).SelectedItem = null;
            Roles = selectedExamsTest.ExamsTest;

        } 
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

        }
    }

    private async void GoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }

    private void SaveButtonClick(object sender, EventArgs e)
    {
        Reg();
    }
}

