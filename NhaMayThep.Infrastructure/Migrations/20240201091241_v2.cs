using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER tg_insert_npt\r\nON dbo.ThongTinGiamTruGiaCanh\r\nAFTER INSERT\r\nAS\r\nBEGIN\r\nUPDATE NhanVien\r\nSET SoNguoiPhuThuoc = SoNguoiPhuThuoc+1\r\nWHERE ID IN (SELECT NhanVienID FROM inserted)\r\nEND");

            migrationBuilder.Sql("CREATE TRIGGER tg_update_npt\r\nON dbo.ThongTinGiamTruGiaCanh\r\nAFTER UPDATE\r\nAS  \r\nBEGIN\r\nUPDATE NhanVien\r\nSET SoNguoiPhuThuoc = SoNguoiPhuThuoc-1\r\nWHERE ID IN (SELECT NhanVienID FROM inserted)\r\nEND");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER tg_insert_npt");
            migrationBuilder.Sql("DROP TRIGGER tg_update_npt");
        }
    }
}
