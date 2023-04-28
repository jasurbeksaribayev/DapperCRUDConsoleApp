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
    public class MentorRepository : IMentorRepository
    {
        private readonly NpgsqlConnection connection;

        public MentorRepository()
        {
            connection = new NpgsqlConnection(ConnectionString.conStrDapperApp);
        }
        public async ValueTask<Mentor> CreateAsync(Mentor mentor)
        {
            var query = "INSERT INTO mentors (firstname,lastname,email,password,bio,creationtime,lastmodifiedtime)" +
                "VALUES (@FirstName,@LastName,@email,@password,@BIO,@CreationTime,@LastModifiedTime);";

            var result = await connection.ExecuteAsync(query, mentor);

            return mentor;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var query = $"DELETE FROM mentors WHERE id = {id};";

            var result = await connection.ExecuteAsync(query);

            return true;
        }

        public async Task<IEnumerable<Mentor>> GetAllAsync(Expression<Func<Mentor, bool>> expression=null)
        {
            //var query = "SELECT * FROM mentors;";

            //var result = connection.Query<Mentor>(query).ToList();

            var sql = @"SELECT * FROM mentors m LEFT JOIN courses c ON m.id = c.mentorid;";

            var mentors = new Dictionary<int, Mentor>();

            await connection.QueryAsync<Mentor, Course, Mentor>(sql,
        (mentor, course) =>
        {
            if (!mentors.TryGetValue(mentor.Id, out var currentMentor))
            {
                currentMentor = mentor;
                currentMentor.Courses = new List<Course>();
                mentors.Add(currentMentor.Id, currentMentor);
            }

            if (course != null)
            {
                currentMentor.Courses.Add(course);
            }

            return currentMentor;
        },
        splitOn: "id");

            return mentors.Values;
        }        

        public async ValueTask<Mentor> GetAsync(int id)
        {
            //var query = $"SELECT * FROM mentors WHERE id={id};";

            //var result = await connection.QueryFirstOrDefaultAsync<Mentor>(query);

            var a = (await GetAllAsync()).FirstOrDefault(m => m.Id == id);

            return a;
        }

        public async ValueTask<Mentor> UpdateAsync(int id, Mentor mentor)
        {
            mentor.LastModifiedTime = DateTime.UtcNow;

            var query = $"UPDATE mentors SET firstname = @FirstName,lastname=@LastName,email=@Email,password=@Password,bio=@BIO,creationtime=@CreationTime,lastmodifiedtime=@LastModifiedTime WHERE id={id};";

            var result = await connection.ExecuteAsync(query, mentor);

            return mentor;
        }
    }
}
