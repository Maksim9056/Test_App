using Class_interaction_Users;

namespace Client.Users.Doc.DocTestQuestionsTheAnswersMark;

public partial class DocTestQuestionsTheAnswersMark : ContentPage
{
    private List<DocTestMenu.DocTestMenu.RefTestQuestion> refTestQuestions;

    public CommandCL command = new CommandCL();
    private TestQuestionEditorViewModel viewModel;
    private TestQuestionManager viewModelManager;
    private Class_interaction_Users.Test CurrrentTest;
    public Class_interaction_Users.Questions Questions { get; set; }
    public Class_interaction_Users.Test Test { get; set; }
    private Class_interaction_Users.Exams Exams;
    private Class_interaction_Users.User CurrrentUser;
   // List <string> Галочка = new List<string>();
    List<RefTestQuestion> refTestQuestions1 = new List<RefTestQuestion>();
    Class_interaction_Users.TestQuestion[] testQuestions { get; set; }
    static Dictionary<int,string>keyValuePairs = new Dictionary<int,string>();


    Галочка[] Ставить;

    public DocTestQuestionsTheAnswersMark(Class_interaction_Users.Test refTestQuestions, Class_interaction_Users.Questions questions, Class_interaction_Users.Exams exams, Class_interaction_Users.User user)
    {

        InitializeComponent();
        //int Locat ;
        viewModel = new TestQuestionEditorViewModel();
        viewModelManager = new TestQuestionManager();
        //CurrrentTest = refTestQuestions;
        Test = refTestQuestions;
        Title = Test.Name_Test;
           Questions = questions;
     

        //Галочка.Add("v");
        TestList.ItemsSource = GetTestQuestions(Test, questions); 
        Ставить = new Галочка[refTestQuestions1.Count()];
 
      //  TestName.Text = Test.Name_Test;
        CurrrentUser = user;
        Exams = exams;
      //  Names. = keyValuePairs;

#pragma warning disable CS0618 // Тип или член устарел
        MessagingCenter.Subscribe<DocTestQuestionsTheAnswersMark>(this, "UpdateForm", (sender) =>
        {
            // Perform the necessary updates to the form here
            // For example, update the fields, refresh data, etc.
            TestList.ItemsSource = GetTestQuestions(Test,questions);
        });
#pragma warning restore CS0618 // Тип или член устарел
    }


    //public void Update()
    //{
    //    Test = refTestQuestions;
    //    Questions = questions;
    //}

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;
        //Сдесь проверку  на выбраный вопрос ввиде списка массивов и выяснить

        var selectedTestQuestion = (RefTestQuestion)e.SelectedItem;
        await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
        await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, Test, Exams,CurrrentUser));

        // var selectedTestQuestion = (RefQuestionAnswer)e.SelectedItem;
        //await DisplayAlert("Выбранный ответ", selectedTestQuestion.QuestionAnswer.Answer.AnswerOptions, "OK");
        ((ListView)sender).SelectedItem = null;

    }

    private List<RefTestQuestion> GetTestQuestions(Class_interaction_Users.Test test, Class_interaction_Users.Questions questions)
    {
        List<RefTestQuestion> testQuestionList = new List<RefTestQuestion>();

        CommandCL.ExamsListGet = null;
        viewModelManager.GetTestQuestionList(test);

        //for (int i = 0; i < refTestQuestions1.Count(); i++)
        //{
          

        //}

        if (CommandCL.TestQuestionListGet == null)
        {
            // Handle the case when the test list is null
        }
        else
        {
            for (int i = 0; i < CommandCL.TestQuestionListGet.ListTestQuestion.Count; i++)
            {

                if (CommandCL.TestQuestionListGet.ListTestQuestion[i].IdQuestions.QuestionName == questions.QuestionName)
                {
                    var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i] , EditCommand = " ✔" };
                    testQuestionList.Add(refTestQuestion);
                
                }
                else
                {
                    var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i],EditCommand = "" };
                    testQuestionList.Add(refTestQuestion);
         
                }
      
            
            }
        }


        return testQuestionList;
    }

    public class RefTestQuestion
    {
        public Class_interaction_Users.TestQuestion TestQuestion { get; set; }
        public string EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }


    public class RefQuestionAnswer
    {
        public Class_interaction_Users.QuestionAnswer QuestionAnswer { get; set; }
        public string EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }

    private  void TestStart_Clicked(object sender, EventArgs e)
    {
         DisplayAlert("Сохранен тест","Завершен тест !" , "Oк");

        Navigation.PushAsync(new Doc.DocPersonalCabinet.DocPersonalCabinet());
    }
}