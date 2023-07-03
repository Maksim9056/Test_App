using System.Data;
using System.Diagnostics;
using Npgsql;
namespace Server_Test_Users
{
    internal class GlobalClass
    {
        /// <summary>
        /// Тип Sql
        /// </summary>
        public static int TypeSQL { get;  set; }

        /// <summary>
        /// Запрос приложения   
        /// </summary>
        public static string connectionStringPostGreSQL = $"Host=localhost;Port=5432;Database=Test;Username=postgres;Password=1";


        public static string _connectionStringPostGreSQl = $"Host=localhost;Port=5432;Username=postgres;Password=1";
        public void Create_Database()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres

                    case 1:
                        string Sql = "CREATE DATABASE IF NOT EXISTS Test;";

                        using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionStringPostGreSQl))
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateTable_Test()
        {
            try
            {
                switch (TypeSQL)
                {
                   //Postgres
                    case 1:
                        string Sql = "Create table Test (Id_test Serial not null CONSTRAINT PK_Id_test PRIMARY KEY," +
                            "Name_Test  varchar not null);";
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

        public void CreateTable_Friends()
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

        public void CreateTable_Users()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    case 1:
                        string Sql = "Create table IF NOT EXISTS  Users(Id Serial not null CONSTRAINT PK_Id PRIMARY KEY," +
                            "Name_Employee varchar not null," +
                            "Password varchar not null," +
                            "Rechte Serial not null," +
                            "Employee_Mail VARCHAR not null CONSTRAINT CH_Suppler_E_Mail CHECK(Suppler_E_Mail like '%@%.%'));";
                       
                        using(NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionStringPostGreSQL))
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
    }
}