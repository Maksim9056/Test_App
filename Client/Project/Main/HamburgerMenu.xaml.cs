using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Class_interaction_Users;
using Microsoft.Maui.Controls.Compatibility;

namespace Client.Project

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMenu : Shell
    {
        public HamburgerMenu()
        {
            InitializeComponent();

            Routing.RegisterRoute("page1", typeof(RefAnswerListPage));
            Routing.RegisterRoute("page2", typeof(RefAnswerListPage));
            Routing.RegisterRoute("page3", typeof(RefAnswerListPage));
        }
    }
}