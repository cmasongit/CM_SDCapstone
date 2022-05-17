using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Test1.Models
{
    public class Course : INotifyPropertyChanged
    {


        private string coursetitle;
        public string CourseTitle { get { return coursetitle; } set { coursetitle = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(coursetitle))); } }

        private string cd;
        public string coursenotify { get; set; }


        private DateTime st;
        public DateTime startdate { get; set; }



        public DateTime enddate { get; set; }





        public string datecombo { get; set; }

        public string timecombo { get; set; }

        public string status { get; set; }

        public string instructorname { get; set; }

        public long instructorphone { get; set; }

        public string instructorphone2 { get; set; }
        public string instructoremail { get; set; }

        public string termname { get; set; }

        public string dates { get; set; }

        public string times { get; set; }

        public string pname { get; set; }

        public string oname { get; set; }

        public DateTime duedatep { get; set; }
        public DateTime duedateo { get; set; }
        public string coursenotes { get; set; }

        private ObservableCollection<Assessments> ag = new ObservableCollection<Assessments>();
        public ObservableCollection<Assessments> assessmentgroup { get { return ag; } set { ag = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ag))); } }

        public string g2 { get; set; }

        public string getg2()
        {
            return g2;
        }


        public void setg2(string a)
        {
            if (a == "Yes")
            {
                g2 = "Notification On";
            }
            else if (a == "No" || a == null)
            {
                g2 = "Notification Off";
            }





        }




        public string getdates()
        {
            return dates;
        }

        public void setdates(DateTime x, DateTime y)
        {
            dates = x.ToShortDateString() + " - " + y.ToShortDateString();
        }




        public void updateCourse(Course a, Course b)
        {
            a = b;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }





    }
}
