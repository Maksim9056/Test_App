using Class_interaction_Users;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using static Servis.Logging;

namespace Servis
{
    internal class Command
    {


        public void CheckMail_and_Passwords(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

            try
            {
                CheckMail_and_Password person3 = JsonSerializer.Deserialize<CheckMail_and_Password>(arg1);


                @class.Check_login_amail(person3);

                // @class.Regis_users
                using (MemoryStream ms = new MemoryStream())
                {

                    JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);

                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }

                if (@class.Travel == null)
                {
                    logging.Insert("Пользователя не нашли", StatusType.Success, Действия.CheckMail_and_Passwords, "");

                }
                else if (@class.Travel.Id == 0)
                {
                    logging.Insert($"Пользователь ввел пароль не верный с почтой :{@class.Travel.Employee_Mail} ", StatusType.Success, Действия.CheckMail_and_Passwords, "");

                }
                else
                {
                    logging.Insert($"{@class.Travel.Name_Employee}", StatusType.Success, Действия.CheckMail_and_Passwords, "");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                logging.Insert("", StatusType.Error, Действия.CheckMail_and_Passwords, ex.Message);

            }
        }

        public void Delete_Message(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
        }

        public void Insert_Message(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
        }

        public void List_Friens(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
        }

        public void List_Friens_Message(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
        }




        /// <summary>
        /// Регистрирует пользователя 
        /// </summary>
        public void Registration_users(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {
                Regis_users person3 = JsonSerializer.Deserialize<Regis_users>(arg1);
                /// person3;

                @class.Regis_user(person3);

                if (@class.Travel == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Roles roles = new Roles { Id = 0 };
                        Regis_users regis_Users = new Regis_users(0, "", "", roles, "", 0);

                        JsonSerializer.Serialize<Regis_users>(ms, regis_Users);

                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {


                    // @class.Regis_users
                    using (MemoryStream ms = new MemoryStream())
                    {
                        JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);

                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                logging.Insert("", StatusType.Success, Действия.Registration_users, "");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                logging.Insert("", StatusType.Error, Действия.Registration_users, e.Message);

            }



        }



        public void Check_test(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

            try
            {
                @class.Check_Tests();

                if (@class.Travels_test == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Tests test = new Tests(@class.Travels_test);
                        JsonSerializer.Serialize<Tests>(ms, test);
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Tests test = new Tests(@class.Travels_test);
                        JsonSerializer.Serialize<Tests>(ms, test);
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }

                logging.Insert("", StatusType.Success, Действия.Check_test, "");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logging.Insert("", StatusType.Error, Действия.Check_test, ex.Message);

            }
        }

        public void Sampling_Users_Correspondence(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

            //   Test
        }




        public void Search_Image(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

            Questions person3 = JsonSerializer.Deserialize<Questions>(arg1);

            @class.Insert_Questin(person3);

            using (MemoryStream ms = new MemoryStream())
            {

                Questionss List_Quest = new Questionss(@class.questionss);

                JsonSerializer.Serialize<Questionss>(ms, List_Quest);

                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
            logging.Insert("", StatusType.Success, Действия.Search_Image, "");

        }

        public void Search_Image_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
        }




        public void Check_Users_test_insert(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Users_test_insert();
            if (@class.Travels == null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Regis_users[] regis_Users = new Regis_users[] { };
                    Regis_users_test regis_Users_Test = new Regis_users_test { regis = regis_Users };
                    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);

                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            else
            {
                // @class.Regis_users
                using (MemoryStream ms = new MemoryStream())
                {
                    Regis_users_test regis_Users_Test = new Regis_users_test { regis = @class.Travels };
                    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);

                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Check_Users_test_insert, "");

        }


        //Для справоника user
        public void Check_Users(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Users_ds();
            if (@class.UserListTest == null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Regis_users[] regis_Users = new Regis_users[] { };
                    Regis_users_test regis_Users_Test = new Regis_users_test { regis = regis_Users };
                    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    UserList regis_Users_Test = new UserList { };
                    regis_Users_Test.ListUser = @class.UserListTest;
                    JsonSerializer.Serialize<UserList>(ms, regis_Users_Test);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Check_Users, "");

        }

        public void Update_Users(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            User UpUser = JsonSerializer.Deserialize<User>(arg1);


            @class.Update_Users_ds(UpUser);
            logging.Insert(UpUser.Name_Employee, StatusType.Success, Действия.Update_Users, "");

        }



        public void Create_Users(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            User CrUser = JsonSerializer.Deserialize<User>(arg1);







            @class.Create_Users_ds(CrUser);
            logging.Insert(CrUser.Name_Employee, StatusType.Success, Действия.Create_Users, "");

        }




        public void Del_Users(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            User DelUser = JsonSerializer.Deserialize<User>(arg1);


            @class.Del_Users_ds(DelUser.Id);

            logging.Insert(DelUser.Name_Employee, StatusType.Success, Действия.Del_Users, "");

        }

        //Для справочника test

        public void Create_Test(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Test CrTest = JsonSerializer.Deserialize<Test>(arg1);


            @class.Create_Test_ds(CrTest);
            logging.Insert("", StatusType.Success, Действия.Create_Test, "");

        }



        public void Update_Test(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Test UpTest = JsonSerializer.Deserialize<Test>(arg1);


            @class.Update_Test_ds(UpTest);


            logging.Insert("", StatusType.Success, Действия.Update_Test, "");

        }

        public void Del_Test(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Test DelTest = JsonSerializer.Deserialize<Test>(arg1);


            @class.Del_Test_ds(DelTest.Id);

            logging.Insert("", StatusType.Success, Действия.Del_Test, "");

        }




        public void Get_TestList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Test_ds();
            if (@class.TestListTest == null)
            {
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    TestList regis_Test = new TestList { };
                    regis_Test.ListTest = @class.TestListTest;
                    JsonSerializer.Serialize<TestList>(ms, regis_Test);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_TestList, "");

        }

        //Для справочника Exams
        public void Create_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Exams CrExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Create_Exams_ds(CrExams);
            logging.Insert("", StatusType.Success, Действия.Create_Exams, "");

        }

