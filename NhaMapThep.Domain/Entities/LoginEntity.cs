﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities
{
    [NotMapped]
    public class LoginEntity
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
