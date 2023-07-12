using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Text.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Animations;

namespace Client;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

  //  Dictionary<string, string> Вопросы = new Dictionary<string, string>();
    string Вопрос { get; set; }
    string Ответ { get; set; }

    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    List<string> Вопросы = new List<string>();

    List<string> Ответы = new List<string>();

    private void nameEntrу4_TextChanged(object sender, TextChangedEventArgs e)
    {
        Ответ = nameEntrу9.Text;
        //Console.WriteLine(Results[0]);
        //Console.WriteLine(Results[1]);
        // Console.WriteLine(Results[3]);
        //var Results = Return?.Split(new char[] { '.' });
        //Console.WriteLine(Results[0]);
        //Console.WriteLine(Results[1]);
        //Console.WriteLine(Results[2]);
        //Console.WriteLine(Results[3]);
    }

    private void CounterLog12_Clicked(object sender, EventArgs e)
    {

    }

    private void nameEntrу4_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {
        Вопрос = nameEntrу5.Text;

    }

    private async void CounterLog13_Clicked(object sender, EventArgs e)
    {
        if (Вопрос == null)
        {
            await DisplayAlert("Уведомление", "Вопросы пустой заполните поле!", "ОK");

        }
        else
        {
            if (string.IsNullOrEmpty(Вопрос))
            {
                await DisplayAlert("Уведомление", "Вопросы пустой заполните поле!", "ОK");

            }
            else
            {
                if (Ответ == null)
                {
                    await DisplayAlert("Уведомление", "Ответ пустой заполните поле!", "ОK");

                }
                else
                {
                    if (string.IsNullOrEmpty(Ответ))
                    {
                        await DisplayAlert("Уведомление", "Ответ пустой заполните поле!", "ОK");

                    }
                    else
                    {
                        Вопросы.Add(Вопрос);

                        Ответы.Add(Ответ);
                        //FileFS обьявляем для отправки на сервер
                        string FileFS = "";
                        //Обьявляем MemoryStream 
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            //Заполняем класс Questions для отправки на сервер
                            Questions questions = new Questions { Questionss = Вопросы[0], Answer_True = Ответы[0] };
                            //Серелизуем класс CheckMail_and_Password для отправки на сервер
                            JsonSerializer.Serialize<Questions>(memoryStream, questions);
                            //Декодировали в строку  memoryStream    класс запоаковали в json строку
                            FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                            Вопросы = null;
                            Ответы = null;
                            Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();

                       
                            await DisplayAlert("Уведомление", "Вопросы и ответ добавлен!", "ОK");

                            string[] strings = new string[CommandCL.Questionss_Travel.Questionsses.Count()];
                            for (int i = 0; i < strings.Length; i++)
                            {
                                strings[i] = CommandCL.Questionss_Travel.Questionsses[i].ToString();
                            }
                            for (int i = 0; i < strings.Length; i++)
                            {
                                usersList.ItemsSource =strings[i];
                            }

                            usersList.ItemsSource = ;
                            usersList.
                            nameEntrу5.Text = null;
                            nameEntrу9.Text = null;
                            Вопрос = null;
                            Ответ = null;
                        }
                    }
                }
            }
            //string[][] вопросы = new string[Вопросы.Keys][Вопросы.Values;)] {};

            //for (int i = 0; i < Вопросы.Count(); i++)
            //{
            //    вопросы[i] = Вопросы[i];
            //}

            //Вопросы.Add();

            //for (int i = 0; i < вопросы.Length; i++)
            //{
            //    Console.WriteLine(вопросы[i]);
            //}
        }
    }

    private void CounterLog13_Clicked_1(object sender, EventArgs e)
    {

    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {

    }

    private void nameEntrу10_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CounterLog15_Clicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Application.Current.MainPage.Window.Width = 1000.8d;
        Application.Current.MainPage.Window.Height = 650.8d;

        Application.Current.MainPage.Window.MinimumWidth = 1000.8d;
        Application.Current.MainPage.Window.MinimumHeight = 650.8d;

        Application.Current.MainPage.Window.MaximumWidth = 1200.8d;
        Application.Current.MainPage.Window.MaximumHeight = 650.8d;
    }

    //private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //        header.Text = $"Вы выбрали: {languagePicker.SelectedItem}";
        
    //}

    private  void header_SizeChanged_1(object sender, EventArgs e)
    {
        //Task.Run(async () => await command.Check_Test(Ip_adress.Ip_adresss, "", "004")).Wait();
        //if (CommandCL.Tests_Travel == null)
        //{

        //}
        //else
        //{
        //    if (CommandCL.Tests_Travel.Test.Count() == 0)
        //    {
        //        await DisplayAlert("Уведомление", "Вопросов нету нету !", "ОK");
        //    }
        //    else
        //    {
        //        string[] strings = new string[CommandCL.Tests_Travel.Test.Count()];
        //        for (int i = 0; i < strings.Length; i++)
        //        {
        //            strings[i] = CommandCL.Tests_Travel.Test[i].ToString();
        //        }
        //        for (int i = 0; i < strings.Length; i++)
        //        {
        //            languagePicker.Items.Add(strings[i]);
        //        }
        //        await DisplayAlert("Уведомление", "Вопросов есть", "ОK");
        //    }
        //}
    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //оставить
        selected.Text = $"Выбрано: {e.SelectedItem}";
    }

    /// <summary>
    /// Передалать на запрос на сервер
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void header_SizeChanged(object sender, EventArgs e)
    {
       //Запрос на сервер передлать
        usersList.ItemsSource = Вопросы;
    }
}