using AutoMapper;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Courses;
using DapperCRUD.Service.DTOs.Mentors;
using DapperCRUD.Service.DTOs.UserCourses;
using DapperCRUD.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //users
            CreateMap<User, UserForCreationDTO>().ReverseMap();
            CreateMap<User, UserForUpdateDTO>().ReverseMap();
            CreateMap<User, UserForViewDTO>().ReverseMap();

            //courses
            CreateMap<Course, CourseForCreationDTO>().ReverseMap();
            CreateMap<Course, CourseForUpdateDTO>().ReverseMap();
            CreateMap<Course, CourseForViewDTO>().ReverseMap();

            //mentors
            CreateMap<Mentor, MentorForCreationDTO>().ReverseMap();
            CreateMap<Mentor, MentorForUpdateDTO>().ReverseMap();
            CreateMap<Mentor, MentorForViewDTO>().ReverseMap();

            //usercourses
            CreateMap<UserCourse, UserCourseForCreationDTO>().ReverseMap();
        }
    }
}
