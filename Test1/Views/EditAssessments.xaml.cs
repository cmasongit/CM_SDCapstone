using Plugin.LocalNotifications;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class EditAssessments : ContentPage
    {

        private Assessment p;
        public Assessment p2 { get { return p; } set { p = value; } }


        public EditAssessments(Assessment t)
        {
            InitializeComponent();
            Title = "Edit Assessment";
            p2 = t;
            an.Text = t.tname;
            ad.Text = t.tdescription;
            TypeA.Items.Add("Objective");
            TypeA.Items.Add("Performance");
            TypeA.SelectedItem = t.ttype;
            DueDate1.Date = t.tduedate;

            Typeh.Items.Add("Yes");
            Typeh.Items.Add("No");

        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            int t = 400;
            CancelEventArgs u = new CancelEventArgs();
            if (Typeh.SelectedItem != null)
            {

                if (an.Text == string.Empty)
                {

                    await DisplayAlert("Alert", "Enter an Assessment Title ", " Ok");
                    u.Cancel = true;
                }
               else if (ad.Text == string.Empty)
                {
                    ad.Text = "This Course Description is N/A";
                }
                else 
                {

                   
                        int tempint;


                        p2.tname = an.Text;
                        p2.tdescription = ad.Text;
                        p2.tduedate = DueDate1.Date;
                        p2.ttype = TypeA.SelectedItem.ToString();

                        tempint = App.Database.GetAssessmenttypeAsync(p2.ttype).Result;
                        int a = App.Database.GetAssessmentgroupAsync(p2.coursename).Result.IndexOf(p2);
                        List<Assessment> temptask = App.Database.GetAssessmentgroupAsync(p2.coursename).Result;

                    

                    int c = 0;


                        if (temptask.Count == 2)
                        {




                            if (temptask[0].ID != p2.ID)
                            {

                                if (temptask[0].ttype == p2.ttype)
                                {
                                    await DisplayAlert("Alert", "Assessment Type has already been used ", " Ok");
                                    u.Cancel = true;

                                }
                                else
                                {



                                    p2.assessnotify = Typeh.SelectedItem.ToString();
                                    p2.setnotificationaccess(p2.assessnotify);
                                    if (p2.assessnotify == "Yes")
                                    {
                                        CrossLocalNotifications.Current.Show(p2.tname, "Course starts today", t, p2.tduedate.AddSeconds(5));
                                    }
                                    await App.Database.UpdateAssessmentAsync(p2);
                                    await Navigation.PopAsync();




                                }


                            }
                            else if (temptask[1].ID != p2.ID)
                            {

                                if (temptask[1].ttype == p2.ttype)
                                {
                                    await DisplayAlert("Alert", "The Selected Assessment Type has already been used ", " Ok");
                                    u.Cancel = true;

                                }
                                else
                                {



                                    p2.assessnotify = Typeh.SelectedItem.ToString();
                                    p2.setnotificationaccess(p2.assessnotify);
                                    if (p2.assessnotify == "Yes")
                                    {
                                        CrossLocalNotifications.Current.Show(p2.tname, "Course starts today", t, p2.tduedate.AddSeconds(5));
                                    }
                                    await App.Database.UpdateAssessmentAsync(p2);
                                    await Navigation.PopAsync();




                                }


                            }



                        }
                        else if (temptask.Count == 1)
                        {

                            p2.assessnotify = Typeh.SelectedItem.ToString();
                            p2.setnotificationaccess(p2.assessnotify);
                            if (p2.assessnotify == "Yes")
                            {
                                CrossLocalNotifications.Current.Show(p2.tname, "Assessment starts today", t, p2.tduedate.AddSeconds(5));
                            }
                            await App.Database.UpdateAssessmentAsync(p2);
                            await Navigation.PopAsync();



                        }





                    



                }






                








               
            }
            else
            {
                await DisplayAlert("Alert", "You did pick a item ", " Ok");
                u.Cancel = true;
            }
            t++;
        }









    }
}
