using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Client;

public partial class Questin : ContentPage
{
    public Questin()
    {
        InitializeComponent();
    }

    string Вопрос { get; set; }
    string Ответ { get; set; }

    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> _Вопросы = new List<string>();

    public List<string> Ответы = new List<string>();


    public List<string> Вопросыs = new List<string>();

    public List<string> Ответыs = new List<string>();

    List<string> Вопросы_вывод = new List<string>();


    //public ObservableCollection<Questions[> Userss ;


    public List<string> Users { get; set; }
    private void nameEntrу9_TextChanged(object sender, TextChangedEventArgs e)
    {
        Ответ = nameEntrу9.Text;

    }

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {
        Вопрос = nameEntrу5.Text;
    }

    private async void CounterLog12_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (Вопрос == null)
            {
                await DisplayAlert("Уведомление", "Вопросы пустой заполните поле!", "ОK");
            }
            else
            {
                if(string.IsNullOrEmpty(Вопрос))
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
                            _Вопросы.Add(Вопрос);

                            Ответы.Add(Ответ);
                            //FileFS обьявляем для отправки на сервер
                            string FileFS = "";
                            //Обьявляем MemoryStream 
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Заполняем класс Questions для отправки на сервер
                                Questions questions = new Questions { Questionss = _Вопросы[0], Answer_True = Ответы[0] };
                                //Серелизуем класс CheckMail_and_Password для отправки на сервер
                                JsonSerializer.Serialize<Questions>(memoryStream, questions);
                                //Декодировали в строку  memoryStream    класс запоаковали в json строку
                                FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                                //Вопросы = Вопросыs;
                                //Ответы = Ответыs;
                                for (int i = 0; i < _Вопросы.Count(); i++)
                                {
                                    _Вопросы.Clear();

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

                                    strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss;


                                }
                              
                                nameEntrу5.Text = "";
                                nameEntrу9.Text = "";

                     
                                for (int i = 0; i < strings.Length; i++)
                                {
                                    Вопросы_вывод.Add(strings[i]);
                                }
                                //  usersList.AutomationId  Admin@Admin.ru
                                //usersList.AutomationId =Convert.ToString( Вопросы_вывод.Count()); 
                                //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                                //     usersList.ItemsSource = Вопросы_вывод;
                                //for (int i = 0; i < strings.Length; i++)
                                //{
                                //    Вопросы.Items.Add(strings[i]);
                                //}
                                //Вопросы.SelectedIndexChanged += Вопросы_SelectedIndexChanged;
                                //Users = Вопросы_вывод;



                                //        usersList.SelectedItem = Вопросы_вывод;
                                Users = Вопросы_вывод;

                                 usersList.ItemsSource = Users;
                             //   usersList.ItemsSource = Вопросы_вывод;
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
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
         //Admin @Admin.ru
         //Application.Current.MainPage.Window.
        Application.Current.MainPage.Window.MinimumWidth = 1000;
        Application.Current.MainPage.Window.MinimumHeight = 800;
        Application.Current.MainPage.Window.MaximumWidth = 1600;
        Application.Current.MainPage.Window.MaximumHeight = 1400;
    }

    private   void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            //if (e.SelectedItem != null)
            //{
            //    nameEntrу1.Text = $"Выбрано: {e.SelectedItem}";

            //}


        }
        catch(Exception )
        {

        }
    }

    //private void usersList_ItemTapped(object sender, ItemTappedEventArgs e)
    //{
    //    try
    //    {
    //     //   usersList.SelectedItem = null;


    //    }
    //    catch(Exception)
    //    {

    //    }

    //}

    private void nameEntrу1_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private void Вопросы_SelectedIndexChanged(object sender, EventArgs e)
    {
      
           // nameEntrу1.Text = $"Вы выбрали: {Вопросы.SelectedItem}";
        
       
    }

    //private void usersList_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
    //{ 
    //     if (e.SelectedItem != null)
    //    {
    //        string selectedValue = (string)e.SelectedItem;
    //        nameEntrу1.Text = selectedValue;
    //    }
    //}

 

    private void usersList_ItemTapped_1(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is string selectedUser)
        {
           nameEntrу1.Text = selectedUser;
        }
    }
}