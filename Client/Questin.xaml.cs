using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
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

    public List<string> Вопросы_вывод   = new List<string>();


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

    //Введите
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
                                if (usersList.ItemsSource == null)
                                {

                                }
                                else
                                {
                                    usersList.ItemsSource = null;
                                    for (int i = 0; i < Вопросы_вывод.Count(); i++)
                                    {
                                        Вопросы_вывод.Clear();
                                    }
                                }

                                for (int i = 0; i < Ответы.Count(); i++)
                                {
                                    Ответы.Clear();
                                }

                                bool Вопрос_уникальный = false;
                                Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();
                                string Team = "";
                                //вопросы
                                for (int i = 0; i < CommandCL.Roles_Accept.Quest.Length; i++)
                                {
                                    if (CommandCL.Roles_Accept.Quest[i].Id == 0)
                                    {
                                        Вопрос_уникальный = true;
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                                if (Вопрос_уникальный == false)
                                {
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
                                    //  usersList.AutomationId 
                                    //usersList.AutomationId =Convert.ToString( Вопросы_вывод.Count()); 
                                    //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                                    usersList.ItemsSource = Вопросы_вывод;

                                    //тест работы с git151556
                                    // Обработчик события выбора ячейки
                                    //usersList.ItemSelected += (sender, e) =>
                                    //{
                                    //    if (e.SelectedItem != null)
                                    //    {
                                    //        int selectedIndex = Вопросы_вывод.IndexOf(e.SelectedItem.ToString());
                                    //        string selectedValue = e.SelectedItem.ToString();
                                    //        // Выполните необходимые действия с выбранным значением и индексом
                                    //        // Например, выведите их на экран или сохраните в переменные
                                    //        DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
                                    //    }
                                    //};

                                    
                                    // определяем источник данных
                                    //  usersList.ItemsSource = ;
                                    // usersList.
                                }
                                else
                                {
                                    await DisplayAlert("Уведомление","Вопросы уже есть такой !Введите другой вопрос !", "ОK");

                                    //usersList.ItemSelected += (sender, e) =>
                                    //{
                                    //    if (e.SelectedItem != null)
                                    //    {
                                    //        int selectedIndex = Вопросы_вывод.IndexOf(e.SelectedItem.ToString());
                                    //        string selectedValue = e.SelectedItem.ToString();
                                    //        // Выполните необходимые действия с выбранным значением и индексом
                                    //        // Например, выведите их на экран или сохраните в переменные
                                    //        DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
                                    //    }
                                    //};
                                }
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
        try
        {
            string FileFS = "";
            //Admin @Admin.ru
            //Application.Current.MainPage.Window.
            Application.Current.MainPage.Window.MinimumWidth = 1550;
            Application.Current.MainPage.Window.MinimumHeight = 1250;
            Application.Current.MainPage.Window.MaximumWidth = 1550;
            Application.Current.MainPage.Window.MaximumHeight = 1300;

            Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, FileFS, "008")).Wait();
            string[] strings = new string[CommandCL.Roles_Accept.Quest.Length];
            for (int i = 0; i < strings.Length; i++)
            {

                strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss;

              
            }

            for (int j = 0; j < strings.Length; j++)
            {
                Вопросы_вывод.Add(strings[j]);
            }

            usersList.ItemsSource = Вопросы_вывод;
        }catch (Exception )
        {

        }
    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = Вопросы_вывод.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // Выполните необходимые действия с выбранным значением и индексом
            // Например, выведите их на экран или сохраните в переменные
            DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
        }
    }

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        if (usersList.ItemsSource == null)
        {

        }
        else
        {
            usersList.ItemsSource = null;
            for (int i = 0; i < Вопросы_вывод.Count(); i++)
            {
                Вопросы_вывод.Clear();
            }
        }
        var mainPage = new Администратор();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {

    }
}