using Microsoft.EntityFrameworkCore.Migrations;
namespace NhaMayThep.Infrastructure.Trigger;
public partial class InsertNguoiPhuThuocTrigger : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE PROCEDURE sp_insert_npt
        AS
        BEGIN
            UPDATE NhanVien
            SET SoNguoiPhuThuoc = SoNguoiPhuThuoc + 1
            WHERE ID IN (SELECT NhanVienID FROM inserted)
        END");

        migrationBuilder.Sql(@"CREATE PROCEDURE sp_update_npt
        AS
        BEGIN
            UPDATE NhanVien
            SET SoNguoiPhuThuoc = SoNguoiPhuThuoc - 1
            WHERE ID IN (SELECT NhanVienID FROM inserted)
        END");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP PROCEDURE sp_insert_npt");
        migrationBuilder.Sql("DROP PROCEDURE sp_update_npt");
    }
}