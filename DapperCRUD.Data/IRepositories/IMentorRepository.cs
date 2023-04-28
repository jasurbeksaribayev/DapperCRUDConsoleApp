using DapperCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.IRepositories
{
    public interface IMentorRepository
    {
        Task<IEnumerable<Mentor>> GetAllAsync(Expression<Func<Mentor, bool>> expression = null);
        ValueTask<Mentor> GetAsync(int id);
        ValueTask<Mentor> CreateAsync(Mentor mentor);
        ValueTask<Mentor> UpdateAsync(int id,Mentor mentor);
        ValueTask<bool> DeleteAsync(int id);
    }
}
