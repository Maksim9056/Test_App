using Class_interaction_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Client
{
    public class Ip_adress
    {
        public static string Ip_adresss { get; set; }

        public string Ip_adressss { get; set; }

        public void CheckOS()
        {
            string Path = "";
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: iOS");
                // Создание экземпляра класса Seting
                Seting setting = new Seting("192.168.0.1", 8080, 1);

                // Преобразование объекта Seting в JSON строку
                string json = JsonConvert.SerializeObject(setting);

                // Запись JSON строки в файл
                File.WriteAllText("Client.json", json);

                // Чтение файла и преобразование JSON строки в объект Seting
                string jsonFromFile = File.ReadAllText("Client.json");
                Seting settingsFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);
         
                Ip_adressss = settingsFromFile.Ip_adress;

                // Доступ к данным
                string ipAddress = settingsFromFile.Ip_adress;
                int port = settingsFromFile.Port;
                int typeSQL = settingsFromFile.TypeSQL;
            
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Console.WriteLine("Операционная система: Android");
                //Path = FileSystem.AppDataDirectory;
                Seting seting = new Seting("192.168.0.112", 9595, 1);
                // Преобразование в JSON-строку
                string json = JsonConvert.SerializeObject(seting, Formatting.Indented);

                // Создание и запись в JSON-файл
                string fileName = "Client.json";
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                File.WriteAllText(path, json);

                // Чтение JSON-файла
                string jsonFromFile = File.ReadAllText(path);

                // Преобразование JSON-строки в объект Seting
                Seting setingFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

                // Вывод данных из объекта setingFromFile
                Ip_adressss = setingFromFile.Ip_adress;
                Console.WriteLine($"Ip_adress: {setingFromFile.Ip_adress}");
                Console.WriteLine($"Port: {setingFromFile.Port}");
                Console.WriteLine($"TypeSQL: {setingFromFile.TypeSQL}");
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                FileInfo fileInfo = new FileInfo(Path + "\\Client.json");

                Path = Environment.CurrentDirectory.ToString();
                //         Если есть то загружаем настройки сервера если нет то создают
                if (fileInfo.Exists)
                {
                    using (FileStream fs = new FileStream("Client.json", FileMode.Open))
                    {
                        Seting _aFile = System.Text.Json.JsonSerializer.Deserialize<Seting>(fs);
                        Ip_adresss = _aFile.Ip_adress;
                    }
                }
                else
                {
                    using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
                    {
                        Seting connect_Server_ = new Seting("192.168.0.112", 9595, 1);
                        System.Text.Json.JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
                    }


                    using (FileStream fileStream = new FileStream("Client.json", FileMode.Open))
                    {
                        Seting aFile = System.Text.Json.JsonSerializer.Deserialize<Seting>(fileStream);
                        Ip_adresss = aFile.Ip_adress;
                        Ip_adressss = Ip_adresss.ToString();
                    }

                }
            }
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: macOS");



            }



       
        }
    }
}

    //string fileName = "example.txt";
    //string fileContent = "Hello, Maui!";

    //string fileName = "Client.json";
    //string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

    //File.WriteAllText(path, fileName);
    ////string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

    //using (StreamWriter writer = new StreamWriter(path))
    //{
    //    writer.
    //}

    // Файл успешно создан



        
        ///// <summary>
        ///// Загружаеться Ip_address и port
        ///// </summary>
        //static public void SaveOpen()
        //{
        //    try
        //    {
        //       ;



        //        //switch (DeviceInfo.Platform)
        //        //{
        //        //    case DevicePlatform.iOS:
        //        //        Console.WriteLine("Проект запущен на Android");
        //        //        break;

        //        //    //case :
        //        //    //    Console.WriteLine("Проект запущен на iOS");
        //        //    //    break;

        //        //    case "WinUI":
        //        //        Console.WriteLine("Проект запущен на UWP (Windows)");
        //        //        break;

        //        //    //case :
        //        //    //    Console.WriteLine("Проект запущен на macOS");
        //        //    //    break;

        //        //    default:
        //        //        Console.WriteLine("Проект запущен на неизвестной операционной системе");
        //        //        break;
        //        //}


              
            
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}


        /// <summary>
        /// Меняет   Ip_address  из пграфического измениния
        /// </summary>
        //static public void SaveOpen(string adress)
        //{
        //    try
        //    {

        //        string path = Environment.CurrentDirectory.ToString();
        //        FileInfo fileInfo = new FileInfo(path + "\\Client.json");

        //        //Если есть то загружаем настройки сервера если нет то создают
        //        if (fileInfo.Exists)
        //        {
        //            using (FileStream fs = new FileStream("Client.json", FileMode.Open))
        //            {
        //                Seting _aFile = JsonSerializer.Deserialize<Seting>(fs);
        //                Ip_adresss = _aFile.Ip_adress;
        //            }
        //        }
        //        else
        //        {
        //            using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
        //            {
        //                Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 1);
        //                JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
        //            }


        //            using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
        //            {
        //                Seting aFile = JsonSerializer.Deserialize<Seting>(fileStream);
        //                Ip_adresss = aFile.Ip_adress;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}



//    }
//}
