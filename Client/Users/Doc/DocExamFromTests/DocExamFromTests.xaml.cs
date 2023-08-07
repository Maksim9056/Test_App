namespace Client.Users.Doc.DocExamFromTests;

public partial class DocExamFromTests : ContentPage
{
	public DocExamFromTests()
	{
		InitializeComponent();
	}
    private  void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        //var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        //await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
        //((ListView)sender).SelectedItem = null;
    }

    private void ExamButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("examispersonal");
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


}