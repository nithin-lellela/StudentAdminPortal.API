using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.DomainModels;

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
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();
            var domainModelStudents = _mapper.Map<List<Student>>(students);
            return Ok(domainModelStudents);
            
            /*foreach(var student in students)
            {
                domainModelStudents.Add(new Student()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl= student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Gender = new Gender()
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description
                    },
                    Address = new Address()
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress,
                    }
                });
            }*/

        }
    }
}
