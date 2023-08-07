namespace Client.Users.Doc.DocTheExamisPersonal;

public partial class DocTheExamisPersonal : ContentPage
{
	public DocTheExamisPersonal()
	{
		InitializeComponent();
	}

    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
       // Shell.Current.GoToAsync("logout");
    }

    private void TestList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    //private  void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    if (e.SelectedItem == null)
    //        return;
    //    Shell.Current.GoToAsync("examfromtests");
    ////    var selectedExamsTest = (RefExamsTest)e.SelectedItem;
    //// await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
    ////  ((ListView)sender).SelectedItem = null;
    //}

}