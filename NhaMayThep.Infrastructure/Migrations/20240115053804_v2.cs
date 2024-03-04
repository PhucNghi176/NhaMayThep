using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: "845f021510784efcb3e39b314c178e6f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinGiamTruGiaCanh",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinGiamTruGiaCanh",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinDaoTao",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinDaoTao",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinDangVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinDangVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinCongDoan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinCongDoan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "QuaTrinhNhanSu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "QuaTrinhNhanSu",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "NhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NhanVien",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "LichSuNghiPhepNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "LichSuNghiPhepNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "LichSuCongTacNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "LichSuCongTacNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "HopDong",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "HopDong",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "HoaDonCongTacNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "HoaDonCongTacNhanVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDangVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ChiTietDangVien",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "CanCuocCongDan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "CanCuocCongDan",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "ID", "ChucVuID", "DiaChiLienLac", "Email", "HoVaTen", "MaSoThue", "NgayCapNhatCuoi", "NgayTao", "NgayVaoCongTy", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID", "PasswordHash", "PasswordSalt", "SoDienThoaiLienLac", "SoNguoiPhuThuoc", "SoTaiKhoan", "TenNganHang", "TinhTrangLamViecID" },
                values: new object[,]
                {
                    { "2cd29f0ec8b7496f82c5acd63ebc7fcf", 1, "TP.HCM", "string1", "Test User 1", "1234567", new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3854), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3854), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3890), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 },
                    { "63dfc913ecee46cd88603b2441362827", 1, "TP.HCM", "string2", "Test User 1", "1234567", new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3894), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3894), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3902), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 },
                    { "930158b510ca433fb68bcada3a5b54d0", 1, "TP.HCM", "string3", "Test User 1", "1234567", new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3905), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3905), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3912), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 },
                    { "a91b63fc07bd411a8b6a75ad34f8c537", 1, "TP.HCM", "string4", "Test User 1", "1234567", new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3915), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3915), new DateTime(2024, 1, 15, 12, 38, 4, 200, DateTimeKind.Local).AddTicks(3921), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_Email",
                table: "NhanVien",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NhanVien_Email",
                table: "NhanVien");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: "2cd29f0ec8b7496f82c5acd63ebc7fcf");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: "63dfc913ecee46cd88603b2441362827");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: "930158b510ca433fb68bcada3a5b54d0");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "ID",
                keyValue: "a91b63fc07bd411a8b6a75ad34f8c537");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinGiamTruGiaCanh",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinGiamTruGiaCanh",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinDaoTao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinDaoTao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinDangVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinDangVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinCongDoan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinCongDoan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "QuaTrinhNhanSu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "QuaTrinhNhanSu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "NhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "LichSuNghiPhepNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "LichSuNghiPhepNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "LichSuCongTacNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "LichSuCongTacNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "HopDong",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "HopDong",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "HoaDonCongTacNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "HoaDonCongTacNhanVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "ChiTietDangVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ChiTietDangVien",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayTao",
                table: "CanCuocCongDan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "CanCuocCongDan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "ID", "ChucVuID", "DiaChiLienLac", "Email", "HoVaTen", "MaSoThue", "NgayCapNhatCuoi", "NgayTao", "NgayVaoCongTy", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID", "PasswordHash", "PasswordSalt", "SoDienThoaiLienLac", "SoNguoiPhuThuoc", "SoTaiKhoan", "TenNganHang", "TinhTrangLamViecID" },
                values: new object[] { "845f021510784efcb3e39b314c178e6f", 1, "TP.HCM", "string", "Test User 1", "1234567", new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9056), new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9056), new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9089), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 });
        }
    }
}
