using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.DomainModels;
using DataModels = StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }
        
        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();
            var domainModelStudents = _mapper.Map<List<Student>>(students);
            return Ok(domainModelStudents);
            

        }

        [HttpGet]
        [Route("[Controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await _studentRepository.GetStudentAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            var domainModelStudent = _mapper.Map<Student>(student);
            return Ok(domainModelStudent);

        }

        [HttpPut]
        [Route("[Controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if(await _studentRepository.Exists(studentId))
            {
                //Update student details
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<DataModels.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(_mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();
        }
    }
}
