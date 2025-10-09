using Microsoft.AspNetCore.Mvc;
using PutApi.Models;
using PutApi.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace PutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;

        // Dữ liệu giả lập trong bộ nhớ
        private static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Alice", Age = 20 },
            new Student { Id = 2, Name = "Bob", Age = 22 },
            new Student { Id = 3, Name = "Charlie", Age = 21 },
            new Student { Id = 4, Name = "David", Age = 23 },
            new Student { Id = 5, Name = "Emma", Age = 19 },
            new Student { Id = 6, Name = "Frank", Age = 24 },
        };

        public StudentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // 3.1 Pagination + Get all students
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudents(int page = 1, int pageSize = 5)
        {
            var pagedStudents = students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(_mapper.Map<List<StudentDto>>(pagedStudents));
        }

        // 2.3 Update (PUT)
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            _mapper.Map(studentDto, student);
            return NoContent();
        }
    }
}
