using DapperCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.IRepositories
{
    public interface ICourseRepository
    {
        IList<Course> GetAll(Expression<Func<Course, bool>> expression=null);
        ValueTask<Course> GetAsync(int id);
        ValueTask<Course> CreateAsync(Course course);
        ValueTask<Course> UpdateAsync(int id,Course course);
        ValueTask<bool> DeleteAsync(int id);
    }
}
