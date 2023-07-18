using Class_interaction_Users;
using Microsoft.Maui.Controls;

namespace Client;

public partial class Test : ContentPage
{
    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();



    public Test()
	{
		InitializeComponent();
	}

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Администратор();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }


    private void nameEntrу9_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Администратор();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private  void ContentPage_Loaded(object sender, EventArgs e)
    {
        try 
        {
            Application.Current.MainPage.Window.MinimumWidth = 380;
            Application.Current.MainPage.Window.MinimumHeight = 300;
            Application.Current.MainPage.Window.MaximumWidth = 300;
            Application.Current.MainPage.Window.MaximumHeight = 300;
        }
        catch
        {

        }
    }

    private void usersList3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void CounterLog14_Clicked_1(object sender, EventArgs e)
    {
    }

    private void CounterLog15_Clicked(object sender, EventArgs e)
    {
 
    }

    private void CounterLog14_Clicked_2(object sender, EventArgs e)
    {

    }

    private void CounterLog15_Clicked_1(object sender, EventArgs e)
    {

    }

    private void CounterLog16_Clicked(object sender, EventArgs e)
    {
        //Проверить и обнулить значения 

        var mainPage = new Администратор();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog7_Clicked(object sender, EventArgs e)
    {
      
    }

    private void CounterLog6_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Список_пользователей();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }
}