        public void Update_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Exams UpExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Update_Exams_ds(UpExams);
            logging.Insert("", StatusType.Success, Действия.Update_Exams, "");

        }

        public void Del_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Exams DelExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Del_Exams_ds(DelExams.Id);
            logging.Insert("", StatusType.Success, Действия.Del_Exams, "");

        }


        public void Get_ExamsList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Exams_ds();
            if (@class.ExamsListTest == null)
            {
                // Handle the case when TestListTest is null
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ExamsList regis_Exams = new ExamsList { };
                    regis_Exams.ListExams = @class.ExamsListTest;
                    JsonSerializer.Serialize<ExamsList>(ms, regis_Exams);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_ExamsList, "");

        }


        //Для справочника Questions

        public void Create_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Questions CrQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Create_Questions_ds(CrQuestions);
            logging.Insert("", StatusType.Success, Действия.Create_Questions, "");

        }


        public void Update_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Questions UpQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Update_Questions_ds(UpQuestions);
            logging.Insert("", StatusType.Success, Действия.Update_Questions, "");

        }

        public void Del_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Questions DelQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Del_Questions_ds(DelQuestions.Id);

            logging.Insert("", StatusType.Success, Действия.Del_Questions, "");
        }


        public void Get_QuestionsList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Questions_ds();
            if (@class.QuestionsListTest == null)
            {
                // Handle the case when QuestionsListTest is null 
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QuestionsList regis_Questions = new QuestionsList { };
                    regis_Questions.QuestionList = @class.QuestionsListTest;
                    JsonSerializer.Serialize<QuestionsList>(ms, regis_Questions);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_QuestionsList, "");

        }

        // For the Answers directory

        public void Create_Answer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Answer CrAnswers = JsonSerializer.Deserialize<Answer>(arg1);
            @class.Create_Answers_ds(CrAnswers);
            logging.Insert("", StatusType.Success, Действия.Create_Answer, "");

        }

        public void Update_Answer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Answer UpAnswers = JsonSerializer.Deserialize<Answer>(arg1);
            @class.Update_Answers_ds(UpAnswers);
            logging.Insert("", StatusType.Success, Действия.Update_Answer, "");

        }

        public void Del_Answer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Answer DelAnswers = JsonSerializer.Deserialize<Answer>(arg1);
            @class.Del_Answers_ds(DelAnswers.Id);
            logging.Insert("", StatusType.Success, Действия.Del_Answer, "");

        }

        public void Get_AnswerList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.Check_Answers_ds();
            if (@class.AnswerListTest == null)
            {
                // Handle the case when AnswersListTest is null
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    AnswerList regis_Answers = new AnswerList { };
                    regis_Answers.ListAnswer = @class.AnswerListTest;
                    JsonSerializer.Serialize<AnswerList>(ms, regis_Answers);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_AnswerList, "");

        }

        // Для справочника TestQuestions

        public void Create_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            TestQuestion CrTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Create_TestQuestions_ds(CrTestQuestions);
            logging.Insert("", StatusType.Success, Действия.Create_TestQuestions, "");

        }

        public void Update_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            TestQuestion UpTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Update_TestQuestions_ds(UpTestQuestions);
            logging.Insert("", StatusType.Success, Действия.Update_TestQuestions, "");

        }


        public void Del_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            TestQuestion DelTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Del_TestQuestions_ds(DelTestQuestions.Id);
            logging.Insert("", StatusType.Success, Действия.Del_TestQuestions, "");

        }

        public void Get_TestQuestionsList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Test CrQuestions = JsonSerializer.Deserialize<Test>(arg1);
            @class.Check_TestQuestions_ds(CrQuestions);
            if (@class.TestQuestionListTest == null)
            {
                // Handle the case when TestQuestionsListTest is null
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    TestQuestionList regis_TestQuestions = new TestQuestionList { };
                    regis_TestQuestions.ListTestQuestion = @class.TestQuestionListTest;
                    JsonSerializer.Serialize<TestQuestionList>(ms, regis_TestQuestions);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_TestQuestionsList, "");

        }

        // For the QuestionAnswers directory

        public void Create_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            QuestionAnswer CrQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.CreateQuestionAnswer_ds(CrQuestionAnswer);
            logging.Insert("", StatusType.Success, Действия.Create_QuestionAnswer, "");

        }



        public void Update_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            QuestionAnswer UpQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.UpdateQuestionAnswer_ds(UpQuestionAnswer);
            logging.Insert("", StatusType.Success, Действия.Update_QuestionAnswer, "");

        }

        public void Del_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            QuestionAnswer DelQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.DeleteQuestionAnswer_ds(DelQuestionAnswer.Id);
            logging.Insert("", StatusType.Success, Действия.Del_QuestionAnswer, "");

        }


        public void Get_QuestionAnswerList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Questions CrTest = JsonSerializer.Deserialize<Questions>(arg1);
            @class.CheckQuestionAnswer_ds(CrTest);
            if (@class.QuestionAnswerListTest == null)
            {
                // Handle the case when TestQuestionListTest is null 
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    QuestionAnswerList regis_QuestionAnswers = new QuestionAnswerList { };
                    regis_QuestionAnswers.ListQuestionAnswer = @class.QuestionAnswerListTest;
                    JsonSerializer.Serialize<QuestionAnswerList>(ms, regis_QuestionAnswers);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_QuestionAnswerList, "");

        }

        // For the ExamsTest directory

        public void Create_ExamsTest(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            ExamsTest CrExamsTest = JsonSerializer.Deserialize<ExamsTest>(arg1);
            @class.CreateExamsTest_ds(CrExamsTest);


            logging.Insert("", StatusType.Success, Действия.Create_ExamsTest, "");

        }

        public void Update_ExamsTest(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            ExamsTest UpExamsTest = JsonSerializer.Deserialize<ExamsTest>(arg1);
            @class.UpdateExamsTest_ds(UpExamsTest);
            logging.Insert("", StatusType.Success, Действия.Update_ExamsTest, "");

        }

        public void Del_ExamsTest(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            ExamsTest DelExamsTest = JsonSerializer.Deserialize<ExamsTest>(arg1);
            @class.DeleteExamsTest_ds(DelExamsTest.Id);

            logging.Insert("", StatusType.Success, Действия.Del_ExamsTest, "");

        }

        public void Get_ExamsTestList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Exams CrTest = JsonSerializer.Deserialize<Exams>(arg1);
            @class.CheckExamsTest_ds(CrTest);
            if (@class.ExamsTestListTest == null)
            {
                // Handle the case when ExamsTestListTest is null
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ExamsTestList regis_ExamsTests = new ExamsTestList { };
                    regis_ExamsTests.ListExamsTest = @class.ExamsTestListTest;
                    JsonSerializer.Serialize<ExamsTestList>(ms, regis_ExamsTests);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert("", StatusType.Success, Действия.Get_ExamsTestList, "");

        }


        // For the UserExams directory

        public void Create_UserExams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            UserExams CrUserExams = JsonSerializer.Deserialize<UserExams>(arg1);
            @class.CreateUserExams_ds(CrUserExams);


            logging.Insert(CrUserExams.User.Name_Employee, StatusType.Success, Действия.Create_UserExams, "");

        }

        public void Update_UserExams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            UserExams UpUserExams = JsonSerializer.Deserialize<UserExams>(arg1);
            @class.UpdateUserExams_ds(UpUserExams);
            logging.Insert(UpUserExams.User.Name_Employee, StatusType.Success, Действия.Update_UserExams, "");

        }

        public void Del_UserExams(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            UserExams DelUserExams = JsonSerializer.Deserialize<UserExams>(arg1);
            @class.DeleteUserExams_ds(DelUserExams.Id);
            logging.Insert(DelUserExams.User.Name_Employee, StatusType.Success, Действия.Del_UserExams, "");

        }

        public void Get_UserExamsList(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            User CrTest = JsonSerializer.Deserialize<User>(arg1);
            @class.CheckUserExams_ds(CrTest);
            if (@class.UserExamsListTest == null)
            {
                // Handle the case when UserExamsListTest is null
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    UserExamsList regis_UserExams = new UserExamsList { };
                    regis_UserExams.ListUserExams = @class.UserExamsListTest;
                    JsonSerializer.Serialize<UserExamsList>(ms, regis_UserExams);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            logging.Insert(CrTest.Name_Employee, StatusType.Success, Действия.Get_UserExamsList, "");

        }



        public void SaveTestUsers(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Save_results TravelServerTest = JsonSerializer.Deserialize<Save_results>(arg1);


            @class.SaveTestResultsAnswers(TravelServerTest);
            logging.Insert(TravelServerTest.User_id.Name_Employee, StatusType.Success, Действия.SaveTestUsers, "");


        }



        public void Searh_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {
                @class.Check_Questin();



                using (MemoryStream ms = new MemoryStream())
                {

                    Questionss List_Quest = new Questionss(@class.questionss);
                    JsonSerializer.Serialize<Questionss>(ms, List_Quest);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
                logging.Insert("", StatusType.Success, Действия.Searh_Friends, "");

            }
            catch (Exception ex)
            {
                logging.Insert("Ошибка", StatusType.Error, Действия.Searh_Friends, ex.Message);


            }
        }

        public void Select_job_title(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {
                var Value = @class.Check_Roles();


                if (Value == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {

                        Roles roles_Travel = new Roles();
                        JsonSerializer.Serialize<Roles>(ms, roles_Travel);
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        JsonSerializer.Serialize<Roles>(ms, Value);
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }

                logging.Insert("", StatusType.Success, Действия.Select_job_title, "");

                //Проверяем должности  какие есть и отправляем клиенту 
            }
            catch (Exception ex)
            {

                logging.Insert("Ошибка", StatusType.Error, Действия.Select_job_title, ex.Message);


            }


        }

        public void Update_Message(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

        }



        public void CheckExamUsers(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            CheckExam CheckExams = JsonSerializer.Deserialize<CheckExam>(arg1);


            @class.CheckExam(CheckExams);

            using (MemoryStream ms = new MemoryStream())
            {
                Exams_Check exams_Check = new Exams_Check();
                exams_Check.save_Results = @class.save_Results;

                JsonSerializer.Serialize<Exams_Check>(ms, exams_Check);
                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
            logging.Insert("", StatusType.Success, Действия.CheckExamUsers, "");


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="class"></param>
        /// <param name="stream"></param>
        public void CheckTestUsers(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            CheckUserTest CheckExams = JsonSerializer.Deserialize<CheckUserTest>(arg1);
            //    JsonSerializer.Serialize<>(memoryStream, userExams);



            @class.CheckTest(CheckExams);

            using (MemoryStream ms = new MemoryStream())
            {
                Exams_Check exams_Check = new Exams_Check();
                exams_Check.save_Results = @class.Test_Results;

                JsonSerializer.Serialize<Exams_Check>(ms, exams_Check);
                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
            logging.Insert(CheckExams.CurrrentUser.Name_Employee, StatusType.Success, Действия.CheckExamUsers, "");

        }



        public void CheckStatickUserResult(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            User CrTest = JsonSerializer.Deserialize<User>(arg1);
            @class.CheckStatickUserResult(CrTest);
            using (MemoryStream ms = new MemoryStream())
            {
                Statick statick = new Statick();
                statick.statictics = @class.StatickUsers;


                JsonSerializer.Serialize<Statick>(ms, statick);
                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
            logging.Insert(CrTest.Name_Employee, StatusType.Success, Действия.CheckStatickUserResult, "");

        }


        public void CheckPingIpAdress(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {

                Галочка CrTest = JsonSerializer.Deserialize<Галочка>(arg1);

                using (MemoryStream ms = new MemoryStream())
                {

                    JsonSerializer.Serialize<Галочка>(ms, CrTest);
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
                logging.Insert("", StatusType.Success, Действия.CheckPingIpAdress, "");

            }
            catch (Exception ex)
            {
                logging.Insert("Ошибка", StatusType.Error, Действия.CheckPingIpAdress, ex.Message);

                Console.WriteLine(ex.Message.ToString());
            }
        }




        public void SaveUserImage(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {

                Filles CrTest = JsonSerializer.Deserialize<Filles>(arg1);

                Filles filles = @class.SaveUsersImage(CrTest);
                using (MemoryStream ms = new MemoryStream())
                {

                    //  JsonSerializer.Serialize<Filles>(ms, filles);
                    JsonSerializer.Serialize<Filles>(stream, filles);

                    //   stream.Write(ms.ToArray(), 0, ms.ToArray().Length);

                }
                logging.Insert("", StatusType.Success, Действия.SaveUserImage, "");

            }
            catch (Exception ex)
            {
                logging.Insert("Ошибка", StatusType.Error, Действия.SaveUserImage, ex.Message);

                Console.WriteLine(ex.Message.ToString());
            }
        }



        public void SelectFromFilles(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            try
            {

                Filles CrTest = JsonSerializer.Deserialize<Filles>(arg1);

                Filles filless = @class.SelectFromFilles(CrTest);

                using (MemoryStream ms = new MemoryStream())
                {

                    // JsonSerializer.Serialize<Filles>(stream, filles);
                    JsonSerializer.Serialize<Filles>(ms, filless);

                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);

                }
                logging.Insert("", StatusType.Success, Действия.SelectFromFilles, "");

            }
            catch (Exception ex)
            {
                logging.Insert("Ошибка", StatusType.Error, Действия.SelectFromFilles, ex.Message);

                Console.WriteLine(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Просмотр резервной копии которая существует
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="class"></param>
        /// <param name="stream"></param>
        public void CatalogView(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {

            var strings = @class.CatalogView();
            if (strings == null)
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    string[] Backap = new string[] { };
                    Backap backap = new Backap(Backap);
                    JsonSerializer.Serialize<Backap>(stream, backap);
                    // stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }

            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Backap backap = new Backap(strings);
                    JsonSerializer.Serialize<Backap>(stream, backap);
                    // stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }

            }
            logging.Insert("", StatusType.Success, Действия.CatalogView, "");

        }


        /// <summary>
        /// //Создают резервную копию
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="class"></param>
        /// <param name="stream"></param>
        public void DBackup(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            @class.DBackup();
            logging.Insert("", StatusType.Success, Действия.DBackup, "");

        }




        /// <summary>
        ///  Востановить из резервной копии
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="class"></param>
        /// <param name="stream"></param>
        public void Restoring_a_backup(byte[] arg1, GlobalClass @class, NetworkStream stream, Logging logging)
        {
            Backap CrTest = JsonSerializer.Deserialize<Backap>(arg1);

            if (CrTest == null)
            {

            }
            else
            {
                string File = "";
                for (int i = 0; i < CrTest.Strings.Length; i++)
                {
                    File = CrTest.Strings[i];
                }

                @class.Restoring_a_backup(File);
            }
            logging.Insert("", StatusType.Success, Действия.Restoring_a_backup, "");


        }

    }
}