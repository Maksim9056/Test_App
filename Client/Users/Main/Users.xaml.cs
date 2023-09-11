using Class_interaction_Users;
using Client.Users.Doc.DocPersonalAchievement;
//using HealthKit;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System.Windows.Input;

namespace Client.Users;

public partial class Users : ContentPage
{
    //public static string NameUsers { get; set; }
    //public static int id { get; set; }
    public static User user { get; set; }
    public Regis_users regis_Users { get; set; }
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));


    public Users(Regis_users name )
    {
        InitializeComponent();

        regis_Users = name;
        user = new User
        {
            Id = name.Id,
            Password = name.Password,
            Name_Employee = name.Name_Employee
              ,
            Employee_Mail = name.Employee_Mail
              ,
            Id_roles_users = name.Rechte


        }
   ;
        NameUser.Text = name.Name_Employee;
    }

    public void User_NAME(Regis_users name)
    {

   
    }
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        //var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        //await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
        //((ListView)sender).SelectedItem = null;
    }

    private async void ExamButtonClicked(object sender, EventArgs e)
    {
        // User User =new  User() 

        //      Shell.Current.GoToAsync("examispersonal");
        await Navigation.PushAsync(new DocTheExamisPersonal(user));
        //await Shell.Current.GoToAsync(nameof(DocTheExamisPersonal), new Dictionary<string, object>
        //{
        //    { "user", user }
        //});
        //await Shell.Current.GoToAsync($"{nameof(DocTheExamisPersonal)}", new Dictionary<string, object>
        //{
        //     { nameof(User), user }
        //});

        // User
        //  Class_interaction_Users.User user
    }
    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        Shell.Current.GoToAsync("logout");
    }

    private async void AchievementsButtonClicked(object sender, EventArgs e)
    {
        //      Shell.Current.GoToAsync("achievement");
        await Navigation.PushAsync(new DocPersonalAchievement(user));

    }

    private void SettingsButtonClicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        //var flyoutItemUser = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("User"));
        //if (flyoutItemUser != null)
        //{
        //    flyoutItemUser.IsVisible = true;
        //}

  


        var flyoutItemUser = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_user2"));
        if (flyoutItemUser == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Client.Users.Users(regis_Users) };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Пользователь", Items = { main }, Icon = "dotnet_bot.png", Route = "user2" });

        }




    }
    private  async void Statictick_Users(object sender, EventArgs e)
    {

      //  Shell.Current.GoToAsync("statistics");
        await Navigation.PushAsync(new Client.Users.Doc.DocStatisticsUserResult.DocStatisticsUserResult (user));

    }
}