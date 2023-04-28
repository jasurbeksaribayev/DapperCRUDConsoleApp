using DapperCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.IRepositories
{
    public interface IUserCourseRepository
    {
        ValueTask<IEnumerable<User>> GetUsersForCourseAsync(int courseId);
        ValueTask<IEnumerable<Course>> GetCourseForUserAsync(int userId);
        ValueTask<bool> CreateUserToCourseAsync(int userId , int courseId);
        ValueTask<bool> DeleteUserFromCourseAsync(int userId , int courseId); 
    }
}
