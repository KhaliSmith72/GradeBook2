using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Services.Models
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public IList<AssignmentDTO> Assignment { get; set; }
        public string Subject { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeLevel { get; set; }
    }
}
