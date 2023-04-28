using AutoMapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Mentors;
using DapperCRUD.Service.DTOs.Users;
using DapperCRUD.Service.Exceptions;
using DapperCRUD.Service.Extensions;
using DapperCRUD.Service.IServices.IMentors;
using DapperCRUD.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Services.Mentors
{
    public class MentorService : IMentorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MentorService()
        {
            unitOfWork = new UnitOfWork();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async ValueTask<bool> ChangePasswordAsync(MentorForChangePasswordDTO mentorForChangePasswordDTO)
        {
            var existMentor = (await unitOfWork.Mentors.GetAllAsync()).
                FirstOrDefault(u => u.Email == mentorForChangePasswordDTO.Email);

            if (existMentor == null || existMentor.Password != mentorForChangePasswordDTO.OldPassword.Encrypt())
                throw new DapperCRUDAppException("Email or Password incorrect");

            existMentor.Password = mentorForChangePasswordDTO.NewPassword.Encrypt();

            await unitOfWork.Mentors.UpdateAsync(existMentor.Id, existMentor);

            return true;
        }

        public async ValueTask<MentorForViewDTO> CreateAsync(MentorForCreationDTO mentorForCreationDTO)
        {
            var existMentor = (await unitOfWork.Mentors.GetAllAsync()).FirstOrDefault(u => u.Email == mentorForCreationDTO.Email); ;

            if (existMentor!= null)
                throw new DapperCRUDAppException("Email already taken");

            mentorForCreationDTO.Password = mentorForCreationDTO.Password.Encrypt();

            var createdMentor = await unitOfWork.Mentors.CreateAsync(mapper.Map<Mentor>(mentorForCreationDTO));

            return mapper.Map<MentorForViewDTO>(createdMentor);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedMentor = await unitOfWork.Mentors.DeleteAsync(id);

            if (!deletedMentor)
                throw new DapperCRUDAppException("User not found");

            return true;
        }

        public async ValueTask<IEnumerable<MentorForViewDTO>> GetAllAsync(Func<Mentor, bool> expression = null)
        {
            var result = await unitOfWork.Mentors.GetAllAsync();

            if (expression == null)
                return mapper.Map<IEnumerable<MentorForViewDTO>>(result);

            var mentors = result.Where(expression);

            return mapper.Map<IEnumerable<MentorForViewDTO>>(mentors);
        }

        public async ValueTask<MentorForViewDTO> GetAsync(int id)
        {
            var mentor = await unitOfWork.Mentors.GetAsync(id);

            if (mentor == null)
                throw new DapperCRUDAppException("User not found");

            return mapper.Map<MentorForViewDTO>(mentor);
        }

        public async ValueTask<MentorForViewDTO> UpdateAsync(int id, MentorForUpdateDTO mentorForUpdateDTO)
        {
            var existMentor = await unitOfWork.Mentors.GetAllAsync();

            var mentor = existMentor.FirstOrDefault(u => u.Id == id);

            if (mentor == null)
                throw new DapperCRUDAppException(404, "User not found");



            if (mentor.Email == mentorForUpdateDTO.Email || mentor.Id != id)
                throw new DapperCRUDAppException(404, "This email already taken");

            var mentors = mapper.Map(mentorForUpdateDTO, mentor);

            var updateMentor = await unitOfWork.Mentors.UpdateAsync(mentor.Id, mentor);

            return mapper.Map<MentorForViewDTO>(updateMentor);
        }
    }
}
