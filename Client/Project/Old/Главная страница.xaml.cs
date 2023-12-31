using Class_interaction_Users;

namespace Client;

public partial class Главная_страница : ContentPage
{
    public Главная_страница()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Экземпляр класса CommandCL
    /// </summary>
    public CommandCL command = new CommandCL();


    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
        header.Text = $"Вы выбрали: {languagePicker.SelectedItem}";
    }

    private async void header_SizeChanged(object sender, EventArgs e)
    {
        Task.Run(async () => await command.Check_Test(Ip_adress.Ip_adresss, "", "004")).Wait();
        if (CommandCL.Tests_Travel == null)
        {

        }
        else
        {
            if (CommandCL.Tests_Travel.Test.Count() == 0)
            {
                await DisplayAlert("Уведомление", "Тестов нету !", "ОK");
            }
            else
            {
                string[] strings = new string[CommandCL.Tests_Travel.Test.Count()];
                for (int i = 0; i < strings.Length; i++)
                {
                    strings[i] = CommandCL.Tests_Travel.Test[i].ToString();
                }
                for (int i = 0; i < strings.Length; i++)
                {
                    languagePicker.Items.Add(strings[i]);
                }
                await DisplayAlert("Уведомление", "Тесты есть", "ОK");
            }
        }
    }
}
