using GradeBook2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Services.Models
{
    public class AssignmentDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public ClassDTO Class { get; set; }
        public string Classwork { get; set; }
        public int AssignmentGrade { get; set; }
    }
}
