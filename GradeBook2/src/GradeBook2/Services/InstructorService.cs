using GradeBook2.Infrastructure;
using GradeBook2.Models;
using GradeBook2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Services
{
    public class InstructorService
    {
        private UserRepository _uRepo;
        private GradeRepository _gradeRepo;

        public InstructorService(UserRepository ur, GradeRepository gr)
        {
            _uRepo = ur;
            _gradeRepo = gr;
        }
        public IEnumerable<UserDTO> AdminViewUsers()
        {
            return (from u in _uRepo.AdminViewUsers()
                    select new UserDTO()
                    {
                        UserName = u.UserName,
                        GradeLevel = u.GradeLevel,
                        Grade = u.Grade,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        
                        Classes = (from b in u.Student
                                   select new ClassDTO()
                                   {
                                       Id = b.Id,
                                       Grade = b.Grade,
                                       GradeLevel = b.GradeLevel,
                                       Subject = b.Subject
                                   }).ToList()
                    }).ToList();
        }
        public UserDTO GetClassesForInstructor(string LastName)
        {
            return (from s in _uRepo.GetLastName(LastName)
                    select new UserDTO()
                    {
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        GradeLevel = s.GradeLevel,
                        Grade = s.Grade,
                        
                        Classes = (from w in s.Student
                                   select new ClassDTO()
                                   {
                                       Id = w.Id,
                                       Grade = w.Grade,
                                       GradeLevel = w.GradeLevel,
                                       Subject = w.Subject
                                   }).ToList()
                    }).FirstOrDefault();
        }
        public ClassDTO FindById(int ClassId)
        {
            return (from e in _gradeRepo.GetClassById(ClassId)
                    select new ClassDTO
                    {
                        Id = e.Id,
                        Grade = e.Grade,
                        Subject = e.Subject
                    }).FirstOrDefault();
        }
        public void EditGrade(ClassDTO Class, int ClassId)
        {
            Classes dbClass = _gradeRepo.GetClassById(ClassId).FirstOrDefault();

            dbClass.Grade = Class.Grade;
            _gradeRepo.EditGrade();
        }

        

        public void RemoveClass(ClassDTO Class, int ClassId)
        {
            _gradeRepo.RemoveClass(_gradeRepo.GetClassById(ClassId).First());
        }
        public void RemoveUser(UserDTO User, string LastName)
        {
            _gradeRepo.RemoveUser(_gradeRepo.GetStudentByLastName(LastName).First());
        }
       
    }
}
