using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Models
{
    public class Assessment
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string tname { get; set; }
        public string tdescription { get; set; }
        public DateTime tduedate { get; set; }
        public string twork { get; set; }
        
        public string coursename { get; set; }
        

        public string assessnotify { get; set; }

        public string notificationaccess { get; set; }
        public string ttype { get; set; }

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




    }
}
