using System.Windows.Input;
using System.Collections.Generic;

namespace Client
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            Routes.Add("login", typeof(MainPage));
            //Routes.Add("admin", typeof(Client.Main.Admin));
            //Routes.Add("user", typeof(Client.Users.Users));
            Routes.Add("logout", typeof(Client.MainPage));
            Routes.Add("achievement", typeof(Client.Users.Doc.DocPersonalAchievement.DocPersonalAchievement));
            Routes.Add("examispersonal", typeof(Client.Users.DocTheExamisPersonal));
            Routes.Add("examfromtests", typeof(Client.Users.Users));
            Routes.Add("DocTheExamisPersonal", typeof(Client.Users.DocTheExamisPersonal));
           // Routes.Add("RefUserListPage", typeof(Project.RefUserListPage));
            Routes.Add("statistics", typeof(Client.Users.Doc.DocStatisticsUserResult.DocStatisticsUserResult));


            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}