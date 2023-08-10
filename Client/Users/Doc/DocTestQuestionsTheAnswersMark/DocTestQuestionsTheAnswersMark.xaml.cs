using Class_interaction_Users;

namespace Client.Users.Doc.DocTestQuestionsTheAnswersMark;

public partial class DocTestQuestionsTheAnswersMark : ContentPage
{
    private List<DocTestMenu.DocTestMenu.RefTestQuestion> refTestQuestions;

    public CommandCL command = new CommandCL();
    private TestQuestionEditorViewModel viewModel;
    private TestQuestionManager viewModelManager;
    private Class_interaction_Users.Test CurrrentTest;

    public Class_interaction_Users.Test Test { get; set; }
    public DocTestQuestionsTheAnswersMark()
	{
		InitializeComponent();
        viewModel = new TestQuestionEditorViewModel();
        viewModelManager = new TestQuestionManager();
        //CurrrentTest = refTestQuestions;
        TestList.ItemsSource = GetTestQuestions(Test);
        TestName.Text = Test.Name_Test;
#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTestQuestionsTheAnswersMark>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here
            // For example, update the fields, refresh data, etc.
            TestList.ItemsSource = GetTestQuestions(Test);
        });
#pragma warning restore CS0618 // Тип или член устарел
    }


    public void Update(Class_interaction_Users.Test refTestQuestions)
    {
        Test = refTestQuestions;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedTestQuestion = (RefTestQuestion)e.SelectedItem;
        await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
        await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, Test));

        // var selectedTestQuestion = (RefQuestionAnswer)e.SelectedItem;
        //await DisplayAlert("Выбранный ответ", selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions, "OK");
        ((ListView)sender).SelectedItem = null;

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
                var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i] };
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


    public class RefQuestionAnswer
    {
        public Class_interaction_Users.QuestionAnswer QuestionAnswer { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }
}