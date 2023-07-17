using Class_interaction_Users;
using System.Text;
using System.Text.Json;

namespace Client;

public partial class Вопросы : ContentPage
{  //  Dictionary<string, string> Вопросы = new Dictionary<string, string>();
    string Вопрос { get; set; }
    string Ответ { get; set; }

    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();

    public List<string> _Вопросы = new List<string>();

    public List<string> Ответы = new List<string>();


    public List<string> Вопросыs = new List<string>();

    public List<string> Ответыs = new List<string>();

    public List<string> Вопросы_вывод = new List<string>();

    public Вопросы()
	{
        try
        {
            InitializeComponent();
        }
        catch(Exception)
        {

        }
    }

    private   void CounterLog12_Clicked(object sender, EventArgs e)
    {
      
        //string[][] вопросы = new string[Вопросы.Keys][Вопросы.Values;)] {};

        //for (int i = 0; i < Вопросы.Count(); i++)
        //{
        //    вопросы[i] = Вопросы[i];
        //}

        //Вопросы.Add();

        //for (int i = 0; i < вопросы.Length; i++)
        //{
        //    Console.WriteLine(вопросы[i]);
        //}
    }

    private void nameEntrу9_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void nameEntrу5_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    //private void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    var selectedUser = e.SelectedItem;
    //    if (selectedUser == null)
    //    {

    //    }
    //    else
    //    {
    //        headers.Text = $"Выбрано: {selectedUser}";

    //    }
    //}

    //private void usersList_ItemTapped(object sender, ItemTappedEventArgs e)
    //{

    //    var tappedUser = e.Item;
    //    if (tappedUser == null)
    //    {

    //    }
    //    else
    //    {
    //        header.Text = $"Нажато: {tappedUser}";
    //    }
    //}

    private void CounterLog13_Clicked(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// СТАРТ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
    //    
    }
}