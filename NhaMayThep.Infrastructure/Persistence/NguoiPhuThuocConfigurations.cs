using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Persistence
{
    public class NguoiPhuThuocConfigurations : IEntityTypeConfiguration<ThongTinGiamTruGiaCanhEntity>
    {
        public void Configure(EntityTypeBuilder<ThongTinGiamTruGiaCanhEntity> builder)
        {
            builder.ToSqlQuery(@"CREATE PROCEDURE sp_insert_npt
        AS
        BEGIN
            UPDATE NhanVien
            SET SoNguoiPhuThuoc = SoNguoiPhuThuoc + 1
            WHERE ID IN (SELECT NhanVienID FROM inserted)
        END");
        }
    }
}
