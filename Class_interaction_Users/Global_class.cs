using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_interaction_Users
{

    /// <summary>
    /// Класс настройки конфигурации
    /// </summary>
    /// 

    [Serializable]
    public class Seting
    {
        Seting() { }
        /// <summary>
        /// Ip_адресс
        /// </summary>
        public string         Ip_adress {  get; set; }

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

        public CheckMail_and_Password( string password, string @Mail)
        {
   
            Password = password;

            Employee_Mail = @Mail;
        }





        [Serializable]
        /// <summary>
        /// Класс  для регестрации пользователей и прошедших авторизацию
        /// </summary>
        public class CheckMails
        {
            public CheckMails() { }


            public Regis_users _Users { get; set; }

        //   public string Employee_Mail { get; set; }
          

            public CheckMails(Regis_users Users/* string @Mail*/)
            {

                _Users = Users;

               // Employee_Mail = @Mail;
            }
        }
    }
}
