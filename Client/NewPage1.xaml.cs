using System.Linq;

namespace Client;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private void nameEntrу4_TextChanged(object sender, TextChangedEventArgs e)
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

    private void nameEntrу4_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    List<string> Вопросы;

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {
        Вопросы.Add(nameEntrу5.Text);

    }

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {
        string[] вопросы = new string[Вопросы.Count()];

        for (int i = 0; i < Вопросы.Count(); i++)
        {
            вопросы[i] = Вопросы[i];
        }



        for (int i = 0; i < вопросы.Length; i++)
        {
            Console.WriteLine(вопросы[i]);
        }
    }
}