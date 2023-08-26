using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Client.Main;

public partial class Admin : ContentPage
{
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));


    public Admin()
	{
		InitializeComponent();
        BindingContext = this;

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
        catch (Exception )
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

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    private  void CounterLog4_Clicked(object sender, EventArgs e)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        var mainPage = new Project.RefUserListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
        // Shell.Current.GoToAsync("user");
    }

    //private void GoBack(object sender, EventArgs e)
    //{
    //    var mainPage = new MainPage();
    //    var navigationPage = new NavigationPage(mainPage);

    //    Application.Current.MainPage = navigationPage;
    //}

    //Для авторизации учетной записи
    private void GoBack(object sender, EventArgs e)
    {
         Shell.Current.GoToAsync("../admin");

        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
    }


    private  void CounterLogTest_Clicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefTestListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private  void CounterLogExamsClicked(object sender, EventArgs e)
    {
        var mainPage = new Project.RefExamsListPage();
        var navigationPage = new NavigationPage(mainPage);
        Application.Current.MainPage = navigationPage;
    }

    private  void CounterLogQuestionsClicked(object sender, EventArgs e)
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


