using Class_interaction_Users;
using static System.Net.Mime.MediaTypeNames;

namespace Client.Users.Doc.DocAnswerQuestins;

public partial class DocAnswerQuestins : ContentPage
{
    public CommandCL command = new CommandCL();
    private QuestionAnswerEditorViewModel viewModel;
    private QuestionAnswerManager viewModelManager;
    private Class_interaction_Users.Questions CurrrentQuestions;
       Doc.DocTestQuestionsTheAnswersMark.DocTestQuestionsTheAnswersMark docTestQuestionsTheAnswersMark;
    private Class_interaction_Users.Test CurrrentTest;

    private Class_interaction_Users.Exams Exams;
    public DocAnswerQuestins(Class_interaction_Users.Questions questions, Class_interaction_Users.Test test, Class_interaction_Users.Exams exams)
	{
		InitializeComponent();

        viewModel = new QuestionAnswerEditorViewModel();
        viewModelManager = new QuestionAnswerManager();
        CurrrentQuestions = questions;
        CurrrentTest = test;
        Exams = exams;
        QuestionList.ItemsSource = GetQuestionAnswer(questions);

#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocAnswerQuestins>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here 
            // For example, update the fields, refresh data, etc. 
            QuestionList.ItemsSource = GetQuestionAnswer(questions);
        });
#pragma warning restore CS0618 // Тип или член устарел

    }

    private List<RefQuestionAnswer> GetQuestionAnswer(Class_interaction_Users.Questions questions)
    {
        List<RefQuestionAnswer> testQuestionList = new List<RefQuestionAnswer>();

        CommandCL.QuestionAnswerListGet = null;
        viewModelManager.GetQuestionAnswerList(questions);

        if (CommandCL.QuestionAnswerListGet == null)
        {
            // Handle the case when the test list is null 
        }
        else
        {
            for (int i = 0; i < CommandCL.QuestionAnswerListGet.ListQuestionAnswer.Count; i++)
            {
                var refQuestionAnswer = new RefQuestionAnswer { QuestionAnswer = CommandCL.QuestionAnswerListGet.ListQuestionAnswer[i] };
                testQuestionList.Add(refQuestionAnswer);
            }
        }

        return testQuestionList;
    }



    //private void Edit(object testQuestion)
    //{
    //    var selectedTestQuestion = (RefQuestionAnswer)testQuestion;
    //    Navigation.PushAsync(new QuestionsEditor(selectedTestQuestion.QuestionAnswer.Questions));
    //}

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedTestQuestion = (RefQuestionAnswer)e.SelectedItem;
    //    await DisplayAlert("Выбранный ответ", selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions, "OK");

            await DisplayAlert("Выбранный ответ", selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions, "OK");

        // docTestQuestionsTheAnswersMark.Update();
        // var navigationPage = new NavigationPage(docTestQuestionsTheAnswersMark );
        ((ListView)sender).SelectedItem = null;

        //  Exams
        //  selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions
        docTestQuestionsTheAnswersMark = new Doc.DocTestQuestionsTheAnswersMark.DocTestQuestionsTheAnswersMark(CurrrentTest, CurrrentQuestions,Exams);
       // await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins( ));
    }

    public class RefQuestionAnswer
    {
        public Class_interaction_Users.QuestionAnswer QuestionAnswer { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }

    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
    }
}