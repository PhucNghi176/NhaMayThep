using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace NhaMapThep.Domain.Entities.Base
{
    public abstract class BangMaGocEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public required string Name { get; set; }

        public string? NguoiXoaID { get; set; }
        public DateTime? NgayXoa {  get; set; }
    }
}
