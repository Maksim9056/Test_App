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

            public DbSet<Test_Questions> Test_Questions { get; set; } = null!;
            public DbSet<Answer> Answers { get; set; } = null!;
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
                    Questions [] questions= new Questions[1];
                    questions[0].Questionss = "";

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

                            questions[i] = new Questions { Id = u.Id, Questionss = u.Questionss, Answer_True = u.Answer_True };
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
                var users = db.Questions.Where(p => p.Questionss == Questions.Questionss);
                Console.WriteLine("Users list:");
                int i = 0;
                Questions[] questions = new Questions[1];
                foreach (Questions u in users)
                {

                    Вопрос = true;
                    questions[i] = new Questions { Id = 0, Questionss = u.Questionss, Answer_True = u.Answer_True };
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
                    Questions user1 = new Questions { Questionss = Questions.Questionss, Answer_True = Questions.Answer_True };
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

                            questions[i] = new Questions { Id = u.Id, Questionss = u.Questionss, Answer_True = u.Answer_True };
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



    }
}
