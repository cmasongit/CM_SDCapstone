
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class AboutPage : ContentPage
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ObservableCollection<Terms> t1 = new ObservableCollection<Terms>();
        public ObservableCollection<Terms> t2 { get { return t1; } set { t1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(t1))); } }



        ObservableCollection<Course> t3 = new ObservableCollection<Course>();
        public ObservableCollection<Course> t4 { get { return t3; } }

        public Command YourCommandBinding { get; set; }
        public Terms temp { get; set; }

        private Terms temp1;
        public Terms temp2 { get { return temp1; } set { temp1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(temp1))); } }

        private int temp3;
        public int temp4 { get { return temp3; } set { temp3 = value; } }

        private Course temp5;
        public Course temp6 { get { return temp5; } set { temp5 = value; } }

        public AboutPage()


        {


            InitializeComponent();

      


          

     

            
        


        MessagingCenter.Subscribe<AddTerm, Terms>(this, "Hi", async (sender9, arg9) =>
            {
                await DisplayAlert("Alert", "New Term Added", "ok");
                t2.Add(arg9);

                await App.Database.SaveTermAsync(new Term
                {
                    
                    Name = arg9.termtitle,
                    startdate = arg9.startdate1,
                    enddate = arg9.enddate1
                }); 

                TermView.ItemsSource = await App.Database.GetTermAsync();

            });


            // Task.Run(async () => { await backrunner(); });


            // base.OnAppearing();
            //   base.OnDisappearing();








        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
          await Task.Run(async () => { await sendalerts(App.Database.GetCourseAsync().Result, App.Database.GetAssessmentAsync().Result); });

            //  TermView.ItemsSource = t2;
            
            TermView.ItemsSource = await App.Database.GetTermAsync();

        }


        protected override void OnDisappearing()
        {




      //    Task.Run(async () => { await sendalerts(t2); });

          // TermView.ItemsSource = t2;










        }
















        public async Task sendalerts(List<Courses> t, List<Assessment> p  )
        {
            Random rnd = new Random();
            int qw = rnd.Next(150, 999);
            int pw = rnd.Next(150, 999);
            int ro = 100;
            int ro2 = 200;
            int ro3 = 400;
            List < Term >  termlist = App.Database.GetTermAsync().Result;

         

                foreach (Courses e in t)
                {
                    ro++;
                ro3++;
                    
                        if (e.coursenotify == "Yes" && e.startdate.Date == DateTime.Now.Date)
                        {
                            CrossLocalNotifications.Current.Show(e.coursetitle1, "Course Starts Today " + ro.ToString(), ro, e.startdate);
                        }


                if (e.coursenotify == "Yes" && e.enddate.Date == DateTime.Now.Date)
                {
                    CrossLocalNotifications.Current.Show(e.coursetitle1, "Course Ends Today " + ro3.ToString(), ro, e.enddate);
                }

             //  await App.Database.RemoveCourseAsync(e);

              
            }

            foreach (Assessment f in p)
            {
                ro2++;
                
                    if (f.assessnotify == "Yes" && f.tduedate.Date == DateTime.Now.Date)
                    {

                        CrossLocalNotifications.Current.Show(f.tname, "Assessment Due Today " + ro2.ToString(), ro2, f.tduedate);
                        // DisplayAlert("Notification", f.tname + " Assessment is due today", "ok");

                    }

              

            }



        }




        public int index { get; set; }

        async void TermView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            CancelEventArgs g = new CancelEventArgs();
            Term tappeditem = e.Item as Term;
           // temp = tappeditem;
            index = e.ItemIndex;
            int index2 = tappeditem.Id;

            var ans1 = await DisplayAlert("Alert", "Would you like to View Courses for " + tappeditem.Name + " Term", "Yes", "No");
            if (ans1 == true)
            {
                TermInfo a = new TermInfo(this);
                MessagingCenter.Send<AboutPage, Term>(new AboutPage(), "Hi", tappeditem);
                MessagingCenter.Send<AboutPage, ObservableCollection<Terms>>(this, "Hi", t2);

                MessagingCenter.Send<AboutPage, int>(this, "Hi", index);

                await Navigation.PushAsync(a);
            }
            else if (ans1 == false)
            {


                var ans2 = await DisplayAlert("Question?", "Would you like to Remove this Term? ", "Yes", "No");

                if (ans2 == true)
                {
                    //Success condition

                    String nametemp = tappeditem.Name;

                    foreach(Courses a in App.Database.GetCourseAsync().Result)
                    {
                        if(a.termname == nametemp)
                        {
                            foreach (Assessment b in App.Database.GetAssessmentAsync().Result)
                            {
                                if (b.coursename == a.coursetitle1)
                                {
                                    await App.Database.RemoveAssessmentAsync(b);
                                }
                                
                            }

                            await App.Database.RemoveCourseAsync(a);


                        }
                    }

                    

                    await App.Database.RemoveTermAsync(tappeditem);


                    TermView.ItemsSource = await App.Database.GetTermAsync();

                    //t2.RemoveAt(index);
                }
                else
                {
                    //false conditon

                    var ans3 = await DisplayAlert("Question?", "Would you like to Edit this Term? ", "Yes", "No");
                    if(ans3 == true)
                    {

                       
                        await Navigation.PushAsync(new EditTerm(tappeditem));





                    }
                    else if (ans3 == false){

                        g.Cancel = true;

                    }



                }






            }












        }






        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new AddTerm());

        }

    }
}
