using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class TermInfo : ContentPage
    {



    


      
        AboutPage xc;

        private string termtitle;
        public ObservableCollection<Terms> t7 { get; set; }

        public Term ty { get; set; }

      
        public Term tempa { get { return ty; } set { ty = value; } }


       




        AboutPage AboutPage { get; set; }

        public TermInfo(AboutPage ab)
        {
            AboutPage = ab;

            InitializeComponent();
            // this.BindingContext = termcourse;




            apple1.Text = "Courses";









            //_________________________________________


            int termcount;



            MessagingCenter.Subscribe<AboutPage, Term>(this, "Hi", async (sender2, arg1) =>
            {
                Title = arg1.Name;
                tempa = arg1;



               





                MainCourseView.ItemsSource = await App.Database.GetTermcoursesAsync(arg1.Name);

                MainCourseView.RefreshCommand = new Command(() =>
                {

                    //Do your stuff.
                    RefreshData();
                    MainCourseView.IsRefreshing = false;
                });


               





            });


            MessagingCenter.Subscribe<AboutPage, Term>(AboutPage, "Hi", async (sender2, arg1) =>
            {

                MessagingCenter.Subscribe<AboutPage, int>(AboutPage, "Hi", async (sender6, arg6) =>
                {

                    MessagingCenter.Subscribe<AddCourse, Courses>(this, "Hi", async (sender3, arg2) =>
                    {



                        //  temp4 = arg6;
                        //  temp6 = arg2;
                        await DisplayAlert("Alert", "New Course was Added successfully", "ok");
                        arg2.termname = arg1.Name;

                        await App.Database.SaveCourseAsync(new Courses
                        {
                            coursetitle1 = arg2.coursetitle1,
                            startdate = arg2.startdate,
                            enddate = arg2.enddate,
                            instructoremail = arg2.instructoremail,
                            instructorname = arg2.instructorname,
                            instructorphone = arg2.instructorphone,
                            coursenotify = arg2.coursenotify,
                            status = arg2.status,
                            termname = arg1.Name


                        });

                   


                 
                     
                        MainCourseView.ItemsSource = await App.Database.GetTermcoursesAsync(arg1.Name);
                        // t2[arg6].termcourse.Add(arg2);

                        //  AboutPage.t2[temp4].termcourse.Add(temp6);
                        //  this.AboutPage.t2 = AboutPage.t2;

                        // await Task.Run(async () => { await sendalerts(t2); });

                        //   TermView.ItemsSource = t2;


                    });

                });

            });




            /*
            MessagingCenter.Subscribe<AboutPage, ObservableCollection<Terms>>(this, "Hi", async (sender6, arg6) =>
            {

                MessagingCenter.Subscribe<AddCourse, Course>(this, "Hi", async (sender3, arg2) =>
                {
                    termcount = tempa.termcourse.Count + 1;
                    await DisplayAlert("Success", "New Course added to: " + tempa.termtitle, "OK");

                    if (tempa.termcourse.Count + 1 < 7)
                    {
                        ab.t2[ab.t2.IndexOf(tempa)].termcourse.Add(arg2);
                        tempa.termcourse.Add(arg2);

                    }
                    else
                    {
                        await DisplayAlert("Alert", "Reached Course(s) limit " + tempa.termtitle, "OK");

                    }


                });

            });



            //  Task.Run(async () => { await ab.sendalerts(); });

            /*

             MessagingCenter.Subscribe<EditCourse, Course>(new EditCourse(new Course()), "Hi", async (sender3, arg3) =>
            {


                MessagingCenter.Subscribe<CourseDetail, int>(this, "Hi", async (sender5, arg5) =>
                {


                    //arg1.termcourse.RemoveAt()

                    tempa.termcourse[arg5] = arg3;
                
                    MainCourseView.ItemsSource = null;
                    MainCourseView.ItemsSource = tempa.termcourse;
                });


            });
         

            //  MessagingCenter.Send<TermInfo, Terms>(this, "Hi", tappeditem);
            */

            // base.OnAppearing();
            //   base.OnDisappearing();


        }

        int count { get; set; }
        int count1 { get; set; }

        protected override void OnAppearing()
        {
            //  Task.Run(async () => { await backrunner(); });


        
            List<Courses> templist = new List<Courses>();
            templist = App.Database.GetTermcoursesAsync(tempa.Name).Result;
            


            for (int i = 0; i < templist.Count; i++)
            {
                if (templist[i].startdate < tempa.startdate)
                {
                    count = count + 1;

                }
             



            }

            for (int i = 0; i < templist.Count; i++)
            {

                if (templist[i].enddate > tempa.enddate)
                {
                    count1 = count1 + 1;

                }


            }
        

            if (count > 1 )
            {
               
     

                DisplayAlert("StartDate Out of Range", "There are " + count + " courses that have start dates set BEFORE this Term start date. Please Edit", "ok");
                count = 0;
               
            }
            else if(count == 1)
            {
                DisplayAlert("StartDate Out of Range", "There is " + count + " course that has a start date set BEFORE this Term start date. Please Edit", "ok");
                count = 0;
            }

            if(count1 > 1)
            {
                DisplayAlert("EndDate Out of Range", "There are " + count1 + " courses that have end dates set AFTER this Term end date. Please Edit", "ok");
                count1 = 0;
            }else if(count1 == 1){
                DisplayAlert("EndDate Out of Range", "There is " + count1 + " course that has an end date set AFTER this Term end date. Please Edit", "ok");
                count1 = 0;
            }



        }



    


        protected override void OnDisappearing()
        {


            //  Task.Run(async () => { await backrunner(); });


        }



        public async Task backrunner()
        {





            MessagingCenter.Subscribe<AboutPage, Terms>(this, "Hi", async (sender2, arg1) =>
            {

                MessagingCenter.Subscribe<AboutPage, int>(this, "Hi", async (sender6, arg6) =>
                {

                    MessagingCenter.Subscribe<AddCourse, Course>(this, "Hi", async (sender3, arg2) =>
                    {


                        //temp4 = arg6;
                        // temp6 = arg2;
                        //  arg1.termcourse.Add(arg2);



                        //await DisplayAlert("Alert", "New Course was Added successfully", "ok");
                        //  arg1.termcourse.Add(arg2);




                        // await DisplayAlert("Alert", "New Course was Added", "Ok");

                        //  AboutPage.t2[arg6].termcourse.Add(arg2);

                        //  AboutPage.t2[temp4].termcourse.Add(temp6);
                        // this.AboutPage.t2 = AboutPage.t2;

                      //  await Task.Run(async () => { await AboutPage.sendalerts(AboutPage.t2); });


                    });

                });

            });









        }











        public async void RefreshData()
        {



            MainCourseView.IsRefreshing = true;

            MainCourseView.ItemsSource = null;
            MainCourseView.ItemsSource = await App.Database.GetTermcoursesAsync(tempa.Name);
            MainCourseView.IsRefreshing = false;











        }




        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            CancelEventArgs p = new CancelEventArgs();


            if (App.Database.GetTermcoursesAsync(tempa.Name).Result.Count == 6)
            {
                await DisplayAlert("Max Reached", "Sorry Course Max has been reached", "OK");
                p.Cancel = true;
            }
            else
            {


                await Navigation.PushAsync(new AddCourse());
            }
        }





        async void MainCourseView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

            Courses temp = (Courses)e.Item;
            int cindex = e.ItemIndex;



            var ans = await DisplayAlert("Question?", "Would you like to View this Course? ", "Yes", "No");

            if (ans == true)
            {
                //Success condition

                await Navigation.PushAsync(new CourseDetail(temp, cindex));
            }
            else
            {
                //false conditon
                var ans2 = await DisplayAlert("Question?", "Would you like to Remove this Course? ", "Yes", "No");

                if (ans2 == true)
                {
                    //Success condition

                    
                    await App.Database.RemoveCourseAsync(temp);
                    MainCourseView.ItemsSource = await App.Database.GetTermcoursesAsync(tempa.Name);

                }
                else
                {
                    //false conditon






                }


            }




        }
    }

}
