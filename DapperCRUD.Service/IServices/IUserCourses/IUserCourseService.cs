using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.UserCourses;
using DapperCRUD.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.IServices.IUserCourses
{
    public interface IUserCourseService
    {
        ValueTask<bool> CreateAsync(UserCourseForCreationDTO userCourseForCreationDTO);
        ValueTask<bool> DeleteAsync(UserCourseForCreationDTO userCourseForCreationDTO);
    }
}
