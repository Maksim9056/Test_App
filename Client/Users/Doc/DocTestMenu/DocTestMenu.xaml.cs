using Class_interaction_Users;

namespace Client.Users.Doc.DocTestMenu;

public partial class DocTestMenu : ContentPage
{
    public CommandCL command = new CommandCL();
    private TestQuestionEditorViewModel viewModel;
    private TestQuestionManager viewModelManager;
    private Class_interaction_Users.Test CurrrentTest;

    private Class_interaction_Users.Exams Exams;
    public  List<RefTestQuestion> refTestQuestions = new List<RefTestQuestion>();
    private Class_interaction_Users.User CurrrentUser;
    public DocTestMenu(Class_interaction_Users.Exams exams ,Class_interaction_Users.Test test, Class_interaction_Users.User currrentUser)
	{
		InitializeComponent();
        viewModel = new TestQuestionEditorViewModel();
        viewModelManager = new TestQuestionManager();
        TestName.Text = test.Name_Test;
        CurrrentTest = test;
        Exams =exams;
        CurrrentUser = currrentUser;
       var Result =   GetTestQuestions(test);
        refTestQuestions = Result;
       Question.Text = "Количество вопросов :" +  Result.Count().ToString();
    

    }

    private List<RefTestQuestion> GetTestQuestions(Class_interaction_Users.Test test)
    {
        List<RefTestQuestion> testQuestionList = new List<RefTestQuestion>();

        CommandCL.ExamsListGet = null;
        viewModelManager.GetTestQuestionList(test);

        if (CommandCL.TestQuestionListGet == null)
        {
            // Handle the case when the test list is null
        }
        else
        {
            for (int i = 0; i < CommandCL.TestQuestionListGet.ListTestQuestion.Count; i++)
            {
                var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i]};
                testQuestionList.Add(refTestQuestion);
            }
        }

        return testQuestionList;
    }

    public class RefTestQuestion
    {
        public Class_interaction_Users.TestQuestion TestQuestion { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }


    private async void TestStart_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Doc.DocTestQuestionsTheAnswers.DocTestQuestionsTheAnswers(CurrrentTest, Exams,CurrrentUser));
     
    }
}