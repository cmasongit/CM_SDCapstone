using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Test1.Models
{
    public class Terms : Course
    {
        public string termtitle { get; set; }

        public DateTime startdate1 { get; set; }
        public DateTime enddate1 { get; set; }
        public string dtct { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }





        public string getdtct()
        {
            return dtct;
        }

        public void setdtct(DateTime x, DateTime y)
        {
            dtct = x.ToShortDateString() + " - " + y.ToShortDateString();
        }

        private ObservableCollection<Course> tc = new ObservableCollection<Course>();
        public ObservableCollection<Course> termcourse { get { return tc; } set { tc = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tc))); } }



        public void addCourse(string title, string note, DateTime x, DateTime y, string instructorn, long instructpho, string email, string stat, string yesno)
        {
            Course temp = new Course();
            temp.CourseTitle = title;
            temp.coursenotes = note;
            temp.startdate = x;
            temp.enddate = y;

            temp.setdates(x, y);
            temp.instructorname = instructorn;
            temp.instructorphone = instructpho;

            temp.instructorphone2 = string.Format("{0:(###) ###-####}", long.Parse(temp.instructorphone.ToString()));
            temp.instructoremail = email;
            temp.status = stat;

            temp.termname = this.termtitle;

            temp.coursenotify = yesno;

            temp.setg2(temp.coursenotify);
            termcourse.Add(temp);

        }







    }
}
