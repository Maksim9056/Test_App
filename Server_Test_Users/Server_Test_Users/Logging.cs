using Class_interaction_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Server_Test_Users.Logging;

namespace Server_Test_Users
{
    /// <summary>
    /// Создать класс Логирования сделать в нем атрибуты  :  Время ,Пользователь,Действие,Cтатус,Ошибка.
    /// Действие сделать в словарь.
    /// Статус сделать словарь на выполнение .
    ///Ошибка сделать словарик и в случаи  ошибки сообщение туда записать.
    ///Фильтровать функции enum для выполнентя работы с функциями которые выполнились
    ///Методы работы с класом Логирования
    ///Добавление
    /// </summary>
    public class Logging
    {


        public   Logging()
        {

        }
        public  enum StatusType
        {
            Success,
            Error
        }

        Dictionary<StatusType, string> Статус = new Dictionary<StatusType, string>()
        {
            { StatusType.Success,"Успешно" },
            {StatusType.Error,"Ошибка"},
        };


        public enum Действия
        {
            Registration_users = 1,
            CheckMail_and_Passwords = 2,
            Check_test = 3,
            Check_Users_test_insert = 4,
            Check_Users = 5,
            Create_Users = 6,
            Update_Users = 7,
            Del_Users = 8,
            Create_Test = 9,
            Update_Test = 10,
            Del_Test = 11,
            Get_TestList = 12,
            Create_Exams = 13,
            Update_Exams = 14,
            Del_Exams = 15,
            Get_ExamsList = 16,
            Create_Questions = 17,
            Update_Questions = 18,
            Del_Questions = 19,
            Get_QuestionsList = 20,
            Create_Answer = 21,
            Update_Answer = 22,
            Del_Answer = 23,
            Get_AnswerList = 24,
            Create_TestQuestions = 25,
            Update_TestQuestions = 26,
            Del_TestQuestions = 27,
            Get_TestQuestionsList = 28,
            Create_QuestionAnswer = 29,
            Update_QuestionAnswer = 30,
            Del_QuestionAnswer = 31,
            Get_QuestionAnswerList = 32,
            Create_ExamsTest = 33,
            Update_ExamsTest = 34,
            Del_ExamsTest = 35,
            Get_ExamsTestList = 36,
            Create_UserExams = 37,
            Update_UserExams = 38,
            Del_UserExams = 39,
            Get_UserExamsList = 40,
            SaveTestUsers = 41,
            Searh_Friends = 42,
            Select_job_title = 43,
            CheckExamUsers = 44,
            CheckTestUsers = 45,
            CheckStatickUserResult = 46,
            CheckPingIpAdress = 47,
            SaveUserImage = 48,
            SelectFromFilles = 49,
            CatalogView = 50,
            DBackup = 51,
            Restoring_a_backup = 52,
            Search_Image = 53,

            
        }


