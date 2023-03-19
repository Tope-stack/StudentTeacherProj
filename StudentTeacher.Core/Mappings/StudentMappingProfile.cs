using AutoMapper;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();

            CreateMap<StudentCreationDto, Student>();

            CreateMap<StudentUpdateDto, Student>().ReverseMap();
        }
    }
}
