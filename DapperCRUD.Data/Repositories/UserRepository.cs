using Dapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Domain.Constatnts;
using DapperCRUD.Domain.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NpgsqlConnection connection;

        public UserRepository()
        {
            connection = new NpgsqlConnection(ConnectionString.conStrDapperApp);
        }

        public async ValueTask<User> CreateAsync(User user)
        {
            var query = "INSERT INTO users (firstname,lastname,email,password,level,creationtime,lastmodifiedtime)" +
                "VALUES (@FirstName,@LastName,@email,@password,@Level,@CreationTime,@LastModifiedTime);";

            var result = await connection.ExecuteAsync( query,user);

            return user;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var query = $"DELETE FROM users WHERE id = {id};";

            var result = await connection.ExecuteAsync(query);

            return true;
        }

        public IList<User> GetAll(Expression<Func<User, bool>> expression=null)
        {
            var query = "SELECT * FROM users;";

            var result = connection.Query<User>(query).ToList();
            
            return result;
        }

        public async ValueTask<User> GetByIdAsync(int userId)
        {
            var query = $"SELECT * FROM users WHERE id={userId};";

            var result = await connection.QueryFirstOrDefaultAsync<User>(query);

            return result;
        }

        public async ValueTask<User> UpdateAsync(int id, User user)
        {
            user.LastModifiedTime = DateTime.UtcNow;

            var query = $"UPDATE users SET firstname = @FirstName,lastname=@LastName,email=@Email,password=@Password,level=@Level,creationtime=@CreationTime,lastmodifiedtime=@LastModifiedTime WHERE id={id};";

            var result = await connection.ExecuteAsync(query,user);

            return user;
        }
    }
}
