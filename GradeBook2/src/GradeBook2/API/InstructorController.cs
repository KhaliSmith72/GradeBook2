using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GradeBook2.Services.Models;
using GradeBook2.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GradeBook2.API
{
    [Route("api/[controller]")]
    public class InstructorController : Controller
    {
        private InstructorService _bService;


        public InstructorController(InstructorService bs)
        {
            _bService = bs;
        }
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IEnumerable<UserDTO> UserDetails()
        {
            return _bService.AdminViewUsers();
        }

        //[HttpGet("{id}")]
        //[Authorize(Policy = "AdminOnly")]

        //public ClassDTO ClassId(int id)
        //{
        //    return _bService.FindById(id);
        //}

        [HttpGet("{lastName}")]
        [Authorize(Policy ="AdminOnly")]

        public UserDTO GetStudentDetails(string lastName)
        {
            return _bService.GetClassesForInstructor(lastName);
        }








        [HttpPost("{ClassId}")]
        [Authorize(Policy = "AdminOnly")]

        public void EditGrade([FromBody] ClassDTO grade, int ClassId)
        {
            grade.Id = ClassId;
             _bService.EditGrade(grade, ClassId);
             Ok();
        }


        [HttpDelete("{lastName}")]
        [Authorize(Policy = "AdminOnly")]

        public IActionResult RemoveUser(UserDTO User, string lastName)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }
            
            _bService.RemoveUser(User, lastName);
            return Ok();
        }

        [HttpDelete("classes/{classId}")]
        [Authorize(Policy ="AdminOnly")]

        public IActionResult RemoveClass(ClassDTO Class, int ClassId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bService.RemoveClass(Class,ClassId);
            return Ok();

        }






    }
}
