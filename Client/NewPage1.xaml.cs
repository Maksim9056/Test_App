using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Text.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Animations;
using Microsoft.Maui;

namespace Client;
public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
        try
        {
            InitializeComponent();
        }
        catch
        {

        }
	}

  //  Dictionary<string, string> ������� = new Dictionary<string, string>();
    string ������ { get; set; }
    string ����� { get; set; }

    /// <summary>
    /// ��������� ������ CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> ������� = new List<string>();

    public List<string> ������ = new List<string>();


    public List<string> �������s = new List<string>();

    public List<string> ������s = new List<string>();

    List<string>�������_����� = new List<string>();

    private void nameEntr�4_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            ����� = nameEntr�9.Text;
            //Console.WriteLine(Results[0]);
            //Console.WriteLine(Results[1]);
            // Console.WriteLine(Results[3]);
            //var Results = Return?.Split(new char[] { '.' });
            //Console.WriteLine(Results[0]);
            //Console.WriteLine(Results[1]);
            //Console.WriteLine(Results[2]);
            //Console.WriteLine(Results[3]);
        }
        catch
        {

        }
    }

    private void CounterLog12_Clicked(object sender, EventArgs e)
    {

    }

   

    private void nameEntr�5_TextChanged(object sender, TextChangedEventArgs e)
    {
        ������ = nameEntr�5.Text;

    }

    private async void CounterLog13_Clicked(object sender, EventArgs e)
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
                            �������.Add(������);

                            ������.Add(�����);
                            //FileFS ��������� ��� �������� �� ������
                            string FileFS = "";
                            //��������� MemoryStream 
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //��������� ����� Questions ��� �������� �� ������
                                Questions questions = new Questions { Questionss = �������[0], Answer_True = ������[0] };
                                //���������� ����� CheckMail_and_Password ��� �������� �� ������
                                JsonSerializer.Serialize<Questions>(memoryStream, questions);
                                //������������ � ������  memoryStream    ����� ����������� � json ������
                                FileFS = Encoding.Default.GetString(memoryStream.ToArray());
                                //������� = �������s;
                                //������ = ������s;
                                for(int i = 0; i < �������.Count(); i++)
                                {
                                    �������.Clear();

                                }

                                for (int i = 0; i < ������.Count(); i++)
                                {
                                    ������.Clear();
                                }

                                Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();

                                //�������
                               string[] strings = new string[CommandCL.Roles_Accept.Quest.Length];
                                for (int i = 0; i < strings.Length; i++)
                                {
                                    strings[i] = CommandCL.Roles_Accept.Quest[i].Questionss.ToString();
                                }
                                nameEntr�5.Text = "";
                                nameEntr�9.Text = "";

                              for(int i = 0; i < strings.Length; i++)
                              {
                                    �������_�����.Add(strings[i]);
                              }
                                //  usersList.AutomationId 
                                //usersList.AutomationId =Convert.ToString( �������_�����.Count()); 
                                //.ScrollIntoView(myList.Items[myList.Items.Count - 1])
                                usersList.ItemsSource = �������_�����;
                                for (int i = 0; i < �������_�����.Count(); i++)
                                {
                                    �������_�����.Clear();
                                }
                                // ���������� �������� ������
                                await DisplayAlert("�����������", "������� � ����� ��������!", "�K");
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
        //string[][] ������� = new string[�������.Keys][�������.Values;)] {};

        //for (int i = 0; i < �������.Count(); i++)
        //{
        //    �������[i] = �������[i];
        //}

        //�������.Add();

        //for (int i = 0; i < �������.Length; i++)
        //{
        //    Console.WriteLine(�������[i]);
        //}

    }

    private void CounterLog13_Clicked_1(object sender, EventArgs e)
    {
        try
        {

        }
        catch
        {

        }

    }




    private void ContentPage_Loaded(object sender, EventArgs e)
    {
            //Application.Current.MainPage.Window.Width =;
            //    Application.Current.MainPage.Window.Height = ;  
            //Application.Current.MainPage.Window.MaximumWidth = 1200.8d;
            //Application.Current.MainPage.Window.MaximumHeight = 650.8d;

            //Application.Current.MainPage.GetParentWindow(); 
            //Application.Current.MainPage.GetVisualElementWindow();
            //= 1600.8d; 
            //= 1200.8d;  //Console.WindowHeight;
            //Application.Current.MainPage.Window.MinimumWidth = Application.Current.MainPage.Width; Application.Current.MainPage.Width
            //Application.Current.MainPage.Window.MinimumHeight = Application.Current.MainPage.Height;Application.Current.MainPage.Height
            Application.Current.MainPage.Window.MaximumWidth = 1600;
            Application.Current.MainPage.Window.MaximumHeight = 1400;

      
    }

    //private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //        header.Text = $"�� �������: {languagePicker.SelectedItem}";
        
    //}



    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            //��������
            headers.Text = $"�������: {e.SelectedItem}";
        }
        catch
        {

        }
    }


    private void usersList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        try
        {


            var tappedUser = e.Item  ;
            if (tappedUser != null)
                header.Text = $"������: {tappedUser}";
        }
        catch
        {

        }
    }

    private void usersList_ItemSelected_2(object sender, SelectedItemChangedEventArgs e)
    {
        try

        {
            var selectedUser = e.SelectedItem;
                if (selectedUser != null)
                {

                }
                headers.Text = $"�������: {selectedUser}";
            }
        catch
        {

        }
     }
}