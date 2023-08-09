using Class_interaction_Users;

namespace Client.Users.Doc.DocExamFromTests;

public partial class DocExamFromTests : ContentPage
{
    //public static string NameUsers { get; set; }
    //public static int id { get; set; }
    public static User user {  get; set; }
	public DocExamFromTests()
	{
		InitializeComponent();

    }   

    public void User_NAME(Regis_users name)
    {

        user = new User {Id= name.Id,Password = name.Password ,Name_Employee = name.Name_Employee
            ,Employee_Mail = name.Employee_Mail
          ,Id_roles_users = name.Rechte
        

        }
        ;
    }
    private  void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        //var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        //await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
        //((ListView)sender).SelectedItem = null;
    }

    private  async void ExamButtonClicked(object sender, EventArgs e)
    {
        // User User =new  User() 

        //      Shell.Current.GoToAsync("examispersonal");
        await Navigation.PushAsync(new Doc.DocTheExamisPersonal.DocTheExamisPersonal(user));
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

    private void AchievementsButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("achievement");
    }

    private void SettingsButtonClicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        NameUser.Text = user.Name_Employee;

    }
}