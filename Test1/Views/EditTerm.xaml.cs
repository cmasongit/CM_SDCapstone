using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTerm : ContentPage
    {

      public Term a { get; set; }
        public string tempt { get; set; }
        public EditTerm(Models.Term tappeditem)
        {
            InitializeComponent();


            Title = "Edit Term";
            a = tappeditem;
            Season.Title = "Pick a Season";
            Season.Items.Add("Fall");
            Season.Items.Add("Summer-Fall");
            Season.Items.Add("Summer");
            Season.Items.Add("Fall-Winter");
            Season.Items.Add("Winter");
            Season.Items.Add("Winter-Spring");
            Season.Items.Add("Spring");
            Season.Items.Add("Spring-Summer");

            tempt = tappeditem.Name;
            Year.Title = "Pick a Year";
            for (int i = DateTime.Now.Year; i < 2050; i++)
            {
                Year.Items.Add(i.ToString());
            }



            TermName.Placeholder = tappeditem.Name;
            StartTerm.Date = tappeditem.startdate;
            EndTerm.Date = tappeditem.enddate;







        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            CancelEventArgs b = new CancelEventArgs();
            if (StartTerm.Date == EndTerm.Date)
            {
                await DisplayAlert("Alert", "The Start date is Equal to the End Date", "Ok");
                b.Cancel = true;


            }
            else if (StartTerm.Date > EndTerm.Date)
            {
                await DisplayAlert("Alert", "The Start Date comes after the End Date", "Ok");
                b.Cancel = true;


            }
            else
            {
                if (Season.SelectedItem != null || Year.SelectedItem != null)
                {
                    a.Name = Season.SelectedItem.ToString() + " " + Year.SelectedItem.ToString();

                    a.startdate = StartTerm.Date;
                    a.enddate = EndTerm.Date;

                  
                    foreach (Courses h in App.Database.GetCourseAsync().Result)
                    {
                        if (h.termname == tempt)
                        {
                            h.termname = a.Name;
                            await App.Database.UpdateCourseAsync(h);
                        }
                    }


                    await App.Database.UpdateTermAsync(a);
                    await Navigation.PopAsync();



                }
                else if (TermName.Text != null)
                {
                    a.Name= TermName.Text;
                    a.startdate = StartTerm.Date;
                    a.enddate = EndTerm.Date;

                   foreach(Courses h in App.Database.GetCourseAsync().Result)
                    {
                        if(h.termname == tempt)
                        {
                            h.termname = a.Name;
                          await  App.Database.UpdateCourseAsync(h);
                        }
                    }
                      




                    await App.Database.UpdateTermAsync(a);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", "Please Pick A Season And Year or Enter a Term Name", "OK");
                    b.Cancel = true;
                }


            }
        }





    }
    }
