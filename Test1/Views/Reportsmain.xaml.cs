using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reportsmain : ContentPage
    {

        public string statusgetter { get; set; }


        public Reportsmain()
        {
            InitializeComponent();
        Title= "Reports" ;
            DateTime uno = new DateTime(2021, 12, 1);

            for (int i = 1; i < 13; i++) {

             
               
                listmonths.Items.Add(uno.AddMonths(i).ToString("MMMM"));
                listmonths1.Items.Add(uno.AddMonths(i).ToString("MMMM"));
            }

           









        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CancelEventArgs ab = new CancelEventArgs();
            if (listmonths.SelectedItem != null)
            {
                Navigation.PushAsync(new MonthAssessment(listmonths.SelectedItem.ToString()));
            }
            else
            {
                DisplayAlert("ERROR", "You Have not selected a Month from the picker", "ok");
                ab.Cancel = true;
            }

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CancelEventArgs ab = new CancelEventArgs();
            if (listmonths1.SelectedItem != null)
            {
                if (start.IsChecked == false && end.IsChecked == false)
                {
                    DisplayAlert("ERROR", "Please select either start date or end date", "ok");
                    ab.Cancel = true;
                }
                else
                {
                    Navigation.PushAsync(new MonthCourse(listmonths1.SelectedItem.ToString(), statusgetter));
                }
            }
            else
            {
                DisplayAlert("ERROR", "You Have not selected a Month from the picker", "ok");
                ab.Cancel = true;
            }


        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            CancelEventArgs hk = new CancelEventArgs();

            if (statuspicker.SelectedItem != null)
            {
                Navigation.PushAsync(new StatusCourse(statuspicker.SelectedItem.ToString()));
            }
            else
            {
                DisplayAlert("ERROR", "You Have not selected a status from the picker", "ok");
                hk.Cancel = true;
            }







        }



        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
       
            if(start.IsChecked == true)
            {
                end.IsChecked = false;
                statusgetter = "start";

            }


        }

        private void RadioButton_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {

            if (end.IsChecked == true)
            {
                start.IsChecked = false;
                statusgetter = "end";

            }



        }
    }
}