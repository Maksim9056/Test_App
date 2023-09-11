using Class_interaction_Users;
using Client.Controls;
using System.Windows.Input;

namespace Client.Users.Doc.DocPersonalAchievement;

public partial class DocPersonalAchievement : ContentPage
{
    CheckStatickUserResult checkStatickUserResult = new CheckStatickUserResult();
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public DocPersonalAchievement(User user)
	{
		InitializeComponent();
        Title = "Достижения";

        List<Statictics> Result = GetUserExams(user);


        var chartEntries = new ChartEntry[Result.Count()];

        for(int i = 0; i < Result.Count(); i++)
        {

      

                chartEntries[i] = new ChartEntry
                {
                    Text = Result[i].Exams.Name_exam,
                    Value = Result[i].Count,
                    Color = Color.FromArgb("#6023FF"),

                };
            

        }
        BindingContext = chartEntries;
        //BindingContext = new ChartEntry[]
        //  {
        //    new ChartEntry
        //    {
        //        //Value = Test.Options_Id,
        //        Color = Color.FromArgb("#6023FF"),
        //        Text =
        //    },
        //    new ChartEntry
        //    {
        //     //   Value = 33,
        //        Color = Color.FromArgb("#3059FE"),
        //        Text = "Visual Studio"
        //    },
        //    new ChartEntry
        //    {
        //      //  Value = 29,
        //        Color = Color.FromArgb("#2EF1D2"),
        //        Text = "Notepad++"
        //    },
        //    new ChartEntry
        //    {
        //     //   Value = 28,
        //        Color = Color.FromArgb("#F8426E"),
        //        Text = "IntelliJ"
        //    }
        //};

    }
    private List<Statictics> GetUserExams(Class_interaction_Users.User user)
    {
        var Result = checkStatickUserResult.CheckStatickUserResults(user);
        return Result;
    }
    private async void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        await Shell.Current.Navigation.PopAsync();
    }
}