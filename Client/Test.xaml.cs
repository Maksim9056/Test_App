using Class_interaction_Users;
using Microsoft.Maui.Controls;

namespace Client;

public partial class Test : ContentPage
{
    /// <summary>
    /// ��������� ������ CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> ������������_���_����� = new List<string>();
    public List<string> ������� = new List<string>();
    public List<string> ������ = new List<string>();

    public Test()
	{
		InitializeComponent();
	}

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {

    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void usersList1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = ������������_���_�����.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // ��������� ����������� �������� � ��������� ��������� � ��������
            // ��������, �������� �� �� ����� ��� ��������� � ����������
            DisplayAlert("��������� ������", $"������: {selectedIndex}, ��������: {selectedValue}", "��");
        }
    }

    private void nameEntr�9_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntr�5_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {
        var mainPage = new �������������();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private  void ContentPage_Loaded(object sender, EventArgs e)
    {
        try {
            Application.Current.MainPage.Window.MinimumWidth = 1550;
            Application.Current.MainPage.Window.MinimumHeight = 1250;
            Application.Current.MainPage.Window.MaximumWidth = 1550;
            Application.Current.MainPage.Window.MaximumHeight = 1300;
            Task.Run(async () => await command.From_Friend(Ip_adress.Ip_adresss, "", "015")).Wait();

            if (CommandCL.Regis_Users_Test == null)
            {

            }
            else
            {
                string[] strings = new string[CommandCL.Regis_Users_Test.regis.Length];
                for (int i = 0; i < strings.Length; i++)
                {
                    strings[i] = CommandCL.Regis_Users_Test.regis[i].Name_Employee;
                }


                for (int i = 0; i < strings.Length; i++)
                {
                    ������������_���_�����.Add(strings[i]);
                }

                usersList1.ItemsSource = ������������_���_�����;

                Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, "", "008")).Wait();
                string[] stringsS = new string[CommandCL.Roles_Accept.Quest.Length];
                for (int i = 0; i < stringsS.Length; i++)
                {

                    stringsS[i] = CommandCL.Roles_Accept.Quest[i].Questionss;


                }

                for (int j = 0; j < stringsS.Length; j++)
                {
                    �������.Add(stringsS[j]);
                }

                usersList2.ItemsSource = �������;

                Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, "", "008")).Wait();
                string[] stringsSs = new string[CommandCL.Roles_Accept.Quest.Length];
                for (int i = 0; i < stringsS.Length; i++)
                {

                    stringsSs[i] = CommandCL.Roles_Accept.Quest[i].Answer_True;


                }

                for (int j = 0; j < stringsSs.Length; j++)
                {
                    ������.Add(stringsSs[j]);
                }

             usersList3.ItemsSource = ������;
            }
        }
        catch
        {

        }
    }

    private void usersList3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}