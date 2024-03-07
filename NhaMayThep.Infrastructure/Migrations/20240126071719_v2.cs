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
            migrationBuilder.DropIndex(
                name: "IX_LichSuNghiPhepNhanVien_NguoiDuyet",
                table: "LichSuNghiPhepNhanVien");

            migrationBuilder.AddColumn<bool>(
                name: "DaCoHopDong",
                table: "NhanVien",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 1,
                column: "TenLoaiHoaDon",
                value: "HoaDonDiLai");

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 2,
                column: "TenLoaiHoaDon",
                value: "HoaDonChoO");

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 3,
                column: "TenLoaiHoaDon",
                value: "HoaDonQuaBieuTang");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuNghiPhepNhanVien_NguoiDuyet",
                table: "LichSuNghiPhepNhanVien",
                column: "NguoiDuyet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LichSuNghiPhepNhanVien_NguoiDuyet",
                table: "LichSuNghiPhepNhanVien");

            migrationBuilder.DropColumn(
                name: "DaCoHopDong",
                table: "NhanVien");

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 1,
                column: "TenLoaiHoaDon",
                value: "ChiPhiDiLai");

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 2,
                column: "TenLoaiHoaDon",
                value: "ChiPhiChoO");

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 3,
                column: "TenLoaiHoaDon",
                value: "ChiPhiQuaBieuTang");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuNghiPhepNhanVien_NguoiDuyet",
                table: "LichSuNghiPhepNhanVien",
                column: "NguoiDuyet",
                unique: true);
        }
    }
}
