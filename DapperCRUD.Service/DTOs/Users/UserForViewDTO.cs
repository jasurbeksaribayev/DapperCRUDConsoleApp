using DapperCRUD.Domain.Entities;
using DapperCRUD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.DTOs.Users
{
    public class UserForViewDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Level Level { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
