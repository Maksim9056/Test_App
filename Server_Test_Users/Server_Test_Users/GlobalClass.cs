using System;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using Class_interaction_Users;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Class_interaction_Users.CheckMail_and_Password;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Sockets;
using System.Text.Json;

namespace Server_Test_Users
{
    internal class GlobalClass
    {
        /// <summary>
        /// Использование Entity Framework Core и LINQ
        /// </summary>
        public static bool NewCoreSQL = true;

        /// <summary>
        /// Тип Sql
        /// </summary>
        public static int TypeSQL { get; set; }

        /// <summary>
        /// Запрос уже с созданой базы данных   
        /// </summary>
        public static string connectionStringPostGreSQL = $"Host=localhost;Port=5432;Database=test;Username=postgres;Password=1";

        /// <summary>
        /// Подключение без созданой базы данных
        /// </summary>
        public static string _connectionStringPostGreSQl = $"Host=localhost;Port=5432;Username=postgres;Password=1";





        public int Count_Roles { get; set; }

        /// <summary>
        /// Отсылает клиенту ответ 
        /// </summary>
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Regis_users Regis_users { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


        public bool Tru_user { get; set; } = false;


        /// <summary>
        /// Отсылает тесты
        /// </summary>
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Test[] Travels_test { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.



        /// <summary>
        /// Посылаем клиенту 
        /// </summary>
        public Regis_users? Travel { get; set; }


        public Regis_users[] Travels { get; set; }
        public List<User> UserListTest { get; set; }
        public List<Test> TestListTest { get; set; }
        public List<Exams> ExamsListTest { get; set; }
        public List<Questions> QuestionsListTest { get; set; }
        public List<Answer> AnswerListTest { get; set; }
        public List<TestQuestion> TestQuestionListTest { get; set; }
        public List<QuestionAnswer> QuestionAnswerListTest { get; set; }
        public List<ExamsTest> ExamsTestListTest { get; set; }
        public List<UserExams> UserExamsListTest { get; set; }


#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Questions[] questionss { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


        /// <summary>
        /// https://metanit.com/sharp/efcore/1.2.php
        /// </summary>
        public class ApplicationContext : DbContext
        {
            public DbSet<Roles> Roles { get; set; } = null!;
            public DbSet<User_roles> User_Roles { get; set; } = null!;

            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Questions> Questions { get; set; } = null!;

            public DbSet<TestQuestion> TestQuestion { get; set; } = null!;

            public DbSet<QuestionAnswer> QuestionAnswer { get; set; } = null!;
            public DbSet<ExamsTest> ExamsTest { get; set; } = null!;
            public DbSet<UserExams> UserExams { get; set; } = null!;

            public DbSet<Answer> Answer { get; set; } = null!;
            public DbSet<Options> Options { get; set; } = null!;

            public DbSet<Test> Test { get; set; } = null!;
            public DbSet<Exam> Exam { get; set; } = null!;
            public DbSet<Exams> Exams { get; set; } = null!;
            public DbSet<Save_results> Save_Results { get; set; } = null!;

            public ApplicationContext()
            {
                // Database.EnsureDeleted(); // гарантируем, что бд удалена
                Database.EnsureCreated(); // гарантируем, что бд будет созд
                //Database.Migrate();  // миграция
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                switch (TypeSQL)
                {
                    //Postgres
                    //IF NOT EXISTS
                    case 1:
                        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Testdb;Username=postgres;Password=1");
                        break;
                    case 2:
                        optionsBuilder.UseSqlite("Data Source=helloapp.db");
                        break;
                }
            }
        }


        public void TestSQL()
        {
            using (ApplicationContext db = new ApplicationContext())
            {

            }


            int Count_roles = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Roles.Count();
                Count_roles = users;
                // Console.WriteLine("Users list:");
                //foreach (int  u in users)
                //{
                //    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //}

            }
            if (Count_roles == 1)
            {

            }
            else
            {
                // добавление данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User

                    Roles user1 = new Roles { Name_roles = "Admin" };
                    // добавляем их в бд
                    db.Roles.AddRange(user1);
                    db.SaveChanges();
                }

                string Email = "Admin@Admin.ru";
                DateTime dateTime = DateTime.Now;
                var data = $"{dateTime:F}";
                Roles roles = new Roles { Id = 1 };

                // добавление данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User

                    User user1 = new User { Name_Employee = "Admin", Password = "Admin", DataMess = data, Id_roles_users = roles.Id, Employee_Mail = Email };

                    // добавляем их в бд
                    db.Users.AddRange(user1);
                    db.SaveChanges();
                }
            }
            // получение данных
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Users list:");
            //    foreach (User u in users)
            //    {
            //   //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //    }
            //}
            //// добавление данных
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // создаем два объекта User
            //    Questions Q1 = new Questions { Name = "Tom1", Answers = "33" };
            //    Questions Q2 = new Questions { Name = "Alice1", Answers = "26" };

