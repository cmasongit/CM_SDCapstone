using Test1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentsDetail : TabbedPage
    {
        public AssessmentsDetail(Assessment a2)
        {
            InitializeComponent();
            Title = "Assessments Detail";
            // this.Children.Add(new ViewAssessments(a2) { Title = "View Assessments" });

            this.Children.Add(new EditAssessments(a2) { Title = "Edit Assessments" });





        }
    }
}
