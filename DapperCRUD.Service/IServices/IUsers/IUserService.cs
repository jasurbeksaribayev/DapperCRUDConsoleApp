using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.IServices.IUsers
{
    public interface IUserService
    {
        Task<IEnumerable<UserForViewDTO>> GetAllAsync(Func<User, bool> expression = null);
        ValueTask<UserForViewDTO> GetAsync(int id);
        ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdateDTO);
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<bool> ChangePasswordAsync(int id,UserForChangePasswordDTO userForChangePasswordDTO);
    }
}
