using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.Base
{
    public abstract class BangMaGocEntity
    {
        [Key]
        public required int ID { get; set; }
        public required string Name { get; set; }
    }
}
