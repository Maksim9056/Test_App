using System;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using Class_interaction_Users;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Class_interaction_Users.CheckMail_and_Password;

namespace Server_Test_Users
{
    internal class GlobalClass
    {
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




        /// <summary>
        /// Отсылает клиенту ответ 
        /// </summary>
        public Regis_users? Regis_users { get; set; }


        public bool Tru_user { get; set; } = false;


        /// <summary>
        /// Посылаем клиенту 
        /// </summary>
        public Regis_users? Travel { get; set; }
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
        public  void  CreateTable_Test()
        {
            try
            {
                switch (TypeSQL)
                {
                    //Postgres
                    case 1:
                        string Sql = "Create table IF NOT EXISTS  Test (Id_test Serial not null CONSTRAINT PK_Id_Test PRIMARY KEY," +
                            "Name_Test  varchar );";
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
        public  void CreateTable_Test_Questions()
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
        public  void CreateTable_Users()
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
                string Check_User = $"  Select * From Users where name_employee  = '{regis_Users.Name_Employee}'";
                using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(Check_User, connection);
                    command.CommandText = Check_User;
                    command.ExecuteNonQuery();
                    NpgsqlDataReader sqReader = command.ExecuteReader();

                    if (sqReader.HasRows == true)
                    {
                     
                        Exists_User = true;
                        // Always call Read before accessing data.
                        while (sqReader.Read())
                        {

                        }
                    }
                } DateTime dateTime = DateTime.Now;

                if (Exists_User == false)
                {
                    string sql = $"INSERT INTO Users (Name_Employee,passwords,rechte, employee_mail) VALUES ('{regis_Users.Name_Employee}','{regis_Users.Password}',{regis_Users.Rechte},'{regis_Users.Employee_Mail}');";
                    using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                    {
                        connection.Open();
                        NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        string sq = "SELECT id, name_employee, passwords, rechte, datamess, employee_mail\r\n\tFROM public.users;";
                        command.CommandText = sq; 
                        command.ExecuteNonQuery();
                        NpgsqlDataReader sqReader = command.ExecuteReader();

                        while (sqReader.Read())
                        {
                            Travel = new Regis_users(Convert.ToInt32(sqReader["id"]), sqReader["Name_Employee"].ToString(), sqReader["passwords"].ToString(), Convert.ToInt32(sqReader["Rechte"]), sqReader["employee_mail"].ToString());
                        }
                        sqReader.Close();

                    }
                }
                else
                {
                 //   Travel = new Regis_users(0,"False" ,"",1,"");
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void Check_login_amail(CheckMail_and_Password checkMail_And_Password)
        {
            try
            {
                bool Check = false;
                int Current_User;
                string sqlExpressiol = $"SELECT * FROM Users  WHERE employee_mail = '{checkMail_And_Password.Employee_Mail}' and Passwords ='{checkMail_And_Password.Password}'";
                using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sqlExpressiol, connection);
                    NpgsqlDataReader sqReader = command.ExecuteReader();
                    if (sqReader.HasRows == true)
                    {
                        Tru_user = true;
                        while (sqReader.Read())
                        {
                            Current_User = Convert.ToInt32(sqReader["id"]);
                            int Id = Convert.ToInt32(Current_User);
                            Travel = new Regis_users(Id, sqReader["Name_Employee"].ToString(), sqReader["passwords"].ToString(), Convert.ToInt32(sqReader["Rechte"]), sqReader["employee_mail"].ToString());
                        }
                        sqReader.Close();
                    }
                    else
                    {
                        Check = true;
                    }
                    connection.Close();
                }

                if (Check == true)
                {
                    string sqlExpressi = $"SELECT * FROM Users  WHERE Employee_Mail = '{checkMail_And_Password.Employee_Mail}'";
                    using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                    {
                        connection.Open();
                        NpgsqlCommand command = new NpgsqlCommand(sqlExpressi, connection);
                        NpgsqlDataReader sqReader = command.ExecuteReader();
                        //NpgsqlCommand __commandS = new NpgsqlCommand(sqlExpressi, connectio);

                        if (sqReader.HasRows == true)
                        {
                            Tru_user = true;
                            // Always call Read before accessing data.
                            while (sqReader.Read())
                            {
                                Travel = new Regis_users(0, "", "", 0, sqReader["Employee_Mail"].ToString());
                            }
                            sqReader.Close();
                        }
                        else
                        {

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
    }
}
