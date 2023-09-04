using Class_interaction_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class Ip_adress
    {
        public static string Ip_adresss { get; set; }


        public void CheckOS()
        {
            string Path = "";
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: iOS");
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Console.WriteLine("Операционная система: Android");
                Path = FileSystem.AppDataDirectory;
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                Path = Environment.CurrentDirectory.ToString();
            }
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: macOS");
            }


            FileInfo fileInfo = new FileInfo(Path + "\\Client.json");

            //Если есть то загружаем настройки сервера если нет то создают
            if (fileInfo.Exists)
            {
                using (FileStream fs = new FileStream("Client.json", FileMode.Open))
                {
                    Seting _aFile = JsonSerializer.Deserialize<Seting>(fs);
                    Ip_adresss = _aFile.Ip_adress;
                }
            }
            else
            {
                using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
                {
                    Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 1);
                    JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
                }


                using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
                {
                    Seting aFile = JsonSerializer.Deserialize<Seting>(fileStream);
                    Ip_adresss = aFile.Ip_adress;
                }
            }
        }
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
        static public void SaveOpen(string adress)
        {
            try
            {

                string path = Environment.CurrentDirectory.ToString();
                FileInfo fileInfo = new FileInfo(path + "\\Client.json");

                //Если есть то загружаем настройки сервера если нет то создают
                if (fileInfo.Exists)
                {
                    using (FileStream fs = new FileStream("Client.json", FileMode.Open))
                    {
                        Seting _aFile = JsonSerializer.Deserialize<Seting>(fs);
                        Ip_adresss = _aFile.Ip_adress;
                    }
                }
                else
                {
                    using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
                    {
                        Seting connect_Server_ = new Seting(IPAddress.Loopback.ToString(), 9595, 1);
                        JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
                    }


                    using (FileStream fileStream = new FileStream("Client.json", FileMode.OpenOrCreate))
                    {
                        Seting aFile = JsonSerializer.Deserialize<Seting>(fileStream);
                        Ip_adresss = aFile.Ip_adress;
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
