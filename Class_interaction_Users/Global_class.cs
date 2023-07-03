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
}
