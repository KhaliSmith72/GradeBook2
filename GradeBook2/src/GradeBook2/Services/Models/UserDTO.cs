using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Services.Models
{
    public class UserDTO
    {
        public IList<ClassDTO> Classes { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassId { get; set; }
        public int Grade { get; set; }
        public string GradeLevel { get; set; }
        public string Subject { get; set; }
        
    }
}
