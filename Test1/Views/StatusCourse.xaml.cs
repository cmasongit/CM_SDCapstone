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
    public partial class StatusCourse : ContentPage
    {
        List<Courses> templist = new List<Courses>();


    

        public StatusCourse(string a)
        {
            InitializeComponent();
            Title = "Courses by status";
            List<Courses> templist2 = App.Database.GetCourseAsync().Result;
            titlehead.Text = "Report created at: " + DateTime.Now.ToString();
 
            for (int i = 0; i < templist2.Count; i++)
            {
                if(templist2[i].status.ToLower() == a.ToLower())
                {
                    templist.Add(templist2[i]);
                }
            }
          

       

            numcou.Text = "Number of courses found: " + templist.Count.ToString();

 MainCourseView1.ItemsSource = templist;



        }
    }
}