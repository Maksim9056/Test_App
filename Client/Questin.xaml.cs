using Class_interaction_Users;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Client;

public partial class Questin : ContentPage
{
    public Questin()
    {
        InitializeComponent();
    }

    string ������ { get; set; }
    string ����� { get; set; }

    /// <summary>
    /// ��������� ������ CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> _������� = new List<string>();

    public List<string> ������ = new List<string>();


    public List<string> �������s = new List<string>();

    public List<string> ������s = new List<string>();

    public List<string> �������_�����   = new List<string>();


    //public ObservableCollection<Questions[> Userss ;


    public List<string> Users { get; set; }
    private void nameEntr�9_TextChanged(object sender, TextChangedEventArgs e)
    {
        ����� = nameEntr�9.Text;

    }

    private void nameEntr�5_TextChanged(object sender, TextChangedEventArgs e)
    {
        ������ = nameEntr�5.Text;
    }

    //�������
    private async void CounterLog12_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (������ == null)
            {
                await DisplayAlert("�����������", "������� ������ ��������� ����!", "�K");
            }
            else
            {
                if (string.IsNullOrEmpty(������))
                {
                    await DisplayAlert("�����������", "������� ������ ��������� ����!", "�K");

                }
                else
                {
                    if (����� == null)
                    {
                        await DisplayAlert("�����������", "����� ������ ��������� ����!", "�K");

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(�����))
                        {
                            await DisplayAlert("�����������", "����� ������ ��������� ����!", "�K");

                        }
                        else
                        {
                            _�������.Add(������);

                            ������.Add(�����);
                            //FileFS ��������� ��� �������� �� ������
                            string FileFS = "";
                            //��������� MemoryStream 
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //��������� ����� Questions ��� �������� �� ������
                                Questions questions = new Questions { Questionss = _�������[0], Answer_True = ������[0] };
                                //���������� ����� CheckMail_and_Password ��� �������� �� ������
                                JsonSerializer.Serialize<Questions>(memoryStream, questions);
                                //������������ � ������  memoryStream    ����� ����������� � json ������
                                FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                                //������� = �������s;
                                //������ = ������s;
                                for (int i = 0; i < _�������.Count(); i++)
                                {
                                    _�������.Clear();

                                }
                                if (usersList.ItemsSource == null)
                                {

                                }
                                else
                                {
                                    usersList.ItemsSource = null;
                                    for (int i = 0; i < �������_�����.Count(); i++)
                                    {
                                        �������_�����.Clear();
                                    }
                                }

                                for (int i = 0; i < ������.Count(); i++)
                                {
                                    ������.Clear();
                                }

                                bool ������_���������� = false;
                                Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();
                                string Team = "";
                                //�������
                                for (int i = 0; i < CommandCL.Roles_Accept.Quest.Length; i++)
                                {
                                    if (CommandCL.Roles_Accept.Quest[i].Id == 0)
                                    {
                                        ������_���������� = true;
                                        break;
                                    }
                                    else
                                    {

                                    }
                                }
                                if (������_���������� == false)
                                {
                                    string[] strings = new string[CommandCL.Roles_Accept.Quest.Length];
                                    for (int i = 0; i < strings.Length; i++)
                                    {

                                        strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss;


                                    }

                                    nameEntr�5.Text = "";
                                    nameEntr�9.Text = "";

                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        �������_�����.Add(strings[i]);
                                    }
                                    //  usersList.AutomationId 
                                    //usersList.AutomationId =Convert.ToString( �������_�����.Count()); 
                                    //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                                    usersList.ItemsSource = �������_�����;

                                    //���� ������ � git151556
                                    // ���������� ������� ������ ������
                                    //usersList.ItemSelected += (sender, e) =>
                                    //{
                                    //    if (e.SelectedItem != null)
                                    //    {
                                    //        int selectedIndex = �������_�����.IndexOf(e.SelectedItem.ToString());
                                    //        string selectedValue = e.SelectedItem.ToString();
                                    //        // ��������� ����������� �������� � ��������� ��������� � ��������
                                    //        // ��������, �������� �� �� ����� ��� ��������� � ����������
                                    //        DisplayAlert("��������� ������", $"������: {selectedIndex}, ��������: {selectedValue}", "��");
                                    //    }
                                    //};

                                    
                                    // ���������� �������� ������
                                    //  usersList.ItemsSource = ;
                                    // usersList.
                                }
                                else
                                {
                                    await DisplayAlert("�����������","������� ��� ���� ����� !������� ������ ������ !", "�K");

                                    //usersList.ItemSelected += (sender, e) =>
                                    //{
                                    //    if (e.SelectedItem != null)
                                    //    {
                                    //        int selectedIndex = �������_�����.IndexOf(e.SelectedItem.ToString());
                                    //        string selectedValue = e.SelectedItem.ToString();
                                    //        // ��������� ����������� �������� � ��������� ��������� � ��������
                                    //        // ��������, �������� �� �� ����� ��� ��������� � ����������
                                    //        DisplayAlert("��������� ������", $"������: {selectedIndex}, ��������: {selectedValue}", "��");
                                    //    }
                                    //};
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("�����������", ex.Message, "�K");
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            string FileFS = "";
            //Admin @Admin.ru
            //Application.Current.MainPage.Window.
            Application.Current.MainPage.Window.MinimumWidth = 1550;
            Application.Current.MainPage.Window.MinimumHeight = 1250;
            Application.Current.MainPage.Window.MaximumWidth = 1550;
            Application.Current.MainPage.Window.MaximumHeight = 1300;

            Task.Run(async () => await command.Connect_Friends(Ip_adress.Ip_adresss, FileFS, "008")).Wait();
            string[] strings = new string[CommandCL.Roles_Accept.Quest.Length];
            for (int i = 0; i < strings.Length; i++)
            {

                strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss;

              
            }

            for (int j = 0; j < strings.Length; j++)
            {
                �������_�����.Add(strings[j]);
            }

            usersList.ItemsSource = �������_�����;
        }catch (Exception )
        {

        }
    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            int selectedIndex = �������_�����.IndexOf(e.SelectedItem.ToString());
            string selectedValue = e.SelectedItem.ToString();
            // ��������� ����������� �������� � ��������� ��������� � ��������
            // ��������, �������� �� �� ����� ��� ��������� � ����������
            DisplayAlert("��������� ������", $"������: {selectedIndex}, ��������: {selectedValue}", "��");
        }
    }

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        if (usersList.ItemsSource == null)
        {

        }
        else
        {
            usersList.ItemsSource = null;
            for (int i = 0; i < �������_�����.Count(); i++)
            {
                �������_�����.Clear();
            }
        }
        var mainPage = new �������������();
        var navigationPage = new NavigationPage(mainPage);

        Application.Current.MainPage = navigationPage;
    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {

    }
}