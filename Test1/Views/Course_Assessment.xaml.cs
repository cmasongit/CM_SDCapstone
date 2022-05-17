using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class Course_Assessment : ContentPage
    {

        private Courses a;
        public Courses a2 { get; set; }
        public Course_Assessment(Models.Courses t)
        {
            InitializeComponent();

            a2 = t;
          
        }

        protected override async void OnAppearing()
        {
            //  Task.Run(async () => { await backrunner(); });


            AView.ItemsSource = await App.Database.GetAssessmentgroupAsync(a2.coursetitle1);
            AView.RefreshCommand = new Command(() =>
            {

                //Do your stuff.
                RefreshData();
                AView.IsRefreshing = false;
            });












        }



        public async void RefreshData()
        {
            AView.IsRefreshing = true;
            AView.ItemsSource = null;

            AView.ItemsSource = await App.Database.GetAssessmentgroupAsync(a2.coursetitle1);

            AView.IsRefreshing = false;

        }

        

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            // assesstask = App.Database.GetAssessmentgroupAsync(a2.coursetitle1);
            CancelEventArgs q = new CancelEventArgs();

            if (App.Database.GetAssessmentgroupAsync(a2.coursetitle1).Result.Count == 2)
            {
                DisplayAlert("Max Reached", "The Max total of Assessments has been reached", "OK");
            }
            else
            {
                Navigation.PushAsync(new AddAssessments(a2));
            }
              
            

        }

        async void AView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            CancelEventArgs q = new CancelEventArgs();
            Assessment temp = (Assessment)e.Item;
            int ind = e.ItemIndex;

            var ans = await DisplayAlert("Alert", "Would Like to Edit Assessment?", "Yes", "No");
            if (ans == true)
            {
                await Navigation.PushAsync(new EditAssessments(temp));
            }
            else if (ans == false)
            {

                var ans2 = await DisplayAlert("Alert", "Would Like to Remove Assessment?", "Yes", "No");
                if (ans2 == true)
                {
                    // a2.assessmentgroup.RemoveAt(ind);
                  await  App.Database.RemoveAssessmentAsync(temp);

                    AView.ItemsSource = await App.Database.GetAssessmentgroupAsync(a2.coursetitle1);
                }

            }


        }






    }
}
