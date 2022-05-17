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
    public partial class Searchpage : ContentPage
    {
        public Searchpage()
        {
            InitializeComponent();
            Title = "Search";

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CancelEventArgs kb = new CancelEventArgs();

            string entrya = entrytext.Text;
            if (entrya == string.Empty || entrya == null)
            {
                DisplayAlert("ERROR", "You have not enter anything in the search box.", "Ok");
                kb.Cancel = true;
            }
            else
            {
                

                Navigation.PushAsync(new searchresult(entrya.ToLower()));
            }

        }

     
    }
}