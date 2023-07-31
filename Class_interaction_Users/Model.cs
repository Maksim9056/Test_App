using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Class_interaction_Users
{

    public class UserEditorViewModel : INotifyPropertyChanged
        {
            public CommandCL command = new CommandCL();

            public ObservableCollection<User> Users { get; set; }

            private int id;
            private string name_Employee;
            private string password;
            private string dataMess;
            private int id_roles_users;
            private string employee_Mail;

            public int Id
            {
                get { return id; }
                set
                {
                    if (id != value)
                    {
                        id = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Name_Employee
            {
                get { return name_Employee; }
                set
                {
                    if (name_Employee != value)
                    {
                        name_Employee = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Password
            {
                get { return password; }
                set
                {
                    if (password != value)
                    {
                        password = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string DataMess
            {
                get { return dataMess; }
                set
                {
                    if (dataMess != value)
                    {
                        dataMess = value;
                        OnPropertyChanged();
                    }
                }
            }

            public int Id_roles_users
            {
                get { return id_roles_users; }
                set
                {
                    if (id_roles_users != value)
                    {
                        id_roles_users = value;
                        OnPropertyChanged();
                    }
                }
            }

            public string Employee_Mail
            {
                get { return employee_Mail; }
                set
                {
                    if (employee_Mail != value)
                    {
                        employee_Mail = value;
                        OnPropertyChanged();
                    }
                }
            }

        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void CreateUserData(User user)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JsonSerializer.Serialize<User>(memoryStream, user);
                    Task.Run(async () => await command.CreateUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "018")).Wait();
                }

            }

        public void UpDateUserData(User user)
        {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // UpDateUser(user);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<User>(memoryStream, user);
                Task.Run(async () => await command.UpdateUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "017")).Wait();
            }
        }

        public void DelUserData(User user)
        {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // DelUser(user);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<User>(memoryStream, user);
                Task.Run(async () => await command.DelUser(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "019")).Wait();
            }
        }


        // Метод для получения списка пользователей
        public List<User> GetUserList()
        {
            List<User> aUserList = new List<User>();

            Task.Run(async () => await command.GetUserList(Ip_adress.Ip_adresss, "", "016")).Wait();

            if (CommandCL.UserListGet == null)
            {
                aUserList = null;
            }
            else
            {
                aUserList = CommandCL.UserListGet.ListUser;
            }
            return aUserList;
        }


    }


    public class TestEditorViewModel : INotifyPropertyChanged
    {
        public CommandCL.TestCommand command = new CommandCL.TestCommand();


        //private Test test;

        private int id;
        private string name_Test;
        private int options_Id;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }


        public string Name_Test
        {
            get { return name_Test; }
            set
            {
                if (name_Test != value)
                {
                    name_Test = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Options_Id
        {
            get { return options_Id; }
            set
            {
                if (options_Id != value)
                {
                    options_Id = value;
                    OnPropertyChanged();
                }
            }
        }

        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CreateTestData(Test Test)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Test>(memoryStream, Test);
                Task.Run(async () => await command.CreateTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "020")).Wait();
            }
        }

        public void UpDateTestData(Test Test)
        {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // UpDateUser(user);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Test>(memoryStream, Test);
                Task.Run(async () => await command.UpdateTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "021")).Wait();
            }
        }

        public void DelTestData(Test Test)
        {
            // Implement the logic to save the user data
            // Example: Call a service or repository method to save the user data
            // DelUser(user);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Test>(memoryStream, Test);
                Task.Run(async () => await command.DelTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "022")).Wait();
            }
        }


        // Метод для получения списка тестов
        public List<Test> GetTestList()
        {
            List<Test> aTestList = new List<Test>();

            Task.Run(async () => await command.GetTestList(Ip_adress.Ip_adresss, "", "023")).Wait();

            if (CommandCL.TestListGet == null)
            {
                aTestList = null;
            }
            else
            {
                aTestList = CommandCL.TestListGet.ListTest;
            }
            return aTestList;
        }


    }

    public class ExamsEditorViewModel : INotifyPropertyChanged
    {
        public CommandCL command = new CommandCL();

        private int id;
        private string name_exam;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name_exam
        {
            get { return name_exam; }
            set
            {
                if (name_exam != value)
                {
                    name_exam = value;
                    OnPropertyChanged();
                }
            }
        }

        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExamManager
    {
        private CommandCL.ExamsCommand command = new CommandCL.ExamsCommand();

        public void CreateExamsData(Exams exams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Exams>(memoryStream, exams);
                Task.Run(async () => await command.CreateExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "024")).Wait();
            }
        }

        public void UpdateExamsData(Exams exams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Exams>(memoryStream, exams);
                Task.Run(async () => await command.UpdateExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "025")).Wait();
            }
        }

        public void DeleteExamsData(Exams exams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Exams>(memoryStream, exams);
                Task.Run(async () => await command.DelExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "026")).Wait();
            }
        }

        public List<Exams> GetExamsList()
        {
            List<Exams> examList = new List<Exams>();

            Task.Run(async () => await command.GetExamsList(Ip_adress.Ip_adresss, "", "027")).Wait();

            if (CommandCL.ExamsListGet == null)
            {
                examList = null;
            }
            else
            {
                examList = CommandCL.ExamsListGet.ListExams;
            }
            return examList;
        }
    }


    public class QuestionsEditorViewModel : INotifyPropertyChanged
    {

        public CommandCL command = new CommandCL();

        private int id;
        private string questionName;
        private string answerTrue;
        private int grade;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string QuestionName
        {
            get { return questionName; }
            set
            {
                if (questionName != value)
                {
                    questionName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AnswerTrue
        {
            get { return answerTrue; }
            set
            {
                if (answerTrue != value)
                {
                    answerTrue = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Grade
        {
            get { return grade; }
            set
            {
                if (grade != value)
                {
                    grade = value;
                    OnPropertyChanged();
                }
            }
        }

        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class QuestionManager
    {
        private CommandCL.QuestionsCommand command = new CommandCL.QuestionsCommand();

        public void CreateQuestionData(Questions question)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Questions>(memoryStream, question);
                Task.Run(async () => await command.CreateQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "028")).Wait();
            }
        }

        public void UpdateQuestionData(Questions question)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Questions>(memoryStream, question);
                Task.Run(async () => await command.UpdateQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "029")).Wait();
            }
        }

        public void DeleteQuestionData(Questions question)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Questions>(memoryStream, question);
                Task.Run(async () => await command.DelQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "030")).Wait();
            }
        }

        public List<Questions> GetQuestionList()
        {
            List<Questions> questionList = new List<Questions>();

            Task.Run(async () => await command.GetQuestionList(Ip_adress.Ip_adresss, "", "031")).Wait();

            if (CommandCL.QuestionsListGet == null)
            {
                questionList = null;
            }
            else
            {
                questionList = CommandCL.QuestionsListGet.QuestionList;
            }
            return questionList;
        }
    }

    public class AnswerEditorViewModel : INotifyPropertyChanged
    {
        private int newId;
        private string newAnswerOptions;
        private bool newCorrectAnswers;
#pragma warning disable CS0169 // Поле "AnswerEditorViewModel.newIdQuestions" никогда не используется.
        private Questions newIdQuestions;
#pragma warning restore CS0169 // Поле "AnswerEditorViewModel.newIdQuestions" никогда не используется.

        public int Id
        {
            get { return newId; }
            set
            {
                if (newId != value)
                {
                    newId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string AnswerOptions
        {
            get { return newAnswerOptions; }
            set
            {
                if (newAnswerOptions != value)
                {
                    newAnswerOptions = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool CorrectAnswers
        {
            get { return newCorrectAnswers; }
            set
            {
                if (newCorrectAnswers != value)
                {
                    newCorrectAnswers = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => propertyChanged += value;
            remove => propertyChanged -= value;
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AnswerManager
    {
        private CommandCL.AnswerCommand command = new CommandCL.AnswerCommand();

        public void CreateAnswerData(Answer answer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Answer>(memoryStream, answer);
                Task.Run(async () => await command.CreateAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "040")).Wait();
            }
        }

        public void UpdateAnswerData(Answer answer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Answer>(memoryStream, answer);
                Task.Run(async () => await command.UpdateAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "041")).Wait();
            }
        }

        public void DeleteAnswerData(Answer answer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Answer>(memoryStream, answer);
                Task.Run(async () => await command.DelAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "042")).Wait();
            }
        }

        public List<Answer> GetAnswerList()
        {
            List<Answer> answerList = new List<Answer>();

            Task.Run(async () => await command.GetAnswerList(Ip_adress.Ip_adresss, "", "043")).Wait();

            if (CommandCL.AnswerListGet == null)
            {
                answerList = null;
            }
            else
            {
                answerList = CommandCL.AnswerListGet.ListAnswer;
            }
            return answerList;
        }
    }

    public class TestQuestionEditorViewModel 
    {
        private int id;
        private Test test;
        private Questions questions;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public Test Test
        {
            get => test;
            set => SetProperty(ref test, value);
        }

        public Questions Questions
        {
            get => questions;
            set => SetProperty(ref questions, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

    public class TestQuestionManager
    {
        private CommandCL.TestQuestionCommand command = new CommandCL.TestQuestionCommand();

        public void CreateTestQuestionData(TestQuestion testQuestion)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<TestQuestion>(memoryStream, testQuestion);
                Task.Run(async () => await command.CreateTestQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "032")).Wait();
            }
        }

        public void UpdateTestQuestionData(TestQuestion testQuestion)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<TestQuestion>(memoryStream, testQuestion);
                Task.Run(async () => await command.UpdateTestQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "033")).Wait();
            }
        }

        public void DeleteTestQuestionData(TestQuestion testQuestion)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<TestQuestion>(memoryStream, testQuestion);
                Task.Run(async () => await command.DelTestQuestion(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "034")).Wait();
            }
        }

        public List<TestQuestion> GetTestQuestionList(Class_interaction_Users.Test test)
        {
            List<TestQuestion> testQuestionList = new List<TestQuestion>();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Test>(memoryStream, test);
                Task.Run(async () => await command.GetTestQuestionList(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "035")).Wait();
            }

            if (CommandCL.TestQuestionListGet == null)
            {
                testQuestionList = null;
            }
            else
            {
                testQuestionList = CommandCL.TestQuestionListGet.ListTestQuestion;
            }
            return testQuestionList;
        }
    }

    public class QuestionAnswerEditorViewModel
    {
        private int id;
        private Test test;
        private QuestionAnswer questionAnswer;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public Test Test
        {
            get => test;
            set => SetProperty(ref test, value);
        }

        public QuestionAnswer QuestionAnswer
        {
            get => questionAnswer;
            set => SetProperty(ref questionAnswer, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class QuestionAnswerManager
    {
        private CommandCL.QuestionAnswerCommand command = new CommandCL.QuestionAnswerCommand();

        public void CreateQuestionAnswerData(QuestionAnswer questionAnswer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<QuestionAnswer>(memoryStream, questionAnswer);
                Task.Run(async () => await command.CreateQuestionAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "036")).Wait();
            }
        }

        public void UpdateQuestionAnswerData(QuestionAnswer questionAnswer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<QuestionAnswer>(memoryStream, questionAnswer);
                Task.Run(async () => await command.UpdateQuestionAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "037")).Wait();
            }
        }

        public void DeleteQuestionAnswerData(QuestionAnswer questionAnswer)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<QuestionAnswer>(memoryStream, questionAnswer);
                Task.Run(async () => await command.DelQuestionAnswer(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "038")).Wait();
            }
        }

        public List<QuestionAnswer> GetQuestionAnswerList(Questions question)
        {
            List<QuestionAnswer> questionAnswerList = new List<QuestionAnswer>();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Questions>(memoryStream, question);
                Task.Run(async () => await command.GetQuestionAnswerList(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "039")).Wait();
            }

            if (CommandCL.QuestionAnswerListGet == null)
            {
                questionAnswerList = null;
            }
            else
            {
                questionAnswerList = CommandCL.QuestionAnswerListGet.ListQuestionAnswer;
            }
            return questionAnswerList;
        }
    }

    public class ExamsTestEditorViewModel : INotifyPropertyChanged
    {
        private int id;
        private Exams exams;
        private Test test;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public Exams Exams
        {
            get => exams;
            set => SetProperty(ref exams, value);
        }

        public Test Test
        {
            get => test;
            set => SetProperty(ref test, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExamsTestManager
    {
        private CommandCL.ExamsTestCommand command = new CommandCL.ExamsTestCommand();

        public void CreateExamsTestData(ExamsTest examsTest)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<ExamsTest>(memoryStream, examsTest);
                Task.Run(async () => await command.CreateExamsTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "044")).Wait();
            }
        }

        public void UpdateExamsTestData(ExamsTest examsTest)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<ExamsTest>(memoryStream, examsTest);
                Task.Run(async () => await command.UpdateExamsTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "045")).Wait();
            }
        }

        public void DeleteExamsTestData(ExamsTest examsTest)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<ExamsTest>(memoryStream, examsTest);
                Task.Run(async () => await command.DelExamsTest(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "046")).Wait();
            }
        }

        public List<ExamsTest> GetExamsTestList(Exams exams)
        {
            List<ExamsTest> examsTestList = new List<ExamsTest>();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<Exams>(memoryStream, exams);
                Task.Run(async () => await command.GetExamsTestList(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "047")).Wait();
            }

            if (CommandCL.ExamsTestListGet == null)
            {
                examsTestList = null;
            }
            else
            {
                examsTestList = CommandCL.ExamsTestListGet.ListExamsTest;
            }
            return examsTestList;
        }
    }

    public class UserExamsEditorViewModel : INotifyPropertyChanged
    {
        private int id;
        private User user;
        private Exams exams;

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public Exams Exams
        {
            get => exams;
            set => SetProperty(ref exams, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class UserExamsManager
    {
        private CommandCL.UserExamsCommand command = new CommandCL.UserExamsCommand();

        public void CreateUserExamsData(UserExams userExams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<UserExams>(memoryStream, userExams);
                Task.Run(async () => await command.CreateUserExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "048")).Wait();
            }
        }

        public void UpdateUserExamsData(UserExams userExams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<UserExams>(memoryStream, userExams);
                Task.Run(async () => await command.UpdateUserExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "049")).Wait();
            }
        }

        public void DeleteUserExamsData(UserExams userExams)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<UserExams>(memoryStream, userExams);
                Task.Run(async () => await command.DelUserExams(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "050")).Wait();
            }
        }

        public List<UserExams> GetUserExamsList(User user)
        {
            List<UserExams> userExamsList = new List<UserExams>();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                JsonSerializer.Serialize<User>(memoryStream, user);
                Task.Run(async () => await command.GetUserExamsList(Ip_adress.Ip_adresss, Encoding.Default.GetString(memoryStream.ToArray()), "051")).Wait();
            }

            if (CommandCL.UserExamsListGet == null)
            {
                userExamsList = null;
            }
            else
            {
                userExamsList = CommandCL.UserExamsListGet.ListUserExams;
            }
            return userExamsList;
        }
    }

    public class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? "Да" : "Нет";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
