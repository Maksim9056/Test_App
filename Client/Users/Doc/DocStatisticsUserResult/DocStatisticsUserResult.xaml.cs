using Class_interaction_Users;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using System.Windows.Input;

namespace Client.Users.Doc.DocStatisticsUserResult;

public partial class DocStatisticsUserResult : ContentPage
{

    //private UserExamsEditorViewModel viewModel;
    //private UserExamsManager viewModelManager;
    private Class_interaction_Users.User CurrrentUser;
    //public Class_interaction_Users.Exams vSelectedItem { get; set; }

    private CheckUsers command = new CheckUsers();

    public List<string> Commands = new List<string>();
    CheckStatickUserResult checkStatickUserResult = new CheckStatickUserResult();

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public CommandCL commands = new CommandCL();
    private ExamsTestEditorViewModel viewModels;
    private ExamsTestManager viewModelManagers;
    private Class_interaction_Users.Exams CurrrentExams;
    //   private Class_interaction_Users.User CurrrentUser;
    //   private CheckUsers commandS = new CheckUsers();
    //  public List<string> Commands = new List<string>();


  //  public CommandCL command = new CommandCL();
    //private ExamsTestEditorViewModel viewModel;
    //private ExamsTestManager viewModelManager;
    //private Class_interaction_Users.Exams CurrrentExams;
//    private Class_interaction_Users.User CurrrentUser;
    private CheckUsers commandS = new CheckUsers();
    public List<string> Commandss = new List<string>();
   // private ExamsTestManager viewModelManager;

    public DocStatisticsUserResult(User user)
    {
        InitializeComponent();

        Title = "Статистика экзаменов";

        CurrrentUser = user;
      List<Statictics> Result = GetUserExams(user);
   



        //Changes
        CreateTable(Result);
    }


