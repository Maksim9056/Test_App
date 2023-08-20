using Class_interaction_Users;

namespace Client.Users.Doc.DocTheExamisPersonal;

public partial class DocTheExamisPersonal : ContentPage
{

    private UserExamsEditorViewModel viewModel;
    private UserExamsManager viewModelManager;
    private Class_interaction_Users.User CurrrentUser;
    public Class_interaction_Users.Exams vSelectedItem { get; set; }

    private CheckUsers command = new CheckUsers();

    public List<string> Commands = new List<string>();  
    public DocTheExamisPersonal(Class_interaction_Users.User user)
	{
        //Запросить все тесты из экзамена и посматреть какой пользователь прошел
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
             Exams_Check [] exams_Check = new Exams_Check[CommandCL.UserExamsListGet.ListUserExams.Count()] ;
            // Здесь вызвать  функцию что пришло 
            for (int i = 0; i < CommandCL.UserExamsListGet.ListUserExams.Count(); i++)
            {

                var userExams = CommandCL.UserExamsListGet.ListUserExams[i];

                exams_Check[i] = command.CheckExams(userExams);
                //Запоминает проверку 
            }
        
            //Здесь 
            for (int i = 0; i < CommandCL.UserExamsListGet.ListUserExams.Count(); i++)
            {

                if (exams_Check[i].save_Results.Count() == 0)
                {

                    var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = " " };
                    testUserExamsList.Add(refUserExams);
                }
                else
                {
                    if (CommandCL.UserExamsListGet.ListUserExams[i].Exams.Id == exams_Check[i].save_Results[i].Exam_id.Id)
                    {

                        var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = "✔" };
                        testUserExamsList.Add(refUserExams);
                        Commands.Add(refUserExams.UserExams.Exams.Name_exam);



                    }
                    else
                    {
                        var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = " " };
                        testUserExamsList.Add(refUserExams);
                    }
                }
                //Здесь exams_Check[i].save_Results[i].Exam_id.Id 2 значения нету
            
            }
                //exams_Check[i]

            //    var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = " " }; 
               // //if (CommandCL.TestQuestionListGet.ListTestQuestion[i].IdTest.QuestionName == questions.QuestionName)
               // //{
               // //      var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i], EditCommand = " ✔" };
               // //    testQuestionList.Add(refTestQuestion);
               // var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = " ✔" };
               //     testUserExamsList.Add(refUserExams);

               // }
               // else
               // {
               //     var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = "" };

               //  //   var refTestQuestion = new RefTestQuestion { TestQuestion = CommandCL.TestQuestionListGet.ListTestQuestion[i], EditCommand = "" };
               ////     testQuestionList.Add(refTestQuestion);
               //     testUserExamsList.Add(refUserExams);

               // }
            //   testUserExamsList.Add(refUserExams);
     
        }
        return testUserExamsList;
    }


    public class RefUserExams
    {
        public Class_interaction_Users.UserExams UserExams { get; set; }
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


    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //if (e.SelectedItem == null)
        //    return;
       if (e.SelectedItem == null)
            return;

       
       //Сдесь проверку то что екзамен  и все тесты сданы 

        var selectedTest = (RefUserExams)e.SelectedItem;

   

        ((ListView)sender).SelectedItem = null;
       

            if (!Commands.Any(q => q  == selectedTest.UserExams.Exams.Name_exam))
            {
                //await DisplayAlert("Выбранный вопрос", selectedTestQuestion.TestQuestion.IdQuestions.QuestionName, "OK");
                await DisplayAlert("Выбранный экзамен", selectedTest.UserExams.Exams.Name_exam, "OK");
                //await Navigation.PushAsync(new Doc.DocAnswerQuestins.DocAnswerQuestins(selectedTestQuestion.TestQuestion.IdQuestions, Test, Exams, CurrrentUser, questions1));
                await Navigation.PushAsync(new Doc.DocTestsFromQuestions.DocTestsFromQuestions(selectedTest.UserExams.Exams, CurrrentUser));


            }
            else
            {
                await DisplayAlert("Вы  cдали экзамен  !", selectedTest.UserExams.Exams.Name_exam, "OK");
            }
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