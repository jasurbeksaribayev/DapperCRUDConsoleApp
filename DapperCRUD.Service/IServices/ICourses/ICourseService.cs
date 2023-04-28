using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Courses;
using DapperCRUD.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.IServices.ICourses
{
    public interface ICourseService
    {
        ValueTask<IEnumerable<CourseForViewDTO>> GetAllAsync(Expression<Func<Course, bool>> expression = null);
        ValueTask<CourseForViewDTO> GetAsync(int id);
        ValueTask<CourseForViewDTO> UpdateAsync(int id, CourseForUpdateDTO courseForUpdateDTO);
        ValueTask<CourseForViewDTO> CreateAsync(CourseForCreationDTO courseForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
    }
}
