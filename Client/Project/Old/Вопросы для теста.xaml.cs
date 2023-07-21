using Class_interaction_Users;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;

namespace Client;

public partial class Вопросы_для_теста : ContentPage
{
    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> Вопросы = new List<string>();


    public List<string> Ответы = new List<string>();

    public List<string> _Вопросы = new List<string>();

    public List<string> Ответыs = new List<string>();

    public Вопросы_для_теста()
    {
		InitializeComponent();
        
        
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

        Application.Current.MainPage.Window.MinimumWidth = 580;
        Application.Current.MainPage.Window.MinimumHeight = 650;
        Application.Current.MainPage.Window.MaximumWidth = 590;
        Application.Current.MainPage.Window.MaximumHeight = 650;
        Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, "", "008")).Wait();
        string[] stringsS = new string[CommandCL.Roles_Accept.Quest.Length];
        for (int i = 0; i < stringsS.Length; i++)
        {
            stringsS[i] = CommandCL.Roles_Accept.Quest[i].Questionss;
        }
        for (int j = 0; j < stringsS.Length; j++)
        {
            Вопросы.Add(stringsS[j]);
        }
        usersList2.ItemsSource = Вопросы;
        Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, "", "008")).Wait();
        string[] stringsSs = new string[CommandCL.Roles_Accept.Quest.Length];
        for (int i = 0; i < stringsS.Length; i++)
        {
            stringsSs[i] = CommandCL.Roles_Accept.Quest[i].Answer_True;
        }
        for (int j = 0; j < stringsSs.Length; j++)
        {
            Ответы.Add(stringsSs[j]);
        }
        usersList3.ItemsSource = Ответы;
    }

    private void CounterLog2_Clicked(object sender, EventArgs e)
    {

    }

    private void usersList3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = Ответы.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // Выполните необходимые действия с выбранным значением и индексом
            // Например, выведите их на экран или сохраните в переменные
           // DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
            Ответыs.Add(selectedValue);
        }
    }

    private void usersList2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = Вопросы.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // Выполните необходимые действия с выбранным значением и индексом
            // Например, выведите их на экран или сохраните в переменные
       
              //   DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
              _Вопросы.Add(selectedValue);
        }
    }

    private void CounterLog3_Clicked(object sender, EventArgs e)
    {
    }

    private void nameEntrу9_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу9_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу10_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу19_TextChanged(object sender, TextChangedEventArgs e)
    {

    }


    private void CounterLog4_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Список_пользователей();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }
}