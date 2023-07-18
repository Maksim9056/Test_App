using Class_interaction_Users;
using Microsoft.Maui.Controls;

namespace Client;

public partial class Список_пользователей : ContentPage
{
    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> Пользователи_для_теста = new List<string>();
    public Список_пользователей()
    {
        InitializeComponent();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {


        Application.Current.MainPage.Window.MinimumWidth = 580;
        Application.Current.MainPage.Window.MinimumHeight = 400;
        Application.Current.MainPage.Window.MaximumWidth = 590;
        Application.Current.MainPage.Window.MaximumHeight = 400;

        Task.Run(async () => await command.From_Friend(Ip_adress.Ip_adresss, "", "015")).Wait();

        if (CommandCL.Regis_Users_Test == null)
        {

        }
        else
        {
            string[] strings = new string[CommandCL.Regis_Users_Test.regis.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = CommandCL.Regis_Users_Test.regis[i].Name_Employee;
            }


            for (int i = 0; i < strings.Length; i++)
            {
                Пользователи_для_теста.Add(strings[i]);
            }

            usersList1.ItemsSource = Пользователи_для_теста;
        }
    }

    private void usersList1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = Пользователи_для_теста.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // Выполните необходимые действия с выбранным значением и индексом
            // Например, выведите их на экран или сохраните в переменные
            DisplayAlert("Выбранная строка", $"Индекс: {selectedIndex}, Значение: {selectedValue}", "ОК");
        }

    }

    

    private void CounterLog6_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Вопросы_для_теста();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog7_Clicked(object sender, EventArgs e)
    {
    
        var mainPage = new Test();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private void Counter_Clicked(object sender, EventArgs e)
    {

    }

    private void nameEntrу10_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}