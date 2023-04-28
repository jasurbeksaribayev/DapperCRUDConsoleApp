using DapperCRUD.Domain.Entities;
using DapperCRUD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.DTOs.Courses
{
    public class CourseForViewDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public int MentorId { get; set; }
        public List<Mentor> Users { get; set; }
    }
}
