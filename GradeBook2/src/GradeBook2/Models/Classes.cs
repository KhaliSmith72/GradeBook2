using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
       
        public ApplicationUser student { get; set; }
        public IList<Assignment> Assignments { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }
        public int Grade { get; set; }
        public string GradeLevel { get; set; }



    }
}
