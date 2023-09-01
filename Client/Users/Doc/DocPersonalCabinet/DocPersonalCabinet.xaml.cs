using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
//using Microsoft.Maui.Graphics.Xaml;
using System.Collections.Generic;
using Client.Controls;

namespace Client.Users.Doc.DocPersonalCabinet
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocPersonalCabinet : ContentPage
    {
        //   public List<ChartData> Data { get; set; }
        private Class_interaction_Users.User CurrrentUser;
        public Class_interaction_Users.Test Test { get; set; }
        private Class_interaction_Users.Exams Exams;
        public DocPersonalCabinet(  Class_interaction_Users.User currrentUser, Class_interaction_Users.Test Test,Class_interaction_Users.Exams Exams)
        {
            InitializeComponent();
            CurrrentUser = currrentUser;

            Users.Text = CurrrentUser.Name_Employee;


            //ChartEntry[] chartEntries= new ChartEntry[] {};
        

            //for(int i = 0; i < ; i++)
            //{

            //}
          


            //Data = new List<ChartData>()
            //{
            //    new ChartData { Label = "Category 1", Value = 10 },
            //    new ChartData { Label = "Category 2", Value = 20 },
            //    new ChartData { Label = "Category 3", Value = 30 },
            //};

            //var chart = new RadialBarChart
            //{
            //    WidthRequest = 300,
            //    HeightRequest = 300,
            //    Series = new Dictionary<string, double>()
            //};

            //foreach (var item in Data)
            //{
            //    chart.Series.Add(item.Label, item.Value);
            //}

            //Content = new StackLayout
            //{
            //    Children = { chart }
            //};
        }
    }

    //public class ChartData
    //{
    //    public string Label { get; set; }
    //    public double Value { get; set; }
    //}
}
