using DapperCRUD.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.IRepositories
{
    public interface IUnitOfWork
    {
        UserRepository Users { get; set; }
        CourseRepository Courses { get; set; }
        MentorRepository Mentors { get; set; }
        UserCourseRepository UserCourses { get; set; }
    }
}
