using System.Windows.Input;

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
            Routes.Add("admin", typeof(Client.Main.Admin));
            Routes.Add("user", typeof(Client.Users.Doc.DocExamFromTests.DocExamFromTests));
            Routes.Add("logout", typeof(Client.MainPage));
            Routes.Add("achievement", typeof(Client.Users.Doc.DocPersonalAchievement.DocPersonalAchievement));
            Routes.Add("examispersonal", typeof(Client.Users.Doc.DocTheExamisPersonal.DocTheExamisPersonal));
            Routes.Add("examfromtests", typeof(Client.Users.Doc.DocExamFromTests.DocExamFromTests));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}