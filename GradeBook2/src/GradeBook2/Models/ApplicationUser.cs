using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GradeBook2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public IList<Classes>Student { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GradeLevel { get; set; }
        public int Grade { get; set; }
        public string Subject { get; set; }
        public bool AccountRegister { get; set;}


    }
}
