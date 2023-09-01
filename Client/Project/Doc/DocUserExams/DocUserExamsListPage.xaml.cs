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
    public partial class DocUserExamsListPage : ContentPage
    {
        public CommandCL command = new CommandCL();
        private UserExamsEditorViewModel viewModel;
        private UserExamsManager viewModelManager;
        private Class_interaction_Users.User CurrrentUser;

        public DocUserExamsListPage(Class_interaction_Users.User user)
        {
            InitializeComponent();
            viewModel = new UserExamsEditorViewModel();
            viewModelManager = new UserExamsManager();
            CurrrentUser = user;
            ExamsList.ItemsSource = GetUserExams(user);
            Title = "Экзамены для пользователя: " + user.Name_Employee;

#pragma warning disable CS0618 // Тип или член устарел
            MessagingCenter.Subscribe<DocUserExamsListPage>(this, "UpdateForm", (sender) =>
            {
                // Perform the necessary updates to the form here  
                // For example, update the fields, refresh data, etc.  
                ExamsList.ItemsSource = GetUserExams(user);
            });
#pragma warning restore CS0618 // Тип или член устарел
        }

        private void UpdateForm(Class_interaction_Users.User user)
        {
            ExamsList.ItemsSource = GetUserExams(user);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            // Your code here  
        }

        private List<RefUserExams> GetUserExams(Class_interaction_Users.User user)
        {
            List<RefUserExams> testUserExamsList = new List<RefUserExams>();

            CommandCL.UserExamsListGet = null;
            viewModelManager.GetUserExamsList(user);

            if (CommandCL.UserExamsListGet == null)
            {
                // Handle the case when the test list is null  
            }
            else
            {
                for (int i = 0; i < CommandCL.UserExamsListGet.ListUserExams.Count; i++)
                {
                    var refUserExams = new RefUserExams { UserExams = CommandCL.UserExamsListGet.ListUserExams[i], EditCommand = new Command(Edit), DelCommand = new Command(Del) };
                    testUserExamsList.Add(refUserExams);
                }
            }
            return testUserExamsList;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedUserExams = (RefUserExams)e.SelectedItem;
            await DisplayAlert("Выбранный экзамен", selectedUserExams.UserExams.Exams.Name_exam, "OK");
            ((ListView)sender).SelectedItem = null;
        }

        private async void Edit(object userExams)
        {
            var selectedUserExams = (RefUserExams)userExams;
            await   Navigation.PushAsync(new ExamsEditor(selectedUserExams.UserExams.Exams));
        }

        private void Del(object userExams)
        {
            var selectedUserExams = (RefUserExams)userExams;

            viewModelManager.DeleteUserExamsData(selectedUserExams.UserExams);

            DisplayAlert("Удаляется ответ", selectedUserExams.UserExams.Exams.Name_exam, "OK");
            UpdateForm(CurrrentUser);
        }

        private async void GoBack(object sender, EventArgs e)
        {
            //  Shell.Current.Navigation.PopAsync();

            //await Navigation.PushAsync(new  RefUserListPage());
            //await Shell.Current.Navigation.PopAsync();
            await Navigation.PopAsync();

        }

        public class RefUserExams
        {
            public Class_interaction_Users.UserExams UserExams { get; set; }
            public Command EditCommand { get; set; }
            public Command DelCommand { get; set; }
        }

        private void ContentPageLoaded(object sender, EventArgs e)
        {

        }

        private async void CreateButtonClicked(object sender, EventArgs e)
        {
            var refExamsListPage = new RefExamsListPage();
            refExamsListPage.Mode = 1; // Здесь вы можете указать нужный режим

            refExamsListPage.Disappearing += (s, args) =>
            {
                if (refExamsListPage.vSelectedItem != null)
                {
                    var selectedItem = refExamsListPage.vSelectedItem;
                    UserExams aQuestionQ = new UserExams();
                    aQuestionQ.User = CurrrentUser;
                    aQuestionQ.Exams = selectedItem;
                    viewModelManager.CreateUserExamsData(aQuestionQ);
                    refExamsListPage.vSelectedItem = null;
#pragma warning disable CS0618 // Тип или член устарел
                    MessagingCenter.Send(this, "UpdateForm");
#pragma warning restore CS0618 // Тип или член устарел
                }
            };
            await Navigation.PushModalAsync(refExamsListPage);
        }
    }
}