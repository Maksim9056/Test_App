﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interaction_Users
{


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Questions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Answers { get; set; }
    }





    /// <summary>
    /// Класс настройки конфигурации
    /// </summary>
    /// 
    public class Client
    {
        public string Ip_adress { get; set; }
        public Client(string ip_adress)
        {
            Ip_adress = ip_adress;
        }
    }

    [Serializable]
    public class Seting
    {
        Seting() { }
        /// <summary>
        /// Ip_адресс
        /// </summary>
        public string Ip_adress {  get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public int  Port { get; set; }

        /// <summary>
        /// Тип Sql
        /// </summary>
        public int TypeSQL { get; set; }

       
        public Seting(string ip_adress, int port, int typeSQL)
        {
            Ip_adress = ip_adress;
            Port = port;
            TypeSQL = typeSQL;
        }

    }

    [Serializable]
    /// <summary>
    /// Класс Regis_users для регестрации пользователей
    /// </summary>
    public class Regis_users
    {
        public Regis_users() { }
        public int Id { get; set; }
        public   string Name_Employee { get; set; }
        public string Password { get; set; }

        public int  Rechte { get; set; }
        public string Employee_Mail { get; set; }
                   
        public Regis_users(int id, string name_Employee, string password,int rechte,string @Mail)
        {
            Id = id; 
            Name_Employee = name_Employee;
            Password = password;
            Rechte = rechte;
            Employee_Mail = @Mail;
        }
    }

    [Serializable]
    /// <summary>
    /// Класс Regis_users для регестрации пользователей
    /// </summary>
    public class CheckMail_and_Password
    {
        public CheckMail_and_Password() { }


        public string Password { get; set; }

        public string Employee_Mail { get; set; }

        public CheckMail_and_Password(string password, string @Mail)
        {

            Password = password;

            Employee_Mail = @Mail;
        }
    }

        [Serializable]
        /// <summary>
        /// Класс  для регестрации пользователей и прошедших авторизацию
        /// </summary>
        public class CheckMails
        {
            public CheckMails() { }
            public Regis_users Users { get; set; }
            public CheckMails(Regis_users users)
            {
                Users = users;
            }
        }

        [Serializable]
        /// <summary>
        /// Класс  для названия теста которые создали
        /// </summary>
        public class Test
        {
            public Test() { }
            public int Id { get; set; }
            public string Tests { get; set; }
            public Test(int id,string tests)
            {
                Id = id;
                Tests = tests;
            }
        }


        [Serializable]
        /// <summary>
        /// Класс  для Test запоковываем
        /// </summary>
        public class Tests
        {
            public Tests() { }

            public Test[] TEST { get; set; }

            public Tests (Test[] test)
            {
                TEST = test;
            }
        }


         [Serializable]
        /// <summary>
        /// Класс  для Tests запоковываем в List
        /// </summary>
        public class  Tests_Travel
        {
            public List<Tests> Test { get; set; } = new List<Tests>();

        }

    
}
