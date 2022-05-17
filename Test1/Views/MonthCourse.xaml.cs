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
    public partial class MonthCourse : ContentPage
    {
        List<Courses> templist = new List<Courses>();
        public MonthCourse(string a, string statusgetter)
        {
            InitializeComponent();
            List<Courses> templist2 = App.Database.GetCourseAsync().Result;
            titlehead.Text = "Report created at: " + DateTime.Now.ToString();


            if (statusgetter.ToLower() == "start")
            {
                Title = "Courses that Start in: " + a;

                foreach (Courses b in templist2)
                {
                    if (b.startdate.ToString("MMMM").ToLower() == a.ToLower())
                    {
                        templist.Add(b);
                    }
                }

                numcou.Text = "Number of courses found: " + templist.Count.ToString();

                MainCourseView2.ItemsSource = templist;





            }
            else if(statusgetter.ToLower() == "end")
            {
                Title = "Courses that Ends in: " + a;
                foreach (Courses b in templist2)
                {
                    if (b.enddate.ToString("MMMM").ToLower() == a.ToLower())
                    {
                        templist.Add(b);
                    }
                }


                numcou.Text = "Number of courses found: " + templist.Count.ToString();
                MainCourseView2.ItemsSource = templist;




            }




         

           


        }
    }
}