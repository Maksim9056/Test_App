using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;
using System.Collections.ObjectModel;

namespace Client.Project
{
public partial class RefTestListPage : ContentPage
{
    public CommandCL command = new CommandCL();
    private TestEditorViewModel viewModel; 
    public Class_interaction_Users.Test vSelectedItem { get; set; }



        public RefTestListPage()
        {
            InitializeComponent();
            viewModel = new TestEditorViewModel();
            TestList.ItemsSource = GetTest();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateForm();
        }

        private void UpdateForm()
        {
            TestList.ItemsSource = GetTest();
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
    {
        // Your code here
    }

    private List<RefTest> GetTest()
        {
            List<RefTest> aTestList = new List<RefTest>();

            CommandCL.TestListGet = null;
            viewModel.GetTestList();

            if (CommandCL.TestListGet == null)
            {
                // Handle the case when the test list is null
            }
            else
            {
                for (int i = 0; i < CommandCL.TestListGet.ListTest.Count; i++)
                {
                    var Ref = new RefTest { Test = CommandCL.TestListGet.ListTest[i], EditCommand = new Command(EditTest), DelCommand = new Command(DelTest) };
                    aTestList.Add(Ref);
                }
            }

            return aTestList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedTest = (RefTest)e.SelectedItem;
            //await DisplayAlert("Выбранный тест", selectedTest.Test.Name_Test, "OK");
            await Navigation.PushAsync(new DocTestQuestionListPage(selectedTest.Test));

            ((ListView)sender).SelectedItem = null;
            vSelectedItem = selectedTest.Test;


//         await   Navigation.PopModalAsync();
        }

        private void EditTest(object test)
        {
            var selectedTest = (RefTest)test;
            Navigation.PushAsync(new TestEditor(selectedTest.Test));
        }

        private void DelTest(object test)
        {
            var selectedTest = (RefTest)test;

            viewModel.DelTestData(selectedTest.Test);

            DisplayAlert("Удаляется тест", selectedTest.Test.Name_Test, "OK");
            UpdateForm();
        }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Client.Main.Admin();
            var navigationPage = new NavigationPage(mainPage);

            Application.Current.MainPage = navigationPage;
        }
        //private void GoBack(object sender, EventArgs e)
        //{
        //    if (Application.Current.MainPage is NavigationPage navigationPage)
        //    {
        //        navigationPage.Navigation.PopAsync();
        //    }
        //}


        public class RefTest
        {
            public Class_interaction_Users.Test Test { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private void CreateButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestCreate());
        }

    }
}
