using GradeBook2.Infrastructure;
using GradeBook2.Models;
using GradeBook2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook2.Services
{
    public class UserService
    {
        private UserRepository _uRepo;
        private GradeRepository _gradeRepo;

        public UserService(UserRepository ur, GradeRepository gr)
        {
            _uRepo = ur;
            _gradeRepo = gr;
        }
        public IList<ClassDTO> GetClassesForUser( string currentUser)
        {
            return (from s in _uRepo.GetClasses(currentUser)
                    select new ClassDTO()
                    {
                        Id = s.Id,
                        Subject = s.Subject,
                        Grade = s.Grade,
                        GradeLevel = s.GradeLevel
                        
                    }).ToList();
        }

        public void AddClasses(ClassDTO Class, string currentUser)
        {
            Classes dbClass = new Classes()
            {
                Id = Class.Id,
                Subject = Class.Subject,
                Grade = Class.Grade,
                GradeLevel = Class.GradeLevel,
                StudentId = _uRepo.GetUser(currentUser).First().Id
                
            };
            _gradeRepo.AddClasses(dbClass, currentUser);
        }

    }
}
