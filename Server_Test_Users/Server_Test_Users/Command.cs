using Class_interaction_Users;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using static Class_interaction_Users.CheckMail_and_Password;

namespace Server_Test_Users
{
    internal class Command
    {

        public void CheckMail_and_Passwords(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            try
            {
                CheckMail_and_Password? person3 = JsonSerializer.Deserialize<CheckMail_and_Password>(arg1);

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                @class.Check_login_amail(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                // @class.Regis_users
                using (MemoryStream ms = new MemoryStream())
                {
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                    JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                              //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Insert_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void List_Friens(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void List_Friens_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }


        /// <summary>
        /// Регистрирует пользователя 
        /// </summary>
        public void Registration_users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            try
            {
                Regis_users? person3 = JsonSerializer.Deserialize<Regis_users>(arg1);
                /// person3;
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                @class.Regis_user(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

                if (@class.Travel == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Regis_users regis_Users = new Regis_users(0,"","",0,"");
                        JsonSerializer.Serialize<Regis_users>(ms, regis_Users);
                        //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {


                    // @class.Regis_users
                    using (MemoryStream ms = new MemoryStream())
                    {
                        JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);
                        //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }

        public void Check_test(byte[] arg1, GlobalClass @class, NetworkStream stream)
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
            
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Sampling_Users_Correspondence(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {

         //   Test
        }

        public void Search_Image(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {

            Questions? person3 = JsonSerializer.Deserialize<Questions>(arg1);
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            @class.Insert_Questin(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            using (MemoryStream ms = new MemoryStream())
            {
                
                Questionss List_Quest = new Questionss(@class.questionss);
                JsonSerializer.Serialize<Questionss>(ms, List_Quest);
                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
            }
            /// person3;
           // @class.Regis_user(person3);
        }

        public  void Search_Image_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Check_Users_test_insert(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            @class.Check_Users_test_insert();
            if (@class.Travels == null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Regis_users [] regis_Users = new Regis_users[] {};
        //            Regis_users regis_Users = new Regis_users(0, "", "", 0, "2");
                    Regis_users_test regis_Users_Test = new Regis_users_test {regis = regis_Users };
                    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);
                    //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
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
                    //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
        }


        //Для справоника user
        public void Check_Users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            @class.Check_Users_ds();
            if (@class.UserListTest == null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Regis_users[] regis_Users = new Regis_users[] { };
                    //            Regis_users regis_Users = new Regis_users(0, "", "", 0, "2");
                    Regis_users_test regis_Users_Test = new Regis_users_test { regis = regis_Users };
                    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);
                    //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
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
                    //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                }
            }
        }


        public void Update_Users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            User? UpUser = JsonSerializer.Deserialize<User>(arg1);

            @class.Update_Users_ds(UpUser);
        }

        public void Create_Users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            User? CrUser = JsonSerializer.Deserialize<User>(arg1);

            @class.Create_Users_ds(CrUser);
        }

        public void Del_Users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            User? DelUser = JsonSerializer.Deserialize<User>(arg1);

            @class.Del_Users_ds(DelUser.Id);
        }

        //Для справочника test

        public void Create_Test(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Test? CrTest = JsonSerializer.Deserialize<Test>(arg1);

            @class.Create_Test_ds(CrTest);
        }

        public void Update_Test(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Test? UpTest = JsonSerializer.Deserialize<Test>(arg1);

            @class.Update_Test_ds(UpTest);
        }

        public void Del_Test(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Test? DelTest = JsonSerializer.Deserialize<Test>(arg1);

            @class.Del_Test_ds(DelTest.Id);
        }

        public void Get_TestList(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            @class.Check_Test_ds();
            if (@class.TestListTest == null)
            {
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    Regis_users[] regis_Users = new Regis_users[] { };
                //    Regis_users_test regis_Users_Test = new Regis_users_test { regis = regis_Users };
                //    JsonSerializer.Serialize<Regis_users_test>(ms, regis_Users_Test);
                //    stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                //}
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
        }

        //Для справочника Exams
        public void Create_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Exams? CrExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Create_Exams_ds(CrExams);
        }

        public void Update_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Exams? UpExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Update_Exams_ds(UpExams);
        }

        public void Del_Exams(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Exams? DelExams = JsonSerializer.Deserialize<Exams>(arg1);
            @class.Del_Exams_ds(DelExams.Id);
        }

        public void Get_ExamsList(byte[] arg1, GlobalClass @class, NetworkStream stream)
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
        }

        //Для справочника Questions

        public void Create_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Questions? CrQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Create_Questions_ds(CrQuestions);
        }

        public void Update_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Questions? UpQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Update_Questions_ds(UpQuestions);
        }

        public void Del_Questions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Questions? DelQuestions = JsonSerializer.Deserialize<Questions>(arg1);
            @class.Del_Questions_ds(DelQuestions.Id);
        }

        public void Get_QuestionsList(byte[] arg1, GlobalClass @class, NetworkStream stream)
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
        }


        // Для справочника TestQuestions

        public void Create_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            TestQuestion? CrTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Create_TestQuestions_ds(CrTestQuestions);
        }

        public void Update_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            TestQuestion? UpTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Update_TestQuestions_ds(UpTestQuestions);
        }

        public void Del_TestQuestions(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            TestQuestion? DelTestQuestions = JsonSerializer.Deserialize<TestQuestion>(arg1);
            @class.Del_TestQuestions_ds(DelTestQuestions.Id);
        }

        public void Get_TestQuestionsList(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Test? CrQuestions = JsonSerializer.Deserialize<Test>(arg1);
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
        }


        // For the QuestionAnswers directory

        public void Create_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            QuestionAnswer CrQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.CreateQuestionAnswer_ds(CrQuestionAnswer);
        }

        public void Update_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            QuestionAnswer UpQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.UpdateQuestionAnswer_ds(UpQuestionAnswer);
        }

        public void Del_QuestionAnswer(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            QuestionAnswer DelQuestionAnswer = JsonSerializer.Deserialize<QuestionAnswer>(arg1);
            @class.DeleteQuestionAnswer_ds(DelQuestionAnswer.Id);
        }

        public void Get_QuestionAnswerList(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            Questions CrTest = JsonSerializer.Deserialize<Questions>(arg1);
            @class.CheckQuestionAnswer_ds(CrTest);
            if (@class.TestQuestionListTest == null)
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
        }

        public void Searh_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream)
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
            }
            catch
            {


            }
        }

        public void Select_job_title(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            try
            {
                @class.Check_Roles();


                if (@class.Count_Roles == 1)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Roles[] roles = new Roles[] { };

                        Roles_Travel roles_Travel = new Roles_Travel(roles);
                        JsonSerializer.Serialize<Roles_Travel>(ms, roles_Travel);
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
                //Проверяем должности  какие есть и отправляем клиенту 
            }catch { }


        }

        public void Update_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }
    }
}