namespace Client.Project.Main;

public partial class Backup : ContentPage
{
	public Backup()
	{
		InitializeComponent();
	}

    private async void CounterLog4_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Client.Project.Main.Type_of_resverve_copy());

    }

    private async void GoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }
}