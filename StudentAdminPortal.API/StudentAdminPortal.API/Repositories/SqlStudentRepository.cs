using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            this._context = context;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student
                .Include(nameof(Gender))
                .Include(nameof(Address))
                .ToListAsync();
        }
        public async Task<Student> GetStudentAsync(Guid studentId)
        {
            return await _context.Student
                .Include(nameof(Gender))
                .Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }
        public async Task<bool> Exists(Guid studentId)
        {
            return await _context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var studentDetails = await GetStudentAsync(studentId);
            if(studentDetails != null)
            {
                studentDetails.FirstName = request.FirstName;
                studentDetails.LastName = request.LastName;
                studentDetails.Email = request.Email;
                studentDetails.DateOfBirth = request.DateOfBirth;
                studentDetails.Mobile = request.Mobile;
                studentDetails.GenderId = request.GenderId;
                studentDetails.Address.PhysicalAddress = request.Address.PhysicalAddress;
                studentDetails.Address.PostalAddress = request.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return studentDetails;
            }
            return null;
        }
    }
}
