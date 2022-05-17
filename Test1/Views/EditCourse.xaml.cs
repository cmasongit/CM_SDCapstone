using Plugin.LocalNotifications;
using System;
using System.ComponentModel;
using System.IO;
using Test1.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test1.Views
{


    public partial class EditCourse : ContentPage
    {
        public int indextemp { get; set; }
        private Courses a;
        public Courses temp1 { get { return a; } set { a = value; } }



        public string btemp { get; set; }


        //Send back to TERM INFO
        public EditCourse(Courses t)
        {
            InitializeComponent();

            Title = "Edit Course";
            temp1 = t;
            CourseName.Text = t.coursetitle1;
            CourseEmail.Text = t.instructoremail;
            CourseInstructor.Text = t.instructorname;
            CoursePhone.Text = t.instructorphone.ToString();
            Startdate.Date = t.startdate;
            EndDate.Date = t.enddate;

            CourseN.Text = t.coursenotes;
            btemp = t.coursetitle1;





        }

        void Handle_Completed(object sender, System.EventArgs e)
        {
            CourseN.Text = ((Editor)sender).Text;
        }


        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            CancelEventArgs a = new CancelEventArgs();

            int t = 500;
            // temp1.coursedept = CourseDeptm.Text;


            if (statuspicker1.SelectedItem == null || statuspicker2.SelectedItem == null)
            {
                await DisplayAlert("Alert", "You did not pick a status or Answer the Notification Question", "Ok");
                a.Cancel = true;

            }
            else if (CourseEmail.Text == string.Empty || CourseInstructor.Text == string.Empty || CoursePhone.Text == string.Empty
                || CourseName.Text == string.Empty)
            {
                await DisplayAlert("Alert", "There are missing fields", "Ok");
                a.Cancel = true;

            }
            else if (CoursePhone.Text.Length < 10)
            {
                await DisplayAlert("Alert", "Please enter 10 digits", "OK");
                a.Cancel = true;
            }
            else if (Startdate.Date == EndDate.Date)
            {
                await DisplayAlert("Alert", "The Start date is Equal to the End Date", "Ok");
                a.Cancel = true;


            }
            else if (Startdate.Date > EndDate.Date)
            {
                await DisplayAlert("Alert", "The Start Date comes after the End Date", "Ok");
                a.Cancel = true;


            }
            else
            {
                temp1.coursetitle1 = CourseName.Text;
                temp1.status = statuspicker1.SelectedItem.ToString();
                temp1.instructorname = CourseInstructor.Text;
                temp1.instructoremail = CourseEmail.Text;
                temp1.instructorphone = long.Parse(CoursePhone.Text);
                //temp1.instructorphone2 = string.Format("{0:(###) ###-####}", long.Parse(temp1.instructorphone.ToString()));
                temp1.coursenotify = statuspicker2.SelectedItem.ToString();
               // temp1.setg2(temp1.coursenotify);
                temp1.startdate = Startdate.Date;
                temp1.enddate = EndDate.Date;
              //  temp1.setdates(Startdate.Date, EndDate.Date);
                Random rnd = new Random();
                int r = rnd.Next(140, 999);
                

                  if (temp1.coursenotify == "Yes")
                  {
                      CrossLocalNotifications.Current.Show(temp1.coursetitle1, "Course starts Today", t, temp1.startdate.AddSeconds(5));
                    CrossLocalNotifications.Current.Show(temp1.coursetitle1, "Course ends Today", t++, temp1.enddate.AddSeconds(6));
                }

                  foreach(Assessment f in App.Database.GetAssessmentgroupAsync(btemp).Result)
                {
                    f.coursename = CourseName.Text;
                    await App.Database.UpdateAssessmentAsync(f);
                }





  
                //   temp1.coursenotes = CourseNotes.Text;
                temp1.coursenotes = CourseN.Text;

                await App.Database.UpdateCourseAsync(temp1);

                var ans1 = await DisplayAlert("Alert", "Would you like to Share Edited Course Notes?", "Yes", "No");

                if (ans1 == true)
                {

                    var fn = temp1.coursetitle1 + "Notes" + ".txt";
                    var file = Path.Combine(FileSystem.CacheDirectory, fn);
                    File.WriteAllText(file, temp1.coursenotes);

                    await Share.RequestAsync(new ShareFileRequest
                    {
                        Title = Title,
                        File = new ShareFile(file)
                    });

                }
                else
                {
                    await DisplayAlert("Alert", "Course was edited successfully " + temp1.termname, "OK");



                    await Navigation.PopAsync();



                }


                t++;

            }















        }











    }
}
