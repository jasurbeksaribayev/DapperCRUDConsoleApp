using DapperCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.IRepositories
{
    public interface IUserRepository
    {
        IList<User> GetAll(Expression<Func<User, bool>> expression=null);
        ValueTask<User> GetByIdAsync(int userId);
        ValueTask<User> CreateAsync(User user);
        ValueTask<User> UpdateAsync(int id, User user);
        ValueTask<bool> DeleteAsync(int id);
    }
}
