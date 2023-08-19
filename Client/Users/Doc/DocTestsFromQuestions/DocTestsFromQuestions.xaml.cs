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
    private CheckUsers commandS = new CheckUsers();
    public List<string> Commands = new List<string>();

    public DocTestsFromQuestions(Class_interaction_Users.Exams exams, Class_interaction_Users.User currrentUser)
    {
        //Проверить тест для экзамена который сдан 
        InitializeComponent();
        viewModel = new ExamsTestEditorViewModel();
        viewModelManager = new ExamsTestManager();
        CurrrentExams = exams;
        CurrrentUser = currrentUser;
        TestList.ItemsSource = GetExamsTest(exams, currrentUser);
        Title = "Тесты для экзамена: " + exams.Name_exam;

#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTestsFromQuestions>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here   
            // For example, update the fields, refresh data, etc.   
            TestList.ItemsSource = GetExamsTest(exams, currrentUser);
        });
#pragma warning restore CS0618 // Тип или член устарел

    }


    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        //Сделать проверку что тест уже пройден или нет

        //     Commands 
        //await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, Test, Exams, CurrrentUser, questions1));
        // await Navigation.PushAsync(new Doc.DocTestsFromQuestions.DocTestsFromQuestions(selectedTest.UserExams.Exams, CurrrentUser));
       //await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");

        if (!Commands.Any(q => q == selectedExamsTest.ExamsTest.Test.Name_Test))
        {
            await DisplayAlert("Выбранный экзамен", selectedExamsTest.ExamsTest.Test.Name_Test, "OK");
           
            await Navigation.PushAsync(new Doc.DocTestMenu.DocTestMenu(CurrrentExams, selectedExamsTest.ExamsTest.Test, CurrrentUser));

        }
        else
        {
            await DisplayAlert("Вы уже cдали Тест!", selectedExamsTest.ExamsTest.Test.Name_Test, "OK");
        }

      //  await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Test.Name_Test, "OK");

     //   await Navigation.PushAsync(new Doc.DocTestMenu.DocTestMenu(CurrrentExams ,selectedExamsTest.ExamsTest.Test,CurrrentUser));
               ((ListView)sender).SelectedItem = null;

    }

    private List<RefExamsTest> GetExamsTest(Class_interaction_Users.Exams exams, Class_interaction_Users.User currrentUser)  
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

            Exams_Check[] exams_Check = new Exams_Check[CommandCL.UserExamsListGet.ListUserExams.Count()];
            // Здесь вызвать  функцию что пришло 
            for (int i = 0; i < CommandCL.ExamsTestListGet.ListExamsTest.Count(); i++)
            {

                ExamsTest userExams = CommandCL.ExamsTestListGet.ListExamsTest[i];
                CheckUserTest checkUserTest = new CheckUserTest(userExams , currrentUser);
               //     userExams.
                exams_Check[i] = commandS.Check(checkUserTest);
                //Запоминает проверку 
            }



                for (int i = 0; i < CommandCL.ExamsTestListGet.ListExamsTest.Count; i++)
                {




                if (CommandCL.UserExamsListGet.ListUserExams[i].Exams.Id == exams_Check[i].save_Results[i].Exam_id.Id)
                {

                   var refExamsTest = new RefExamsTest { ExamsTest = CommandCL.ExamsTestListGet.ListExamsTest[i], EditCommand = " ✔" };
                    testExamsTestList.Add(refExamsTest);
                    Commands.Add(CommandCL.ExamsTestListGet.ListExamsTest[i].Test.Name_Test);
                }
                else
                {
                 
                
                    var refExamsTest = new RefExamsTest { ExamsTest = CommandCL.ExamsTestListGet.ListExamsTest[i], EditCommand = "" };
                    testExamsTestList.Add(refExamsTest);
                }

                //var refExamsTest = new RefExamsTest { ExamsTest = CommandCL.ExamsTestListGet.ListExamsTest[i] ,EditCommand = ""};
                //    testExamsTestList.Add(refExamsTest);
                
            
            
                }
            }
            return testExamsTestList;
    }

    public class RefExamsTest
    {
        public Class_interaction_Users.ExamsTest ExamsTest { get; set; }
        public string EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }

    public class RefTest
    {
        public Class_interaction_Users.Test Test { get; set; }
        public string EditCommand { get; set; }
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
