using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PutApi.Data;
using PutApi.Models;
using PutApi.DTOs;
using AutoMapper;

namespace PutApi.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // 3.1 Pagination + Get all students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(int page = 1, int pageSize = 5)
        {
            var students = await _context.Students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }

        // 2.3 Update (PUT)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _mapper.Map(studentDto, student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
