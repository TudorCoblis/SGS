using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace MobileApp.Models
{
    public class CourseEnrollment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Enrollment))]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }

    }
}
