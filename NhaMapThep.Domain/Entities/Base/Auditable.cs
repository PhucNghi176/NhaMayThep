using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Entities.Base
{

    public abstract class Auditable
    {
        public Guid NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public Guid? NguoiCapNhap { get; set; }
        public DateTime? NgayCapNhap { get; set; }
    }
}
