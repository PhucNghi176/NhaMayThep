using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "NhanVien");

            migrationBuilder.RenameColumn(
                name: "SoTienPhuCap",
                table: "ThongTinPhuCap",
                newName: "PhanTramPhuCap");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "TrinhDoHocVan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "TrinhDoHocVan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "TrinhDoHocVan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "TrinhDoHocVan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "TrinhDoHocVan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "TrinhDoHocVan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinTinhTrangLamViec",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinTinhTrangLamViec",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinTinhTrangLamViec",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinTinhTrangLamViec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinTinhTrangLamViec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinTinhTrangLamViec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinQuaTrinhNhanSu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinQuaTrinhNhanSu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinQuaTrinhNhanSu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinQuaTrinhNhanSu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinQuaTrinhNhanSu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinQuaTrinhNhanSu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinPhuCap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinPhuCap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinPhuCap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinPhuCap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinPhuCap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinPhuCap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinGiamTru",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinGiamTru",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinGiamTru",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinGiamTru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinGiamTru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinGiamTru",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinChucVu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinChucVu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinChucVu",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinChucVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinChucVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinChucVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "ThongTinChucDanh",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinChucDanh",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinChucDanh",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinChucDanh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinChucDanh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinChucDanh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "PhongBan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "PhongBan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "PhongBan",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "PhongBan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "PhongBan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "PhongBan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "LoaiNghiPhep",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "LoaiNghiPhep",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "LoaiNghiPhep",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "LoaiNghiPhep",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "LoaiNghiPhep",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "LoaiNghiPhep",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "LoaiHopDong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "LoaiHopDong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "LoaiHopDong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "LoaiHopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "LoaiHopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "LoaiHopDong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "LoaiHoaDon",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "LoaiHoaDon",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "LoaiHoaDon",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "LoaiHoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "LoaiHoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "LoaiHoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "LoaiCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "LoaiCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "LoaiCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "LoaiCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "LoaiCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "LoaiCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "DonViCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "DonViCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "DonViCongTac",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "DonViCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "DonViCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "DonViCongTac",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "CapBacLuong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "CapBacLuong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "CapBacLuong",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "CapBacLuong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "CapBacLuong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "CapBacLuong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChinhSachNhanSu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MucDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ChinhSachNhanSuID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNgayNghiPhep",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiNghiPhepID = table.Column<int>(type: "int", nullable: false),
                    TongSoGio = table.Column<double>(type: "float", nullable: false),
                    SoGioDaNghiPhep = table.Column<double>(type: "float", nullable: false),
                    SoGioConLai = table.Column<double>(type: "float", nullable: false),
                    NamHieuLuc = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNgayNghiPhep", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietNgayNghiPhep_LoaiNghiPhep_LoaiNghiPhepID",
                        column: x => x.LoaiNghiPhepID,
                        principalTable: "LoaiNghiPhep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNgayNghiPhep_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinLuongNhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoHopDong = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuongCu = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LuongMoi = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhanVienEntityID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinLuongNhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinLuongNhanVien_HopDong_MaSoHopDong",
                        column: x => x.MaSoHopDong,
                        principalTable: "HopDong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinLuongNhanVien_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinLuongNhanVien_NhanVien_NhanVienEntityID",
                        column: x => x.NhanVienEntityID,
                        principalTable: "NhanVien",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinGiamTru",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinGiamTru",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNgayNghiPhep_LoaiNghiPhepID",
                table: "ChiTietNgayNghiPhep",
                column: "LoaiNghiPhepID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNgayNghiPhep_MaSoNhanVien",
                table: "ChiTietNgayNghiPhep",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinLuongNhanVien_MaSoHopDong",
                table: "ThongTinLuongNhanVien",
                column: "MaSoHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinLuongNhanVien_MaSoNhanVien",
                table: "ThongTinLuongNhanVien",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinLuongNhanVien_NhanVienEntityID",
                table: "ThongTinLuongNhanVien",
                column: "NhanVienEntityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChinhSachNhanSu");

            migrationBuilder.DropTable(
                name: "ChiTietNgayNghiPhep");

            migrationBuilder.DropTable(
                name: "ThongTinLuongNhanVien");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "TrinhDoHocVan");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinTinhTrangLamViec");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinPhuCap");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinGiamTru");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinChucVu");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinChucDanh");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "PhongBan");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "LoaiNghiPhep");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "LoaiHopDong");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "LoaiHoaDon");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "LoaiCongTac");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "DonViCongTac");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "CapBacLuong");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "CapBacLuong");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "CapBacLuong");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "CapBacLuong");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "CapBacLuong");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "CapBacLuong");

            migrationBuilder.RenameColumn(
                name: "PhanTramPhuCap",
                table: "ThongTinPhuCap",
                newName: "SoTienPhuCap");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "NhanVien",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "NhanVien",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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
        }
    }
}
