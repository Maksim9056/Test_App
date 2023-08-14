using Class_interaction_Users;

namespace Client.Users.Doc.DocTheExamisPersonal;

public partial class DocTheExamisPersonal : ContentPage
{

    private UserExamsEditorViewModel viewModel;
    private UserExamsManager viewModelManager;
    private Class_interaction_Users.User CurrrentUser;
    public Class_interaction_Users.Exams vSelectedItem { get; set; }
    public DocTheExamisPersonal(Class_interaction_Users.User user)
	{
		InitializeComponent();
           viewModel = new UserExamsEditorViewModel();
        viewModelManager = new UserExamsManager();
       CurrrentUser = user;
    
        myListView.ItemsSource = GetUserExams(user);

#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTheExamisPersonal>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here  
            // For example, update the fields, refresh data, etc.  
            myListView.ItemsSource = GetUserExams(user);
        });
#pragma warning restore CS0618 // Тип или член устарел
                              //  ExamsList.ItemsSource = GetUserExams(user);
                              //    Title = "Экзамены для пользователя: " + user.Name_Employee;

#pragma warning disable CS0618 // Тип или член устарел
        //MessagingCenter.Subscribe<DocTheExamisPersonal>(this, "UpdateForm", (sender) =>
        //{
        //    // Perform the necessary updates to the form here  
        //    // For example, update the fields, refresh data, etc.  
        //    myListView.ItemsSource = GetUserExams(user);
        //});
    }


    private List<RefUserExams> GetUserExams(Class_interaction_Users.User user)
    {
        List<RefUserExams> testUserExamsList = new List<RefUserExams>();

        CommandCL.UserExamsListGet = null;
        viewModelManager.GetUserExamsList(user);

        if (CommandCL.UserExamsListGet == null)
        {
            // Handle the case when the test list is null  
        }
        else
        {
            for (int i = 0; i < CommandCL.UserExamsListGet.ListUserExams.Count; i++)
            {
                var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i]};
                testUserExamsList.Add(refUserExams);
            }
        }
        return testUserExamsList;
    }


    public class RefUserExams
    {
        public Class_interaction_Users.UserExams UserExams { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }


    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
       // Shell.Current.GoToAsync("logout");
    }


    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //if (e.SelectedItem == null)
        //    return;
       if (e.SelectedItem == null)
            return;

        var selectedTest = (RefUserExams)e.SelectedItem;
        await DisplayAlert("Выбранный экзамен", selectedTest.UserExams.Exams.Name_exam, "OK");
        ((ListView)sender).SelectedItem = null;
        await Navigation.PushAsync(new Doc.DocTestsFromQuestions.DocTestsFromQuestions(selectedTest.UserExams.Exams, CurrrentUser));
        // vSelectedItem = selectedTest.Exams;




        // Закройте форму RefQuestionsListPage
        // Исключается для выбора ответа
#pragma warning disable CS4014 // Так как 


        //if (e.SelectedItem == null)
        //    return;

        //var selectedUserExams = (RefUserExams)e.SelectedItem;
        //await DisplayAlert("Выбранный экзамен", selectedUserExams.UserExams.Exams.Name_exam, "OK");
        //((ListView)sender).SelectedItem = null;

    }

    public class RefExams
    {
        public Class_interaction_Users.Exams Exams { get; set; }
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