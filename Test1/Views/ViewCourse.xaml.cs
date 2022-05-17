using System.IO;
using Test1.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class ViewCourse : ContentPage
    {

        private Courses temp;
        private Courses temp1 { get { return temp; } set { temp = value; } }


        public ViewCourse(Models.Courses t)
        {
            InitializeComponent();

            temp1 = t;
            CourseName.Text = " " + t.coursetitle1;
            CourseStat.Text = "Course Status: " + t.status;
            CourseInstructor.Text = " Instructor Name: " + t.instructorname;
            Instructnum.Text = " Instructor Number: " + string.Format("{0:(###) ###-####}", long.Parse(temp1.instructorphone.ToString()));
            Dates2.Text = "Dates: " + t.datecombo1;
            Instructemail.Text = " Instructor Email: " + t.instructoremail;
            CourseN.Text = t.coursenotes;
            CourseNot.Text = t.cn1;
            CourseTerm.Text = "Term: " + t.termname;


        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var ans1 = await DisplayAlert("Alert", "Would you like to Share Course Notes?", "Yes", "No");

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
        }
    }
}
