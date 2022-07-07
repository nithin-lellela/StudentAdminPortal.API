using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataModels = StudentAdminPortal.API.DataModels;
using DomainModels = StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Profiles.AfterMaps;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, DomainModels.Student>().
                ReverseMap();
            CreateMap<DataModels.Gender, DomainModels.Gender>().
                ReverseMap();
            CreateMap<DataModels.Address, DomainModels.Address>().
                ReverseMap();
            CreateMap<DomainModels.UpdateStudentRequest, DataModels.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
        }
    }
}
