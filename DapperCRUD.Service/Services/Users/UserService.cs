using AutoMapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Users;
using DapperCRUD.Service.Exceptions;
using DapperCRUD.Service.Extensions;
using DapperCRUD.Service.IServices.IUsers;
using DapperCRUD.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async ValueTask<bool> ChangePasswordAsync(int id,UserForChangePasswordDTO userForChangePasswordDTO)
        {
            var existUser = await unitOfWork.Users.GetByIdAsync(id);

            if (existUser.Email != userForChangePasswordDTO.Email || existUser.Password != userForChangePasswordDTO.OldPassword.Encrypt())
                throw new DapperCRUDAppException("Email or Password incorrect");

            existUser.Password = userForChangePasswordDTO.NewPassword.Encrypt();
           
            await unitOfWork.Users.UpdateAsync(id,existUser);

            return true;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var existUser = unitOfWork.Users.GetAll();

            var result = existUser.FirstOrDefault(u => u.Email == userForCreationDTO.Email);

            if (result != null)
                throw new DapperCRUDAppException("Email already taken");

            userForCreationDTO.Password = userForCreationDTO.Password.Encrypt();

            var createdUser = await unitOfWork.Users.CreateAsync(mapper.Map<User>(userForCreationDTO));

            return mapper.Map<UserForViewDTO>(createdUser);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedUser = await unitOfWork.Users.DeleteAsync(id);

            if (!deletedUser)
                throw new DapperCRUDAppException("User not found");

            return true;
        }

        public async Task<IEnumerable<UserForViewDTO>> GetAllAsync(Func<User, bool> expression = null)
        {
            var result = unitOfWork.Users.GetAll();

            //for (int i=0;i<result.Count;i++)
            //{
            //    var a =  await unitOfWork.UserCourses.GetCourseForUserAsync(result[i].Id);

            //    result[i].Courses = a.ToList();
            //}

            //var a = await unitOfWork.UserCourses.GetCourseForUserAsync(18);


            //for (int i = 0; i < a.Count(); i++)
            //{
            //    result[i].Courses[i] = a.ElementAt(i);
            //}


            if (expression == null)
                return mapper.Map<IEnumerable<UserForViewDTO>>(result);

            var users = result.Where(expression);

            return mapper.Map<IEnumerable<UserForViewDTO>>(users);
        }

        public async ValueTask<UserForViewDTO> GetAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
                throw new DapperCRUDAppException("User not found");

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdateDTO)
        {
            var existUser = unitOfWork.Users.GetAll();

            var user = existUser.FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new DapperCRUDAppException(404,"User not found");



            if (user.Email == userForUpdateDTO.Email || user.Id != id)
                throw new DapperCRUDAppException(404,"This email already taken");

            var users = mapper.Map(userForUpdateDTO, user);

            var updateUser = await unitOfWork.Users.UpdateAsync(user.Id,user);

            return mapper.Map<UserForViewDTO>(updateUser);

        }
    }
}
