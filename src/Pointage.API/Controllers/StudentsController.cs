using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointage.Core.Dtos;
using Pointage.Core.IRepositories;

namespace Pointage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
            
        }

        [HttpGet("{id}")]
        public async Task<StudentDto?> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudent(id);
            if(student == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return student;
        }

        [HttpPut("{id}/toggle-presence")]
        public async Task<StudentDto?> TogglePresence(int id)
        {
            await _studentRepository.TogglePresenceStudent(id);

            var student = await _studentRepository.GetStudent(id);
            if(student == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return student;
        }
        
    }
}
