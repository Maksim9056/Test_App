using Class_interaction_Users;
using static Client.Project.DocExamTestListPage;

namespace Client.Users.Doc.DocTestsFromQuestions;

public partial class DocTestsFromQuestions : ContentPage
{
    public CommandCL command = new CommandCL();
    private ExamsTestEditorViewModel viewModel;
    private ExamsTestManager viewModelManager;
    private Class_interaction_Users.Exams CurrrentExams;
    public DocTestsFromQuestions(Class_interaction_Users.Exams exams)
    {
        InitializeComponent();
        viewModel = new ExamsTestEditorViewModel();
        viewModelManager = new ExamsTestManager();
        CurrrentExams = exams;
        TestList.ItemsSource = GetExamsTest(exams);
        Title = "Тесты для экзамена: " + exams.Name_exam;

#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTestsFromQuestions>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here   
            // For example, update the fields, refresh data, etc.   
            TestList.ItemsSource = GetExamsTest(exams);
        });
#pragma warning restore CS0618 // Тип или член устарел

    }


    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
        ((ListView)sender).SelectedItem = null;
    }

    private List<RefExamsTest> GetExamsTest(Class_interaction_Users.Exams exams)
        {
            List<RefExamsTest> testExamsTestList = new List<RefExamsTest>();

            CommandCL.ExamsTestListGet = null;
            viewModelManager.GetExamsTestList(exams);

            if (CommandCL.ExamsTestListGet == null)
            {
                // Handle the case when the test list is null   
            }
            else
            {
                for (int i = 0; i < CommandCL.ExamsTestListGet.ListExamsTest.Count; i++)
                {
                    var refExamsTest = new RefExamsTest { ExamsTest = CommandCL.ExamsTestListGet.ListExamsTest[i] };
                    testExamsTestList.Add(refExamsTest);
                }
            }
            return testExamsTestList;
        }
    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        // Shell.Current.GoToAsync("logout");
    }

}
