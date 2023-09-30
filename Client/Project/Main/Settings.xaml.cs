using Class_interaction_Users;
using Client.Main;
using Newtonsoft.Json;

namespace Client.Project;

public partial class Settings : ContentPage
{

    public  int PortEntrys { get; set; }
    public string AddressEntrys { get; set; }
    public Settings()
	{
		InitializeComponent();

        string Path = "";
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            //Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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

          //  Ip_adressss = settingsFromFile.Ip_adress;

            // Доступ к данным
            string ipAddress = settingsFromFile.Ip_adress;
            PortEntry.Text = settingsFromFile.Port.ToString();
            int typeSQL = settingsFromFile.TypeSQL;

        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            Console.WriteLine("Операционная система: Android");
            //Path = FileSystem.AppDataDirectory;
            //Seting seting = new Seting("127.0.0.1", 9595, 1);
            // Преобразование в JSON-строку

        
            //string json = JsonConvert.SerializeObject(seting, Formatting.Indented);

            // Создание и запись в JSON-файл
            string fileName = "Client.json";
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            //File.WriteAllText(path, json);

            // Чтение JSON-файла
            bool fileExists = File.Exists(path);

            if (!fileExists)
            {
                //"File Existence", "The file does not exist.
                Seting settings = new Seting("экзаменатор.москва", 9595, 1);
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            string jsonFromFile = File.ReadAllText(path);
            // Преобразование JSON-строки в объект Seting
            Seting setingFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

            // Вывод данных из объекта setingFromFile
            //  Ip_adressss = setingFromFile.Ip_adress;
            AddressEntry.Text = setingFromFile.Ip_adress.ToString();

            PortEntry.Text = setingFromFile.Port.ToString();
            Console.WriteLine($"Ip_adress: {setingFromFile.Ip_adress}");
            Console.WriteLine($"Port: {setingFromFile.Port}");
            Console.WriteLine($"TypeSQL: {setingFromFile.TypeSQL}");
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            //string assemblyPath = Assembly.GetEntryAssembly().Location;
            //Path = System.IO.Path.GetDirectoryName(assemblyPath);
            //     Path = System.IO.Path.Combine(Environment.CurrentDirectory, "..", "..", "MyProject");
            //     Path = Environment.CurrentDirectory.ToString();



            //string[] args = Environment.GetCommandLineArgs();
            //string assemblyPath = args[0];
            ////Path = Path.GetDirectoryName(assemblyPath);
            //string path = Directory.GetCurrentDirectory();
            ////var d = Environment.ProcessPath;
            //string currentDirectory = Environment.CurrentDirectory;
            //Console.WriteLine($"Текущая рабочая директория: {currentDirectory}");
            string appDirectory = System.AppContext.BaseDirectory;

            FileInfo fileInfo = new FileInfo(appDirectory + "\\Client.json");

            // Если есть то загружаем настройки сервера если нет то создают
            if (fileInfo.Exists)
            {
                using (FileStream fs = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                {
                    Seting _aFile = System.Text.Json.JsonSerializer.Deserialize<Seting>(fs);
                    //      Ip_adressss = _aFile.Ip_adress;

                   AddressEntry.Text = _aFile.Ip_adress.ToString();  
                   PortEntry.Text = _aFile.Port.ToString();

                }
            }
            else
            {
                using (FileStream fileStream = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                {
                    Seting connect_Server_ = new Seting("192.168.0.112", 9595, 1);
                    System.Text.Json.JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
                }


                using (FileStream fileStream = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                {
                    Seting aFile = System.Text.Json.JsonSerializer.Deserialize<Seting>(fileStream);

                    AddressEntry.Text =aFile.Ip_adress.ToString();
                    PortEntry.Text = aFile.Port.ToString();
         //           Ip_adresss = aFile.Ip_adress;
         //      Ip_adressss = Ip_adresss.ToString();
                }

            }
        }
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Операционная система: macOS");



        }
        

    }


    public void SaveButtonClicked(object sender, EventArgs e)
    {
        try {
            string Path = "";

            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: iOS");
                // Создание экземпляра класса Seting
                Seting setting = new Seting(AddressEntrys, PortEntrys, 1);

                // Преобразование объекта Seting в JSON строку
                string json = JsonConvert.SerializeObject(setting);

                // Запись JSON строки в файл
                File.WriteAllText("Client.json", json);

                // Чтение файла и преобразование JSON строки в объект Seting
                string jsonFromFile = File.ReadAllText("Client.json");

                Seting settingsFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

                //  Ip_adressss = settingsFromFile.Ip_adress;

                // Доступ к данным
                string ipAddress = settingsFromFile.Ip_adress;
                //     PortEntry.Text = settingsFromFile.Port.ToString();
                int typeSQL = settingsFromFile.TypeSQL;

            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Console.WriteLine("Операционная система: Android");
                //Path = FileSystem.AppDataDirectory;
                Seting seting = new Seting(AddressEntrys, PortEntrys, 1);
                // Преобразование в JSON-строку
                string json = JsonConvert.SerializeObject(seting, Formatting.Indented);

                // Создание и запись в JSON-файл
                string fileName = "Client.json";
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, json);

                // Чтение JSON-файла
                string jsonFromFile = File.ReadAllText(path);

                // Преобразование JSON-строки в объект Seting
                Seting setingFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

                // Вывод данных из объекта setingFromFile
                //  Ip_adressss = setingFromFile.Ip_adress;
                //    AddressEntry.Text = setingFromFile.Ip_adress.ToString();

                //      PortEntry.Text = setingFromFile.Port.ToString();
                Console.WriteLine($"Ip_adress: {setingFromFile.Ip_adress}");
                Console.WriteLine($"Port: {setingFromFile.Port}");
                Console.WriteLine($"TypeSQL: {setingFromFile.TypeSQL}");
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                //string assemblyPath = Assembly.GetEntryAssembly().Location;
                //Path = System.IO.Path.GetDirectoryName(assemblyPath);
                //     Path = System.IO.Path.Combine(Environment.CurrentDirectory, "..", "..", "MyProject");
                //     Path = Environment.CurrentDirectory.ToString();



                //string[] args = Environment.GetCommandLineArgs();
                //string assemblyPath = args[0];
                ////Path = Path.GetDirectoryName(assemblyPath);
                //string path = Directory.GetCurrentDirectory();
                ////var d = Environment.ProcessPath;
                //string currentDirectory = Environment.CurrentDirectory;
                //Console.WriteLine($"Текущая рабочая директория: {currentDirectory}");
                string appDirectory = System.AppContext.BaseDirectory;

                FileInfo fileInfo = new FileInfo(appDirectory + "\\Client.json");

                // Если есть то загружаем настройки сервера если нет то создают
                if (fileInfo.Exists)
                {
                    File.Delete(appDirectory + "\\Client.json");
                    using (FileStream fs = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                    {
                        Seting seting = new Seting(AddressEntrys, PortEntrys, 1);
                        System.Text.Json.JsonSerializer.Serialize<Seting>(fs, seting);
                        //      Ip_adressss = _aFile.Ip_adress;

                        //AddressEntry.Text = _aFile.Ip_adress.ToString();
                        //PortEntry.Text = _aFile.Port.ToString();

                    }
                }
                else
                {
                    using (FileStream fileStream = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                    {
                        Seting connect_Server_ = new Seting(AddressEntrys, PortEntrys, 1);
                        System.Text.Json.JsonSerializer.Serialize<Seting>(fileStream, connect_Server_);
                    }


                    using (FileStream fileStream = new FileStream(appDirectory + "\\Client.json", FileMode.OpenOrCreate))
                    {
                        Seting aFile = System.Text.Json.JsonSerializer.Deserialize<Seting>(fileStream);

                        //    AddressEntry.Text = aFile.Ip_adress.ToString();
                        //    PortEntry.Text = aFile.Port.ToString();
                        //           Ip_adresss = aFile.Ip_adress;
                        //      Ip_adressss = Ip_adresss.ToString();
                    }

                }
            }
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
            {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("Операционная система: macOS");
            }
        }
        catch(Exception ex) 
        {
            DisplayAlert("Ошибка", ex.Message, "ОК");
        }
        Navigation.PushAsync(new MainPage());
    }

    public async void CancelButtonClicked(object sender, EventArgs e)
	{

        await Navigation.PushAsync(new MainPage());
        //await Navigation.PopAsync();
    }

    private async void PortEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {        
          PortEntrys = Convert.ToInt32( PortEntry.Text);
        }
        catch (Exception ex) 
        {

            await DisplayAlert("Ошибка", ex.Message.ToString(), "ОК");
        }
    }

    private void AddressEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        AddressEntrys = AddressEntry.Text;
    }
}