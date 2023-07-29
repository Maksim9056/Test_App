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
public partial class RefExamsListPage : ContentPage
{
    public CommandCL command = new CommandCL();
        private ExamsEditorViewModel viewModel;
        private ExamManager viewModelManager;

        public RefExamsListPage()
    {
        InitializeComponent();
            viewModel = new ExamsEditorViewModel();
            viewModelManager = new ExamManager();
            ExamsList1.ItemsSource = GetExams();
    }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateForm();
        }

        private void UpdateForm()
    {
         ExamsList1.ItemsSource = GetExams();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        // Your code here
    }

    private List<RefExams> GetExams()
    {
        List<RefExams> aExamsList = new List<RefExams>();

        CommandCL.ExamsListGet = null;
        viewModelManager.GetExamsList();

        if (CommandCL.ExamsListGet == null)
        {
            // Handle the case when the test list is null
        }
        else
        {
            for (int i = 0; i < CommandCL.ExamsListGet.ListExams.Count; i++)
            {
                var Ref = new RefExams { Exams = CommandCL.ExamsListGet.ListExams[i], EditCommand = new Command(EditExams), DelCommand = new Command(DelExams) };
                    aExamsList.Add(Ref);
            }
        }

        return aExamsList;
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var selectedTest = (RefExams)e.SelectedItem;
        await DisplayAlert("Выбранный тест", selectedTest.Exams.Name_exam, "OK");
        ((ListView)sender).SelectedItem = null;
    }

    private void EditExams(object test)
    {
        var selectedTest = (RefExams)test;
        Navigation.PushAsync(new ExamsEditor(selectedTest.Exams));
    }

    private void DelExams(object test)
    {
        var selectedTest = (RefExams)test;

        viewModelManager.DeleteExamsData(selectedTest.Exams);

        DisplayAlert("Удаляется тест", selectedTest.Exams.Name_exam, "OK");
        UpdateForm();
    }

        private void GoBack(object sender, EventArgs e)
        {
            var mainPage = new Администратор();
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


        public class RefExams
        {
        public Class_interaction_Users.Exams Exams { get; set; }
        public Command EditCommand { get; set; }
        public Command DelCommand { get; set; }
    }

    private void CreateButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ExamsCreate());
    }
}
}
