using System.Linq;

namespace Client;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void nameEntr�4_TextChanged(object sender, TextChangedEventArgs e)
    {

        

  
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

    List<string> �������;

    private void nameEntr�5_TextChanged(object sender, TextChangedEventArgs e)
    {
        �������.Add(nameEntr�5.Text);

    }

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        string[] ������� = new string[�������.Count()];

        for (int i = 0; i < �������.Count(); i++)
        {
            �������[i] = �������[i];
        }



        for (int i = 0; i < �������.Length; i++)
        {
            Console.WriteLine(�������[i]);
        }
    }
}