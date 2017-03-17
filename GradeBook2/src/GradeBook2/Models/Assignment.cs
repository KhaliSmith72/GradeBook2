using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Classes Class { get; set; }
       
        public string Classwork { get; set; }
        public int AssignmentGrade { get; set; }

    }
}
