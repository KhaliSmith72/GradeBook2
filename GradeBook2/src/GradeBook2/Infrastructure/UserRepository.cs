using GradeBook2.Data;
using GradeBook2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Infrastructure
{
    public class UserRepository
    {
        public ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }



        public IQueryable<ApplicationUser> GetFirstName(string FirstName)
        {
            return from u in _db.Users
                   where u.FirstName == FirstName
                   select u;
        }

        public IQueryable<ApplicationUser> GetLastName(string LastName)
        {
            return from l in _db.Users
                   where l.LastName == LastName
                   select l;
        }

        public IQueryable<Classes> GetClasses(string UserName)
        {
            return from b in _db.Classes
                   where b.student.UserName == UserName
                   select b;
        }

        public IQueryable<Classes> GetClasses()
        {
            return from a in _db.Classes
                   select a;
        }

        public IQueryable<ApplicationUser> GetUser(string userName)
        {
            return from u in _db.Users
                   where u.UserName == userName
                   select u;
        }

        public IQueryable<ApplicationUser> AdminViewUsers()
        {
            return from g in _db.Users
                   select g;
        }
    } 
}
