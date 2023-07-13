using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Text.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Animations;
using Microsoft.Maui;

namespace Client;
public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
        try
        {
            InitializeComponent();
        }
        catch
        {

        }
	}

  //  Dictionary<string, string> Вопросы = new Dictionary<string, string>();
    string Вопрос { get; set; }
    string Ответ { get; set; }

    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> Вопросы = new List<string>();

    public List<string> Ответы = new List<string>();


    public List<string> Вопросыs = new List<string>();

    public List<string> Ответыs = new List<string>();

    List<string>Вопросы_вывод = new List<string>();

    private void nameEntrу4_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
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
        catch
        {

        }
    }

    private void CounterLog12_Clicked(object sender, EventArgs e)
    {

    }

   

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {
        Вопрос = nameEntrу5.Text;

    }

    private async void CounterLog13_Clicked(object sender, EventArgs e)
    {
        try
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
                                //Вопросы = Вопросыs;
                                //Ответы = Ответыs;
                                for(int i = 0; i < Вопросы.Count(); i++)
                                {
                                    Вопросы.Clear();

                                }

                                for (int i = 0; i < Ответы.Count(); i++)
                                {
                                    Ответы.Clear();
                                }

                                Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();

                                //вопросы
                               string[] strings = new string[CommandCL.Roles_Accept.Quest.Length];
                                for (int i = 0; i < strings.Length; i++)
                                {
                                    strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss.ToString();
                                }
                                nameEntrу5.Text = "";
                                nameEntrу9.Text = "";

                              for(int i = 0; i < strings.Length; i++)
                              {
                                    Вопросы_вывод.Add(strings[i]);
                              }
                                //  usersList.AutomationId 
                                //usersList.AutomationId =Convert.ToString( Вопросы_вывод.Count()); 
                                //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                                usersList.ItemsSource = Вопросы_вывод;
                                for (int i = 0; i < Вопросы_вывод.Count(); i++)
                                {
                                    Вопросы_вывод.Clear();
                                }
                                // определяем источник данных
                                await DisplayAlert("Уведомление", "Вопросы и ответ добавлен!", "ОK");
                                //  usersList.ItemsSource = ;
                                // usersList.
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Уведомление", ex.Message, "ОK");
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

    private void CounterLog13_Clicked_1(object sender, EventArgs e)
    {
        try
        {

        }
        catch
        {

        }

    }




    private void ContentPage_Loaded(object sender, EventArgs e)
    {
            //Application.Current.MainPage.Window.Width =;
            //    Application.Current.MainPage.Window.Height = ;  
            //Application.Current.MainPage.Window.MaximumWidth = 1200.8d;
            //Application.Current.MainPage.Window.MaximumHeight = 650.8d;

            //Application.Current.MainPage.GetParentWindow(); 
            //Application.Current.MainPage.GetVisualElementWindow();
            //= 1600.8d; 
            //= 1200.8d;  //Console.WindowHeight;
            //Application.Current.MainPage.Window.MinimumWidth = Application.Current.MainPage.Width; Application.Current.MainPage.Width
            //Application.Current.MainPage.Window.MinimumHeight = Application.Current.MainPage.Height;Application.Current.MainPage.Height
            Application.Current.MainPage.Window.MaximumWidth = 1600;
            Application.Current.MainPage.Window.MaximumHeight = 1400;

      
    }

    //private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //        header.Text = $"Вы выбрали: {languagePicker.SelectedItem}";
        
    //}



    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            //оставить
            headers.Text = $"Выбрано: {e.SelectedItem}";
        }
        catch
        {

        }
    }


    private void usersList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        try
        {


            var tappedUser = e.Item  ;
            if (tappedUser != null)
                header.Text = $"Нажато: {tappedUser}";
        }
        catch
        {

        }
    }

    private void usersList_ItemSelected_2(object sender, SelectedItemChangedEventArgs e)
    {
        try

        {
            var selectedUser = e.SelectedItem;
                if (selectedUser != null)
                {

                }
                headers.Text = $"Выбрано: {selectedUser}";
            }
        catch
        {

        }
     }
}