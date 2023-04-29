using DapperCRUD.Data.IRepositories;
using DapperCRUD.Domain.Constatnts;
using DapperCRUD.Domain.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserRepository Users { get; set ; }
        public CourseRepository Courses { get; set ; }
        public MentorRepository Mentors { get; set; }
        public UserCourseRepository UserCourses { get; set; }
       
        private readonly NpgsqlConnection connection;

        public UnitOfWork()
        {
            Users = new UserRepository();
            Courses = new CourseRepository();
            Mentors = new MentorRepository();
            UserCourses = new UserCourseRepository();
            connection = new NpgsqlConnection(ConnectionString.conStrDapperApp);
        }
    
    }
}
