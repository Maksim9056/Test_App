using Class_interaction_Users;
using Microsoft.Maui.Controls;

namespace Client;

public partial class Администратор : ContentPage
{
   

    public Администратор()
	{
		InitializeComponent();
	}

     /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();
  
    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
      //     header.Text = $"Вы выбрали: {languagePicker.SelectedItem}";
        }
        catch
        {

        }
    }

    private   void header_SizeChanged(object sender, EventArgs e)
    {
        try
        {
            //Task.Run(async () => await command.Check_Test(Ip_adress.Ip_adresss, "", "004")).Wait();
            //if (CommandCL.Tests_Travel == null)
            //{

            //}
            //else
            //{
            //    if (CommandCL.Tests_Travel.Test.Count() == 0)
            //    {
            //        await DisplayAlert("Уведомление", "Тестов нету !", "ОK");
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
            //        await DisplayAlert("Уведомление", "Тесты есть", "ОK");
            //    }
            //}
        }
        catch
        {

        }
       //.Add("1");

    }

    private async void CounterLog1Clicked(object sender, EventArgs e)
    {
        try
        {
            var mainPage = new Questin();
            var navigationPage = new NavigationPage(mainPage);
            await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
        }
        catch (Exception ex)
        {
            // Обработка исключения, если необходимо
        }
    }
    private void CounterLog2_Clicked(object sender, EventArgs e)
    {
        var mainPage = new MainPage();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog3_Clicked(object sender, EventArgs e)
    {

        var mainPage = new Тест_название();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private async void CounterLog4_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefUserListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    //private void GoBack(object sender, EventArgs e)
    //{
    //    var mainPage = new MainPage();
    //    var navigationPage = new NavigationPage(mainPage);

    //    Application.Current.MainPage = navigationPage;
    //}
    private void GoBack(object sender, EventArgs e)
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
        {
            navigationPage.Navigation.PopAsync();
        }
    }


    private async void CounterLogTest_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefTestListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private async void CounterLogExamsClicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefExamsListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private async void CounterLogQuestionsClicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefQuestionsListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private void CounterLogAnswerClicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefAnswerListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;

    }
}


