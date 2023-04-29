using AutoMapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Mentors;
using DapperCRUD.Service.DTOs.UserCourses;
using DapperCRUD.Service.DTOs.Users;
using DapperCRUD.Service.Exceptions;
using DapperCRUD.Service.IServices.IUserCourses;
using DapperCRUD.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Services.UserCourses
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserCourseService()
        {
            unitOfWork = new UnitOfWork();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
        public async ValueTask<bool> CreateAsync(UserCourseForCreationDTO userCourseForCreationDTO)
        {
            var existUserCourse = (await unitOfWork.UserCourses.GetAllAsync()).FirstOrDefault(u => u.UserId == userCourseForCreationDTO.UserId && u.CourseId == userCourseForCreationDTO.CourseId); ;

            if (existUserCourse != null)
                throw new DapperCRUDAppException(404,"You sold this course already");
            
            var createdUserCourse = await unitOfWork.UserCourses.CreateUserToCourseAsync(userCourseForCreationDTO.UserId,userCourseForCreationDTO.CourseId);
            
            mapper.Map<UserCourse>(userCourseForCreationDTO);

            return true;
        }

        public async ValueTask<bool> DeleteAsync(UserCourseForCreationDTO userCourseForCreationDTO)
        {
            var deletedMentor = await unitOfWork.UserCourses.DeleteUserFromCourseAsync(userCourseForCreationDTO.UserId,userCourseForCreationDTO.CourseId);

            if (!deletedMentor)
                throw new DapperCRUDAppException(404,"User or Course not found");

            return true;
        }
    }
}
