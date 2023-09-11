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
        //    var mainPage = new ();
            await Navigation.PushAsync(new Questin());

            //var navigationPage = new NavigationPage(mainPage);
          //  await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
        }
        catch (Exception )
        {
            // Обработка исключения, если необходимо
        }
    }
    private async void CounterLog2_Clicked(object sender, EventArgs e)
    {
        //var mainPage = new ();
        //var navigationPage = new NavigationPage(mainPage);
        await Navigation.PushAsync(new MainPage());

        //Application.Current.MainPage = navigationPage;
    }

    private async void CounterLog3_Clicked(object sender, EventArgs e)
    {

  //      var mainPage = new ();

        await Navigation.PushAsync(new Тест_название());

       // var navigationPage = new NavigationPage(mainPage);

     //   Application.Current.MainPage = navigationPage;
    }

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    private async void CounterLog4_Clicked(object sender, EventArgs e)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
    {


        await Navigation.PushAsync(new Project.RefUserListPage());


        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        //var mainPage = new Project.RefUserListPage();
        //var navigationPage = new NavigationPage(mainPage);
        //Application.Current.MainPage = navigationPage;
        // Shell.Current.GoToAsync("user");

        //var mainPage = new Project.RefUserListPage();
        //var navigationPage = new NavigationPage(mainPage);
        //Application.Current.MainPage = navigationPage;
        // await Shell.Current.GoToAsync("RefUserListPage");

    }

    //private void GoBack(object sender, EventArgs e)
    //{
    //    var mainPage = new MainPage();
    //    var navigationPage = new NavigationPage(mainPage);

    //    Application.Current.MainPage = navigationPage;
    //}

    //Для авторизации учетной записи
    private  async void GoBack(object sender, EventArgs e)
    {
        try
        {
            //var flyoutItem = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("admin"));
            //if (flyoutItem != null)
            //{
            //    flyoutItem.IsVisible = false;
            //}
            //var flyoutItemUser = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("User"));
            //if (flyoutItemUser != null)
            //{
            //    flyoutItemUser.IsVisible = false;
            //}
            //var flyoutItemhelp = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_admin"));
            //if (flyoutItemhelp != null)
            //{
            //    flyoutItemhelp.IsVisible = false;
            //}


            // await Shell.Current.Navigation.PopAsync();

            //  Navigation.PopAsync();

          await   Navigation.PushAsync(new MainPage());

          Shedow();

      

            // await Navigation.PopToRootAsync();


            //if (Application.Current.MainPage is NavigationPage navigationPage)
            //{
            //     Shell.Current.GoToAsync("//admin");
            //    navigationPage.Navigation.PopAsync();
            //}
        }
        catch(Exception ex) 
        {
        await    DisplayAlert("Ошибка", ex.Message, "Ок");

        }

    }



    //public  async void Shedow()
    //{
    //    try
    //    {
    //        var flyoutItemIMPL_admin = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_admin"));
    //        if (flyoutItemIMPL_admin != null)
    //        {
    //            flyoutItemIMPL_admin.IsVisible = false;
    //        }

    //        var flyoutItemIMPL_user = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_user"));
    //        if (flyoutItemIMPL_user != null)
    //        {
    //            flyoutItemIMPL_user.IsVisible = false;
    //        }

    //        var flyoutItemIMPL_test = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_test"));
    //        if (flyoutItemIMPL_test != null)
    //        {
    //            flyoutItemIMPL_test.IsVisible = false;
    //        }


    //        var flyoutItemIMPL_Exams = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Exams"));
    //        if (flyoutItemIMPL_Exams != null)
    //        {
    //            flyoutItemIMPL_Exams.IsVisible = false;
    //        }

    //        var flyoutItemIMPL_Questions = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Questions"));
    //        if (flyoutItemIMPL_Questions != null)
    //        {
    //            flyoutItemIMPL_Questions.IsVisible = false;
    //        }

    //        var flyoutItemIMPL_Answer = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Answer"));

    //        if (flyoutItemIMPL_Answer != null)
    //        {
    //            flyoutItemIMPL_Answer.IsVisible = false;
    //        }

    //        var flyoutItemseting1 = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
    //        if (flyoutItemseting1 != null)
    //        {
    //            flyoutItemseting1.IsVisible = true;
    //        }
    //    }
    //    catch( Exception ex)
    //    {
    //        await DisplayAlert("Ошибка", ex.Message, "Ок");

    //    }
    //}



    public async void Shedow()
    {
        try
        {  
         
            var flyoutItemIMPL_admin = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_admin"));
            if (flyoutItemIMPL_admin != null)
            {
                flyoutItemIMPL_admin.IsVisible = false;
            }

            //var flyoutItemIMPL_user = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_userd"));
            //if (flyoutItemIMPL_user != null)
            //{
            //    flyoutItemIMPL_user.IsVisible = false;
            //}
            var flyoutItemIMPL_test = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_test"));
            if (flyoutItemIMPL_test != null)
            {
                flyoutItemIMPL_test.IsVisible = false;
            }

            var flyoutItemIMPL_Exams = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Exams"));
            if (flyoutItemIMPL_Exams != null)
            {
                flyoutItemIMPL_Exams.IsVisible = false;
            }

            var flyoutItemIMPL_Questions = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Questions"));
            if (flyoutItemIMPL_Questions != null)
            {
                flyoutItemIMPL_Questions.IsVisible = false;
            }

          
            var flyoutItemIMPL_Answer = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Answer"));
            if (flyoutItemIMPL_Answer != null)
            {
                flyoutItemIMPL_Answer.IsVisible = false;
            }

      
            //var flyoutItemseting1 = Shell.Current?.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
            //if (flyoutItemseting1 != null)
            //{
            //    flyoutItemseting1.IsVisible = true;
            //}   
            
         

        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "Ок");
        }
    }

    private async void CounterLogTest_Clicked(object sender, EventArgs e)
    {
        //var mainPage = new ;
        //var navigationPage = new NavigationPage(mainPage);
        //await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
        await Navigation.PushAsync(new Project.RefTestListPage());

    }

    private async void CounterLogExamsClicked(object sender, EventArgs e)
    {
       // var mainPage = new ;
       // var navigationPage = new NavigationPage(mainPage);
        await Navigation.PushAsync(new Project.RefExamsListPage());

       // await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
    }

    private async void CounterLogQuestionsClicked(object sender, EventArgs e)
    {
        //var mainPage = new ;
        //var navigationPage = new NavigationPage(mainPage);
        await Navigation.PushAsync(new Project.RefQuestionsListPage());

     //   await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
    }

    private async void CounterLogAnswerClicked(object sender, EventArgs e)
    {
        //var mainPage = new ;
        //var navigationPage = new NavigationPage(mainPage);
        await Navigation.PushAsync(new Project.RefAnswerListPage());

      //  await Application.Current.MainPage.Navigation.PushAsync(navigationPage);
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        //var flyoutItemUser = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_user"));
        //if (flyoutItemUser == null)
        //{
        //    // Создание пунктов меню класса
        //    var main = new ShellContent { Content = new Project.RefUserListPage(), Route = "user" };
        //    // Добавление пунктов меню в класс
        //    Shell.Current.Items.Add(new ShellSection { Title = "Справочник пользователей", Items = { main }, Icon = "dotnet_bot.png", Route = "user" });
        //    // Обработчик события при нажатии на пункт меню
        //    main.PropertyChanged += async (sender, e) =>
        //    {
        //        if (e.PropertyName == nameof(ShellContent.IsEnabled) && !main.IsEnabled)
        //        {
        //            // Переход обратно
        //            await Shell.Current.GoToAsync("//IMPL_user");
        //        }
        //    };
        //}

      


        var flyoutItemAdmin = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_admin"));
        if (flyoutItemAdmin == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Client.Main.Admin(), Route = "admin" };

            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Админская панель", Icon = "dotnet_bot.png", Route = "admin", Items = { main } });

            // Обработчик события при нажатии на пункт меню
            //main.PropertyChanged += async (sender, e) =>
            //{
            //    if (e.PropertyName == nameof(ShellContent.IsEnabled) && !main.IsEnabled)
            //    {
            //        // Переход обратно
            //        await Shell.Current.GoToAsync("//IMPL_user");
            //    }
            //};
        }

        var flyoutItemUser = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_userd"));
        if (flyoutItemUser == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Project.RefUserListPage()};

            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Справочник пользователей", Icon = "dotnet_bot.png", Route = "userd", Items = { main } });

            //// Обработчик события при нажатии на пункт меню
            //main.PropertyChanged += async (sender, e) =>
            //{
            //    if (e.PropertyName == nameof(ShellContent.IsEnabled) && !main.IsEnabled)
            //    {
            //        // Переход обратно
            //        await Shell.Current.GoToAsync("//IMPL_user");
            //    }
            //};
        }


        var flyoutItemTest = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_test"));
        if (flyoutItemTest == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Project.RefTestListPage() };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Справочник тестов", Items = { main }, Icon = "dotnet_bot.png", Route = "test" });

        }

        var flyoutItemExams = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Exams"));
        if (flyoutItemExams == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Project.RefExamsListPage() };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Справочник экзаменов", Items = { main }, Icon = "dotnet_bot.png", Route = "Exams" });

        }

        var flyoutItemQuestions = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Questions"));
        if (flyoutItemQuestions == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Project.RefQuestionsListPage() };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Справочник вопросов", Items = { main }, Icon = "dotnet_bot.png", Route = "Questions" });

        }

        var flyoutItemAnswer = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_Answer"));
        if (flyoutItemAnswer == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Project.RefAnswerListPage() };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Справочник ответов", Items = { main }, Icon = "dotnet_bot.png", Route = "Answer" });

        }

        //var flyoutItemEnd = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_End"));
        //if (flyoutItemEnd == null)
        //{
        //    // Создание пунктов меню класса
        //    var main = new ShellContent { Content = new Client.MainPage() };
        //    // Добавление пунктов меню в класс
        //    Shell.Current.Items.Add(new ShellSection { Title = "Выход", Items = { main }, Icon = "dotnet_bot.png", Route = "End" });

        //}

        if(BindingContext == null)
        {
         BindingContext = this;

        }

    }


}


