using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Class_interaction_Users;
using System.IO;
using System.Text.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.ServiceProcess;

namespace Server_Test_Users
{
    public class Program
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


        Logging logging = new Logging();

         static void Main(string[] args)
         {

            try
            {
                   GlobalClass globalClass = new GlobalClass();
                    SaveOpen();

                    globalClass.TestSQL();

                    int MaxThreadsCount = Environment.ProcessorCount;
                    ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);

                    IPAddress localAddr = IPAddress.Parse(Ip_Adress);
                    Console.WriteLine();
                    Console.WriteLine("Конфигурация многопоточного сервера:" + MaxThreadsCount.ToString());
                    Console.WriteLine("Пользователь:" + Environment.UserName.ToString());
                    Console.WriteLine("IP-адрес :" + Ip_Adress.ToString());
                    Console.WriteLine("Путь:" + Environment.CurrentDirectory.ToString());

                    int counter = 0;
                    RegisterCommands();
                    globalClass.Catalog_Add();

                //globalClass.DBackup();

                //globalClass.CatalogView();
                TcpListener server;
                server = new TcpListener(localAddr, port);

                server.Start();
                    Console.WriteLine("\nСервер запушен");
                    while (true)
                    {
                        Console.WriteLine("\nОжидание соединения...");
                  //  ThreadPool.QueueUserWorkItem(ClientProcessing, client);
                    ThreadPool.QueueUserWorkItem(ClientProcessing, server.AcceptTcpClient());
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



        static Dictionary<string, Action<byte[], GlobalClass, NetworkStream, Logging, Mail>> FDictCommands = new Dictionary<string, Action<byte[], GlobalClass, NetworkStream, Logging, Mail>>();

        public   static void RegisterCommands()
        {
            try
            {
                
                Command command = new Command();
                FDictCommands.Add("001", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Registration_users));
                FDictCommands.Add("002", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Registration_users));
                FDictCommands.Add("003", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CheckMail_and_Passwords));
                FDictCommands.Add("004", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Check_test));
                FDictCommands.Add("005", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Check_test));
                FDictCommands.Add("006", new Action<byte[], GlobalClass, NetworkStream ,Logging, Mail>(command.Select_job_title));
                FDictCommands.Add("007", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Search_Image));
                FDictCommands.Add("008", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Searh_Friends));
                FDictCommands.Add("009", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Insert_Message));
                FDictCommands.Add("010", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Message));
                FDictCommands.Add("011", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Delete_Message));
                FDictCommands.Add("012", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.List_Friens_Message));
                FDictCommands.Add("013", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.List_Friens));
                FDictCommands.Add("014", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Search_Image_Friends));
                FDictCommands.Add("015", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Check_Users_test_insert));

                FDictCommands.Add("016", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Check_Users));  // Получить список User
                FDictCommands.Add("017", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Users)); // Изменить данные User
                FDictCommands.Add("018", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_Users)); // Создать данные User
                FDictCommands.Add("019", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_Users));    // Удалить данные User 

                FDictCommands.Add("020", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_Test));  
                FDictCommands.Add("021", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Test));  
                FDictCommands.Add("022", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_Test));
                FDictCommands.Add("023", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_TestList));

                FDictCommands.Add("024", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_Exams));
                FDictCommands.Add("025", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Exams));
                FDictCommands.Add("026", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_Exams));
                FDictCommands.Add("027", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_ExamsList));

                FDictCommands.Add("028", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_Questions));
                FDictCommands.Add("029", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Questions));
                FDictCommands.Add("030", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_Questions));
                FDictCommands.Add("031", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_QuestionsList));

                FDictCommands.Add("032", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_TestQuestions));
                FDictCommands.Add("033", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_TestQuestions));
                FDictCommands.Add("034", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_TestQuestions));
                FDictCommands.Add("035", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_TestQuestionsList));

                FDictCommands.Add("036", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_QuestionAnswer));
                FDictCommands.Add("037", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_QuestionAnswer));
                FDictCommands.Add("038", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_QuestionAnswer));
                FDictCommands.Add("039", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_QuestionAnswerList));

                FDictCommands.Add("040", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_Answer));
                FDictCommands.Add("041", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_Answer));
                FDictCommands.Add("042", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_Answer));
                FDictCommands.Add("043", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_AnswerList));

                FDictCommands.Add("044", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_ExamsTest));
                FDictCommands.Add("045", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_ExamsTest));
                FDictCommands.Add("046", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_ExamsTest));
                FDictCommands.Add("047", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_ExamsTestList));

                FDictCommands.Add("048", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Create_UserExams));
                FDictCommands.Add("049", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Update_UserExams));
                FDictCommands.Add("050", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Del_UserExams));
                FDictCommands.Add("051", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Get_UserExamsList));

                FDictCommands.Add("052", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.SaveTestUsers));//Сохраняет Тест
                FDictCommands.Add("053", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CheckExamUsers));//Проверяет Екзамен 
                FDictCommands.Add("054", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CheckTestUsers));//Проверяет Екзамен 
                FDictCommands.Add("055", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CheckStatickUserResult));
                FDictCommands.Add("056", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CheckPingIpAdress));
                FDictCommands.Add("057", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.SaveUserImage));
                FDictCommands.Add("058", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.SelectFromFilles));
                //РАБОТА С РЕЗЕРВНОЙ КОПИЕЙ
                FDictCommands.Add("059", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.DBackup));//Создают резервную копию
                FDictCommands.Add("060", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Restoring_a_backup)); //Востановить из резервной копии
                FDictCommands.Add("061", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.CatalogView)); //Просмотр резервной копии которая существует
                FDictCommands.Add("062", new Action<byte[], GlobalClass, NetworkStream, Logging, Mail>(command.Mail)); //Почта




            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }

        static  void HandleCommand(string aCommand, byte[] data, GlobalClass cls, NetworkStream ns, Logging logging ,Mail mail)
        {
            Action<byte[], GlobalClass, NetworkStream, Logging,Mail> actionCommand;
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            if (FDictCommands.TryGetValue(aCommand, out actionCommand)) actionCommand(data, cls, ns, logging, mail);
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            else
            {
                // Если не нашли, то обрабатываем это }
            }
        }

        public static void ClientProcessing(object client_obj)
        {
            try
            {
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                using (TcpClient client = client_obj as TcpClient)
                {


                    GlobalClass globalClass = new GlobalClass();

                    Mail mail = new Mail();
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                    NetworkStream stream = client.GetStream();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
                    Command command = new Command();
                    Logging logging  = new Logging();
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

                    HandleCommand(comand, msg, globalClass, stream, logging, mail);
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
                        Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 2);
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

        public int Add(int a, int b)
        {
            return a + b;
        }

        

    }
}
