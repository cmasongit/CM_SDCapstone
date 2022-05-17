using System;
using System.ComponentModel;
using Test1.Models;
using Xamarin.Forms;

namespace Test1.Views
{
    public partial class AddTerm : ContentPage
    {
        public AddTerm()
        {
            InitializeComponent();
            Title = "Add Term";

            Season.Title = "Pick a Season";
            Season.Items.Add("Fall");
            Season.Items.Add("Summer-Fall");
            Season.Items.Add("Summer");
            Season.Items.Add("Fall-Winter");
            Season.Items.Add("Winter");
            Season.Items.Add("Winter-Spring");
            Season.Items.Add("Spring");
            Season.Items.Add("Spring-Summer");


            Year.Title = "Pick a Year";
            for (int i = DateTime.Now.Year; i < 2050; i++)
            {
                Year.Items.Add(i.ToString());
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Terms a = new Terms();
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
                    a.termtitle = Season.SelectedItem.ToString() + " " + Year.SelectedItem.ToString();

                    a.startdate1 = StartTerm.Date;
                    a.enddate1 = EndTerm.Date;
                    a.setdtct(a.startdate1, a.enddate1);

                    MessagingCenter.Send<AddTerm, Terms>(new AddTerm(), "Hi", a);
                    

                    await DisplayAlert("Success", "New Term was Added Successfully", "OK");
                    await Navigation.PopAsync();

                }
                else if (TermName.Text != null)
                {
                    a.termtitle = TermName.Text;
                    a.startdate1 = StartTerm.Date;
                    a.enddate1 = EndTerm.Date;
                    a.setdtct(a.startdate1, a.enddate1);

                    MessagingCenter.Send<AddTerm, Terms>(new AddTerm(), "Hi", a);

                    await DisplayAlert("Success", "New Custom Name Term was Added Successfully", "OK");
                    await Navigation.PopAsync();


                   // await Navigation.PopToRootAsync();
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
