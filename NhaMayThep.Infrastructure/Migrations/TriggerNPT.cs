using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Migrations
{
    public partial class TriggerNPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER tg_insert_npt\r\nON dbo.ThongTinGiamTruGiaCanh\r\nAFTER INSERT\r\nAS\r\nBEGIN\r\nUPDATE NhanVien\r\nSET SoNguoiPhuThuoc = SoNguoiPhuThuoc+1\r\nWHERE ID IN (SELECT NhanVienID FROM inserted)\r\nEND");

            migrationBuilder.Sql("CREATE TRIGGER tg_update_npt\r\nON dbo.ThongTinGiamTruGiaCanh\r\nAFTER UPDATE\r\nAS  \r\nBEGIN\r\nUPDATE NhanVien\r\nSET SoNguoiPhuThuoc = SoNguoiPhuThuoc-1\r\nWHERE ID IN (SELECT NhanVienID FROM inserted)\r\nEND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER tg_insert_npt");
            migrationBuilder.Sql("DROP TRIGGER tg_update_npt");
        }
    }
}
