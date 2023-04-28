using Dapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Domain.Constatnts;
using DapperCRUD.Domain.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly NpgsqlConnection connection;

        public CourseRepository()
        {
            connection = new NpgsqlConnection(ConnectionString.conStrDapperApp);
        }
        public async ValueTask<Course> CreateAsync(Course course)
        {
            var query = "INSERT INTO courses (name,description,mentorid,section,creationtime,lastmodifiedtime)" +
                "VALUES (@Name,@Description,@MentorId,@Section,@CreationTime,@LastModifiedTime);";

            var result = await connection.ExecuteAsync(query, course);

            return course;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var query = $"DELETE FROM courses WHERE id = {id};";

            var result = await connection.ExecuteAsync(query);

            return true;
        }

        public IList<Course> GetAll(Expression<Func<Course, bool>> expression = null)
        {
            var query = "SELECT * FROM courses;";

            var result = connection.Query<Course>(query).ToList();

            return result;
        }

        public async ValueTask<Course> GetAsync(int id)
        {
            var query = $"SELECT * FROM courses WHERE id={id};";

            var result = await connection.QueryFirstOrDefaultAsync<Course>(query);

            return result;
        }

        public async ValueTask<Course> UpdateAsync(int id, Course course)
        {
            course.LastModifiedTime = DateTime.UtcNow;

            var query = $"UPDATE courses SET name = @Name,description=@Description,mentorid=@MentorId,section=@Section,creationtime=@CreationTime,lastmodifiedtime=@LastModifiedTime WHERE id={id};";

            var result = await connection.ExecuteAsync(query, course);

            return course;
        }
    }
}
