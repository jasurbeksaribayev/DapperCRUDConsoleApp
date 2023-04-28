﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Domain.Commons
{
    public class Auditable
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTime { get; set; }
    }
}
