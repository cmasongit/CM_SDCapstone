using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Models
{
    public class Courses
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        public string coursetitle1 { get; set; }
     
      
        public string coursenotify { get; set; }


        public string cn1 { get{
                if (this.coursenotify == "Yes")
                {
                    return "Notification On";
                }
                else if (this.coursenotify == "No" || this.coursenotify == null)
                {
                    return  "Notification Off";
                }
                else
                {
                    return "";
                }
                ;



            }
        }

     











        public DateTime startdate { get; set; }

      public string startdatestring { get { return "Course Start Date: " + this.startdate.ToShortDateString(); } }

        public DateTime enddate { get; set; }
        public string enddatestring { get { return "Course End Date: " + this.enddate.ToShortDateString(); } }

        public string datecombo1 { get { return this.startdate.ToShortDateString() + " - " + this.enddate.ToShortDateString(); } }

        public string status { get; set; }

        public string status1 { get { return "Course Status: " + this.status; } }

        public string instructorname { get; set; }

        public string instructorname1 { get { return "Course Instructor: " + instructorname; } }

        public long instructorphone { get; set; }

       
        public string instructoremail { get; set; }
        public string instructoremail1 { get { return "Instructor Email: " + instructoremail; } }
        public string termname { get; set; }

   
        public string coursenotes { get; set; }
       
     
    }
}