        Dictionary<Действия, string> ДействияКоманд = new Dictionary<Действия, string>()
        {
            { Действия.Registration_users, "Регистрация пользователей" },
            { Действия.CheckMail_and_Passwords, "Проверка почты и пароля" },
            { Действия.Check_test, "Проверка теста" },
            { Действия.Check_Users_test_insert, "Проверка вставки теста пользователей" },
            { Действия.Check_Users, "Проверка пользователей" },
            { Действия.Create_Users, "Создание пользователей" },
            { Действия.Update_Users, "Обновление пользователей" },
            { Действия.Del_Users, "Удаление пользователей" },
            { Действия.Create_Test, "Создание теста" },
            { Действия.Update_Test, "Обновление теста" },
            { Действия.Del_Test, "Удаление теста" },
            { Действия.Get_TestList, "Получение списка тестов" },
            { Действия.Create_Exams, "Создание экзаменов" },
            { Действия.Update_Exams, "Обновление экзаменов" },
            { Действия.Del_Exams, "Удаление экзаменов" },
            { Действия.Get_ExamsList, "Получение списка экзаменов" },
            { Действия.Create_Questions, "Создание вопросов" },
            { Действия.Update_Questions, "Обновление вопросов" },
            { Действия.Del_Questions, "Удаление вопросов" },
            { Действия.Get_QuestionsList, "Получение списка вопросов" },
            { Действия.Create_Answer, "Создание ответов" },
            { Действия.Update_Answer, "Обновление ответов" },
            { Действия.Del_Answer, "Удаление ответов" },
            { Действия.Get_AnswerList, "Получение списка ответов" },
            { Действия.Create_TestQuestions, "Создание вопросов теста" },
            { Действия.Update_TestQuestions, "Обновление вопросов теста" },
            { Действия.Del_TestQuestions, "Удаление вопросов теста" },
            { Действия.Get_TestQuestionsList, "Получение списка вопросов теста" },
            { Действия.Create_QuestionAnswer, "Создание вопросов и ответов" },
            { Действия.Update_QuestionAnswer, "Обновление вопросов и ответов" },
            { Действия.Del_QuestionAnswer, "Удаление вопросов и ответов" },
            { Действия.Get_QuestionAnswerList, "Получение списка вопросов и ответов" },
            { Действия.Create_ExamsTest, "Создание экзамена и теста" },
            { Действия.Update_ExamsTest, "Обновление экзамена и теста" },
            { Действия.Del_ExamsTest, "Удаление экзамена и теста" },
            { Действия.Get_ExamsTestList, "Получение списка экзамена и теста" },
            { Действия.Create_UserExams, "Создание экзамена пользователя" },
            { Действия.Update_UserExams, "Обновление экзамена пользователя" },
            { Действия.Del_UserExams, "Удаление экзамена пользователя" },
            { Действия.Get_UserExamsList, "Получение списка экзамена пользователя" },
            { Действия.SaveTestUsers, "Сохранение пользователей теста" },
            { Действия.Searh_Friends, "Поиск друзей" },
            { Действия.Select_job_title, "Выбор должности" },
            { Действия.CheckExamUsers, "Проверка экзамена пользователей" },
            { Действия.CheckTestUsers, "Проверка теста пользователей" },
            { Действия.CheckStatickUserResult, "Проверка статического результата пользователя" },
            { Действия.CheckPingIpAdress, "Проверка пинга IP-адреса" },
            { Действия.SaveUserImage, "Сохранение изображения пользователя" },
            { Действия.SelectFromFilles, "Выбор из файлов" },
            { Действия.CatalogView, "Просмотр каталога" },
            { Действия.DBackup, "Создание резервной копии" },
            { Действия.Restoring_a_backup, "Восстановление резервной копии" },
            { Действия.Search_Image, "Вставить вопрос" },
        };


        public DateTime DateTime { get; set; } 

        public string Name { get; set; }

        public string Действие { get; set; }


        public string Cтатус { get; set; }


        public string Ошибка {  get; set; }



        public Logging(DateTime dateTime,string name ,string действие , string cтатус,string oшибка)
        {
            DateTime = dateTime;
            Name = name;
            Действие = действие;
            Cтатус = cтатус;

            Ошибка = oшибка;
        }


        public string SearhStatus(StatusType statusType)
        {
            string value = string.Empty;
            // Пример вывода значения по ключу
            StatusType action = statusType;
            if (Статус.TryGetValue(action, out string actionName))
            {
                value = actionName;
               // Console.WriteLine($"Действие: {actionName}");

            }
            else
            {
              //  Console.WriteLine("Действие не найдено в словаре.");
            }

            return value;
        }
       public string  SearhComand(Действия действия)
       {

            string Value = string.Empty;
            // Пример вывода значения по ключу
            Действия action = действия;
            if (ДействияКоманд.TryGetValue(action, out string actionName))
            {
                Value = actionName;
         //       Console.WriteLine($"Действие: {actionName}");
                
            }
            else
            {
           //     Console.WriteLine("Действие не найдено в словаре.");
            }
            return Value;
       }



        public async void Insert(string user, StatusType statusType, Действия действия,string Ошибка)
        {

            var Comand = SearhComand(действия);

            var Cтатус = SearhComand(действия);


            DateTime d = DateTime.Now;


            using (StreamWriter writer = new StreamWriter("LogsFile.txt", true))
            {

                Logging logging = new Logging(d, user, Comand, Cтатус, Ошибка);


                // Запиши данные в файл
               await writer.WriteLineAsync($"{logging.DateTime}, {logging.Name}, {logging.Действие}, {logging.Cтатус}, {logging.Ошибка}");
                // Или использовать writer.Write(), если нужно записать данные в файл без переноса строки

                // Закрой StreamWriter
                writer.Close();

            }


        }

    }
}
