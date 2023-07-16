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
                                string Team ="";
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
                                //  usersList.AutomationId 
                                //usersList.AutomationId =Convert.ToString( Вопросы_вывод.Count()); 
                                //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                               usersList.ItemsSource = Вопросы_вывод;

                                // Обработчик события выбора ячейки
                                usersList.ItemSelected += (sender, e) =>
                                {
                                    if (e.SelectedItem != null)
                                    {
                                        int selectedIndex = Вопросы_вывод.IndexOf(e.SelectedItem.ToString());
                                        string selectedValue = e.SelectedItem.ToString();
                                        // Выполните необходимые действия с выбранным значением и индексом
                                        // Например, выведите их на экран или сохраните в переменные
                                        DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
                                    }
                                };

                                //for (int i = 0; i < Вопросы_вывод.Count(); i++)
                                //{
                                //    Вопросы_вывод.Clear();
                                //}
                                // определяем источник данных
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
}