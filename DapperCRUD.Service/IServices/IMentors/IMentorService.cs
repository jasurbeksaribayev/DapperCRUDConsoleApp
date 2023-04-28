using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Mentors;
using DapperCRUD.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.IServices.IMentors
{
    public interface IMentorService
    {
        ValueTask<IEnumerable<MentorForViewDTO>> GetAllAsync(Func<Mentor, bool> expression = null);
        ValueTask<MentorForViewDTO> GetAsync(int id);
        ValueTask<MentorForViewDTO> UpdateAsync(int id, MentorForUpdateDTO mentorForUpdateDTO);
        ValueTask<MentorForViewDTO> CreateAsync(MentorForCreationDTO mentorForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<bool> ChangePasswordAsync(MentorForChangePasswordDTO mentorForChangePasswordDTO);
    }
}
