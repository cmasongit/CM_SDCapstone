using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

      
        public string Name { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }


        public string datecombo { get { return this.startdate.ToShortDateString() + " - " + this.enddate.ToShortDateString(); } }


        public List<Courses> termcourse = new List<Courses>();




    }
}
