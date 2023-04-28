﻿using DapperCRUD.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Domain.Entities
{
    public class Mentor : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BIO { get; set; }
        public List<Course> Courses { get; set; }


    }
}
