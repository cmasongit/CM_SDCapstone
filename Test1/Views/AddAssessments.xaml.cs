using Plugin.LocalNotifications;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class AddAssessments : ContentPage
    {
        private Courses a = new Courses();
        public Courses a3 { get { return a; } set { a = value; } }

        public string holder { get; set; }

        public AddAssessments(Courses t)
        {
            Title = "Add Assessment";
            InitializeComponent();
            a3 = t;

            AssessmentTy.Items.Add("Objective");
            AssessmentTy.Items.Add("Performance");

            AssessmentNotify.Items.Add("Yes");
            AssessmentNotify.Items.Add("No");


            // holder = typea;



        }

        public void assessmentchecker(string a)
        {


        }

        Task<List<Assessment>> assesstask;

        async void submitcourse_Clicked(System.Object sender, System.EventArgs e)
        {

            CancelEventArgs p = new CancelEventArgs();
            int t = 300;
            assesstask = App.Database.GetAssessmentgroupAsync(a3.coursetitle1);

            if (AssessmentNotify.SelectedItem != null)
            {

                // App.Database.GetAssessmentgroupAsync(a3.coursetitle1);


                // Assessments a = new Assessments(AssessmentTy.SelectedItem.ToString(), AssessmentTitle.Text, AssessmentDescription.Text, AssessmentDueDate.Date, AssessmentNotify.SelectedItem.ToString());

                // await  DisplayAlert("Alert",a.name + a.typework + a.description + a.duedate,"ok");
                if (AssessmentTitle.Text == null)
                {

                    await DisplayAlert("Alert", "Please fill out all fields, More Specificially add Assessment Title and Due Date. Use N/A if field not needed", "OK");
                    p.Cancel = true;


                }
                else
                {



                    Assessment a = new Assessment
                    {
                        coursename = a3.coursetitle1,
                        assessnotify = AssessmentNotify.SelectedItem.ToString(),
                        tname = AssessmentTitle.Text,
                        tduedate = AssessmentDueDate.Date,
                        tdescription = AssessmentDescription.Text,
                        ttype = AssessmentTy.SelectedItem.ToString()


                    };


                    a.setnotificationaccess(a.assessnotify);

                    var count = App.Database.GetAssessmentCountAsync(a3.coursetitle1);


                    if (count.Result == 2)
                    {
                        await DisplayAlert("Alert", "The Max Amount of Assessments has been reached", "OK");
                        p.Cancel = true;

                    }
                    else if (count.Result == 1)

                    {



                        if (App.Database.GetAssessmentgroupAsync(a3.coursetitle1).Result[count.Result - 1].ttype == a.ttype)
                        {
                            await DisplayAlert("Alert", "This Course Already has an " + a.ttype + " Assessment", "OK");
                            p.Cancel = true;
                        }
                        else
                        {
                            if (a.assessnotify == "Yes")
                            {
                                CrossLocalNotifications.Current.Show(a.tname, "Course starts today", t, a.tduedate.AddSeconds(5));
                            }


                            //App.Database.GetAssessmentsNotDoneAsync(a.coursename);

                            await App.Database.SaveAssessmentAsync(a);

                            await Navigation.PopAsync();

                        }

                    }


                    else if (count.Result == 0)
                    {

                        if (a.assessnotify == "Yes")
                        {
                            CrossLocalNotifications.Current.Show(a.tname, "Assessment starts today", t, a.tduedate.AddSeconds(5));
                        }

                        //App.Database.GetAssessmentsNotDoneAsync(a.coursename);

                        await App.Database.SaveAssessmentAsync(a);

                        await Navigation.PopAsync();

                    }



                }



            }
            else
            {
                await DisplayAlert("Alert", "Answer if you would like to be notified?", "Ok");
                p.Cancel = true;
            }
            t++;



        


        }
    }


        }

        
    
                

