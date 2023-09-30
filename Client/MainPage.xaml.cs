using Class_interaction_Users;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Platform;
using Client.Main;
using System.Windows.Input;
using System.Web;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Net.Mail;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;
using static Client.MainPage;

//using Microsoft.AspNetCore.Components.Navigation;


namespace Client
{
    public partial class MainPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        CheckPing checkPing = new CheckPing();
        public MainPage()
        {
            try
            {

                InitializeComponent();
                BindingContext = this;
                AddSettings();
            }
            catch
            {

            }
        }


        public void AddSettings()
        {
            try
            {
                var flyoutItemseting = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
                if (flyoutItemseting == null)
                {
                    // Создание пунктов меню класса
                    var main = new ShellContent { Content = new Client.Project.Settings()};

                    // Добавление пунктов меню в класс
                    Shell.Current.Items.Add(new ShellSection { Title = "Настройки", Icon = "dotnet_bot.png", Route = "seting", Items = { main } });

                    // Обработчик события при нажатии на пункт меню
                    //main.PropertyChanged += async (sender, e) =>
                    //{
                    //    if (e.PropertyName == nameof(ShellContent.IsEnabled) && !main.IsEnabled)
                    //    {
                    //        // Переход обратно
                    //        await Shell.Current.GoToAsync("admin");
                    //    }
                    //};
                }
            }
            catch(Exception ex) 
            {
                DisplayAlert("Ошибка", ex.Message, "Ок");
            }
        }
        //var rt = Shell.Current.CurrentState.Location.OriginalString;
        //var parameters = System.Web.HttpUtility.ParseQueryString(rt);
        //var sellValue = parameters.Get("sell");


        public CommandCL command = new CommandCL();
        public string Mail { get; set; }
        public string Password { get; set; }



        private void OnCounterClicked(object sender, EventArgs e)
        {

        }