    public void CreateTable(List<Statictics> statictics)
    {

        //var labelsAll = new List<List<string>>();

        //for (int i = 0; i < statictics.Count; i++)
        //{
        //    labelsAll[i] = new List<string> { statictics[i].Exams.Name_exam, statictics[i].Test.Name_Test, statictics[i].Count.ToString() };
        //}

        var labels = new List<List<string>>();

        var Lab = new List<string> { "Экзамен", "Имя теста", "Оценка" };
        labels.Insert(0, Lab);

        for (int i = 0; i < statictics.Count; i++)
        {
            var tt = new List<string> { statictics[i].Exams.Name_exam, statictics[i].Test.Name_Test, statictics[i].Count.ToString() };

            labels.Insert(i+1,tt);
            //labels[i].Add(statictics[i].Exams.Name_exam);
            //labels[i].Add(statictics[i].Test.Name_Test);
            //labels[i].Add(statictics[i].Count.ToString());
        }

        //var labels = new List<List<string>>
        //{
        //     new List<string> { "Имя", "Возраст", "Пол" },
        //     new List<string> { "Максим", "25", "Мужской" },
        //     new List<string> { "Полина", "30", "Женский" },
        //     new List<string> { "Полина3", "30", "Женский" },
        //     new List<string> { "Даниил", "22", "Мужской" },
        //     new List<string> { "Даниил2", "22", "Мужской" }
        //};


        var numRows = labels.Count;
        var numCols = labels[0].Count;

        for (int i = 0; i < numRows; i++)
        {
            RowDefinition row = new RowDefinition();
            row.Height = GridLength.Auto;
            DataTable.RowDefinitions.Add(row);

            for (int j = 0; j < numCols; j++)
            {
                var label = new Label
                {
                    Text = labels[i][j],
                    TextColor = i == 0 ? Colors.White : Colors.Black,
                    BackgroundColor = i == 0 ? Colors.Gray : Colors.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(6)
                };

                DataTable.Add(label, j, i);
            }
        }





        // List<Statictics> statictics
        //DataTable.Add(nameLabel, 0, 0);
        //DataTable.Add(ageLabel, 1, 0);
        //DataTable.Add(genderLabel, 2, 0);
        //var labels = new string[statictics.Count(), statictics.Count()];

        //int k = 0;
        //int j1 = 1;
        //int j2 = 2;
        //for(int i = 0; i < statictics.Count; i++)
        //{

        //        labels[i, k] = statictics[i].Exams.Name_exam;
        //        labels[j1, k] = statictics[i].Test.Name_Test;
        //      labels[j2, k] = statictics[i].Count.ToString();

        //    k++;
        //}


        //var labelss = new string[,]
        //{
        //  { "Имя", "Возраст", "Пол" },
        //  { "Максим", "25", "Мужской" },
        //  { "Полина", "30", "Женский" },
        //  { "Полина3", "30", "Женский" },
        //  { "Даниил", "22", "Мужской" },
        //  { "Даниил2", "22", "Мужской" }
        //};


        ////Grid grid = new Grid();

        //var numRows = labels.GetLength(0);
        //var numCols = labels.GetLength(1);

        //for (int i = 0; i < numRows; i++)
        //{
        //    RowDefinition row = new RowDefinition();
        //    row.Height = GridLength.Auto;
        //    DataTable.RowDefinitions.Add(row);
        //    for (int j = 0; j < numCols; j++)
        //    {
        //        var label = new Label
        //        {
        //            Text = labels[i, j],
        //            TextColor = i == 0 ? Colors.White : Colors.Black,
        //            BackgroundColor = i == 0 ? Colors.Gray : Colors.White,
        //            HorizontalOptions = LayoutOptions.FillAndExpand,
        //            Padding = new Thickness(6)
        //        };
        //        DataTable.Add(label, j, i);
        //    }
        //}

        var frame = new Frame
        {
            Content = DataTable,
            BorderColor = Colors.Black,
            BackgroundColor = Colors.Transparent,
            HasShadow = false
        };

        //var nameLabel = new Label
        //{
        //    Text = "Имя",
        //    TextColor = Colors.White,
        //    BackgroundColor = Colors.Gray,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var ageLabel = new Label
        //{
        //    Text = "Возраст",
        //    TextColor = Colors.White,
        //    BackgroundColor = Colors.Gray,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var genderLabel = new Label
        //{
        //    Text = "Пол",
        //    TextColor = Colors.White,
        //    BackgroundColor = Colors.Gray,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var johnNameLabel = new Label
        //{
        //    Text = "John",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var johnAgeLabel = new Label
        //{
        //    Text = "25",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var johnGenderLabel = new Label
        //{
        //    Text = "Male",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var janeNameLabel = new Label
        //{
        //    Text = "Jane",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var janeAgeLabel = new Label
        //{
        //    Text = "30",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};
        //var janeGenderLabel = new Label
        //{
        //    Text = "Female",
        //    TextColor = Colors.Black,
        //    BackgroundColor = Colors.White,
        //    HorizontalOptions = LayoutOptions.FillAndExpand,
        //    Padding = new Thickness(6)
        //};

        ////var dataTable = new Grid();
        //DataTable.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        //DataTable.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        //DataTable.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        //DataTable.Add(nameLabel, 0, 0);
        //DataTable.Add(ageLabel, 1, 0);
        //DataTable.Add(genderLabel, 2, 0);
        //DataTable.Add(johnNameLabel, 0, 1);
        //DataTable.Add(johnAgeLabel, 1, 1);
        //DataTable.Add(johnGenderLabel, 2, 1);
        //DataTable.Add(janeNameLabel, 0, 2);
        //DataTable.Add(janeAgeLabel, 1, 2);
        //DataTable.Add(janeGenderLabel, 2, 2);

        //var frame = new Frame
        //{
        //    Content = DataTable,
        //    BorderColor = Colors.Black,
        //    BackgroundColor = Colors.Transparent,
        //    HasShadow = false
        //};

        //// Заголовки столбцов
        //var nameLabel = new Label { Text = "Name", HorizontalOptions = LayoutOptions.Center };
        //var ageLabel = new Label { Text = "Age", HorizontalOptions = LayoutOptions.Center };
        //var genderLabel = new Label { Text = "Gender", HorizontalOptions = LayoutOptions.Center };

        //DataTable.Add(nameLabel, 0, 0);
        //DataTable.Add(ageLabel, 1, 0);
        //DataTable.Add(genderLabel, 2, 0);

        //// Данные таблицы
        //var johnNameLabel = new Label { Text = "John", HorizontalOptions = LayoutOptions.Center };
        //var johnAgeLabel = new Label { Text = "25", HorizontalOptions = LayoutOptions.Center };
        //var johnGenderLabel = new Label { Text = "Male", HorizontalOptions = LayoutOptions.Center };

        //DataTable.Add(johnNameLabel, 0, 1);
        //DataTable.Add(johnAgeLabel, 1, 1);
        //DataTable.Add(johnGenderLabel, 2, 1);

        //var janeNameLabel = new Label { Text = "Jane", HorizontalOptions = LayoutOptions.Center };
        //var janeAgeLabel = new Label { Text = "30", HorizontalOptions = LayoutOptions.Center };
        //var janeGenderLabel = new Label { Text = "Female", HorizontalOptions = LayoutOptions.Center };

        //DataTable.Add(janeNameLabel, 0, 2);
        //DataTable.Add(janeAgeLabel, 1, 2);
        //DataTable.Add(janeGenderLabel, 2, 2);
    }
    private async void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        await Shell.Current.Navigation.PopAsync();
    }

    private List<Statictics> GetUserExams(Class_interaction_Users.User user)
    {

   
     var Result =    checkStatickUserResult.CheckStatickUserResults(user);
    
        return Result;

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

    public class RefUserExams
    {
        public Class_interaction_Users.UserExams UserExams { get; set; }
        public string EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }
}