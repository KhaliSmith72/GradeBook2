using GradeBook2.Data;
using GradeBook2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Infrastructure
{
    public class GradeRepository
    {
        private ApplicationDbContext _db;
        public GradeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<Classes> GetClassById(int ClassId)
        {
            return from b in _db.Classes
                   where b.Id == ClassId
                   select b;
        }
        public IQueryable<ApplicationUser> GetStudentById(string UserName)
        {
            return from o in _db.Users
                   where o.UserName == UserName
                   select o;
        }

        public IQueryable<ApplicationUser>GetStudentByLastName(string LastName)
        {
            return from c in _db.Users
                   where c.LastName == LastName
                   select c;
        }

        public IQueryable<Assignment> GetAssignments(string ClassWork)
        {
            return from w in _db.Assignment
                   where w.Classwork == ClassWork
                   select w;
        }
       
        

        public void RemoveClass(Classes classes)
        {
            _db.Classes.Remove(classes);
            _db.SaveChanges();
        }

        public void RemoveUser(ApplicationUser user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void EditGrade()
        {
            _db.SaveChanges();
        }

        public void AddClasses(Classes Class, string currentUser)
        {
            _db.Classes.Add(Class);
            _db.SaveChanges();
        }

        public void RemoveAssignment(Assignment ClassWork)
        {
            _db.Assignment.Remove(ClassWork);
            _db.SaveChanges();
        }

        public void EditClassWorkGrade()
        {
            _db.SaveChanges();
        }

        public void AddAssignments(Assignment ClassWork)
        {
            _db.Assignment.Add(ClassWork);
            _db.SaveChanges();
        }





    }
}
