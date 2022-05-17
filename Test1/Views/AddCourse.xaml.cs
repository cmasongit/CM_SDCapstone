using Plugin.LocalNotifications;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class AddCourse : ContentPage
    {

        public ObservableCollection<Course> tempcourses { get; set; }


        DateTime sp { get; set; }
        DateTime ep { get; set; }




        public AddCourse()
        {
            InitializeComponent();

            Title = "Add a Course";

          
            AssessmentNotify2.Items.Add("Yes");
            AssessmentNotify2.Items.Add("No");

          


        }
        void Handle_Completed(object sender, System.EventArgs e)
        {
            CourseN.Text = ((Editor)sender).Text;
        }



        async void submitcourse_Clicked(System.Object sender, System.EventArgs e)
        {

            CancelEventArgs a = new CancelEventArgs();



            if (statuspicker.SelectedItem == null || AssessmentNotify2.SelectedItem == null)
            {
                await DisplayAlert("Alert", "Pick a Course Status/ Pick Yes or No for Notification question", "Ok");
                a.Cancel = true;

            }
            else if (Teacheremail.Text == string.Empty|| Teacherphone.Text == string.Empty|| Teachername.Text == string.Empty
                || Titlecourse.Text == string.Empty|| Titlecourse.Text == string.Empty)
            {
                await DisplayAlert("Alert", "There are missing fields", "Ok");
                a.Cancel = true;
            }
            else if (Teacherphone.Text.Length < 10)
            {
                await DisplayAlert("Alert", "The Instructor phone number is less than 10 digits", "Ok");
                a.Cancel = true;
            }
            else if (SDate.Date == EDate.Date)
            {
                await DisplayAlert("Alert", "The Start date is Equal to the End Date", "Ok");
                a.Cancel = true;


            }
            else if (SDate.Date > EDate.Date)
            {
                await DisplayAlert("Alert", "The Start Date comes after the End Date", "Ok");
                a.Cancel = true;


            }
           
            else

            {




                Courses temp1 = new Courses();


                temp1.coursetitle1 = Titlecourse.Text;

                temp1.status = statuspicker.SelectedItem.ToString();
                temp1.instructorname = Teachername.Text;
                temp1.instructoremail = Teacheremail.Text;
                temp1.instructorphone = long.Parse(Teacherphone.Text);
               // temp1.instructorphone2 = string.Format("{0:(###) ###-####}", long.Parse(temp1.instructorphone.ToString()));

                temp1.startdate = SDate.Date;
                temp1.enddate = EDate.Date;
             //   temp1.setdates(SDate.Date, EDate.Date);
                temp1.coursenotify = AssessmentNotify2.SelectedItem.ToString();

               // temp1.setg2(temp1.coursenotify);


                
                if (temp1.coursenotify == "Yes")
                {
                    CrossLocalNotifications.Current.Show(temp1.coursetitle1, "Course starts today", 124, temp1.startdate.AddSeconds(5));
                    CrossLocalNotifications.Current.Show(temp1.coursetitle1, "Course ends today", 125, temp1.enddate.AddSeconds(6));
                }
                




                temp1.coursenotes = CourseN.Text;

             




                    MessagingCenter.Send<AddCourse, Courses>(new AddCourse(), "Hi", temp1);




                    //await Navigation.PopToRootAsync(); USE TO GO BACK HOME


                    //Send a message to insert/update the expense to all subscribers


                    Navigation.RemovePage(this);
                

            }
            /*
             * 
             * <Entry x:Name="Titlecourse" Placeholder="Enter Course Title" />
<Entry x:Name="Teachername" Placeholder="Enter Course Instructor" />
<Entry x:Name="Teacherphone" Placeholder="Enter Course Instructor Phone" />
<Entry x:Name="Teacheremail" Placeholder="Enter Course Instructor email" />

    <Picker x:Name="statuspicker" Title="Select Course Status"
        TitleColor="DarkBlue">
  <Picker.Items>
    <x:String>In Progress</x:String>
    <x:String>Completed</x:String>
    <x:String>Dropped</x:String>
    <x:String>Plan to Take</x:String>

   
  </Picker.Items>
</Picker>

  

<Label Text="Enter Start Date and Time:" TextColor="DarkBlue"/>
<DatePicker x:Name="SDate" Format="D" />
    <TimePicker x:Name="Stime"/>


<Label Text="Enter End Date and Time:" TextColor="DarkBlue" />
<DatePicker x:Name="EDate" Format="D"/>
<TimePicker x:Name="Etime" />

<Button x:Name="submitcourse" Clicked="submitcourse_Clicked"/>
             * 
             * 
             */






        }




    }
}
