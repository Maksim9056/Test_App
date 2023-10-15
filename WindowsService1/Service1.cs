using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {  
    }

        protected override void OnStop()
        {
        }
    }
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

            string DATE = "";
            var date = dateTime.ToString();
            var dates = date.Replace('.', '_');

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
                    context.BackupDatabasePostgreSQL(path + $"\\Postgres" + $"\\Cоздания_резервной_копии дата_{DATE}" + ".bak", "Testdb");
                    break;
                case 2: // SQLite


                    context.BackupDatabaseSQLite(path + "\\Sqlite" + $"\\Cоздания_резервной_копии дата_{DATE}" + ".bak");
                    break;
                case 3: // SQL Server


                    break;
                    //context.BackupDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb");
                    //context.RestoreDatabasePostgreSQL("C:\\Development\\2\\путь_к_файлу_резервной_копии.bak", "Testdb","1");
            }








        }
    }
}
