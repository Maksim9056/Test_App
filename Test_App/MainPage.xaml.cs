using Microsoft.Maui.Graphics.Text;

namespace Test_App
{
    public partial class MainPage : ContentPage
    {

        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void CounterBts_Clicked(object sender, EventArgs e)
        {

            StackLayout stackLayout = new StackLayout();
            Grid grid = new Grid();

            {
            
                Entry entry = new Entry
                {
                    Placeholder = "Введите Техт",
                    //  FontFamily = "Helvetica",
                    FontSize = 15,
                    MaxLength = 20,
                    Margin = 100,
                    Background = Brush.Default,
                    BackgroundColor = Colors.White,
                    CursorPosition = 50,
                    //   IsTextPredictionEnabled = true,
                    //      SelectionLength = 10,
                    //   MaximumHeightRequest = 20,
                    HeightRequest = 20,
                    WidthRequest = 500,
                };
          
                grid.Children.Add(entry);
                Content = grid;
                  //     stackLayout.Children.Add(entry);
         //       grid;


            }
        }
    }
}