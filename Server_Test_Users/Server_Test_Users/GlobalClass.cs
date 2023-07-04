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




#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        /// <summary>
        /// Отсылает клиенту ответ 
        /// </summary>
        public Regis_users Regis_users { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.





#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        /// <summary>
        /// Посылаем клиенту 
        /// </summary>
        public Regis_users Travel { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
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
                            "Name_Employee varchar not null," +
                            "Password varchar not null," +
                            "Rechte Serial not null" +
                            "DataMess TIMESTAMP NOT NULL," +
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
                string Check_User = $"Select  * From User Where Name_Employee = '{regis_Users.Name_Employee}'";
                using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(Check_User, connection);
                    command.CommandText = Check_User;
                    command.ExecuteNonQuery();
                    NpgsqlDataReader sqReader = command.ExecuteReader();

                    if (sqReader.HasRows == true)
                    {
                        //int id_telegram_user = 0;
                        Console.WriteLine("Такое имя уже есть");
                        Exists_User = true;
                        // Always call Read before accessing data.
                        while (sqReader.Read())
                        {
                        }
                    }
                }

#pragma warning disable CS0665 // Назначение в условном выражении всегда является константой
                if (Exists_User = false)
                {
                    DateTime dateTime = DateTime.Now;

                    string sql = $"INSERT INTO Users (Name_Employee,Password,Rechte,Employee_Mail,DataMess) VALUES ({regis_Users.Name_Employee},{regis_Users.Password},'{regis_Users.Rechte}','{regis_Users.Employee_Mail}','{dateTime:s}')";
                    using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                    {
                        connection.Open();
                        NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    Regis_users.Name_Employee = "";

                }
                else
                {
                    Regis_users.Name_Employee = "Пользователь зарегистрирован !";
                }
#pragma warning restore CS0665 // Назначение в условном выражении всегда является константой

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        public void Check_login_amail(CheckMail_and_Password checkMail_And_Password)
        {
            try {
                int Current_User;
                string sqlExpressiol = $"SELECT * FROM Users  WHERE Employee_Mail = '{checkMail_And_Password.Employee_Mail}' and Password='{checkMail_And_Password.Password}'";

                using (var connection = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                {
                    connection.Open();
                    NpgsqlCommand command = new NpgsqlCommand(sqlExpressiol, connection);
                    NpgsqlDataReader sqReader = command.ExecuteReader();

                    if (sqReader.HasRows == true)
                    {
                        // Always call Read before accessing data.
                        while (sqReader.Read())
                        {
                            Current_User = Convert.ToInt32(sqReader["Id"]);
                            int Image = Convert.ToInt32(sqReader["Image"].ToString());
                            int Id = Convert.ToInt32(Current_User);
                            Travel = new Regis_users(Id, sqReader["Name_Employee"].ToString(), sqReader["Password"].ToString(), Convert.ToInt32(sqReader["Rechte"]), sqReader["Employee_Mail"].ToString());
                        }
                        sqReader.Close();
                        string buton = $"UPDATE Users SET Id_Telegram =   WHERE Id = ''";
                    }
                    else
                    {
                        string sqlExpressi = $"SELECT * FROM Users  WHERE Employee_Mail = '{checkMail_And_Password.Employee_Mail}'";
                        using (var connectio = new NpgsqlConnection(GlobalClass.connectionStringPostGreSQL))
                        {
                            connectio.Open();
                            NpgsqlCommand _command = new NpgsqlCommand(sqlExpressi, connectio);
                            //NpgsqlCommand __commandS = new NpgsqlCommand(sqlExpressi, connectio);
                            NpgsqlDataReader sqReaders = _command.ExecuteReader();
                            if (sqReaders.HasRows == true)
                            {
                                // Always call Read before accessing data.
                                while (sqReaders.Read())
                                {
                                    //       Current_User = sqReader["Id"].ToString();
                                    Travel = new Regis_users(Convert.ToInt32(sqReaders["Id"]), sqReaders["Name_Employee"].ToString(), "", 0, sqReader["Employee_Mail"].ToString());

                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    connection.Close();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
