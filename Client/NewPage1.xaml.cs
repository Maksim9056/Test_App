using Class_interaction_Users;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Text.Json;
using System.Text;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Animations;

namespace Client;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

  //  Dictionary<string, string> ������� = new Dictionary<string, string>();
    string ������ { get; set; }
    string ����� { get; set; }

    /// <summary>
    /// ��������� ������ CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    List<string> ������� = new List<string>();

    List<string> ������ = new List<string>();

    private void nameEntr�4_TextChanged(object sender, TextChangedEventArgs e)
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

    private void CounterLog12_Clicked(object sender, EventArgs e)
    {

    }

    private void nameEntr�4_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntr�5_TextChanged(object sender, TextChangedEventArgs e)
    {
        ������ = nameEntr�5.Text;

    }

    private async void CounterLog13_Clicked(object sender, EventArgs e)
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
                            ������� = null;
                            ������ = null;
                            Task.Run(async () => await command.Get_Image_Friends(Ip_adress.Ip_adresss, FileFS, "007")).Wait();

                       
                            await DisplayAlert("�����������", "������� � ����� ��������!", "�K");

                            string[] strings = new string[CommandCL.Questionss_Travel.Questionsses.Count()];
                            for (int i = 0; i < strings.Length; i++)
                            {
                                strings[i] = CommandCL.Questionss_Travel.Questionsses[i].ToString();
                            }
                            for (int i = 0; i < strings.Length; i++)
                            {
                                usersList.ItemsSource =strings[i];
                            }

                            usersList.ItemsSource = ;
                            usersList.
                            nameEntr�5.Text = null;
                            nameEntr�9.Text = null;
                            ������ = null;
                            ����� = null;
                        }
                    }
                }
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
    }

    private void CounterLog13_Clicked_1(object sender, EventArgs e)
    {

    }

    private void CounterLog14_Clicked(object sender, EventArgs e)
    {

    }

    private void nameEntr�10_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void CounterLog15_Clicked(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Application.Current.MainPage.Window.Width = 1000.8d;
        Application.Current.MainPage.Window.Height = 650.8d;

        Application.Current.MainPage.Window.MinimumWidth = 1000.8d;
        Application.Current.MainPage.Window.MinimumHeight = 650.8d;

        Application.Current.MainPage.Window.MaximumWidth = 1200.8d;
        Application.Current.MainPage.Window.MaximumHeight = 650.8d;
    }

    //private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //        header.Text = $"�� �������: {languagePicker.SelectedItem}";
        
    //}

    private  void header_SizeChanged_1(object sender, EventArgs e)
    {
        //Task.Run(async () => await command.Check_Test(Ip_adress.Ip_adresss, "", "004")).Wait();
        //if (CommandCL.Tests_Travel == null)
        //{

        //}
        //else
        //{
        //    if (CommandCL.Tests_Travel.Test.Count() == 0)
        //    {
        //        await DisplayAlert("�����������", "�������� ���� ���� !", "�K");
        //    }
        //    else
        //    {
        //        string[] strings = new string[CommandCL.Tests_Travel.Test.Count()];
        //        for (int i = 0; i < strings.Length; i++)
        //        {
        //            strings[i] = CommandCL.Tests_Travel.Test[i].ToString();
        //        }
        //        for (int i = 0; i < strings.Length; i++)
        //        {
        //            languagePicker.Items.Add(strings[i]);
        //        }
        //        await DisplayAlert("�����������", "�������� ����", "�K");
        //    }
        //}
    }

    private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //��������
        selected.Text = $"�������: {e.SelectedItem}";
    }

    /// <summary>
    /// ���������� �� ������ �� ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void header_SizeChanged(object sender, EventArgs e)
    {
       //������ �� ������ ���������
        usersList.ItemsSource = �������;
    }
}