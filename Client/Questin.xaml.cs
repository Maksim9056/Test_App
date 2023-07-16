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
                if(string.IsNullOrEmpty(������))
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

                                for (int i = 0; i < ������.Count(); i++)
                                {
                                    ������.Clear();
                                }

                                Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();
                                string Team ="";
                                //�������
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

                                // ���������� ������� ������ ������
                                usersList.ItemSelected += (sender, e) =>
                                {
                                    if (e.SelectedItem != null)
                                    {
                                        int selectedIndex = �������_�����.IndexOf(e.SelectedItem.ToString());
                                        string selectedValue = e.SelectedItem.ToString();
                                        // ��������� ����������� �������� � ��������� ��������� � ��������
                                        // ��������, �������� �� �� ����� ��� ��������� � ����������
                                        DisplayAlert("��������� ������", $"������: {selectedIndex}, ��������: {selectedValue}", "��");
                                    }
                                };

                                //for (int i = 0; i < �������_�����.Count(); i++)
                                //{
                                //    �������_�����.Clear();
                                //}
                                // ���������� �������� ������
                                //  usersList.ItemsSource = ;
                                // usersList.
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
         //Admin @Admin.ru
         //Application.Current.MainPage.Window.
        Application.Current.MainPage.Window.MinimumWidth = 1000;
        Application.Current.MainPage.Window.MinimumHeight = 800;
        Application.Current.MainPage.Window.MaximumWidth = 1600;
        Application.Current.MainPage.Window.MaximumHeight = 1400;
    }
}