using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.Repositories;
using AutoMapper;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            this._studentRepository = studentRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("[Controller]")]
        public async Task<IActionResult> Index()
        {
            var gendersList = await _studentRepository.GetGendersAsync();
            if(gendersList == null || !gendersList.Any())
            {
                return NotFound();
            }
            var domainModelGenders = _mapper.Map<List<Gender>>(gendersList);
            return Ok(domainModelGenders);
        }
    }
}
