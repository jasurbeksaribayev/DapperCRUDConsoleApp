using DapperCRUD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.DTOs.Courses
{
    public class CourseForCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public int MentorId { get; set; }
    }
}
