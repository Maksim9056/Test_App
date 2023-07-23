﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Class_interaction_Users;
using System.IO;
using System.Text.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Server_Test_Users
{
    internal class Program
    {
        public bool Users = false;
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        /// <summary>
        /// Ip адрес
        /// </summary>
        static public string Ip_Adress { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        /// <summary>
        /// Порт
        /// </summary>
        static public Int32 port { get; set; }
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        /// <summary>
        /// Данные
        /// </summary>
        public static string data_ { get; set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.


#pragma warning disable IDE0060 // Удалите неиспользуемый параметр


        static void Main(string[] args)
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
        {

            try
            {
                GlobalClass globalClass = new GlobalClass();
                SaveOpen();

                globalClass.TestSQL();

                globalClass.Create_Database();
               
                globalClass.CreateTable_Test();
               
                globalClass.CreateTable_Users();
                
                globalClass.CreateTable_Test_Questions();

                TcpListener server;

                int MaxThreadsCount = Environment.ProcessorCount;
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);

                IPAddress localAddr = IPAddress.Parse(Ip_Adress);
                Console.WriteLine();
                server = new TcpListener(localAddr, port);
                Console.WriteLine("Конфигурация многопоточного сервера:" + MaxThreadsCount.ToString());
                Console.WriteLine("Пользователь:" + Environment.UserName.ToString());
                Console.WriteLine("IP-адрес :" + Ip_Adress.ToString());
                Console.WriteLine("Путь:" + Environment.CurrentDirectory.ToString());
                ;
                int counter = 0;
                RegisterCommands();
                server.Start();
                Console.WriteLine("\nСервер запушен");
                while (true)
                {
                    Console.WriteLine("\nОжидание соединения...");
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                    ThreadPool.UnsafeQueueUserWorkItem(ClientProcessing, server.AcceptTcpClient());
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
                    counter++;
                    Console.Write("\nСоединие№" + counter.ToString() + "!");

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException:{0}", e.Message);
            }
            Console.WriteLine("\nНажмите Enter");
            Console.Read();

        }


        static Dictionary<string, Action<byte[], GlobalClass, NetworkStream>> FDictCommands = new Dictionary<string, Action<byte[], GlobalClass, NetworkStream>>();

        static void RegisterCommands()
        {
            try
            {
                Command command = new Command();
                FDictCommands.Add("001", new Action<byte[], GlobalClass, NetworkStream>(command.Registration_users));
                FDictCommands.Add("002", new Action<byte[], GlobalClass, NetworkStream>(command.Registration_users));
                FDictCommands.Add("003", new Action<byte[], GlobalClass, NetworkStream>(command.CheckMail_and_Passwords));
                FDictCommands.Add("004", new Action<byte[], GlobalClass, NetworkStream>(command.Check_test));
                FDictCommands.Add("005", new Action<byte[], GlobalClass, NetworkStream>(command.Check_test));
                FDictCommands.Add("006", new Action<byte[], GlobalClass, NetworkStream>(command.Select_job_title));
                FDictCommands.Add("007", new Action<byte[], GlobalClass, NetworkStream>(command.Search_Image));
                FDictCommands.Add("008", new Action<byte[], GlobalClass, NetworkStream>(command.Searh_Friends));
                FDictCommands.Add("009", new Action<byte[], GlobalClass, NetworkStream>(command.Insert_Message));
                FDictCommands.Add("010", new Action<byte[], GlobalClass, NetworkStream>(command.Update_Message));
                FDictCommands.Add("011", new Action<byte[], GlobalClass, NetworkStream>(command.Delete_Message));
                FDictCommands.Add("012", new Action<byte[], GlobalClass, NetworkStream>(command.List_Friens_Message));
                FDictCommands.Add("013", new Action<byte[], GlobalClass, NetworkStream>(command.List_Friens));
                FDictCommands.Add("014", new Action<byte[], GlobalClass, NetworkStream>(command.Search_Image_Friends));
                FDictCommands.Add("015", new Action<byte[], GlobalClass, NetworkStream>(command.Check_Users_test_insert));
                FDictCommands.Add("016", new Action<byte[], GlobalClass, NetworkStream>(command.Check_Users));  // Получить список User
                FDictCommands.Add("017", new Action<byte[], GlobalClass, NetworkStream>(command.Update_Users)); // Изменить данные User
                FDictCommands.Add("018", new Action<byte[], GlobalClass, NetworkStream>(command.Create_Users)); // Создать данные User
                FDictCommands.Add("019", new Action<byte[], GlobalClass, NetworkStream>(command.Del_Users));    // Удалить данные User
                FDictCommands.Add("020", new Action<byte[], GlobalClass, NetworkStream>(command.Create_Test));  
                FDictCommands.Add("021", new Action<byte[], GlobalClass, NetworkStream>(command.Update_Test));  
                FDictCommands.Add("022", new Action<byte[], GlobalClass, NetworkStream>(command.Del_Test));
                FDictCommands.Add("023", new Action<byte[], GlobalClass, NetworkStream>(command.Get_TestList));
                FDictCommands.Add("024", new Action<byte[], GlobalClass, NetworkStream>(command.Create_Exams));
                FDictCommands.Add("025", new Action<byte[], GlobalClass, NetworkStream>(command.Update_Exams));
                FDictCommands.Add("026", new Action<byte[], GlobalClass, NetworkStream>(command.Del_Exams));
                FDictCommands.Add("027", new Action<byte[], GlobalClass, NetworkStream>(command.Get_ExamsList));
                FDictCommands.Add("028", new Action<byte[], GlobalClass, NetworkStream>(command.Create_Questions));
                FDictCommands.Add("029", new Action<byte[], GlobalClass, NetworkStream>(command.Update_Questions));
                FDictCommands.Add("030", new Action<byte[], GlobalClass, NetworkStream>(command.Del_Questions));
                FDictCommands.Add("031", new Action<byte[], GlobalClass, NetworkStream>(command.Get_QuestionsList));


            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        static void HandleCommand(string aCommand, byte[] data, GlobalClass cls, NetworkStream ns)
        {
            Action<byte[], GlobalClass, NetworkStream> actionCommand;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            if (FDictCommands.TryGetValue(aCommand, out actionCommand)) actionCommand(data, cls, ns);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            else
            {
                // Если не нашли, то обрабатываем это }
            }
        }

        private static void ClientProcessing(object client_obj)
        {
            try
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                using (TcpClient client = client_obj as TcpClient)
                {


                    GlobalClass globalClass = new GlobalClass();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                    NetworkStream stream = client.GetStream();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                    Command command = new Command();

                    String responseData = String.Empty;
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseData = completeMessage.ToString();
                    string comand = responseData.Substring(0, 3);
                    string json = responseData.Substring(3, responseData.Length - 3);
                    data_ = json;
                    byte[] msg = Encoding.Default.GetBytes(json);
                    HandleCommand(comand, msg, globalClass, stream);
                }
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Загружаеться Ip_address и port
        /// </summary>
        static public void SaveOpen()
        {

            try
            {
                string path = Environment.CurrentDirectory.ToString();
                FileInfo fileInfo = new FileInfo(path + "\\Server.json");

                //Если есть то загружаем настройки сервера если нет то создают
                if (fileInfo.Exists)
                {
                    using (FileStream fs = new FileStream("Server.json", FileMode.Open))
                    {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                        Seting _aFile = JsonSerializer.Deserialize<Seting>(fs);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                        Ip_Adress = _aFile.Ip_adress;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                        port = _aFile.Port;
                        GlobalClass.TypeSQL = _aFile.TypeSQL;
                   
                    }
                }
                else
                {
                    using (FileStream fileStream = new FileStream("Server.json", FileMode.OpenOrCreate))
                    {
                        Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 1);
                        JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);

                    }

                    using (FileStream fileStream = new FileStream("Server.json", FileMode.OpenOrCreate))
                    {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                        Seting aFile = JsonSerializer.Deserialize<Seting>(fileStream);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                        Ip_Adress = aFile.Ip_adress;
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                        port = aFile.Port;
                        GlobalClass.TypeSQL = aFile.TypeSQL;



                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

//Console.WriteLine(Environment.MachineName);
//Console.WriteLine(Environment.WorkingSet);
/*   //  Console.WriteLine(Environment.WorkingSet);
 */
/* IPHostEntry ipEntry = Dns.GetHostByName(Dns.GetHostName());
foreach (var a in ipEntry.AddressList) {
Console.WriteLine(a);

}*/
/*   //string Host = System.Net.Dns.GetHostName();
   //string Ip_adres=      System.Net.Dns.Resolve();
   Console.WriteLine($"Ip-адрес: {localAddr}");            
   //127.0.0.1 System.Net.Sockets.AddressFamily family   */
//Console.WriteLine("\nСервер запушен")
/*
                        //byte[] bytes = new byte[99999999];
                       //    string data;
                       // StringBuilder data;
                       // /*
                        //int i;
                        //while ((i = await stream.ReadAsync(bytes, 0, bytes.Length)) != 0)
                        //{
                        //    data = Encoding.Default.GetString(bytes, 0, i);
                        //    string comand = data.Substring(0, 3);
                        //    string json = data.Substring(3, data.Length - 3);
                        //    byte[] msg = Encoding.Default.GetBytes(json);

                        //    //Заменяет работу switch (comand)
                        //    HandleCommand(comand, msg, globalClass, stream);


                        //}                */