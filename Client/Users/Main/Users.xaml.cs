using Class_interaction_Users;
using Client.Main;
using Client.Users.Doc.DocPersonalAchievement;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
//using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Storage;
using SkiaSharp;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Input;
using System.Xml.Linq;
using Image = Microsoft.Maui.Controls.Image;

namespace Client.Users;

public partial class Users : ContentPage
{
    //public static string NameUsers { get; set; }
    //public static int id { get; set; }
    public static User user { get; set; }
    public Regis_users regis_Users { get; set; }
    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public Filles_Work filles_Work = new Filles_Work();

    public Filles files { get; set; }


     public string Connect()
    {
        try
        {
            Ip_adress ip_Adress = new Ip_adress();
            ip_Adress.CheckOS();

            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip_Adress.Ip_adressss, 50);
            //  string FileFS = "";
            if (reply.Status == IPStatus.Success)
            {
                //  Start(FileFS, ip_Adress);
               Class_interaction_Users.Ip_adress.Ip_adresss = ip_Adress.Ip_adressss;

               
            }
            else
            {
                //   FileFS = "";
                //   Start(FileFS, ip_Adress);

            }
            return ip_Adress.Ip_adressss;
        }
        catch (Exception ex)
        {
             DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.HelpLink, "Ок");

        }
        return null;
    }
    
    public void Images(Regis_users name, Filles filles)
    {
        try
        {
            NameUser.Text = name.Name_Employee;
            string IPAdress = Connect();
            var file = filles_Work.SelectFromFilles(IPAdress, filles);

            if (filles_Work.Filles == null)
            {
                Images(name, filles);
            }
            else
            {


                files = filles_Work.Filles;
                Image();


            }
        }
        catch(Exception)
        {

        }
    }
    public Users(Regis_users name )
    {
        try
        {
            InitializeComponent();

            regis_Users = name;
            Filles filles = new Filles { Id = name.Filles };
            user = new User
            {
                Id = name.Id,
                Password = name.Password,
                Name_Employee = name.Name_Employee ,
                Employee_Mail = name.Employee_Mail,
                Id_roles_users = name.Rechte.Id,
                Email = filles

            };

            Images(name,filles);


        }
        catch(Exception)
        {

        }
        //ImageUser.Source 
    }



    public void Image()
    {
        try
        {



            string path = System.AppContext.BaseDirectory + "\\путь_к_файлу.jpg";


            // Создание потока на основе массива байт изображения

            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {

                string paths = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "путь_к_файлу.jpg");


                if (System.IO.File.Exists(paths))
                {
                    // Удаление файла
                    System.IO.File.Delete(paths);
                }

                File.WriteAllText(paths, files.Name.ToString());
                ImageUser.Source = File.ReadAllText(paths);

            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                string paths = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "путь_к_файлу.png");
                string filePath = Path.Combine(Path.GetTempPath(), "путь_к_файлу.");

               // Создание объекта Bitmap из MemoryStream

         //       Bitmap bitmap;
     

                // Преобразование в объект Bitmap

                string filePaths = Path.Combine(Path.GetTempPath(), "image.jpg"); // 
              

                using (MemoryStream stream = new MemoryStream(files.Name))
                {


                    // image = Microsoft.Maui.Graphics.Platform.PlatformImage.FromStream(stream);

                    System.IO.File.WriteAllBytes(path, files.Name); 
                    ImageUser.Source  = path;
                    //     bitmap = BitmapFactory.DecodeByteArray(ms.GetByteArray(), 0, ms.GetByteArray().Length); // Исправленное создание объекта Bitmap из массива байтов

                    //var image = new Image();
                    //image.Source = ImageSource.FromFile(filePath);



                    if (System.IO.File.Exists(paths))
                    {
                        // Удаление файла
                        System.IO.File.Delete(paths);
                    }

                    //   File.WriteAllText(paths, files.Name.ToString());
                    //var sd   = File.ReadAllText(paths);
                    //   ImageUser.Source = sd;

                }
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {

                using (MemoryStream memoryStream = new MemoryStream(files.Name))
                {
                    // Сохранение изображения на диск


                    if (System.IO.File.Exists(path))
                    {
                        // Удаление файла
                        System.IO.File.Delete(path);
                    }

                    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                    ImageUser.Source = path;
                }




            }
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
            {

            }
        }
        catch(Exception ex) 
        {
           // DisplayAlert("Ошибка", "Сообщение" + ex.Message + "\n" + "Помощь:" + ex.Data, "Ок");
        }
    }

   public void User_NAME(Regis_users name)
    {

   
    }
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        //var selectedExamsTest = (RefExamsTest)e.SelectedItem;
        //await DisplayAlert("Выбранный тест", selectedExamsTest.ExamsTest.Exams.Name_exam, "OK");
        //((ListView)sender).SelectedItem = null;
    }

    private async void ExamButtonClicked(object sender, EventArgs e)
    {
        // User User =new  User() 

        //      Shell.Current.GoToAsync("examispersonal");
        await Navigation.PushAsync(new DocTheExamisPersonal(user));
        //await Shell.Current.GoToAsync(nameof(DocTheExamisPersonal), new Dictionary<string, object>
        //{
        //    { "user", user }
        //});
        //await Shell.Current.GoToAsync($"{nameof(DocTheExamisPersonal)}", new Dictionary<string, object>
        //{
        //     { nameof(User), user }
        //});

        // User
        //  Class_interaction_Users.User user
    }
    private void GoBack(object sender, EventArgs e)
    {
        //if (Application.Current.MainPage is NavigationPage navigationPage)
        //{
        //    navigationPage.Navigation.PopAsync();
        //}
        Shell.Current.GoToAsync("logout");
    }

    private async void AchievementsButtonClicked(object sender, EventArgs e)
    {
        //      Shell.Current.GoToAsync("achievement");
        await Navigation.PushAsync(new DocPersonalAchievement(user));

    }

    private void SettingsButtonClicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        //var flyoutItemUser = (FlyoutItem)Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("User"));
        //if (flyoutItemUser != null)
        //{
        //    flyoutItemUser.IsVisible = true;
        //}

  


        var flyoutItemUser = Shell.Current.Items.FirstOrDefault(item => item.Route.Equals("IMPL_user2"));
        if (flyoutItemUser == null)
        {
            // Создание пунктов меню класса
            var main = new ShellContent { Content = new Client.Users.Users(regis_Users) };
            // Добавление пунктов меню в класс
            Shell.Current.Items.Add(new ShellSection { Title = "Пользователь", Items = { main }, Icon = "dotnet_bot.png", Route = "user2" });

        }




    }
    private  async void Statictick_Users(object sender, EventArgs e)
    {

      //  Shell.Current.GoToAsync("statistics");
        await Navigation.PushAsync(new Client.Users.Doc.DocStatisticsUserResult.DocStatisticsUserResult (user));

    }
}