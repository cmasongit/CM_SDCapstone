using Test1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetail : TabbedPage
    {



        public CourseDetail(Courses t, int temp)
        {
            InitializeComponent();
            Title = "Course Detail";

            int a = temp;
            MessagingCenter.Send<CourseDetail, int>(this, "Hi", a);

            this.Children.Add(new ViewCourse(t) { Title = "View Course" });

            this.Children.Add(new EditCourse(t) { Title = "Edit" });

            this.Children.Add(new Course_Assessment(t) { Title = "Course Assessments" });


        }
    }
}
