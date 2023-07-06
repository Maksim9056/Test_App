using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
//using Microsoft.UI.Xaml.Controls;
using System.Text.Json;
using System.Text;
using TextChangedEventArgs = Microsoft.Maui.Controls.TextChangedEventArgs;
using System.Text.RegularExpressions;
//using PushKit;

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
    private void nameEntry1_TextChanged(object sender, TextChangedEventArgs e)
    {
        Password = nameEntry1.Text;

    }

    private void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
   
        Mail = nameEntry.Text;
    }

    private void nameEntry2_TextChanged(object sender, TextChangedEventArgs e)
    {
        Password1 = nameEntry2.Text;
    }

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


                if (string.IsNullOrEmpty(Password))
                {
                    await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");

                }
                else
                {

                    if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(Password1))
                    {
                        await DisplayAlert("Уведомление", "Пароль и пароль  подтверждения не заполнен!", "ОK");
                    }
                    else {

                        if (string.IsNullOrEmpty(User_Name))
                        {
                            await DisplayAlert("Уведомление", "Имя не заполнено", "ОK");
                        }
                        else
                        {

                            if (Rechte == null)
                            {
                                await DisplayAlert("Уведомление", "Не заполнено разрешение!", "ОK");

                            }
                            else
                            {
                                if (string.IsNullOrEmpty(Mail))
                                {
                                    await DisplayAlert("Уведомление", "Почта не заполнена!", "ОK");
                                }
                                else
                                {

                                    string patern = "@.";
                                    Regex regex =new Regex(patern);
                                    //      MatchCollection matches = regex.Matches(Mail);

                                    if (Regex.IsMatch(Mail, patern))
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
                                            //command.Reg_User(IP_ADRES.Ip_adress, FileFS, "002");

                                            Task.Run(async () => await command.Reg_User(Ip_adress.Ip_adresss, FileFS, "002")).Wait();
                                            //Получаем из сервера и фильтруем
                                            var Message = CommandCL.Travel_Regis_users_message;
                                            //Фильтруем по имени 
                                            if (Message.Name_Employee == User_Name)
                                            {

                                                await DisplayAlert("Уведомление", "Пользователь зарегистровался!", "ОK");
                                                //Выводим успешная регистрация и закрываем эту страницу и преходи на вход!
                                                await Navigation.PushAsync(new MainPage());

                                            }
                                            else
                                            {
                                                await DisplayAlert("Уведомление", "Пользователь такой уже есть!", "ОK");
                                                //обрабатываем  пишем регестрация  не прошла и что он свои данные обратно данные ввел
                                            }

                                        }
                                    }
                                    else
                                    {
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
           
          
         
         await DisplayAlert("Уведомление", "Пароль и пароль  подтверждения не одинаковые!", "ОK");

            
            //Обрабатываем если пароль не одинаковый
        }
    }

    private void nameEntry1_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntry1_TextChanged_2(object sender, TextChangedEventArgs e)
    {
        User_Name = nameEntry3.Text;
    }

    private void nameEntry4_TextChanged(object sender, TextChangedEventArgs e)
    {
        Rechte = nameEntry4.Text;
    }
}