            //    // добавляем их в бд
            //    db.Questions.AddRange(Q1, Q2);
            //    db.SaveChanges();
            //}
            //// получение данных
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var Qu = db.Questions.ToList();
            //    Console.WriteLine("Questions list:");
            //    foreach (Questions u in Qu)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Answers}");
            //    }
            //}

        }


        /// <summary>
        /// Создает  базу данных 
        /// </summary>
        /// 
        public void Create_Database()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    //IF NOT EXISTS
                    case 1:


                        string sql = "SELECT datname FROM pg_catalog.pg_database WHERE datname = 'test'";
                        bool Create_DATABASE = false;

                        using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionStringPostGreSQl))
                        {

                            npgsqlConnection.Open();
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.Connection = npgsqlConnection;
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            //   NpgsqlCommand command = new NpgsqlCommand(sqlExpressiol, connection);
                            //var n = command.ExecuteReader();

                            //NpgsqlCommand commandS = new NpgsqlCommand(sqlExpressiol, connection);
                            NpgsqlDataReader sqReader = command.ExecuteReader();

                            if (sqReader.HasRows == true)
                            {
                                Create_DATABASE = true;
                                // Always call Read before accessing data.
                                while (sqReader.Read())
                                {
                                }
                            }
                        }

                        string Sql = "CREATE DATABASE  Test;";
                        if (Create_DATABASE == false)
                        {
                            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionStringPostGreSQl))
                            {
                                npgsqlConnection.Open();
                                NpgsqlCommand command = new NpgsqlCommand();
                                command.Connection = npgsqlConnection;
                                command.CommandText = sql;
                                command.ExecuteNonQuery();

                                command.CommandText = Sql;
                                command.ExecuteNonQuery();
                            }
                        }
                        break;
                    case 2:





                        break;
                    case 3:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Создает табличку в базе данных Test
        /// </summary>
        public void CreateTable_Test()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    case 1:
                        string Sql = "Create table IF NOT EXISTS  Test (Id_test Serial not null CONSTRAINT PK_Id_Test PRIMARY KEY," +
                            "Name_Test  varchar," +
                            "test_id Serial );";
                        using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionStringPostGreSQL))
                        {
                            npgsqlConnection.Open();
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.Connection = npgsqlConnection;

                            command.CommandText = Sql;
                            command.ExecuteNonQuery();
                        }
                        break;

                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Создает табличку в базе данных Test_Questions
        /// </summary>
        public void CreateTable_Test_Questions()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    case 1:
                        string Sql = "Create table IF NOT EXISTS  Test_Questions" +
                            "(Id_Questions Serial not null CONSTRAINT PK_Id_Questions PRIMARY KEY," +
                            "Name_Test  varchar not null," +
                            "Questions varchar not null," +
                            "Answers varchar not null);";
                        using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionStringPostGreSQL))
                        {
                            npgsqlConnection.Open();
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.Connection = npgsqlConnection;
                            command.CommandText = Sql;
                            command.ExecuteNonQuery();

                        }

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Создает табличку в базе данных пользователями 
        /// </summary>
        public void CreateTable_Users()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    case 1:
                        string Sql = "Create table IF NOT EXISTS  Users(Id Serial not null CONSTRAINT PK_Id PRIMARY KEY," +
                            "Name_Employee Varchar not null," +
                            "Passwords Varchar not null," +
                            "Rechte Serial not null," +
                            "DataMess TIMESTAMP  null DEFAULT(CURRENT_TIMESTAMP)," +
                            "Employee_Mail VARCHAR not null CONSTRAINT CH_Employee_Mail CHECK(Employee_Mail like '%@%.%'));";

                        using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionStringPostGreSQL))
                        {
                            npgsqlConnection.Open();
                            NpgsqlCommand command = new NpgsqlCommand();
                            command.Connection = npgsqlConnection;

                            command.CommandText = Sql;
                            command.ExecuteNonQuery();
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        /// <summary>
        /// Добавляеет пользователя и проверяет его по имени если есть такой пользователь то не создовать
        /// </summary>
        public void Regis_user(Regis_users regis_Users)
        {
            try
            {
#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
                bool Exists_User = false;
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется

                //    string Check_User = $"Select from User Where Name_Employee and Name_Employee ={regis_Users.Employee_Mail}";




                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.Where(p => p.Name_Employee == regis_Users.Name_Employee);
                    if (users == null)
                    {

                    }
                    else
                    {

                        foreach (User user in users)
                        {
                            Exists_User = true;
                            Console.WriteLine($"{user.Name_Employee} ({user.Name_Employee})");
                        }
                    }
                }



                DateTime dateTime = DateTime.Now;
                var data = $"{dateTime:F}";

                Roles roles = new Roles { Id = regis_Users.Rechte };


                // добавление данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User
                    User user1 = new User { Name_Employee = regis_Users.Name_Employee, Password = regis_Users.Password, DataMess = data, Id_roles_users = roles.Id, Employee_Mail = regis_Users.Employee_Mail };
                    //  User user2 = new User { Name = "Alice", Age = 26 };


                    // добавляем их в бд
                    db.Users.AddRange(user1);
                    db.SaveChanges();
                }

                //using (ApplicationContext db = new ApplicationContext())
                //{
                //    // получаем объекты из бд и выводим на консоль
                //    var users = db.Users.ToList();
                //    Console.WriteLine("Users list:");
                //    foreach (User u in users)
                //    {
                //        //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //    }
                //}

                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.ToList();
                    if (users == null)
                    {

                    }
                    else
                    {

                        foreach (User user in users)
                        {
                            Exists_User = true;
                            Travel = new Regis_users(user.Id, user.Name_Employee, user.Password, user.Id_roles_users, user.Employee_Mail);

                            Console.WriteLine($"{user.Name_Employee} ({user.Name_Employee})");
                        }
                    }
                }
                /*
                //if (Exists_User == false)
                //{
                //    string sql = $"INSERT INTO Users (Name_Employee,passwords,rechte, employee_mail) VALUES ('{regis_Users.Name_Employee}','{regis_Users.Password}',{regis_Users.Rechte},'{regis_Users.Employee_Mail}');";
                //    using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                //    {
                //        connection.Open();
                //        NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                //        command.CommandText = sql;
                //        command.ExecuteNonQuery();
                //        string sq = "SELECT id, name_employee, passwords, rechte, datamess, employee_mail\r\n\tFROM public.users;";
                //        command.CommandText = sq;
                //        command.ExecuteNonQuery();
                //        NpgsqlDataReader sqReader = command.ExecuteReader();

                //        while (sqReader.Read())
                //        {
                //            Travel = new Regis_users(Convert.ToInt32(sqReader["id"]), sqReader["Name_Employee"].ToString(), sqReader["passwords"].ToString(), Convert.ToInt32(sqReader["Rechte"]), sqReader["employee_mail"].ToString());
                //        }
                //        sqReader.Close();

                //    }
                //}
                //else
                //{
                //    //   Travel = new Regis_users(0,"False" ,"",1,"");
                //}*/

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }


        /// <summary>
        /// Проверка  почты пароля  авторизация  и проверяет по почте есть ли пользователь  
        /// </summary>
        public void Check_login_amail(CheckMail_and_Password checkMail_And_Password)
        {
            try
            {
                bool Check = false;
                //     int Current_User;

                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.Where(p => p.Employee_Mail == checkMail_And_Password.Employee_Mail && p.Password == checkMail_And_Password.Password);
                    if (users == null)
                    {

                    }
                    else
                    {

                        foreach (User user in users)
                        {
                            Check = true;
                            Travel = new Regis_users(user.Id, user.Name_Employee, user.Password, user.Id_roles_users, user.Employee_Mail);

                            Console.WriteLine($"{user.Name_Employee} ({user.Name_Employee})");
                        }
                    }
                }

                if (Check == false)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var users = db.Users.Where(p => p.Employee_Mail == checkMail_And_Password.Employee_Mail);

                        if (users == null)
                        {

                        }
                        else
                        {
                            foreach (User user in users)
                            {
                                // Check = true;
                                Travel = new Regis_users(0, "", "", 0, user.Employee_Mail);

                                Console.WriteLine($"{user.Name_Employee} ({user.Name_Employee})");
                            }
                        }

                    }
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Check_Tests()
        {
            try
            {


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        //Roles
        public void Check_Roles()
        {
            int Count_roles = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Roles.Count();
                Count_roles = users;
                // Console.WriteLine("Users list:");
                //foreach (int  u in users)
                //{

                //    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //}
            }


            if (Count_roles == 1)
            {

            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    var users = db.Roles.ToList();
                    Console.WriteLine("Users list:");
                    foreach (Roles u in users)
                    {

                        //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                    }
                }
            }
            Count_Roles = Count_roles;
        }

        public void Check_Questin()
        {
            try
            {
                int Count = 0;
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    Count = db.Questions.Count();
                }
                if (Count == 0)
                {
                    Questions[] questions = new Questions[1];
                    questions[0].QuestionName = "";

                    questionss = questions;
                }
                else
                {


                    Questions[] questions = new Questions[Count];
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // получаем объекты из бд и выводим на консоль
                        var users = db.Questions.ToList();
                        Console.WriteLine("Users list:");
                        int i = 0;
                        foreach (Questions u in users)
                        {

                            questions[i] = new Questions { Id = u.Id, QuestionName = u.QuestionName, AnswerTrue = u.AnswerTrue };
                            i++;  //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                        }
                    }
                    questionss = questions;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Insert_Questin(Questions Questions)
        {
            bool Вопрос = false;
            //Проверка вопрос на уникальный
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Questions.Where(p => p.QuestionName == Questions.QuestionName);
                Console.WriteLine("Users list:");
                int i = 0;
                Questions[] questions = new Questions[1];
                foreach (Questions u in users)
                {

                    Вопрос = true;
                    questions[i] = new Questions { Id = 0, QuestionName = u.QuestionName, AnswerTrue = u.AnswerTrue };
                    // i++;  //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
                if (questions == null)
                {

                }
                else
                {
                    questionss = questions;

                }

            }
            if (Вопрос == false)
            {
                // добавление данных
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User
                    Questions user1 = new Questions { QuestionName = Questions.QuestionName, AnswerTrue = Questions.AnswerTrue };
                    //  User user2 = new User { Name = "Alice", Age = 26 };


                    // добавляем их в бд
                    db.Questions.AddRange(user1);
                    db.SaveChanges();
                }

                int Count = 0;
                using (ApplicationContext db = new ApplicationContext())
                {
                    // получаем объекты из бд и выводим на консоль
                    Count = db.Questions.Count();
                }
                if (Count == 0)
                {

                }
                else
                {
                    Questions[] questions = new Questions[Count];
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // получаем объекты из бд и выводим на консоль
                        var users = db.Questions.ToList();
                        Console.WriteLine("Users list:");
                        int i = 0;
                        foreach (Questions u in users)
                        {

                            questions[i] = new Questions { Id = u.Id, QuestionName = u.QuestionName, AnswerTrue = u.AnswerTrue };
                            i++;  //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                        }
                    }
                    questionss = questions;
                }
            }
            else
            {

            }
        }

        public void Check_Users_test_insert()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                Count = db.Users.Count();
            }
            if (Count == 0)
            {

            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.ToList();
                    if (users == null)
                    {

                    }
                    else
                    {

                        Regis_users[] regis_Users = new Regis_users[Count];
                        int i = 0;

                        foreach (User user in users)
                        {

                            regis_Users[i] = new Regis_users(user.Id, user.Name_Employee, user.Password, user.Id_roles_users, user.Employee_Mail);
                            i++;
                        }
                        Travels = regis_Users;
                    }
                }
            }
        }

        public void Check_Users_ds()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                Count = db.Users.Count();
            }
            if (Count == 0)
            {
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var users = db.Users.ToList();
                    if (users == null)
                    {
                    }
                    else
                    {
                        UserListTest = users;
                    }
                }
            }
        }

        public void Update_Users_ds(User updatedUser)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Retrieve the existing user from the database based on the user's ID
                User existingUser = db.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

                if (existingUser != null)
                {
                    // Update the properties of the existing user with the new values
                    existingUser.Name_Employee = updatedUser.Name_Employee;
                    existingUser.Password = updatedUser.Password;
                    existingUser.DataMess = updatedUser.DataMess;
                    existingUser.Id_roles_users = updatedUser.Id_roles_users;
                    existingUser.Employee_Mail = updatedUser.Employee_Mail;

                    // Save the changes to the database
                    db.SaveChanges();
                }
            }
        }

        public void Create_Users_ds(User newUser)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User
                {
                    Name_Employee = newUser.Name_Employee,
                    Password = newUser.Password,
                    DataMess = newUser.DataMess,
                    Id_roles_users = newUser.Id_roles_users,
                    Employee_Mail = newUser.Employee_Mail
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Del_Users_ds(int userId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }


        public void Create_Test_ds(Test newTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Test test = new Test
                {
                    Name_Test = newTest.Name_Test,
                    Options_Id = newTest.Options_Id
                };

                db.Test.Add(test);
                db.SaveChanges();
            }
        }

        public void Del_Test_ds(int testId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Test test = db.Test.FirstOrDefault(t => t.Id == testId);
                if (test != null)
                {
                    db.Test.Remove(test);
                    db.SaveChanges();
                }
            }
        }

        public void Update_Test_ds(Test updatedTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Retrieve the existing test from the database based on the test's ID
                Test existingTest = db.Test.FirstOrDefault(t => t.Id == updatedTest.Id);
                if (existingTest != null)
                {
                    // Update the properties of the existing test with the new values
                    existingTest.Name_Test = updatedTest.Name_Test;
                    existingTest.Options_Id = updatedTest.Options_Id;

                    // Save the changes to the database
                    db.SaveChanges();
                }
            }
        }

        public void Check_Test_ds()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                // Get the count of tests from the database
                Count = db.Test.Count();
            }

            if (Count == 0)
            {
                // Handle the case when there are no tests
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var tests = db.Test.ToList();
                    if (tests == null)
                    {
                        // Handle the case when the tests list is null
                    }
                    else
                    {
                        TestListTest = tests;
                    }
                }
            }
        }


        // для класса Exams
        public void Create_Exams_ds(Exams newExams)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Exams exams = new Exams
                {
                    Name_exam = newExams.Name_exam,
                    // Options_Id = newTest.Options_Id
                };
                db.Exams.Add(exams);
                db.SaveChanges();
            }
        }

        public void Del_Exams_ds(int ExamsId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Exams exams = db.Exams.FirstOrDefault(t => t.Id == ExamsId);
                if (exams != null)
                {
                    db.Exams.Remove(exams);
                    db.SaveChanges();
                }
            }
        }

        public void Update_Exams_ds(Exams updatedExams)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Exams existingExams = db.Exams.FirstOrDefault(t => t.Id == updatedExams.Id);
                if (existingExams != null)
                {
                    existingExams.Name_exam = updatedExams.Name_exam;
                    //existingTest.Options_Id = updatedTest.Options_Id;
                    db.SaveChanges();
                }
            }
        }

        public void Check_Exams_ds()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                Count = db.Exams.Count();
            }
            if (Count == 0)
            {
                // Handle the case when there are no exams
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var exams = db.Exams.ToList();
                    if (exams == null)
                    {
                        // Handle the case when the exams list is null
                    }
                    else
                    {
                        ExamsListTest = exams;
                    }
                }
            }
        }

        // Для класса Questions

        public void Create_Questions_ds(Questions newQuestions)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Questions questions = new Questions
                {
                    QuestionName = newQuestions.QuestionName,
                    AnswerTrue = newQuestions.AnswerTrue,
                    Grade = newQuestions.Grade
                };
                db.Questions.Add(questions);
                db.SaveChanges();
            }
        }

        public void Del_Questions_ds(int QuestionsId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Questions questions = db.Questions.FirstOrDefault(t => t.Id == QuestionsId);
                if (questions != null)
                {
                    db.Questions.Remove(questions);
                    db.SaveChanges();
                }
            }
        }

        public void Update_Questions_ds(Questions updatedQuestions)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Questions existingQuestions = db.Questions.FirstOrDefault(t => t.Id == updatedQuestions.Id);
                if (existingQuestions != null)
                {
                    existingQuestions.QuestionName = updatedQuestions.QuestionName;
                    existingQuestions.AnswerTrue = updatedQuestions.AnswerTrue;
                    existingQuestions.Grade = updatedQuestions.Grade;
                    db.SaveChanges();
                }
            }
        }

        public void Check_Questions_ds()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                Count = db.Questions.Count();
            }
            if (Count == 0)
            {
                // Handle the case when there are no questions
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var questions = db.Questions.ToList();
                    if (questions == null)
                    {
                        // Handle the case when the questions list is null
                    }
                    else
                    {
                        QuestionsListTest = questions;
                    }
                }
            }
        }

        // For the Answers class
        public void Create_Answers_ds(Answer newAnswers)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Questions question = null;

                Answer answer = new Answer
                {
                    AnswerOptions = newAnswers.AnswerOptions,
                    CorrectAnswers = newAnswers.CorrectAnswers,
                };
                db.Answer.Add(answer);
                db.SaveChanges();
            }
        }

        public void Del_Answers_ds(int AnswersId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Answer answers = db.Answer.FirstOrDefault(t => t.Id == AnswersId);
                if (answers != null)
                {
                    db.Answer.Remove(answers);
                    db.SaveChanges();
                }
            }
        }

        public void Update_Answers_ds(Answer updatedAnswers)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Answer existingAnswers = db.Answer.FirstOrDefault(t => t.Id == updatedAnswers.Id);
                if (existingAnswers != null)
                {
                    existingAnswers.AnswerOptions = updatedAnswers.AnswerOptions;
                    existingAnswers.CorrectAnswers = updatedAnswers.CorrectAnswers;
                    db.SaveChanges();
                }
            }
        }
        public void Check_Answers_ds()
        {
            int Count = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                Count = db.Answer.Count();
            }
            if (Count == 0)
            {
                // Handle the case when there are no answers
            }
            else
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var answers = db.Answer.ToList();
                    if (answers == null)
                    {
                        // Handle the case when the answers list is null
                    }
                    else
                    {
                        AnswerListTest = answers;
                    }
                }
            }
        }

        // для TestQuestion

        public void Create_TestQuestions_ds(TestQuestion newTestQuestions)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                TestQuestion questions = new TestQuestion();

                // Retrieve the Test and Questions objects from the database
                Test test = db.Test.Find(newTestQuestions.IdTest.Id);
                Questions questions1 = db.Questions.Find(newTestQuestions.IdQuestions.Id);

                // Assign the retrieved objects to the TestQuestion properties
                questions.IdTest = test;
                questions.IdQuestions = questions1;

                db.TestQuestion.Add(questions);
                db.SaveChanges();
            }
        }

        public void Del_TestQuestions_ds(int TestQuestionsId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                TestQuestion testQuestions = db.TestQuestion.FirstOrDefault(t => t.Id == TestQuestionsId);
                if (testQuestions != null)
                {
                    db.TestQuestion.Remove(testQuestions);
                    db.SaveChanges();
                }
            }
        }

        public void Update_TestQuestions_ds(TestQuestion updatedTestQuestions)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                TestQuestion existingTestQuestions = db.TestQuestion.FirstOrDefault(t => t.Id == updatedTestQuestions.Id);
                if (existingTestQuestions != null)
                {
                    existingTestQuestions.IdTest = updatedTestQuestions.IdTest;
                    existingTestQuestions.IdQuestions = updatedTestQuestions.IdQuestions;
                    db.SaveChanges();
                }
            }
        }

        public void Check_TestQuestions_ds(Test test)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int count = db.TestQuestion.Count();
                if (count == 0)
                {
                    // Обработка случая, когда нет вопросов в тесте
                }
                else
                {
                    var testQuestions = db.TestQuestion
                        .Include(tq => tq.IdTest)
                        .Include(tq => tq.IdQuestions)
                        .Where(tq => tq.IdTest != null && tq.IdTest.Id == test.Id)
                        .ToList();

                    if (testQuestions == null)
                    {
                        // Обработка случая, когда список вопросов равен null
                    }
                    else
                    {
                        // Используйте список testQuestions по мере необходимости
                        TestQuestionListTest = testQuestions;
                    }
                }
            }
        }


        // For the QuestionAnswer class

        public void CreateQuestionAnswer_ds(QuestionAnswer newQuestionAnswer)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                QuestionAnswer questionAnswer = new QuestionAnswer();

                Questions questions = db.Questions.Find(newQuestionAnswer.Questions.Id);
                questionAnswer.Questions = questions;
                questionAnswer.CorrectAnswers = newQuestionAnswer.CorrectAnswers;
                questionAnswer.Grade = newQuestionAnswer.Grade;
                Answer answer = db.Answer.Find(newQuestionAnswer.Answer.Id);

                questionAnswer.Answer = answer;

                db.QuestionAnswer.Add(questionAnswer);
                db.SaveChanges();
            }
        }

        public void DeleteQuestionAnswer_ds(int testQuestionId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                QuestionAnswer testQuestion = db.QuestionAnswer.FirstOrDefault(tq => tq.Id == testQuestionId);
                if (testQuestion != null)
                {
                    db.QuestionAnswer.Remove(testQuestion);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateQuestionAnswer_ds(QuestionAnswer updatedQuestionAnswer)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                QuestionAnswer existingQuestionAnswer = db.QuestionAnswer.FirstOrDefault(tq => tq.Id == updatedQuestionAnswer.Id);
                if (existingQuestionAnswer != null)
                {
                    existingQuestionAnswer.Questions.Id = updatedQuestionAnswer.Questions.Id;
                    db.SaveChanges();
                }
            }
        }

        public void CheckQuestionAnswer_ds(Questions questions)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var testQuestions = db.QuestionAnswer
                    .Include(tq => tq.Questions)
                    .Include(tq => tq.Answer)
                    .Where(tq => tq.Questions != null && tq.Questions.Id == questions.Id)
                    .ToList();
                QuestionAnswerListTest = testQuestions;
            }
        }


        // For the ExamsTest class
        public void CreateExamsTest_ds(ExamsTest newExamsTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ExamsTest examsTest = new ExamsTest();
                Exams exams = db.Exams.Find(newExamsTest.Exams.Id);
                examsTest.Exams = exams;
                Test test = db.Test.Find(newExamsTest.Test.Id);
                examsTest.Test = test;
                db.ExamsTest.Add(examsTest);
                db.SaveChanges();
            }
        }

        public void DeleteExamsTest_ds(int testId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ExamsTest examsTest = db.ExamsTest.FirstOrDefault(et => et.Id == testId);
                if (examsTest != null)
                {
                    db.ExamsTest.Remove(examsTest);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateExamsTest_ds(ExamsTest updatedExamsTest)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ExamsTest existingExamsTest = db.ExamsTest.FirstOrDefault(et => et.Id == updatedExamsTest.Id);
                if (existingExamsTest != null)
                {
                    existingExamsTest.Exams.Id = updatedExamsTest.Exams.Id;
                    db.SaveChanges();
                }
            }
        }

        public void CheckExamsTest_ds(Exams exams)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var examsTests = db.ExamsTest
                    .Include(et => et.Exams)
                    .Include(et => et.Test)
                    .Where(et => et.Exams != null && et.Exams.Id == exams.Id)
                    .ToList();
                ExamsTestListTest = examsTests;
            }
        }


        // For the UserExams class
        public void CreateUserExams_ds(UserExams newUserExams)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UserExams userExams = new UserExams();
                User user = db.Users.Find(newUserExams.User.Id);
                userExams.User = user;
                Exams exams = db.Exams.Find(newUserExams.Exams.Id);
                userExams.Exams = exams;
                db.UserExams.Add(userExams);
                db.SaveChanges();
            }
        }

        public void DeleteUserExams_ds(int userExamsId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UserExams userExams = db.UserExams.FirstOrDefault(ue => ue.Id == userExamsId);
                if (userExams != null)
                {
                    db.UserExams.Remove(userExams);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateUserExams_ds(UserExams updatedUserExams)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                UserExams existingUserExams = db.UserExams.FirstOrDefault(ue => ue.Id == updatedUserExams.Id);
                if (existingUserExams != null)
                {
                    existingUserExams.User.Id = updatedUserExams.User.Id;
                    db.SaveChanges();
                }
            }
        }

        public void CheckUserExams_ds(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var userExams = db.UserExams
                    .Include(ue => ue.User)
                    .Include(ue => ue.Exams)
                    .Where(ue => ue.Exams != null && ue.Exams.Id == user.Id)
                    .ToList();
                UserExamsListTest = userExams;
            }
        }


    }
}
