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
using System.Collections.Generic;
using System.Security.Claims;
using System.Runtime.Serialization.Formatters;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IO;
using static Server_Test_Users.Logging;
//using Microsoft.Extensions.Options;

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


#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Regis_users[] Travels { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<User> UserListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Test> TestListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Exams> ExamsListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Questions> QuestionsListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Answer> AnswerListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<TestQuestion> TestQuestionListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<QuestionAnswer> QuestionAnswerListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<ExamsTest> ExamsTestListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<UserExams> UserExamsListTest { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Questions[] questionss { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.





#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Save_results> save_Results { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public List<Save_results> Test_Results { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

      public  List<Statictics> StatickUsers { get; set; }

    public  string path = Environment.CurrentDirectory.ToString();

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
            public DbSet<Class_interaction_Users.Options> Options { get; set; } = null!;
            public DbSet<Test> Test { get; set; } = null!;
            public DbSet<Exam> Exam { get; set; } = null!;
            public DbSet<Exams> Exams { get; set; } = null!;
            public DbSet<Save_results> Save_Results { get; set; } = null!;
            public DbSet<Filles> Filles { get; set; } = null!;

            public ApplicationContext()
            {
                // Database.EnsureDeleted(); // гарантируем, что бд удалена
                Database.EnsureCreated(); // гарантируем, что бд будет созд
                                          // Database.Migrate();  // миграция
                                          // Database.MigrateAsync(); // асинхронный метод для миграции
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                switch (TypeSQL)
                {
                    case 1: // Postgres
                        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Testdb;Username=postgres;Password=1");
                        break;
                    case 2: // SQLite
                        optionsBuilder.UseSqlite("Data Source=helloapp.db");
                        break;
                    case 3: // SQL Server
                        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
                        break;
                }
            }
            public void BackupDatabaseMSSQL(string backupFilePath)
            {
                using (var connection = Database.GetDbConnection() as SqlConnection)
                {
                    var query = $"BACKUP DATABASE Testdb TO DISK = '{backupFilePath}'";
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            //public void BackupDatabasePosgree(string backupFilePath)
            //{
            //    using (var connection = Database.GetDbConnection() as NpgsqlConnection)
            //    {
            //        var query = $"pg_dump -Fc -f {backupFilePath} Testdb";
            //        connection.Open();

            //        using (var command = new NpgsqlCommand(query, connection))
            //        {
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //public void BackupDatabasePostgreSQL(string backupFilePath, string databaseName)
            //{
            //    // Строка подключения к базе данных PostgreSQL
            //    string connectionString = "Host=localhost;Port=5432;Database=Testdb;Username=postgres;Password=1";

            //    // Создаем подключение к базе данных PostgreSQL
            //    using (var connection = new NpgsqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        // Создаем команду для выполнения pg_dump
            //        using (var command = new NpgsqlCommand())
            //        {
            //            command.Connection = connection;
            //            command.CommandText = $"pg_dump -Fc -f {backupFilePath} {databaseName}";

            //            // Запускаем pg_dump
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            public void BackupDatabasePostgreSQL(string backupFilePath, string databaseName)
            {
                // Команда для выполнения pg_dump
                string pg_dumpCommand = $"-U postgres -h localhost -p 5432 -Ft -f \"{backupFilePath}\" {databaseName}";

                // Создаем новый процесс для выполнения команды
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "pg_dump";
                startInfo.Arguments = pg_dumpCommand;
                // Задаем пароль
                startInfo.EnvironmentVariables.Add("PGPASSWORD", "1");

                // Запускаем процесс и ожидаем его завершения
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // Проверяем код возврата процесса
                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine("Ошибка при выполнении pg_dump");
                    }
                    Console.WriteLine("Резервная копия успешно создана.");

                }
            }

            public void RestoreDatabasePostgreSQL(string backupFilePath, string databaseName, string password)
            {
                // Команда для выполнения pg_restore
                string pg_restoreCommand = $"-U postgres -h localhost -p 5432 -c -d {databaseName} \"{backupFilePath}\"";

                // Создаем новый процесс для выполнения команды
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "pg_restore";
                startInfo.Arguments = pg_restoreCommand;

                // Задаем пароль
                startInfo.EnvironmentVariables.Add("PGPASSWORD", password);

                // Запускаем процесс и ожидаем его завершения
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    // Проверяем код возврата процесса
                    if (process.ExitCode != 0)
                    {
                        Console.WriteLine("Ошибка при выполнении pg_restore");
                    }
                }
            }


            public void BackupDatabaseSQLite(string backupFilePath)
            {
                using (var connection = new SqliteConnection("Data Source=helloapp.db"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = $"ATTACH DATABASE '{backupFilePath}' AS backup";
                        command.ExecuteNonQuery();

                        command.CommandText = "SELECT sql FROM sqlite_master WHERE sql NOT NULL AND type = 'table'";
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var createTableSql = reader.GetString(0);
                                command.CommandText = createTableSql.Replace("CREATE TABLE", "CREATE TABLE backup.");
                                command.ExecuteNonQuery();
                            }
                        }

                        command.CommandText = "DETACH DATABASE backup";
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

            //    Console.WriteLine("Резервная копия успешно создана.");
                Console.WriteLine($"Путь к резервной копии: {backupFilePath}");
                //using (var backup = new SqliteConnection("Data Source=helloapp.db"))
                //{


                //    // Create a full backup of the database

                //    backup.BackupDatabase(backup, backupFilePath,"Sqlite_путь_к_файлу_резервной_копии.bak");
                //}
            }
        }

        public void DBackup()
        {
            using (var context = new ApplicationContext())
            {
               // string path = Environment.CurrentDirectory.ToString();


                List<string> list = new List<string>();
                DateTime dateTime = DateTime.Now;

                string DATE ="";
                var date = dateTime.ToString();
                var dates = date.Replace('.','_');

                var DA = dates.Replace(':', '_');
                for (int i = 0; i < DA.Length; i++)
                {
                    if (DA[i].ToString() == "13")
                    {
                        DATE += "_";
                    }
                    else
                    {
                        list.Add(DA[i].ToString());
                    


                    }
                }
                DATE = "";
                list.RemoveAt(10);
                list.Insert(10, "_");
                for (int i = 0; i < list.Count(); i++)
                {
                    if (list[i] == "")
                    {
                      
                    }
                    else
                    {


                        DATE += list[i].ToString();  

                    }
                }

                switch (TypeSQL)
                {
                    case 1: // Postgres
                        context.BackupDatabasePostgreSQL(path + $"\\Postgres"+ $"\\Cоздания_резервной_копии дата_{DATE}"+".bak", "Testdb");
                        break;
                    case 2: // SQLite


                        context. BackupDatabaseSQLite(path + "\\Sqlite" + $"\\Cоздания_резервной_копии дата_{DATE}"+".bak");
                        break;
                    case 3: // SQL Server

                  
                    break;
                        //context.BackupDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb");
                        //context.RestoreDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb","1");
                }








            }
        }


        public string [] CatalogView()
        {
          //  string path = Environment.CurrentDirectory.ToString();
          string[] list = null;
            switch (TypeSQL)
            {
                case 1: // Postgres
               


                    // Проверяем, существует ли заданная папка
                    if (Directory.Exists(path +"\\Postgres"))
                    {
                        // Получаем список файлов в папке
                        string[] fileList = Directory.GetFiles(path + "\\Postgres");

                        if (fileList.Length == 0)
                        {

                        }
                        else
                        {


                            string[] fileLists = new string[fileList.Length];

                            for (int i = 0; i < fileList.Length; i++)
                            {
                                fileLists[i] = Path.GetFileName(fileList[i]);
                            }
                            // Выводим названия файлов
                            list = fileLists;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Указанная папка не существует.");
                    }
                    break;
                case 2: // SQLite


         
                    //// Проверяем, существует ли заданная папка
                    //if (Directory.Exists(path + "\\Sqlite"))
                    //{
                    //    // Получаем список файлов в папке
                    //    string[] fileList = Directory.GetFiles(path + "\\Sqlite");

                    //    // Выводим названия файлов
                    //    foreach (string filePath in fileList)
                    //    {
                    //        string fileName = Path.GetFileName(filePath);
                    //        Console.WriteLine(fileName);
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Указанная папка не существует.");
                    //}
                    break;
                case 3: // SQL Server


                    break;
                    //context.BackupDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb");
                    //context.RestoreDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb","1");
            }
            return list;
        }
        public void Restoring_a_backup(string File)
        {


            switch (TypeSQL)
            {     
                case 1: // Postgres
                    using (ApplicationContext db = new ApplicationContext())
                    {
                     
                        db.RestoreDatabasePostgreSQL(path + "\\Postgres\\"+ File , "Testdb","1");

                    }   
                   
             
                    break;
                case 2: // SQLite



                    //// Проверяем, существует ли заданная папка
                    //if (Directory.Exists(path + "\\Sqlite"))
                    //{
                    //    // Получаем список файлов в папке
                    //    string[] fileList = Directory.GetFiles(path + "\\Sqlite");

                    //    // Выводим названия файлов
                    //    foreach (string filePath in fileList)
                    //    {
                    //        string fileName = Path.GetFileName(filePath);
                    //        Console.WriteLine(fileName);
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Указанная папка не существует.");
                    //}
                    break;
                case 3: // SQL Server


                break;
                    //context.BackupDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb");
                    //context.RestoreDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb","1");
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


            }

         
          //  string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'MyAir-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            if (Count_roles > 0)
            {

                //var backupFilePath = Environment.CurrentDirectory.ToString(); // Замените на путь, где вы хотите сохранить резервную копию
                //                                                              // Создание подключения к базе данных PostgreSQL
                //using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                //{
                //    var NAME = Environment.MachineName;
                //    connection.Open();
                //    string backupPath = $"{backupFilePath} \\Backup.bak";
                //    string backupQuery = $"BACKUP DATABASE Testdb TO DISK = '{backupPath}'";
                
                //    NpgsqlCommand command = new NpgsqlCommand(backupQuery, connection);
              
                  
                //    command.ExecuteNonQuery();
                // }
                    //     var connectionString = "Host=localhost;Port=5432;Database=Testdb;Username=postgres;Password=1"; // Замените на свою строку подключения         

                    //      string connectionSмtring = "YourConnectionString";







                    // db.Database.SqlQueryRaw(sqlCommand,);
                    // Создание SQL-команды для выполнения резервного копирования

                    //using (var command = new NpgsqlCommand($"pg_dump -U <username> -Fc -f {backupFilePath} <database_name>", connection))
                    //{
                    //    // Замените "<username>" на имя пользователя для подключения к PostgreSQL
                    //    // Замените "<database_name>" на имя базы данных, которую вы хотите скопировать

                    //    // Выполнение команды резервного копирования
                    //    command.ExecuteNonQuery();
                    //}
               

            }
            else
            {
                // Console.WriteLine("Users list:");
                //foreach (int  u in users)
                //{
                //    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //}
                int D = 0;
                using (ApplicationContext context = new ApplicationContext())
                {
                    D = context.Roles.Count();
                }

                if (D == 0)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // создаем два объекта User

                        Roles user1 = new Roles { Name_roles = "Пользователь" };
                        // добавляем их в бд
                        db.Roles.AddRange(user1);
                        db.SaveChanges();
                    }


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
                        Filles filles = new Filles() { Id = 0};
                        User user1 = new User { Name_Employee = "Admin", Password = "Admin", DataMess = data, Id_roles_users = 2, Employee_Mail = Email,Email = filles };

                        // добавляем их в бд
                        db.Users.AddRange(user1);
                        db.SaveChanges();
                    }
                }
                else
                {


                }
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


                // добавление данных Максим@Максим.ru
                using (ApplicationContext db = new ApplicationContext())
                {



                   
                   DateTime dateTime = DateTime.Now;
                   var data = $"{dateTime:F}";

                  Roles roles = new Roles { Id = regis_Users.Rechte.Id };

                   Filles filles =  db.Filles.FirstOrDefault( ue =>ue.Id == regis_Users.Filles );

                    // создаем два объекта User
                    User user1 = new User { Name_Employee = regis_Users.Name_Employee,
                        Password = regis_Users.Password,
                        DataMess = data,
                        Id_roles_users = roles.Id,
                        Employee_Mail = regis_Users.Employee_Mail,
                        Email = filles


                    };
                    
                    // добавляем их в бд
                    db.Users.AddRange(user1);
                    db.SaveChanges();
                }

      
                using (ApplicationContext db = new ApplicationContext())
                {
                    Filles filles = db.Filles.FirstOrDefault(ue => ue.Id == regis_Users.Filles);
                    var users = db.Users.FirstOrDefault(ue => ue.Name_Employee == regis_Users.Name_Employee && ue.Employee_Mail == regis_Users.Employee_Mail && ue.Email == filles);
                    if (users == null)
                    {

                    }
                    else
                    {


                            User user = users;

                            Exists_User = true;
                            Roles roles1 = new Roles { Id = user.Id_roles_users };

                            Travel = new Regis_users(user.Id, user.Name_Employee, user.Password, roles1, user.Employee_Mail, user.Email.Id);

                            Console.WriteLine($"{user.Name_Employee} ({user.Name_Employee})");
                        
                    }
                }
             

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
                bool d = false;
                bool Check = false;
                // int Current_User;
                Roles roles1 = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    var use = db.Filles.ToList();
                 
                    var user = db.Users.FirstOrDefault (p => p.Employee_Mail == checkMail_And_Password.Employee_Mail && p.Password == checkMail_And_Password.Password  && p.Email == use[0]);
                  
                    if (user != null)
                    {
                        Check = true;

                        bool Game = true;
                        if(user == null)
                        {

                        }
                        else
                        {
                         Roles roles = new Roles { Id = user.Id_roles_users };
                            roles1 = roles;
                        }

                        if(user.Email == null)
                        {
                            Game = false;

                            do
                            {
                                for (int i = 0; i < use.Count(); i++)
                                {
                                    var n = db.Users.FirstOrDefault(p => p.Employee_Mail == checkMail_And_Password.Employee_Mail && p.Password == checkMail_And_Password.Password && p.Email == use[i]);

                                    if (n == null)
                                    {

                                    }
                                    else
                                    {
                                        Roles roles = new Roles { Id = user.Id_roles_users };
                                        roles1 = roles;
                                    }
                                 

                                    if (n.Email == null)
                                    {

                                    }
                                    else
                                    {
                                        Travel = new Regis_users(n.Id, n.Name_Employee, n.Password, roles1, n.Employee_Mail, n.Email.Id);
                                        d = true;
                                        Check = true;

                                        break;
                                    }

                                }



                            } while (d == true);  
                            Console.WriteLine($"{user.Name_Employee} ({user.Employee_Mail})");

                            
                        }

                        if(Game == true)
                        {
                         Travel = new Regis_users(user.Id, user.Name_Employee, user.Password, roles1, user.Employee_Mail, user.Email.Id);

                        }

                    }
                    else
                    {
                        Check = false;

                        bool Game = true;
                        if (user == null)
                        {

                        }
                        else
                        {
                            Roles roles = new Roles { Id = user.Id_roles_users };
                            roles1 = roles;
                        }
                        
                        if (user == null)
                        {
                            Game = false;

                            do
                            {
                                for (int i = 0; i < use.Count(); i++)
                                {
                                    var n = db.Users.FirstOrDefault(p => p.Employee_Mail == checkMail_And_Password.Employee_Mail && p.Password == checkMail_And_Password.Password && p.Email == use[i]);

                                    if (n == null)
                                    {

                                    }
                                    else
                                    {
                                        Roles roles = new Roles { Id = n.Id_roles_users };
                                        roles1 = roles;
                                    }

                                    if(n == null)
                                    {

                                    }
                                    else
                                    {
                                    if (n.Email == null)
                                    {

                                    }
                                    else
                                    {
                                        Travel = new Regis_users(n.Id, n.Name_Employee, n.Password, roles1, n.Employee_Mail, n.Email.Id);
                                        d = false;
                                            Check = true;

                                            break;
                                    }
                                    }

                                 

                                }



                            } while (d == true);

                            if(user == null)
                            {

                            }
                            else
                            {
                             Console.WriteLine($"{user.Name_Employee} ({user.Employee_Mail})");

                            }


                        }

                        if (Game == true)
                        {
                            Travel = new Regis_users(user.Id, user.Name_Employee, user.Password, roles1, user.Employee_Mail, user.Email.Id);

                        }
                    }
                }

                if (Check == false)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var users = db.Users.FirstOrDefault(p => p.Employee_Mail == checkMail_And_Password.Employee_Mail);

                        if (users != null)
                        {
                            Roles roles = new Roles { Id = 0 };
                            Travel = new Regis_users(0, "", "", roles, users.Employee_Mail,0);
                            Console.WriteLine($"{users.Name_Employee} ({users.Employee_Mail})");
                        }
                    }
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
        public Roles Check_Roles()
        {


            int Count_roles = 0;
            Roles roles = new Roles();
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Roles.FirstOrDefault(ue =>ue.Name_roles == "Пользователь");
                roles = users;

        
            }
            Count_Roles = Count_roles;
            return roles ;
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
                        int i = 0;
                        foreach (Questions u in users)
                        {

                            questions[i] = new Questions { Id = u.Id, QuestionName = u.QuestionName, AnswerTrue = u.AnswerTrue };
                            i++;  
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
                            Roles roles = new Roles { Id = user.Id };

                            regis_Users[i] = new Regis_users(user.Id, user.Name_Employee, user.Password, roles, user.Employee_Mail, user.Email.Id);
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                User existingUser = db.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

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
                    Employee_Mail = newUser.Employee_Mail,
                    Email = newUser.Email
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Del_Users_ds(int userId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                User user = db.Users.FirstOrDefault(u => u.Id == userId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Test test = db.Test.FirstOrDefault(t => t.Id == testId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Test existingTest = db.Test.FirstOrDefault(t => t.Id == updatedTest.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Exams exams = db.Exams.FirstOrDefault(t => t.Id == ExamsId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Exams existingExams = db.Exams.FirstOrDefault(t => t.Id == updatedExams.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Questions questions = db.Questions.FirstOrDefault(t => t.Id == QuestionsId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Questions existingQuestions = db.Questions.FirstOrDefault(t => t.Id == updatedQuestions.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Questions question = null;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется

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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Answer answers = db.Answer.FirstOrDefault(t => t.Id == AnswersId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Answer existingAnswers = db.Answer.FirstOrDefault(t => t.Id == updatedAnswers.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Test test = db.Test.Find(newTestQuestions.IdTest.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Questions questions1 = db.Questions.Find(newTestQuestions.IdQuestions.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                TestQuestion testQuestions = db.TestQuestion.FirstOrDefault(t => t.Id == TestQuestionsId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                TestQuestion existingTestQuestions = db.TestQuestion.FirstOrDefault(t => t.Id == updatedTestQuestions.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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

#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Questions questions = db.Questions.Find(newQuestionAnswer.Questions.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                questionAnswer.Questions = questions;
                questionAnswer.CorrectAnswers = newQuestionAnswer.CorrectAnswers;
                questionAnswer.Grade = newQuestionAnswer.Grade;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Answer answer = db.Answer.Find(newQuestionAnswer.Answer.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

                questionAnswer.Answer = answer;

                db.QuestionAnswer.Add(questionAnswer);
                db.SaveChanges();
            }
        }

        public void DeleteQuestionAnswer_ds(int testQuestionId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                QuestionAnswer testQuestion = db.QuestionAnswer.FirstOrDefault(tq => tq.Id == testQuestionId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                QuestionAnswer existingQuestionAnswer = db.QuestionAnswer.FirstOrDefault(tq => tq.Id == updatedQuestionAnswer.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Exams exams = db.Exams.Find(newExamsTest.Exams.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                examsTest.Exams = exams;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Test test = db.Test.Find(newExamsTest.Test.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                examsTest.Test = test;
                db.ExamsTest.Add(examsTest);
                db.SaveChanges();
            }
        }

        public void DeleteExamsTest_ds(int testId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                ExamsTest examsTest = db.ExamsTest.FirstOrDefault(et => et.Id == testId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                ExamsTest existingExamsTest = db.ExamsTest.FirstOrDefault(et => et.Id == updatedExamsTest.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                User user = db.Users.Find(newUserExams.User.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                userExams.User = user;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                Exams exams = db.Exams.Find(newUserExams.Exams.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                userExams.Exams = exams;
                db.UserExams.Add(userExams);
                db.SaveChanges();
            }
        }

        public void DeleteUserExams_ds(int userExamsId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                UserExams userExams = db.UserExams.FirstOrDefault(ue => ue.Id == userExamsId);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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

#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                UserExams existingUserExams = db.UserExams.FirstOrDefault(ue => ue.Id == updatedUserExams.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
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
                    .Where(ue => ue.User != null && ue.User.Id == user.Id)
                    .ToList();
                UserExamsListTest = userExams;
            }
        }




        public void SaveTestResultsAnswers(Save_results newUserExams)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var tt = db.QuestionAnswer
                        .Include(ue => ue.Questions)
                        .Include(ue => ue.Answer)
                        .FirstOrDefault(ue => ue.Id == Convert.ToInt32(newUserExams.Users_Answers_Questions));

                    List<QuestionAnswer> questionAnswers = db.QuestionAnswer
                        .Where(tq => tq.Answer.Id == tt.Id && tq.Answer.CorrectAnswers == tt.Answer.CorrectAnswers)
                        .ToList();

#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    Exams exam = db.Exams.FirstOrDefault(e => e.Id == newUserExams.Exam_id.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    Questions questions = db.Questions.FirstOrDefault(e => e.Id == newUserExams.Questions.Id);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    DateTime dateTime = DateTime.Now;
                    string data = dateTime.ToString("F");

#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    Test test = db.Test.FirstOrDefault(e => e.Name_Test == newUserExams.Name_Test.Name_Test);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

                    User user = db.Users.FirstOrDefault(e => e.Id == newUserExams.User_id.Id);

                    Questions questionss = db.Questions.FirstOrDefault(e => e.Id == newUserExams.Questions.Id);

                    QuestionAnswer questionAnswer = db.QuestionAnswer.FirstOrDefault(u => u.Answer.CorrectAnswers == tt.Answer.CorrectAnswers && u.Answer.Id == tt.Answer.Id);

                    Save_results userExams = new Save_results
                    {
                        Name_Test = test,
                        Exam_id = exam,
                        Date_of_Result_Exam_Endings = data,
                        Questions = questions,
                        Users_Answers_Questions = questions.AnswerTrue,
                        Name_Users = newUserExams.User_id.Name_Employee,
                        User_id = user,
                        Resukts_exam = questionAnswers.Count() == 0 ? 0 : questions.Grade
                    };

                    db.Save_Results.Add(userExams);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                // Обработка исключения
            }
        }
        public void CheckExam(CheckExam checkExam)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool CheckSave = false;

                Exams exam = db.Exams.FirstOrDefault(e => e.Id == checkExam.UserExams.Exams.Id);

                var examsTests = db.ExamsTest
                    .Include(et => et.Exams)
                    .Include(et => et.Test)
                    .Where(et => et.Exams != null && et.Exams.Id == checkExam.UserExams.Exams.Id)
                    .ToList();
                List<string> users = new List<string>();
                foreach (var examsTest in examsTests)
                {
                    users.Add(examsTest.Test.Name_Test);
                }
                User user = db.Users.FirstOrDefault(e => e.Id == checkExam.UserExams.User.Id);

                int f = 0;
                List<Save_results> results = new List<Save_results>();
                for (int i = 0; i < examsTests.Count(); i++)
                {
                    List<Save_results> userExams = db.Save_Results
                        .Include(ue => ue.Name_Test)
                        .Where(ue => ue.Exam_id == examsTests[i].Exams && ue.User_id == user && ue.Name_Test == examsTests[i].Test)
                        .ToList();
                    if (userExams.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        f++;
                        results = userExams;
                    }
                }

                bool Test = false;
                if (examsTests.Count() == f)
                {
                    Test = true;
                    save_Results = results;
                }
                else
                {
                    save_Results = new List<Save_results>();
                    Test = false;
                    Exams examsSS = new Exams();
                    examsSS.Id = 0;
                    Save_results save_ResultsS = new Save_results();
                    examsSS.Name_exam = "";
                    save_ResultsS.Exam_id = examsSS;
                    save_Results.Add(save_ResultsS);
                }

                var eXAMS = Test ? examsTests : new List<ExamsTest>();
            }
        }


        public void CheckTest(CheckUserTest CheckExams)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                bool CheckSave = false;

                Exams exam = db.Exams.FirstOrDefault(e => e.Id == CheckExams.Exams.Id);

                var examsTests = db.ExamsTest
                    .Include(et => et.Exams)
                    .Include(et => et.Test)
                    .Where(et => et.Exams != null && et.Exams.Id == CheckExams.Exams.Id)
                    .ToList();
                List<string> users = new List<string>();
                foreach (var examsTest in examsTests)
                {
                    users.Add(examsTest.Test.Name_Test);
                }
                User user = db.Users.FirstOrDefault(e => e.Id == CheckExams.CurrrentUser.Id);

                int f = 0;
                List<Save_results> results = new List<Save_results>();
                for (int i = 0; i < examsTests.Count(); i++)
                {
                    List<Save_results> userExams = db.Save_Results
                        .Include(ue => ue.Name_Test)
                        .Where(ue => ue.Exam_id == examsTests[i].Exams && ue.User_id == user && ue.Name_Test == examsTests[i].Test)
                        .ToList();
                    if (userExams.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        f++;
                        results = userExams;
                    }
                }

                bool Test = false;
                if (examsTests.Count() == f)
                {
                    Test = true;
                    save_Results = results;
                }
                else
                {
                    save_Results = new List<Save_results>();
                    Test = false;
                    Exams examsSS = new Exams();
                    examsSS.Id = 0;
                    Save_results save_ResultsS = new Save_results();
                    examsSS.Name_exam = "";
                    save_ResultsS.Exam_id = examsSS;
                    save_Results.Add(save_ResultsS);
                }

               
            }
        }


        /// <summary>
        /// Для статистике сразу сделай новую функцию чем каждый раз в клиенте   сделав сразу в одном блоке и  присылать результат полный 
        /// </summary>
        /// <param name="user"></param>
        public void CheckStatickUserResult(User user)
        {
            List<Statictics> statictics1 = new List<Statictics>();
            List<UserExams> UserExamsListTests = new List<UserExams>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var userExams = db.UserExams
                    .Include(ue => ue.User)
                    .Include(ue => ue.Exams)
                    .Where(ue => ue.User != null && ue.User.Id == user.Id)
                    .ToList();
                UserExamsListTests = userExams;
            }

            //Проверяем через цикл один экзамен
            for (int i = 0; i < UserExamsListTests.Count; i++)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var examsTests = db.ExamsTest
                        .Include(et => et.Exams)
                        .Include(et => et.Test)
                        .Where(et => et.Exams != null && et.Exams.Id == UserExamsListTests[i].Exams.Id)
                        .ToList();



                    //Здесь надо посмотреть к тесту вопросы 
                    for (int j = 0; j < examsTests.Count; j++)
                    {
                        //Здесь падает
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
                                .Where(tq => tq.IdTest != null && tq.IdTest.Id == examsTests[j].Test.Id)
                                .ToList();

                            if (testQuestions == null)
                            {
                                // Обработка случая, когда список вопросов равен null
                            }
                            else
                            {
                                TestQuestionListTest = new List<TestQuestion>();
                                // Используйте список testQuestions по мере необходимости
                                TestQuestionListTest = testQuestions;
                                 int Result = 0;
                               //Здесь проверяем 1 экзамен и тесты и вопросы TestQuestionListTest
                               for (int l = 0; l < TestQuestionListTest.Count; l++)
                               {

                                    User user1 = db.Users.FirstOrDefault(u => u.Id == user.Id);

                                var userExams = db.Save_Results.FirstOrDefault(ue => ue.Exam_id == examsTests[j].Exams && ue.User_id == user1 &&
                                ue.Name_Test == examsTests[j].Test && ue.Questions == TestQuestionListTest[l].IdQuestions);

                                    if(userExams == null)
                                    {

                                    }
                                    else
                                    {
                                        Result = Result + userExams.Resukts_exam;

                                    }
                                }

                                int Средний_балл = 0;
                                if (Result == 0)
                                {
                                   Средний_балл = 0;

                                     Statictics statictics = new Statictics(examsTests[j].Exams, examsTests[j].Test, Средний_балл);

                                    statictics1.Add(statictics);

                                }
                                else
                                {
                                    Средний_балл = Result / TestQuestionListTest.Count();
                                    Statictics statictics = new Statictics(examsTests[j].Exams, examsTests[j].Test, Средний_балл);

                                    statictics1.Add(statictics);

                                }

                                for(int d = 0; d < TestQuestionListTest.Count; d++)
                                {
                                    TestQuestionListTest.Clear();
                                }

                            }
                        }
                    }
                }  
            }
               
            StatickUsers = statictics1;
        }

        public Filles SaveUsersImage(Filles filless)
        {
            try
            {

                Filles filles = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User



                    db.Filles.AddRange(filless);
                    db.SaveChanges();

                    filles = db.Filles.FirstOrDefault(ue =>ue.Name == filless.Name);
                }
                return filles;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());

            }
            return null;
        }


        public Filles SelectFromFilles(Filles filless)
        {
            try
            {

                Filles filles = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    // создаем два объекта User


                    return filles = db.Filles.FirstOrDefault(ue => ue.Id == filless.Id); 
                }
                 ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
            return null;
        }





        public void Catalog_Add()
        {
            string path = Environment.CurrentDirectory.ToString();

            if (!Directory.Exists(path + "\\Postgres"))
            {
                Directory.CreateDirectory(path + "\\Postgres");
                Console.WriteLine($"Папка успешно создана! {path + "\\Postgres"}");
            }
            else
            {
                Console.WriteLine($"Папка с указанным путем уже существует: {path + "\\Postgres"}");
            }


            if (!Directory.Exists(path+"\\Sqlite"))
            {
                Directory.CreateDirectory(path + "\\Sqlite");
                Console.WriteLine($"Папка успешно создана!{path + "\\Sqlite"}");
            }
            else
            {
                Console.WriteLine($"Папка с указанным путем уже существует: {path + "\\Sqlite"}");
            }

            if (!Directory.Exists(path + "\\MSSql"))
            {
                Directory.CreateDirectory(path + "\\MSSql");
                Console.WriteLine($"Папка успешно создана!{path + "\\MSSql"}");
            }
            else
            {
                Console.WriteLine($"Папка с указанным путем уже существует: {path + "\\MSSql"}");
            }
        }
    }
}
