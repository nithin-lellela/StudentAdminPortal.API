﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
