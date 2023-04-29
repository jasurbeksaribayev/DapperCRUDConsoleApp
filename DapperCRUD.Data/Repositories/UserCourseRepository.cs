using Dapper;
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
    public class UserCourseRepository : IUserCourseRepository
    {
        private readonly NpgsqlConnection connection;

        public UserCourseRepository()
        {
            connection = new NpgsqlConnection(ConnectionString.conStrDapperApp);
        }
        public async ValueTask<bool> CreateUserToCourseAsync(int userId, int courseId)
        {
            var query = $"INSERT INTO usercourse (userid, courseid) VALUES ({userId}, {courseId});"; 
            
            await connection.ExecuteAsync(query);

            return true;
        }

        public async ValueTask<bool> DeleteUserFromCourseAsync(int userId, int courseId)
        {
            var exist = (await GetAllAsync()).FirstOrDefault(u => u.UserId == userId && u.CourseId == courseId);
            
            var query = $"DELETE FROM usercourse WHERE userid = {userId} AND courseid = {courseId};";

            if (exist == null)
                return false;

            await connection.ExecuteAsync(query);

            return true; 
        }

        public async ValueTask<IEnumerable<Course>> GetCourseForUserAsync(int userId)
        {
            var query = $"SELECT c.* FROM courses c INNER JOIN usercourse uc ON c.id = uc.courseid WHERE uc.userid = {userId};";

            UnitOfWork unitOfWork = new UnitOfWork();

            var a = await connection.QueryAsync<Course>(query);

            return a;
        }

        public async ValueTask<IEnumerable<User>> GetUsersForCourseAsync(int courseId)
        {
            var query = $"SELECT u.* FROM users u INNER JOIN usercourse uc ON u.id = uc.userid WHERE uc.courseid = {courseId};";

            return await connection.QueryAsync<User>(query);
      }



        public async ValueTask<IEnumerable<UserCourse>> GetAllAsync()
        {
            var query = $"SELECT * FROM usercourse;";

            return await connection.QueryAsync<UserCourse>(query);
        }

    }
}
