using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Class_interaction_Users;
using System.Text.Json;

namespace Servis
{
    public class SettingStart
    {
        public bool Users = false;
        /// <summary>
        /// Ip адрес
        /// </summary>
        static public string Ip_Adress { get; set; }
        /// <summary>
        /// Порт
        /// </summary>
        static public Int32 port { get; set; }
        /// <summary>
        /// Данные
        /// </summary>
        public static string data_ { get; set; }


        Logging logging = new Logging();

        public void Starting()
        {
            try
            {
                GlobalClass globalClass = new GlobalClass();
                SaveOpen();

                globalClass.TestSQL();
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

                int counter = 0;
                RegisterCommands();
                globalClass.Catalog_Add();

                //globalClass.DBackup();

                //globalClass.CatalogView();
                server.Start();
                Console.WriteLine("\nСервер запушен");
                while (true)
                {
                    Console.WriteLine("\nОжидание соединения...");
                    ThreadPool.UnsafeQueueUserWorkItem(ClientProcessing, server.AcceptTcpClient());
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
        static Dictionary<string, Action<byte[], GlobalClass, NetworkStream, Logging>> FDictCommands = new Dictionary<string, Action<byte[], GlobalClass, NetworkStream, Logging>>();

        public static void RegisterCommands()
        {
            try
            {
                Command command = new Command();
                FDictCommands.Add("001", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Registration_users));
                FDictCommands.Add("002", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Registration_users));
                FDictCommands.Add("003", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CheckMail_and_Passwords));
                FDictCommands.Add("004", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Check_test));
                FDictCommands.Add("005", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Check_test));
                FDictCommands.Add("006", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Select_job_title));
                FDictCommands.Add("007", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Search_Image));
                FDictCommands.Add("008", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Searh_Friends));
                FDictCommands.Add("009", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Insert_Message));
                FDictCommands.Add("010", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Message));
                FDictCommands.Add("011", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Delete_Message));
                FDictCommands.Add("012", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.List_Friens_Message));
                FDictCommands.Add("013", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.List_Friens));
                FDictCommands.Add("014", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Search_Image_Friends));
                FDictCommands.Add("015", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Check_Users_test_insert));

                FDictCommands.Add("016", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Check_Users));  // Получить список User
                FDictCommands.Add("017", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Users)); // Изменить данные User
                FDictCommands.Add("018", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_Users)); // Создать данные User
                FDictCommands.Add("019", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_Users));    // Удалить данные User 

                FDictCommands.Add("020", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_Test));
                FDictCommands.Add("021", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Test));
                FDictCommands.Add("022", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_Test));
                FDictCommands.Add("023", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_TestList));

                FDictCommands.Add("024", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_Exams));
                FDictCommands.Add("025", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Exams));
                FDictCommands.Add("026", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_Exams));
                FDictCommands.Add("027", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_ExamsList));

                FDictCommands.Add("028", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_Questions));
                FDictCommands.Add("029", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Questions));
                FDictCommands.Add("030", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_Questions));
                FDictCommands.Add("031", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_QuestionsList));

                FDictCommands.Add("032", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_TestQuestions));
                FDictCommands.Add("033", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_TestQuestions));
                FDictCommands.Add("034", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_TestQuestions));
                FDictCommands.Add("035", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_TestQuestionsList));

                FDictCommands.Add("036", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_QuestionAnswer));
                FDictCommands.Add("037", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_QuestionAnswer));
                FDictCommands.Add("038", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_QuestionAnswer));
                FDictCommands.Add("039", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_QuestionAnswerList));

                FDictCommands.Add("040", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_Answer));
                FDictCommands.Add("041", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_Answer));
                FDictCommands.Add("042", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_Answer));
                FDictCommands.Add("043", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_AnswerList));

                FDictCommands.Add("044", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_ExamsTest));
                FDictCommands.Add("045", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_ExamsTest));
                FDictCommands.Add("046", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_ExamsTest));
                FDictCommands.Add("047", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_ExamsTestList));

                FDictCommands.Add("048", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Create_UserExams));
                FDictCommands.Add("049", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Update_UserExams));
                FDictCommands.Add("050", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Del_UserExams));
                FDictCommands.Add("051", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Get_UserExamsList));

                FDictCommands.Add("052", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.SaveTestUsers));//Сохраняет Тест
                FDictCommands.Add("053", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CheckExamUsers));//Проверяет Екзамен 
                FDictCommands.Add("054", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CheckTestUsers));//Проверяет Екзамен 
                FDictCommands.Add("055", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CheckStatickUserResult));
                FDictCommands.Add("056", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CheckPingIpAdress));
                FDictCommands.Add("057", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.SaveUserImage));
                FDictCommands.Add("058", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.SelectFromFilles));
                //РАБОТА С РЕЗЕРВНОЙ КОПИЕЙ
                FDictCommands.Add("059", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.DBackup));//Создают резервную копию
                FDictCommands.Add("060", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.Restoring_a_backup)); //Востановить из резервной копии
                FDictCommands.Add("061", new Action<byte[], GlobalClass, NetworkStream, Logging>(command.CatalogView)); //Просмотр резервной копии которая существует




            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        static void HandleCommand(string aCommand, byte[] data, GlobalClass cls, NetworkStream ns, Logging logging)
        {
            Action<byte[], GlobalClass, NetworkStream, Logging> actionCommand;
            if (FDictCommands.TryGetValue(aCommand, out actionCommand)) actionCommand(data, cls, ns, logging);
            else
            {
                // Если не нашли, то обрабатываем это }
            }
        }

        public static void ClientProcessing(object client_obj)
        {
            try
            {
                using (TcpClient client = client_obj as TcpClient)
                {


                    GlobalClass globalClass = new GlobalClass();
                    NetworkStream stream = client.GetStream();
                    Command command = new Command();
                    Logging logging = new Logging();
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
                    HandleCommand(comand, msg, globalClass, stream, logging);
                }
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
                        Seting _aFile = JsonSerializer.Deserialize<Seting>(fs);
                        Ip_Adress = _aFile.Ip_adress;
                        port = _aFile.Port;
                        GlobalClass.TypeSQL = _aFile.TypeSQL;

                    }
                }
                else
                {
                    using (FileStream fileStream = new FileStream("Server.json", FileMode.OpenOrCreate))
                    {
                        Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 2);
                        JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);

                    }

                    using (FileStream fileStream = new FileStream("Server.json", FileMode.OpenOrCreate))
                    {
                        Seting aFile = JsonSerializer.Deserialize<Seting>(fileStream);

                        Ip_Adress = aFile.Ip_adress;
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
