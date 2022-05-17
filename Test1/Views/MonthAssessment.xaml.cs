using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthAssessment : ContentPage
    {
        List<Assessment> templist = new List<Assessment>();
        public MonthAssessment(string a)
        {
            InitializeComponent();

            Title = "Assessments due in " + a;
            titlehead.Text = "Report created at: " + DateTime.Now.ToString();

            List<Assessment> templist2 = App.Database.GetAssessmentAsync().Result;


            foreach (Assessment b in templist2)
            {
                if (b.tduedate.ToString("MMMM").ToLower() == a.ToLower())
                {
                    templist.Add(b);
                }
            }

            numcou.Text = "Number of courses found: " + templist.Count.ToString();
            MainCourseView3.ItemsSource = templist;

        }
    }
}