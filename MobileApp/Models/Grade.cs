﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileApp.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        [Range(1, 10)]
        [Display(Name = "Nota")]
        public int GradeValue { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime DateOfGrading { get; set; }
        //public int? EnrollmentID { get; set; }
        //public Enrollment? Enrollment { get; set; }
    }
}
