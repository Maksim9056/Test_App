using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Class_chat;
//using Newtonsoft.Json.Linq;
///using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net.Sockets;
//using System.Security.Policy;
//using System.Text;
//using System.Text.Json;
//using System.Text.Json.Nodes;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Class_interaction_Users
{


    public class CommandCL
    {
        //Передает пользователя имя и его друзей
        //public static MsgUser_Logins User_Logins_and_Friends { get; set; }
        ////Друзья
        //public Searh_Friends _Friends { get; set; }

        ///// <summary>
        ///// Для id друга телегама 
        ///// </summary>
        //public _Name id_Friends { get; set; }
        ////Проверка
        //public JToken _Answe { get; set; }
        ////Количество друзей
        //public JToken _List_Mess_count { get; set; }
        ////Класс с друзьями и сообщениями
        //public JToken _AClass { get; set; }

        //// Проверка редактированых 
        //public JToken AnsweIm { get; set; }

        ////Количество картинок редактированых
        //public JToken List_Mess_countIm { get; set; }

        ////Класс картинок редактированых
        //public JToken AClassIm { get; set; }

        //public JToken List_Friends { get; set; }

        ////Класс пользователей зарестрированых в телеграм
        //public static List_Bot_Telegram Id_Telegram { get; set; }

        ///// <summary>
        ///// id голосового сообщения
        ///// </summary>
        //public Insert_Fille_Music Insert_Fille_Music_id { get; set; }



        ///// <summary>
        ///// id голосового сообщения для воспроизведения 
        ///// </summary>
        //public Insert_Fille_Music Select_Fille_Music_id { get; set; }
        public static Regis_users_test Regis_Users_Test { get; set; }
        public static UserList UserListGet { get; set; }
        public static TestList TestListGet { get; set; }
        public static ExamsList ExamsListGet { get; set; }
        public static QuestionsList QuestionsListGet { get; set; }
        public static AnswerList AnswerListGet { get; set; }

        public static TestQuestionList TestQuestionListGet { get; set; }
        public static QuestionAnswerList QuestionAnswerListGet { get; set; }
        public static ExamsTestList ExamsTestListGet { get; set; }
        public static UserExamsList UserExamsListGet { get; set; }

        public static QuestionssList QuestionssList { get; set; }
        /// <summary>
        /// Роли 
        /// </summary>
        public static Roles_Accept_Client Roles_Accept_Client { get; set; }

        public static Roles roles_Accept_Client { get; set; }


        /// <summary>
        /// Класс авторизации и регистрации
        /// </summary>
        public Regis_users Travel_logout { get; set; }


        public static Questionss Roles_Accept { get; set; }
        /// <summary>
        /// Класс тесты
        /// </summary>
        public static Tests_Travel Tests_Travel { get; set; }

        ///// <summary>
        ///// Отправки в телеграм в чат
        ///// </summary>
        public static Regis_users Travel_Regis_users_message { get; set; }


        public static JToken Answer_True { get; set; }

        public static JToken Questionss { get; set; }
        public static JToken Answe { get; set; }








        //Функция считывания байт из потока и формирование единой строки
        public string Func_Read(Stream str, int length, TcpClient client)
        {
            string Result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                int cnt = 0;
                Byte[] locbuffer = new byte[length];
                do
                {
                    cnt = str.Read(locbuffer, 0, locbuffer.Length);
                    ms.Write(locbuffer, 0, cnt);
                }
                while (client.Available > 0);
                Result = Encoding.Default.GetString(ms.ToArray());
            }
            return Result;
        }

        // Процедура отправки регистрации пользователей 002
        async public Task Reg_User(String server, string fs, string command)
        {
            try
            {
                //Регистрация
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseData = String.Empty;
                    //Функия получения
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
                    //Получаем имя пользователя


                    Regis_users msgImage = JsonSerializer.Deserialize<Regis_users>(responseData);
                    Travel_Regis_users_message = msgImage;

                    //User_reg.UserName = responseData;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
            }
        }


        // Передача 003 проверка пользователя и его пароль 
        async public Task Check_User_Possword(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    string Host = System.Net.Dns.GetHostName();
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseData = String.Empty;
                    /*
                    //String responseDat = String.Empty;                    
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    int cnt = 0;
                    //    Byte[] locbuffer = new byte[1024];
                    //    do
                    //    {
                    //        cnt = stream.Read(locbuffer, 0, locbuffer.Length);
                    //        ms.Write(locbuffer, 0, cnt);
                    //    } while (client.Available > 0);
                    //    responseData = Encoding.Default.GetString(ms.ToArray());

                    //}
                    */

                    //Функция получаем
                    //responseData = await Task<string>.Run(() =>
                    //{
                    //    return Func_Read(stream, data.Length, client);
                    //});

                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    //Получили результат
                    responseData = completeMessage.ToString();


                    //Проверяем
                    if (responseData == "false")
                    {
                        // User_Logins_and_Friends = null;
                    }
                    else
                    {
                        //Десерилизуем класс
                        Regis_users person3 = JsonSerializer.Deserialize<Regis_users>(responseData);
                        Travel_logout = person3;
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //Console.WriteLine("SocketException: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }

        }


        // Передача 007 получение картинки
        async public Task Get_Image(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseData = String.Empty;
                    //Функция получения
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    //Получили результат
                    responseData = completeMessage.ToString();

                    //Проверяем условия
                    if (responseData == "false")
                    {
                        //Нету картинки
                    }
                    else
                    {

                        Roles roles_Accept = JsonSerializer.Deserialize<Roles>(responseData);


                        roles_Accept_Client = roles_Accept;
                        ////Так обрабатываем картинки 
                        //JObject details = JObject.Parse(responseData);
                        //JToken Answe = details.SelectToken("Answe");
                        //JToken List_Mess = details.SelectToken("List_Mess");
                        //JToken AClass = details.SelectToken("Image");
                        //AnsweIm = Answe;
                        //List_Mess_countIm = List_Mess;
                        //AClassIm = AClass;

                        //UserImage = AClass;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                //  MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                //   MessageBox.Show(e.Message);
            }

        }

        // Передача картинок друзей
        async public Task Get_Image_Friends(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {   //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили на сервер
                    await stream.WriteAsync(data, 0, data.Length);
                    //data = new Byte[1024];
                    String responseData = String.Empty;
                    //Функция получения
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
                    int numberOfBytesRead = 0;
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется
                    responseData = await Task<string>.Run(() =>
                    {
                        return Func_Read(stream, data.Length, client);
                    });
                    //do
                    //{
                    //    numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                    //    completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    //}
                    //while (stream.DataAvailable);
                    //responseData = completeMessage.ToString();
                    //Проверяем
                    if (responseData == "false")
                    {
                        //Обработаем
                    }
                    else
                    {

                        //JObject details = JObject.Parse(responseData);
                        //JToken List_Mess = details.SelectToken("Quest");
                        // Answe = List_Mess.SelectToken("Id");
                        // Questionss = List_Mess.SelectToken("Questionss");
                        // Answer_True = List_Mess.SelectToken("Answer_True");

                        //ВЕЗЕНИЕ ДЕСЕРИЛИЗАЦИЯ ПОЛУЧИЛАСЬ
                        Questionss roles_Accept = JsonSerializer.Deserialize<Questionss>(responseData);

                        Roles_Accept = roles_Accept;

                        //Questionss_Travel = Questionss_TravelS;
                        ////Разбераем JObject и JToken удобно без обрезания серилизует байты
                        //JToken Answe = details.SelectToken("List_Mess");
                        //List_Friends = List_Mess;
                        ////UserImage = AClass;

                    }
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //  MessageBox.Show("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }


        // Процедура отправки 005
        async public Task Check_Test(string server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {   //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили  на сервер
                    await stream.WriteAsync(data, 0, data.Length);
                    //Назначаем длину 1024
                    //data = new Byte[1024];
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
                    //получить перечень сообщений
                    if (responseData == null)
                    {   //Если нету списка
                        Tests_Travel = null;
                    }
                    else
                    {
                        //Разбераем классом но надо правильно это делать может не сработать 
                        //В данном случаи сработал
                        Tests_Travel msgtest = JsonSerializer.Deserialize<Tests_Travel>(responseData);

                        Tests_Travel = msgtest;

                    }

                }
            }
            catch (ArgumentNullException)
            {
                //   MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
            }

        }


        // Проццедура отправки 008
        async public Task Connect_Friends(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {    //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили друзей
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseDat = String.Empty;
                    //Функция для получения ответа 
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);



                    responseDat = completeMessage.ToString();
                    if (string.IsNullOrEmpty(responseDat))
                    {

                    }
                    else
                    {
                        Questionss roles_Accept = JsonSerializer.Deserialize<Questionss>(responseDat);

                        Roles_Accept = roles_Accept;
                    }

                    //Получили данные в строке и десеризовали класс Searh_Friends
                    //Searh_Friends searh_Friends = JsonSerializer.Deserialize<Searh_Friends>(responseDat);
                    //_Friends = searh_Friends;
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        // Процедура отправки 009
        async public Task Insert_Message(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseDat = String.Empty;

                    responseDat = await Task<string>.Run(() =>
                    {
                        return Func_Read(stream, data.Length, client);
                    });

                    //MsgInfo msgInfo = JsonSerializer.Deserialize<MsgInfo>(responseDat);

                    //JObject details = JObject.Parse(responseDat);
                    //JToken Answe = details.SelectToken("Answe");
                    //JToken List_Mess = details.SelectToken("List_Mess");
                    //JToken AClass = details.SelectToken("AClass");
                    //_Answe = Answe;
                    //_List_Mess_count = List_Mess;
                    //_AClass = AClass;
                }
            }
            catch (ArgumentNullException)
            {
                //  MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //  MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        // Процедура отправки 010
        async public Task Update_Message_make_up(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправли на сервер
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseDat = String.Empty;
                    //получаем из сервера ответ
                    responseDat = await Task<string>.Run(() =>
                    {
                        return Func_Read(stream, data.Length, client);
                    });
                    // десеризовали класс MsgInfo в д
                    //MsgInfo msgInfo = JsonSerializer.Deserialize<MsgInfo>(responseDat);
                    ////Разбераем JObject и JToken удобно для повторного использования
                    //JObject details = JObject.Parse(responseDat);
                    //JToken Answe = details.SelectToken("Answe");
                    //JToken List_Mess = details.SelectToken("List_Mess");
                    //JToken AClass = details.SelectToken("AClass");
                    //_Answe = Answe;
                    //_List_Mess_count = List_Mess;
                    //_AClass = AClass;
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                // MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        /// <summary>
        /// Процедура отправки 011
        /// </summary>
        /// <param name="server"></param>
        /// <param name="fs"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async public Task Delete_message_make_up(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили на сервер
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseDat = String.Empty;
                    //получаем строку
                    responseDat = await Task<string>.Run(() =>
                    {
                        return Func_Read(stream, data.Length, client);
                    });
                    //Разбераем классом MsgInfo  но надо правильно это делать может не сработать  
                    //Сдесь сработала десерилизация
                    //MsgInfo msgInfo = JsonSerializer.Deserialize<MsgInfo>(responseDat);
                    ////Разбераем JObject и JToken удобно для повторного использования
                    //JObject details = JObject.Parse(responseDat);
                    //JToken Answe = details.SelectToken("Answe");
                    //JToken List_Mess = details.SelectToken("List_Mess");
                    //JToken AClass = details.SelectToken("AClass");
                    //_Answe = Answe;
                    //_List_Mess_count = List_Mess;
                    //_AClass = AClass;
                }
            }
            catch (ArgumentNullException)
            {
                //MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //  MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        /// <summary>
        /// 015 Запрашивает перечень телеграм пользователей
        /// </summary>
        /// <param name="server"></param>
        /// <param name="fs"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async public Task Select_User_Bot(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    string Host = System.Net.Dns.GetHostName();
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);
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
                    //Получили результат
                    responseData = completeMessage.ToString();


                    //Проверяем
                    if (responseData == "false")
                    {
                        // User_Logins_and_Friends = null;
                    }
                    else
                    {
                        ////Десерилизуем класс
                        //List_Bot_Telegram person3 = JsonSerializer.Deserialize<List_Bot_Telegram>(responseData);
                        //Id_Telegram = person3;
                        ////User_Logins_and_Friends = person3;

                        //JObject keyValuePairs = new JObject();
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }

        }

        /// <summary>
        /// Процедура отправки 016
        /// </summary>
        /// <param name="server"></param>
        /// <param name="fs"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async public Task Select_User_(String server, string fs, string command)
        {

            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    string Host = System.Net.Dns.GetHostName();
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);
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
                    //Получили результат
                    responseData = completeMessage.ToString();

                    //MsgUser_Logins person3 = JsonSerializer.Deserialize<MsgUser_Logins>(responseData);
                    //User_Logins_and_Friends = person3;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }
        }

        // Процедура отправки 016
        async public Task Select_Message(String server, string fs, string command)
        {

            try
            {

                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    string Host = System.Net.Dns.GetHostName();
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);
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
                    //Получили результат
                    responseData = completeMessage.ToString();

                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }

        }


        // Процедура отправки 017
        async public Task Insert_Message_Telegram(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);

                    //     String responseDat = String.Empty;
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
                    //Получили результат
                    responseData = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseData))
                    {

                    }
                    else
                    {
                        //MsgInfo msgInfo = JsonSerializer.Deserialize<MsgInfo>(responseData);
                        //Travel_Telegram_message = msgInfo;
                        //JObject details = JObject.Parse(responseData);
                        //JToken Answe = details.SelectToken("Answe");
                        //JToken List_Mess = details.SelectToken("List_Mess");
                        //JToken AClass = details.SelectToken("AClass");
                        //_Answe = Answe;
                        //_List_Mess_count = List_Mess;
                        //_AClass = AClass;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                //  MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //  MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        // Проццедура отправки 019
        async public Task From_Friend(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {    //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили друзей

                    await stream.WriteAsync(data, 0, data.Length);

                    String responseDat = String.Empty;
                    //Функция для получения ответа 
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseDat = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseDat))
                    {

                    }
                    else
                    {


                        Regis_users_test msgImage = JsonSerializer.Deserialize<Regis_users_test>(responseDat);
                        if (msgImage == null)
                        {

                        }
                        else
                        {


                            Regis_Users_Test = msgImage;
                        }
                        //Получили данные в строке и десеризовали класс Searh_Friends
                        //_Name searh_Friends = JsonSerializer.Deserialize<_Name>(responseDat);
                        //id_Friends = searh_Friends;
                    }

                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        // Процедура отправки регистрации пользователей 019
        async public Task Stream_Filles_music(String server, string fs, string command)
        {
            try
            {
                //Регистрация
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseData = String.Empty;
                    //Функия получения
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
                    //Получаем имя пользователя
                    if (responseData == null)
                    {
                    }
                    else
                    {
                        //Insert_Fille_Music insert_Fille_Music = JsonSerializer.Deserialize<Insert_Fille_Music>(responseData);
                        //Insert_Fille_Music_id = insert_Fille_Music;
                    }

                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Процедура отправки регистрации пользователей 020
        /// </summary>
        /// <param name="server"></param>
        /// <param name="fs"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        async public Task Stream_Fille_accept_music(String server, string fs, string command)
        {
            try
            {
                //Регистрация
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    //Декодируем Bite []
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправляем на сервер
                    await stream.WriteAsync(data, 0, data.Length);

                    String responseData = String.Empty;
                    //Функия получения
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
                    //Получаем имя пользователя
                    if (responseData == null)
                    {

                    }
                    else
                    {
                        //Insert_Fille_Music Select_Fille_Music = JsonSerializer.Deserialize<Insert_Fille_Music>(responseData);
                        //Select_Fille_Music_id = Select_Fille_Music;
                    }

                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e.Message);
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message);
            }
        }

        // Процедура отправки 017
        async public Task Insert_Message_Voice_Telegram(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);

                    //     String responseDat = String.Empty;
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
                    //Получили результат
                    responseData = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseData))
                    {

                    }
                    else
                    {
                        //MsgInfo msgInfo = JsonSerializer.Deserialize<MsgInfo>(responseData);
                        //Travel_Telegram_message = msgInfo;
                        //JObject details = JObject.Parse(responseData);
                        //JToken Answe = details.SelectToken("Answe");
                        //JToken List_Mess = details.SelectToken("List_Mess");
                        //JToken AClass = details.SelectToken("AClass");
                        //_Answe = Answe;
                        //_List_Mess_count = List_Mess;
                        //_AClass = AClass;
                    }
                }
            }
            catch (ArgumentNullException)
            {
                //  MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //  MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        // Проццедура отправки 016
        async public Task GetUserList(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {    //Сформировали в Byte массив весь класс и команду
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    //Отправили друзей

                    await stream.WriteAsync(data, 0, data.Length);

                    String responseDat = String.Empty;
                    //Функция для получения ответа 
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseDat = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseDat))
                    {
                    }
                    else
                    {
                        UserList msgUserList = JsonSerializer.Deserialize<UserList>(responseDat);
                        if (msgUserList == null)
                        {
                        }
                        else
                        {
                            UserListGet = msgUserList;
                        }
                        //Получили данные в строке и десеризовали класс Searh_Friends
                        //_Name searh_Friends = JsonSerializer.Deserialize<_Name>(responseDat);
                        //id_Friends = searh_Friends;
                    }

                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        // Проццедура отправки 017
        async public Task UpdateUser(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseDat = String.Empty;
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseDat = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseDat))
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        // Проццедура отправки 018
        async public Task CreateUser(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseDat = String.Empty;
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseDat = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseDat))
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }

        async public Task DelUser(String server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                {
                    Byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    NetworkStream stream = client.GetStream();
                    await stream.WriteAsync(data, 0, data.Length);
                    String responseDat = String.Empty;
                    Byte[] readingData = new Byte[256];
                    StringBuilder completeMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                        completeMessage.AppendFormat("{0}", Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    responseDat = completeMessage.ToString();

                    if (string.IsNullOrEmpty(responseDat))
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (ArgumentNullException)
            {
                // MessageBox.Show("ArgumentNullException:{0}", e.Message);
            }
            catch (SocketException)
            {
                //MessageBox.Show("SocketException: {0}", e.Message);
            }
        }


        public class TestCommand
        {
            /// <summary>
            /// Procedure for sending 020
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns>True if the procedure succeeds, False otherwise</returns>
            async public Task<bool> CreateTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Procedure for sending 021
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns>True if the procedure succeeds, False otherwise</returns>
            async public Task<bool> UpdateTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Procedure for sending 022
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns>True if the procedure succeeds, False otherwise</returns>
            async public Task<bool> DelTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Проццедура отправки 023
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<TestList> GetTestList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    TestList msgTestList = JsonSerializer.Deserialize<TestList>(responseDat);
                    if (msgTestList == null)
                    {
                        return null;
                    }
                    else
                    {
                        TestListGet = msgTestList;
                        return msgTestList;
                    }
                }
            }
        }

        // для класса Exams
        public class ExamsCommand
        {
            /// <summary>
            /// Проццедура отправки 024
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<bool> CreateExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Проццедура отправки 025
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<bool> UpdateExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Проццедура отправки 026
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<bool> DelExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            /// <summary>
            /// Проццедура отправки 027
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<ExamsList> GetExamsList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    ExamsList msgExamsList = JsonSerializer.Deserialize<ExamsList>(responseDat);
                    if (msgExamsList == null)
                    {
                        return null;
                    }
                    else
                    {
                        ExamsListGet = msgExamsList;
                        return msgExamsList;
                    }
                }
            }
        }


        public class QuestionsCommand
        {
            /// <summary>
            /// Процедура отправки 28
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<bool> CreateQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<QuestionsList> GetQuestionList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    QuestionsList msgQuestionList = JsonSerializer.Deserialize<QuestionsList>(responseDat);
                    if (msgQuestionList == null)
                    {
                        return null;
                    }
                    else
                    {
                        QuestionsListGet = msgQuestionList;
                        return msgQuestionList;
                    }
                }
            }

        }

        public class AnswerCommand
        {
            /// <summary>
            /// Процедура отправки 28
            /// </summary>
            /// <param name="server"></param>
            /// <param name="fs"></param>
            /// <param name="command"></param>
            /// <returns></returns>
            async public Task<bool> CreateAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<AnswerList> GetAnswerList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    AnswerList msgAnswerList = JsonSerializer.Deserialize<AnswerList>(responseDat);
                    if (msgAnswerList == null)
                    {
                        return null;
                    }
                    else
                    {
                        AnswerListGet = msgAnswerList;
                        return msgAnswerList;
                    }
                }
            }
        }

        public class TestQuestionCommand
        {
            async public Task<bool> CreateTestQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateTestQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelTestQuestion(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<TestQuestionList> GetTestQuestionList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    TestQuestionList testQuestionList = JsonSerializer.Deserialize<TestQuestionList>(responseDat);
                    if (testQuestionList == null)
                    {
                        return null;
                    }
                    else
                    {
                        TestQuestionListGet = testQuestionList;
                        return testQuestionList;
                    }
                }
            }
        }

        public class QuestionAnswerCommand
        {
            async public Task<bool> CreateQuestionAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateQuestionAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelQuestionAnswer(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<QuestionAnswerList> GetQuestionAnswerList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    QuestionAnswerList questionAnswerList = JsonSerializer.Deserialize<QuestionAnswerList>(responseDat);
                    if (questionAnswerList == null)
                    {
                        return null;
                    }
                    else
                    {
                        QuestionAnswerListGet = questionAnswerList;
                        return questionAnswerList;
                    }
                }
            }
        }

        public class ExamsTestCommand
        {
            async public Task<bool> CreateExamsTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateExamsTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelExamsTest(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<ExamsTestList> GetExamsTestList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    ExamsTestList examsTestList = JsonSerializer.Deserialize<ExamsTestList>(responseDat);
                    if (examsTestList == null)
                    {
                        return null;
                    }
                    else
                    {
                        ExamsTestListGet = examsTestList;
                        return examsTestList;
                    }
                }
            }
        }

        public class UserExamsCommand
        {
            async public Task<bool> CreateUserExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> UpdateUserExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<bool> DelUserExams(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                return !string.IsNullOrEmpty(responseDat);
            }

            async public Task<UserExamsList> GetUserExamsList(string server, string fs, string command)
            {
                CommandCL ClassInstance = new CommandCL();
                string responseDat = await ClassInstance.SendClass(server, fs, command);
                if (string.IsNullOrEmpty(responseDat))
                {
                    return null;
                }
                else
                {
                    UserExamsList userExamsList = JsonSerializer.Deserialize<UserExamsList>(responseDat);
                    if (userExamsList == null)
                    {
                        return null;
                    }
                    else
                    {
                        UserExamsListGet = userExamsList;
                        return userExamsList;
                    }
                }
            }
        }

        public async Task<string> SendClass(string server, string fs, string command)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, 9595))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = System.Text.Encoding.Default.GetBytes(command + fs);
                    await stream.WriteAsync(data, 0, data.Length);

                    StringBuilder completeMessage = new StringBuilder();
                    byte[] readingData = new byte[256];
                    int numberOfBytesRead = 0;

                    do
                    {
                        numberOfBytesRead = await stream.ReadAsync(readingData, 0, readingData.Length);
                        completeMessage.Append(Encoding.Default.GetString(readingData, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);

                    string responseDat = completeMessage.ToString();
                    return responseDat;
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e.Message}");
            }

            return string.Empty;
        }


        public class SaveTest
        {
            public async Task<string> SaveClass(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();
                    using (TcpClient client = new TcpClient(server, 9595))

                    using (NetworkStream stream = client.GetStream())
                    {
                        string responseDat = await ClassInstance.SendClass(server, fs, command);
                        if (string.IsNullOrEmpty(responseDat))
                        {
                            return null;
                        }
                        else
                        {

                            return responseDat;
                        }
                    }

                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }
        }
        public class Check
        {



            public Exams_Check exams_Check1 { get; set; }
            public Exams_Check exams_Check { get; set; }


            public async Task<string> CheckClass(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();

                    string responseDat = await ClassInstance.SendClass(server, fs, command);
                    if (string.IsNullOrEmpty(responseDat))
                    {
                        return null;
                    }
                    else
                    {

                        Exams_Check exams_Check = JsonSerializer.Deserialize<Exams_Check>(responseDat);
                        exams_Check1 = exams_Check;
                    }


                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }

            public async Task<string> CheckTest(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();

                    string responseDat = await ClassInstance.SendClass(server, fs, command);
                    if (string.IsNullOrEmpty(responseDat))
                    {
                        return null;
                    }
                    else
                    {
                        //    JsonSerializer.Serialize<ExamsTest>(memoryStream, userExams);

                        //    JsonSerializer.Serialize<ExamsTest>(memoryStream, userExams);

                        Exams_Check exams_Checkы = JsonSerializer.Deserialize<Exams_Check>(responseDat);
                        exams_Check = exams_Checkы;
                    }


                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }
        }
        public class CheckStatickUserResult
        {

            public List<Statictics> statictics { get; set; } = new List<Statictics>();
            public async Task<string> CheckStatickUserResults(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();

                    string responseDat = await ClassInstance.SendClass(server, fs, command);
                    if (string.IsNullOrEmpty(responseDat))
                    {
                        return null;
                    }
                    else
                    {

                        Statick exams_Check = JsonSerializer.Deserialize<Statick>(responseDat);
                        statictics = exams_Check.statictics;
                    }


                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }
        }


        public class CheckPingsResult
        {

            public Галочка statictics { get; set; }

            public async Task<string> CheckpingIpAdress(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();

                    string responseDat = await ClassInstance.SendClass(server, fs, command);
                    if (string.IsNullOrEmpty(responseDat))
                    {
                        return null;
                    }
                    else
                    {

                        Галочка exams_Check = JsonSerializer.Deserialize<Галочка>(responseDat);

                        statictics = exams_Check;
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }
        }

        public class Filles_Work_
        {
            public Filles Filles { get; set; }
            public async Task<string> FillesSavess(string server, string fs, string command)
            {

                try
                {
                    CommandCL ClassInstance = new CommandCL();

                    string responseDat = await ClassInstance.SendClass(server, fs, command);
                    if (string.IsNullOrEmpty(responseDat))
                    {
                        return null;
                    }
                    else
                    {

                        Filles exams_Check = JsonSerializer.Deserialize<Filles>(responseDat);

                        Filles = exams_Check;
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e.Message}");

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                return string.Empty;
            }
        }
    }
}




