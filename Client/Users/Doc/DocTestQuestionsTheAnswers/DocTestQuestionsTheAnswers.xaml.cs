using Class_interaction_Users;
using static System.Net.Mime.MediaTypeNames;

namespace Client.Users.Doc.DocTestQuestionsTheAnswers;

public partial class DocTestQuestionsTheAnswers : ContentPage
{
   // private List<DocTestMenu.DocTestMenu.RefTestQuestion> refTestQuestions;

    public CommandCL command = new CommandCL();
    private TestQuestionEditorViewModel viewModel;
    private TestQuestionManager viewModelManager;
    private Class_interaction_Users.Test CurrrentTest;
    private Class_interaction_Users.Exams Exams;
    private Class_interaction_Users.User CurrrentUser;
    public DocTestQuestionsTheAnswers(Class_interaction_Users.Test refTestQuestions , Class_interaction_Users.Exams exams, Class_interaction_Users.User curentUsers)
	{
       

        InitializeComponent();
        viewModel = new TestQuestionEditorViewModel();
        viewModelManager = new TestQuestionManager();
        CurrrentTest = refTestQuestions;
        Exams = exams;
        CurrrentUser = curentUsers;
        TestList.ItemsSource = GetTestQuestions(refTestQuestions);
        Title = refTestQuestions.Name_Test;

        //TestName.Text = refTestQuestions.Name_Test;
#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTestQuestionsTheAnswers>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here
            // For example, update the fields, refresh data, etc.
            TestList.ItemsSource = GetTestQuestions(refTestQuestions);
        });
#pragma warning restore CS0618 // Тип или член устарел
    }

 
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedTestQuestion = (RefTestQuestion)e.SelectedItem;
    //    await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");

        // var selectedTestQuestion = (RefQuestionAnswer)e.SelectedItem;
        await DisplayAlert("Выбранный ответ", selectedTestQuestion.TestQuestion.IdQuestions.AnswerTrue, "OK");      
        await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, CurrrentTest, Exams,CurrrentUser));

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