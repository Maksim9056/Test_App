using Class_interaction_Users;
using static Client.Project.DocExamTestListPage;

namespace Client.Users.Doc.DocTestsFromQuestions;

public partial class DocTestsFromQuestions : ContentPage
{
    public CommandCL command = new CommandCL();
    private ExamsTestEditorViewModel viewModel;
    private ExamsTestManager viewModelManager;
    private Class_interaction_Users.Exams CurrrentExams;
    private Class_interaction_Users.User CurrrentUser;

    public DocTestsFromQuestions(Class_interaction_Users.Exams exams, Class_interaction_Users.User currrentUser)
    {
        InitializeComponent();
        viewModel = new ExamsTestEditorViewModel();
        viewModelManager = new ExamsTestManager();
        CurrrentExams = exams;
        CurrrentUser = currrentUser;
        TestList.ItemsSource = GetExamsTest(exams);
        Title = "����� ��� ��������: " + exams.Name_exam;

#pragma warning disable CS0618 // ��� ��� ���� �������
        MessagingCenter.Subscribe<DocTestsFromQuestions>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here   
            // For example, update the fields, refresh data, etc.   
            TestList.ItemsSource = GetExamsTest(exams);
        });
#pragma warning restore CS0618 // ��� ��� ���� �������

    }


    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        await DisplayAlert("��������� ����", selectedExamsTest.ExamsTest.Test.Name_Test, "OK");

       await Navigation.PushAsync(new Doc.DocTestMenu.DocTestMenu(CurrrentExams ,selectedExamsTest.ExamsTest.Test,CurrrentUser));
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


    public class RefTest
    {
        public Class_interaction_Users.Test Test { get; set; }
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

}
