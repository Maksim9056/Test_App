using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Class_interaction_Users
{

    public class Ip_adress
    {
        public static string Ip_adresss { get; set; } = "192.168.0.112";
    }

    /// <summary>
    /// Справочник Пользователей
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя или работника
        /// </summary>
        public string Name_Employee { get; set; }
        /// <summary>
        /// Пароль 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public string DataMess { get; set; }
        /// <summary>
        /// id роли 
        /// </summary>
        public int Id_roles_users { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Employee_Mail { get; set; }
    }

    [Serializable]
    /// <summary>
    /// Класс  для User запоковываем в List
    /// </summary>
    public class UserList
    {
        public List<User> ListUser { get; set; }
    }


    /// <summary>
    /// Для ролей у пользователей  зарегистрировались
    /// </summary>
    public class User_roles
    {
        public int Id { get; set; }
        public Roles Id_roles { get; set; }
        public User User_id { get; set; }
    }

   /// <summary>
   /// Справочник ролей для название ролей и id
   /// </summary>
    public class Roles
    {
        public int Id { get; set; }
        public string Name_roles { get; set; }    
    }

    /// <summary>
    /// Справочник вопросов для теста
    /// </summary>
    [Serializable]
    public class Questions
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование вопроса
        /// </summary>
        public string QuestionName { get; set; }

        /// <summary>
        /// Правильный ответ
        /// </summary>
        public string AnswerTrue { get; set; }

        /// <summary>
        /// Оценка вопроса
        /// </summary>
        public int Grade { get; set; }

        ///// <summary>
        ///// Выбранные ответы
        ///// </summary>
        //public List<Answer> allAnswers { get; set; }

    }


    [Serializable]
    public class QuestionsList
    {
        public List<Questions> QuestionList { get; set; } = new List<Questions>();
    }



    public class Questionss
    {
        Questionss() { }
        public  Questions[] Quest { get; set; }
        public Questionss(Questions[] quest)
        {
            Quest = quest;
        }
    }

    public class QuestionssList
    {
       public List<Questionss> Questionsses = new List<Questionss>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Roles_Travel 
    {
        Roles_Travel() { }
       public  Roles[] Roles { get; set; } 
        public Roles_Travel(Roles[] roles)
        {
            Roles = roles;
        }   
    }

    /// <summary>
    /// Принемает на клиенте при регистрации 
    /// </summary>
    public class Roles_Accept_Client
    {  
        public List<Roles_Travel> Test { get; set; } = new List<Roles_Travel>();
    }

    /// <summary>
    /// Класс настройки конфигурации
    /// </summary>
    /// 
    public class Client
    {
        public string Ip_adress { get; set; }
        public Client(string ip_adress)
        {
            Ip_adress = ip_adress;
        }
    }

    [Serializable]
    public class Seting
    {
        Seting() { }
        /// <summary>
        /// Ip_адресс
        /// </summary>
        public string Ip_adress {  get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public int  Port { get; set; }

        /// <summary>
        /// Тип Sql
        /// </summary>
        public int TypeSQL { get; set; }

       
        public Seting(string ip_adress, int port, int typeSQL)
        {
            Ip_adress = ip_adress;
            Port = port;
            TypeSQL = typeSQL;
        }

    }

    [Serializable]
    /// <summary>
    /// Класс Regis_users для регестрации пользователей
    /// </summary>
    public class Regis_users
    {
        public Regis_users() { }
        public int Id { get; set; }
        public   string Name_Employee { get; set; }
        public string Password { get; set; }

        public int  Rechte { get; set; }
        public string Employee_Mail { get; set; }
                   
        public Regis_users(int id, string name_Employee, string password,int rechte,string @Mail)
        {
            Id = id; 
            Name_Employee = name_Employee;
            Password = password;
            Rechte = rechte;
            Employee_Mail = @Mail;
        }
    }


    [Serializable]
    public class Regis_users_test 
    {
        public   Regis_users[]  regis { get;set; }
    }

    [Serializable]
    public class Regis_users_travels
    {
     public    List<Regis_users_travels> Regis_Users_Travels = new List<Regis_users_travels>();
    }


    [Serializable]
    /// <summary>
    /// Тест с вопросами
    /// </summary>
    public class TestQuestion
    {
        public TestQuestion() { }

        /// <summary>
        /// Id Теста с вопросами
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тест, к которому относится вопрос
        /// </summary>
        public Test IdTest { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public Questions IdQuestions { get; set; }
    }

    [Serializable]
    public class TestQuestionList
    {
        public List<TestQuestion> ListTestQuestion{ get; set; } = new List<TestQuestion>();
    }


    [Serializable]
    /// <summary>
    /// Вопросы с ответами
    /// </summary>
    public class QuestionAnswer
    {
        public QuestionAnswer() { }

        /// <summary>
        /// Id вопроса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public Questions Questions { get; set; }

        /// <summary>
        /// Правильные ответы
        /// </summary>
        public string CorrectAnswers { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Выбранные ответы
        /// </summary>
        public List<Answer> AllAnswers { get; set; }
    }

    /// <summary>
    /// Ответ
    /// </summary>
    public class Answer
    {
        public int Id { get; set; }

        /// <summary>
        /// Ответ
        /// </summary>
        public string AnswerOptions { get; set; }

        /// <summary>
        /// Правильные ответы
        /// </summary>
        public bool CorrectAnswers { get; set; }

        public Questions IdQuestions { get; set; }
    }

    /// <summary>
    /// Параметры
    /// </summary>
    public class Options 
    { 
     public  int Id { get; set; }
     public Answer Id_Answer { get; set; }
     public string Test_Name { get; set; }
     public Questions Questions { get; set;}
     public Questions Questions_Id { get; set; } 
      public Test Id_Test { get; set; }
    }

    [Serializable]
    /// <summary>
    /// Справочник тестов
    /// </summary>
    public class Test 
    { 
        public int Id { get; set; }
        public string Name_Test { get; set; }
        public int Options_Id { get; set; }
    }

    [Serializable]
    /// <summary>
    /// Класс  для Test запоковываем в List
    /// </summary>
    public class TestList
    {
        public List<Test> ListTest { get; set; }
    }


    /// <summary>
    /// Экзамен
    /// </summary>
    public class Exam
    {
        public int Id { get; set; }

        public string Name_Quesrts { get; set; }

        public User User { get; set; }
        public Questions Questtion { get; set; }

        public User Users_Id_Name { get; set; }

        public DateTime Data_of_Exam { get; set; }
        public int Grade_Exam { get; set; }
        public Exams Name_exam { get; set; }
    }

   /// <summary>
   /// Справочник экзаменов
   /// </summary>
    public class Exams
    {
        public int Id { get; set; }
        public string Name_exam { get; set; }
    }

    [Serializable]
    /// <summary>
    /// Класс  для Exams запоковываем в List
    /// </summary>
    public class ExamsList
    {
        public List<Exams> ListExams { get; set; }
    }


    /// <summary>
    /// Сохраняет результат экзамена
    /// </summary>
    public class Save_results
    {
        public int Id { get; set; }
        public Questions Questions { get; set; }
        public Test Name_Test { get; set; }
        public string Users_Answers_Questions { get; set; }
        public Exam Exam_id { get; set; }
        public DateTime Date_of_Result_Exam_Endings { get; set; }
        public User Name_Users { get; set; }
        public int Resukts_exam { get; set; }
    }


    [Serializable]
    /// <summary>
    /// Класс Regis_users для регестрации пользователей
    /// </summary>
    public class CheckMail_and_Password
    {
        public CheckMail_and_Password() { }
        public string Password { get; set; }
        public string Employee_Mail { get; set; }
        public CheckMail_and_Password(string password, string @Mail)
        {
            Password = password;
            Employee_Mail = @Mail;
        }
    }

        [Serializable]
        /// <summary>
        /// Класс  для регестрации пользователей и прошедших авторизацию
        /// </summary>
        public class CheckMails
        {
            public CheckMails() { }
            public Regis_users Users { get; set; }
            public CheckMails(Regis_users users)
            {
                Users = users;
            }
        }

        //[Serializable]
        ///// <summary>
        ///// Класс  для названия теста которые создали
        ///// </summary>
        //public class Test
        //{
        //    public Test() { }
        //    public int Id { get; set; }
        //    public string Tests { get; set; }
        //    public Test(int id,string tests)
        //    {
        //        Id = id;
        //        Tests = tests;
        //    }
        //}


        [Serializable]
        /// <summary>
        /// Класс  для Test запоковываем
        /// </summary>
        public class Tests
        {
            public Tests() { }
            public Test[] TEST { get; set; }
            public Tests (Test[] test)
            {
                TEST = test;
            }
        }


        [Serializable]
        /// <summary>
        /// Класс  для Tests запоковываем в List
        /// </summary>
        public class  Tests_Travel
        {
            public List<Tests> Test { get; set; } = new List<Tests>();
        }

    [Serializable]
    /// <summary>
    ///Тест вопросами
    /// </summary>
    public class Questions_Travel
    {
        public Questions_Travel() { }

        /// <summary>
        ///Id  Тест вопросами
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Названия теста
        /// </summary>
        public string Name_Test { get; set; }
        /// <summary>
        /// Вопросы
        /// </summary>
        public string Questions { get; set; }
        /// <summary>
        /// Правильный ответ
        /// </summary>
        public string Answer_True { get; set; }
        /// <summary>
        /// Оценка
        /// </summary>
        public string Grade_Quessions { get; set; }

        /// <summary>
        /// Выборка вопросов несколько
        /// </summary>
        public int Answer_id { get; set; }
        public Questions_Travel(int id, string name_Test, string questions, string answer_True, string grade_Quessions, int answer_id)
        {
            Id = id;
            Name_Test = name_Test;
            Questions = questions;
            Answer_True = answer_True;
            Grade_Quessions = grade_Quessions;
            Answer_id = answer_id;
        }
    }






}
