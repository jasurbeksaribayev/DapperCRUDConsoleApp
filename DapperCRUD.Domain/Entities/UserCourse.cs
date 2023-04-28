using DapperCRUD.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Domain.Entities
{
    public class UserCourse : Auditable 
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
