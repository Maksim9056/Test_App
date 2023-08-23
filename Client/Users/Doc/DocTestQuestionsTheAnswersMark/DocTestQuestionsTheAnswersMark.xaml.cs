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
    public Class_interaction_Users.Questions [] Questionsss   { get; set; }

    public List<Class_interaction_Users.Questions> questions1 { get; set; } 
    Галочка[] Ставить;
    List<RefTestQuestion> testQuestionListS = new List<RefTestQuestion>();

    public DocTestQuestionsTheAnswersMark(Class_interaction_Users.Test refTestQuestions, Class_interaction_Users.Questions questions, Class_interaction_Users.Exams exams, Class_interaction_Users.User user, List<Class_interaction_Users.Questions> questions1s)
    {

        InitializeComponent(); 
        
        
        if (questions1 == null)
        {
            questions1 = new List<Questions>();
            questions1 = questions1s;
        }
        //int Locat ;
        viewModel = new TestQuestionEditorViewModel();
        viewModelManager = new TestQuestionManager();
        //CurrrentTest = refTestQuestions;
        Test = refTestQuestions;
        Title = Test.Name_Test;
        Questions = questions;
        //  bool fALSE = false;

        //      questions1
        //if (questions1.SequenceEqual(questions1s))
        //{

        //} // Проверка совпадения с использованием SequenceEqual()

        //bool areEqualы = questions1.Equals(questions2);

        //// Проверка совпадения с использованием Equals()
        //if (!questions1.Any(q => q == questions1s))
        //{
        //    questions1.Add(questions);
        //}
      

        if (!questions1.Any(q => q.QuestionName == questions.QuestionName))
        {
            questions1.Add(questions);
        }

        //if (questions1 == null)
        //{        
        // questions1.Add(questions);
        //}
        //else
        //{
        //    for(int i = 0; i < questions1.Count(); i++) 
        //    {
        //        if (questions1[i] == questions)
        //        {
        //            fALSE = true;
        //        }
        //        else
        //        {
             
        //        }
            
        //    }

        //    if(fALSE == false)
        //    {
        //        questions1.Add (questions);
        //    }


        //}
      //  Class_interaction_Users.Questions[] Questionss = new Questions[questions1.Count()];

      //bool add = false;
      //  for (int i = 0;i < questions1.Count(); i++)
      //  {
      //      if (questions1[i] == Questionss[i])
      //      {
      //          add= true;
      //      }
      //      else
      //      {

      //      }
      //  }

      //  if(add == false)
      //  {
      //      for (int i = 0; i < questions1.Count(); i++)
      //      {
      //          Questionss[i] = questions1[i];
      //      }

      //  }
      //  if(Questionsss == null)
      //  {
      //   Questionsss = Questionss;

      //  }
      //  else
      //  {
      //      for (int i = 0; i < Questionsss.Length; i++)
      //      {
      //          if (Questionsss[i] == Questionss[i])
      //          {
      //              add = true;
      //          }
      //          else
      //          {
                  
      //          }
      //      }
        
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
 
        if (!questions1.Any(q => q.QuestionName == selectedTestQuestion.TestQuestion.IdQuestions.QuestionName))
        {     
            await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
            await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, Test, Exams,CurrrentUser, questions1));

        }
        else
        {
            await DisplayAlert("Вы уже ответили на вопрос !", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
        }

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
        {                  //  questions1.Add(questions);

            for (int i = 0; i < CommandCL.TestQuestionListGet.ListTestQuestion.Count; i++)
            {

                if (!questions1.Any(q => q.QuestionName == CommandCL.TestQuestionListGet.ListTestQuestion[i].IdQuestions.QuestionName))
                {
                    var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i], EditCommand = "" };
                    testQuestionList.Add(refTestQuestion);
                    testQuestionListS.Add(refTestQuestion);
                }
                else
                {
                   
                    var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i], EditCommand = " ✔" };
                    testQuestionList.Add(refTestQuestion);
                    testQuestionListS.Add(refTestQuestion);
                }

                //if (CommandCL.TestQuestionListGet.ListTestQuestion[i].IdQuestions.QuestionName == questions.QuestionName)
                //{
                 
                
                //}
                //else
                //{
             
         
                //}
      
            
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

        if(testQuestionListS.Count() == questions1.Count())
        {
            DisplayAlert("Сохранен тест", "Завершен тест !", "Oк");

            Navigation.PushAsync(new Doc.DocPersonalCabinet.DocPersonalCabinet(CurrrentUser, Test, Exams));
        }
        else
        {
            DisplayAlert("Тест не завершен!", "Ответили не на все вопросы !", "Oк");
        }
        
    }
}