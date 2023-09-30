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
            Console.WriteLine("������������ �������: iOS");
            // �������� ���������� ������ Seting
            Seting setting = new Seting("192.168.0.1", 8080, 1);

            // �������������� ������� Seting � JSON ������
            string json = JsonConvert.SerializeObject(setting);

            // ������ JSON ������ � ����
            File.WriteAllText("Client.json", json);

            // ������ ����� � �������������� JSON ������ � ������ Seting
            string jsonFromFile = File.ReadAllText("Client.json");
            Seting settingsFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

          //  Ip_adressss = settingsFromFile.Ip_adress;

            // ������ � ������
            string ipAddress = settingsFromFile.Ip_adress;
            PortEntry.Text = settingsFromFile.Port.ToString();
            int typeSQL = settingsFromFile.TypeSQL;

        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            Console.WriteLine("������������ �������: Android");
            //Path = FileSystem.AppDataDirectory;
            //Seting seting = new Seting("127.0.0.1", 9595, 1);
            // �������������� � JSON-������

        
            //string json = JsonConvert.SerializeObject(seting, Formatting.Indented);

            // �������� � ������ � JSON-����
            string fileName = "Client.json";
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            //File.WriteAllText(path, json);

            // ������ JSON-�����
            bool fileExists = File.Exists(path);

            if (!fileExists)
            {
                //"File Existence", "The file does not exist.
                Seting settings = new Seting("�����������.������", 9595, 1);
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            string jsonFromFile = File.ReadAllText(path);
            // �������������� JSON-������ � ������ Seting
            Seting setingFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

            // ����� ������ �� ������� setingFromFile
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
            //Console.WriteLine($"������� ������� ����������: {currentDirectory}");
            string appDirectory = System.AppContext.BaseDirectory;

            FileInfo fileInfo = new FileInfo(appDirectory + "\\Client.json");

            // ���� ���� �� ��������� ��������� ������� ���� ��� �� �������
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
            Console.WriteLine("������������ �������: macOS");



        }
        

    }


    public void SaveButtonClicked(object sender, EventArgs e)
    {
        try {
            string Path = "";

            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                //Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine("������������ �������: iOS");
                // �������� ���������� ������ Seting
                Seting setting = new Seting(AddressEntrys, PortEntrys, 1);

                // �������������� ������� Seting � JSON ������
                string json = JsonConvert.SerializeObject(setting);

                // ������ JSON ������ � ����
                File.WriteAllText("Client.json", json);

                // ������ ����� � �������������� JSON ������ � ������ Seting
                string jsonFromFile = File.ReadAllText("Client.json");

                Seting settingsFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

                //  Ip_adressss = settingsFromFile.Ip_adress;

                // ������ � ������
                string ipAddress = settingsFromFile.Ip_adress;
                //     PortEntry.Text = settingsFromFile.Port.ToString();
                int typeSQL = settingsFromFile.TypeSQL;

            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                Console.WriteLine("������������ �������: Android");
                //Path = FileSystem.AppDataDirectory;
                Seting seting = new Seting(AddressEntrys, PortEntrys, 1);
                // �������������� � JSON-������
                string json = JsonConvert.SerializeObject(seting, Formatting.Indented);

                // �������� � ������ � JSON-����
                string fileName = "Client.json";
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.WriteAllText(path, json);

                // ������ JSON-�����
                string jsonFromFile = File.ReadAllText(path);

                // �������������� JSON-������ � ������ Seting
                Seting setingFromFile = JsonConvert.DeserializeObject<Seting>(jsonFromFile);

                // ����� ������ �� ������� setingFromFile
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
                //Console.WriteLine($"������� ������� ����������: {currentDirectory}");
                string appDirectory = System.AppContext.BaseDirectory;

                FileInfo fileInfo = new FileInfo(appDirectory + "\\Client.json");

                // ���� ���� �� ��������� ��������� ������� ���� ��� �� �������
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
                Console.WriteLine("������������ �������: macOS");
            }
        }
        catch(Exception ex) 
        {
            DisplayAlert("������", ex.Message, "��");
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

            await DisplayAlert("������", ex.Message.ToString(), "��");
        }
    }

    private void AddressEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        AddressEntrys = AddressEntry.Text;
    }
}