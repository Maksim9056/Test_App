namespace Client;

public partial class Тест_название : ContentPage
{
	public Тест_название()
	{
		InitializeComponent();
	}

    private void CounterLog3_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Администратор();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog4_Clicked(object sender, EventArgs e)
    {

    }

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Вопросы_для_теста();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void nameEntrу10_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
}