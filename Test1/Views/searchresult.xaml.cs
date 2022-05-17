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
    public partial class searchresult : ContentPage
    {


        List<Courses> templist = new List<Courses>();
        List<Courses> templist2 = new List<Courses>();
        public searchresult(string entrya)
        {
            InitializeComponent();
            Title = "Search Results";
            DateTime now = DateTime.Now;
            templist = App.Database.GetCourseAsync().Result;

       foreach(Courses a in templist)
            {
                if(a.coursetitle1.ToLower() == entrya.ToLower())
                {
                    templist2.Add(a);
                }
             else  if(a.termname.ToLower() == entrya.ToLower())
                {
                    templist2.Add(a);
                }
              else  if (a.coursetitle1.ToLower().Contains(entrya))
                {
                    templist2.Add(a);
                }
             else   if (a.termname.ToLower().Contains(entrya))
                {
                    templist2.Add(a);
                }
             
                else if (a.instructorname.ToLower().Contains(entrya))
                {
                    templist2.Add(a);
                }
                else if( entrya.ToLower() == "All".ToLower())
                {
                    templist2 = templist;
                }

            }

            MainCourseView4.ItemsSource = templist2;

        }
    }
}