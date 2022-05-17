using System;

namespace Test1.Models
{
    public class Assessments
    {



        public string tname { get; set; }
        public string tdescription { get; set; }
        public DateTime tduedate { get; set; }
        public string twork { get; set; }
        public string dtdd { get; set; }
        enum Assessementtype { Objective, Performance }

        public string assessnotify { get; set; }

        public string notificationaccess { get; set; }

        public Assessments()
        {
        }

        public string getnotificationaccess()
        {
            return notificationaccess;
        }

        public void setnotificationaccess(string a)
        {
            if (a == "Yes")
            {
                notificationaccess = "Notification On";
            }
            else if (a == "No" || a == null)
            {
                notificationaccess = "Notification Off";
            }
        }

        public Assessments(string ttype, string aname, string adescription, DateTime x, string yesno)
        {
            twork = ttype;
            tname = aname;
            tdescription = adescription;
            tduedate = x;
            dtdd = tduedate.ToShortDateString();
            assessnotify = yesno;
            setnotificationaccess(assessnotify);



        }


    }
}