        //
        private void OnButtonClicked(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void nameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void CounterBtn_Clicked(object sender, EventArgs e)
        {
            

        }


       public async void Start(string FileFS , Ip_adress ip_Adress)
       {     Галочка галочка1 = null;
            using (MemoryStream stream = new MemoryStream())  {
                Галочка галочка = new Галочка(1, $"{ip_Adress.Ip_adressss}");
                var Result = checkPing.CheckPingIp(галочка);
                галочка1 = Result;   }
            if (галочка1 == null)  {
                await DisplayAlert("Уведомление", "Сервер выключен или недоступен!", "ОK"); }
            else
            {  if (Mail == null) {
                    await DisplayAlert("Уведомление", "Почта не пустая!", "ОK");    }
                else
                { //Проверяет почту пуста или нет
                    if (string.IsNullOrEmpty(Mail)) {
                        await DisplayAlert("Уведомление", "Почта не заполнена!", "ОK");  }
                    else
                    { //Регеулярное выражение
                        string patern = "@.";
                        //Регулярное выражение
                        Regex regex = new Regex(patern);
                        //Проверяет в Mail есть ли в строке это @ почту
                        if (Regex.IsMatch(Mail, patern)) {
                            if (Password == null){
                                await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");}
                            else
                            { if (string.IsNullOrEmpty(Password)){
                                    await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");  }
                                else
                                {//Обьявляем MemoryStream 
                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {//Заполняем класс CheckMail_and_Password для отправки на сервер
                                        CheckMail_and_Password ss = new CheckMail_and_Password(Password, Mail);
                                        //Серелизуем класс CheckMail_and_Password для отправки на сервер
                                        JsonSerializer.Serialize<CheckMail_and_Password>(memoryStream, ss);
                                        //Декодировали в строку  memoryStream    класс запоаковали в json строку
                                        FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                                        //Отправляем на сервер  команду 003
                                        Task.Run(async () => await command.Check_User_Possword(ip_Adress.Ip_adressss, FileFS, "003")).Wait();
                                        //Значение почты пользователя  присваеваем по умолчанию почту для следущего входа пользователей
                                        Mail = null;
                                        //Значение пароля пользователя  присваеваем по умолчанию пароль для следущего входа пользователей 
                                        Password = null;
                                        nameEntry1.Text = null;
                                        nameEntry9.Text = null;
                                        //Ответ с сервера получаем 
                                        if (command.Travel_logout == null)
                                        {
                                            await DisplayAlert("Уведомление", "Такого пользователя нет!", "ОK"); }
                                        else   {
                                            if (string.IsNullOrEmpty(command.Travel_logout.Employee_Mail))
                                            {
                                                await DisplayAlert("Уведомление", "Такого пользователя нет!", "ОK");   }
                                            else
                                            { if (command.Travel_logout.Id == 0)  {
                                                    await DisplayAlert("Уведомление", "Пароль введен не верно!", "ОK");}
                                                else
                                                {   var regis_Users = command.Travel_logout;
                                                    switch (regis_Users.Rechte.Id) {
                                                        case 1:
                                                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Пользователь Авторизовался!", "ОK");
                                                            await Navigation.PushAsync(new Client.Users.Users(regis_Users));
                                                            var flyoutItemhelp1 = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("login"));
                                                            if (flyoutItemhelp1 != null) {
                                                                flyoutItemhelp1.IsVisible = false;}
                                                            var flyoutItemseting1 = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
                                                            if (flyoutItemseting1 != null){
                                                                flyoutItemseting1.IsVisible = false; }
                                                            //await Shell.Current.GoToAsync("user"); // Используйте URI для перехода к пользовательской странице
                                                            break;
                                                        case 2:
                                                            await Navigation.PushAsync(new Admin());
                                                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Администратор Авторизовался!", "ОK");
                                                            //Admin admin = new Admin();
                                                            var flyoutItemhelp = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("login"));
                                                            if (flyoutItemhelp != null){
                                                                flyoutItemhelp.IsVisible = false;}

                                                            var flyoutItemseting = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
                                                            if (flyoutItemseting != null) {
                                                                flyoutItemseting.IsVisible = false; }
                                                            //var adminPage = new ();
                                                            //var navigationPage2 = new NavigationPage(adminPage);
                                                            //   await Shell.Current.GoToAsync("admin");
                                                            // Используйте URI для перехода к административной странице
                                                            //Application.Current.MainPage = navigationPage2;
                                                            break;  } } }  } }}  }  }
                        else
                        {
                            //Не проходит на почту действетульную
                            await DisplayAlert("Уведомление", "Ввели не почту!", "ОK");
                        }}}}}










        public async void Ping(string FileFS, Ip_adress ip_Address)
        {
            Галочка галочка = null;
            using (MemoryStream stream = new MemoryStream())
            {
                Галочка галочка1 = new Галочка(1, $"{ip_Address.Ip_adressss}");
                var Result = checkPing.CheckPingIp(галочка1);
                галочка = Result;
            }
            if (галочка == null)
            {
                await DisplayAlert("Уведомление", "Сервер выключен или недоступен!", "ОK");
                return;
            }
            if (string.IsNullOrEmpty(Mail))
            {
                await DisplayAlert("Уведомление", "Почта не заполнена!", "ОK");
                return;
            }
            string pattern = "@.";
            if (!Regex.IsMatch(Mail, pattern))
            {
                await DisplayAlert("Уведомление", "Некорректный формат адреса электронной почты!", "ОK");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await DisplayAlert("Уведомление", "Пароль не заполнен!", "ОK");
                return;
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                CheckMail_and_Password ss = new CheckMail_and_Password(Password, Mail);
                await JsonSerializer.SerializeAsync<CheckMail_and_Password>(memoryStream, ss);
                FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                await command.Check_User_Possword(ip_Address.Ip_adressss, FileFS, "003");
                Mail = null;
                Password = null;
                nameEntry1.Text = null;
                nameEntry9.Text = null;

                if (command.Travel_logout == null || string.IsNullOrEmpty(command.Travel_logout.Employee_Mail))
                {
                    await DisplayAlert("Уведомление", "Такого пользователя нет!", "ОK");
                }
                else if (command.Travel_logout.Id == 0)
                {
                    await DisplayAlert("Уведомление", "Пароль введен не верно!", "ОK");
                }
                else
                {
                    var regis_Users = command.Travel_logout;
                    switch (regis_Users.Rechte.Id)
                    {
                        case 1:
                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Пользователь Авторизовался!", "ОK");
                            await Navigation.PushAsync(new Client.Users.Users(regis_Users));
                            var flyoutItemhelp1 = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("login"));
                            if (flyoutItemhelp1 != null)
                            {
                                flyoutItemhelp1.IsVisible = false;
                            }
                            var flyoutItemseting1 = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
                            if (flyoutItemseting1 != null)
                            {
                                flyoutItemseting1.IsVisible = false;
                            }
                            break;
                        case 2:
                            await Navigation.PushAsync(new Admin());
                            await Application.Current.MainPage.DisplayAlert("Уведомление", "Администратор Авторизовался!", "ОK");
                            var flyoutItemhelp = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("login"));
                            if (flyoutItemhelp != null)
                            {
                                flyoutItemhelp.IsVisible = false;
                            }
                            var flyoutItemseting = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_seting"));
                            if (flyoutItemseting != null)
                            {
                                flyoutItemseting.IsVisible = false;
                            }
                            break;
                    }}}}

  


        /// <summary>
        /// Пароль 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameEntry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = nameEntry1.Text;
        }


 
        /// <summary>
        /// Вход  в учетную запись команда 003
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CounterLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                Ip_adress ip_Adress = new Ip_adress();
                ip_Adress.CheckOS();
                Class_interaction_Users.Ip_adress.Ip_adresss = ip_Adress.Ip_adressss;
                Ping pingSender = new Ping();

                //IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(ip_Adress.Ip_adressss);
                //foreach (System.Net.IPAddress address in hostEntry.AddressList)
                //{
                //    ip_Adress.Ip_adressss = address.ToString();
                //    break;
                //}

                //IPAddress[] addresses = Dns.GetHostAddresses(ip_Adress.Ip_adressss);

                //foreach (IPAddress address in addresses)
                //{
                //    //Console.WriteLine("IP Address: " + address.ToString());
                //    ip_Adress.Ip_adressss = address.ToString();
                //    break;
                //}
                //string localIP;
                //using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                //{
                //    socket.Connect(ip_Adress.Ip_adressss, 9595);
                //    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                //    localIP = endPoint.Address.ToString();
                //}

                //string interfaceDescription = string.Empty;
                //var result = new List<IPAddress>();
                //var upAndNotLoopbackNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces().Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback
                //                                                                                              && n.OperationalStatus == OperationalStatus.Up);

                //foreach (var networkInterface in upAndNotLoopbackNetworkInterfaces)
                //{
                //    var iPInterfaceProperties = networkInterface.GetIPProperties();

                //    var unicastIpAddressInformation = iPInterfaceProperties.UnicastAddresses.FirstOrDefault(u => u.Address.AddressFamily == AddressFamily.InterNetwork);
                //    if (unicastIpAddressInformation == null) continue;

                //    result.Add(unicastIpAddressInformation.Address);

                //    interfaceDescription += networkInterface.Description + "---";
                //}

                //var address = NetworkInterface.GetAllNetworkInterfaces().Where(_ => _.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                //                                                            _.OperationalStatus == OperationalStatus.Up)
                //.SelectMany(_ => _.GetIPProperties().UnicastAddresses).ToList();

                //[assembly: Dependency(typeof(YourAppNamespace.Android.Android.DependencyServices.IPAddressManager))]

                //IPAddress[] addresses = Dns.GetHostAddresses(ip_Adress.Ip_adressss);

                //foreach (IPAddress address in addresses)
                //{
                //    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                //    {
                //        Console.WriteLine("IP Address: " + address.ToString());
                //    }
                //}
                //string FileFS = "";

                //Ping(FileFS, ip_Adress);


                PingReply reply = pingSender.Send(ip_Adress.Ip_adressss, 50);
                string FileFS = "";
                if (reply.Status == IPStatus.Success)
                {
                    //  Start(FileFS, ip_Adress);
                    //IPHostEntry hostEntry = Dns.GetHostEntry(ip_Adress.Ip_adressss);
                    //foreach (IPAddress address in hostEntry.AddressList)
                    //{
                    //    ip_Adress.Ip_adressss = address.ToString();
                    //    break;
                    //}
                    Ping(FileFS, ip_Adress);

                }
                else
                {
                    FileFS = "";
                    //   Start(FileFS, ip_Adress);
                    Ping(FileFS, ip_Adress);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");
            }
        }


        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private   void CounterBtn_Clicked_1(object sender, EventArgs e)
        {
            try
            {

                // Создание NavigationPage с главной страницей
                //var mainPage = new ;
                //var navigationPage = new NavigationPage(mainPage);
                Ip_adress ip_Adress = new Ip_adress();
                ip_Adress.CheckOS();
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip_Adress.Ip_adressss, 500);
                if (reply.Status == IPStatus.Success)
                {
                    RegUser(ip_Adress);
                }
                else
                {
                    RegUser(ip_Adress);
                }
            }
            catch
            {

            }
            //// Создание NavigationPage с главной страницей
            //var mainPage = new MainPage();
            //var navigationPage = new NavigationPage(mainPage);

            //// Установка NavigationPage в качестве главной страницы приложения

            //  вход_В_Учетную_Запись =new();
            // INavigation navigation = new.Navigation;

            // Переход на предыдущую страницу

            //   await navigation.PopAsync();

            //вход_В_Учетную_Запись.GetVisualElementWindow().Content.CaptureAsync();
            //Открывает
            //  вход_В_Учетную_Запись.DisplayAlert(Title,"Открывает","");
        }

        public async void RegUser(Ip_adress ip_Address)
        {
            try
            {
                Галочка галочка = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    Галочка галочка1 = new Галочка(1, $"{ip_Address.Ip_adressss}");
                    var Result = checkPing.CheckPingIp(галочка1);
                    галочка = Result;
                }
                if (галочка == null)
                {
                    await DisplayAlert("Уведомление", "Сервер выключен или недоступен!", "ОK");
                    return;
                }
                await Navigation.PushAsync(new RegUser());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

            }
        }
        private void nameEntry_TextChanged_1(object sender, TextChangedEventArgs e)
        {
        }

        private void nameEntry9_TextChanged(object sender, TextChangedEventArgs e)
        { 
            Mail = nameEntry9.Text;

        }

        private void ContentPage_Loaded(System.Object sender, System.EventArgs e)
        {
            try
            {


                //  Application.Current.MainPage.SetValue(NavigationPage.HasNavigationBarProperty, false);
                //    Application.Current.MainPage.SetValue(NavigationPage.HasBackButtonProperty, false);
                Application.Current.MainPage.Window.Width = 530.8d;
                Application.Current.MainPage.Window.Height = 650.8d;

                Application.Current.MainPage.Window.MinimumWidth = 530.8d;
                Application.Current.MainPage.Window.MinimumHeight = 650.8d;

                Application.Current.MainPage.Window.MaximumWidth = 530.8d;
                Application.Current.MainPage.Window.MaximumHeight = 650.8d;

                //nameEntry9.Text = "maks_nt@list.ru";
                //nameEntry1.Text = "1";
                //nameEntry9.Text = "Admin@Admin.ru";
                //nameEntry1.Text = "Admin";
                if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=admin"))
                {
                    nameEntry9.Text = "Admin@Admin.ru";
                    nameEntry1.Text = "Admin";
                    //nameEntry9.Text = "+";
                    //nameEntry1.Text = "1";
                }
                else if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=user"))
                {
                    // Handle user parameter
                    nameEntry9.Text = "c";
                    nameEntry1.Text = "1";
                }
                else if (Shell.Current.CurrentState.Location.OriginalString.Contains("sell=help"))
                {
                    // Handle help parameter
                }
                else if (Shell.Current.CurrentState.Location.OriginalString.Contains("//login"))
                {
                    var flyoutItem = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("admin"));
                    if (flyoutItem != null)
                    {
                        flyoutItem.IsVisible = false;
                    }


                    var flyoutItemUser = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("User"));
                    if (flyoutItemUser != null)
                    {
                        flyoutItemUser.IsVisible = false;
                    }
                    var flyoutItemhelp = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("help"));
                    if (flyoutItemhelp != null)
                    {
                        flyoutItemhelp.IsVisible = false;
                    }

                    //nameEntry9.Text = "Admin@Admin.ru";
                    //nameEntry1.Text = "Admin";
                    //nameEntry9.Text = "Полина@Admin.ru";
                    //nameEntry1.Text = "12";


                }


            }
            catch
            {

            }

        }
    }
}
