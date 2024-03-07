using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteChiTietDangVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDangVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongTinCongTy",
                table: "ThongTinCongTy");

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LoaiCongTac",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiHoaDon",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiHopDong",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoaiNghiPhep",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ThongTinChucDanh",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ThongTinChucVu",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ThongTinGiamTru",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThongTinGiamTru",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ThongTinQuaTrinhNhanSu",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ThongTinTinhTrangLamViec",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrinhDoHocVan",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "NgayCapNhat",
                table: "MucSanPham",
                newName: "NgayCapNhatCuoi");

            migrationBuilder.AddColumn<string>(
                name: "ChucVuDang",
                table: "ThongTinDangVien",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DonViCongTacID",
                table: "ThongTinDangVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrinhDoChinhTri",
                table: "ThongTinDangVien",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MaDoanhNghiep",
                table: "ThongTinCongTy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "ThongTinCongTy",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhatCuoi",
                table: "ThongTinCongTy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ThongTinCongTy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayXoa",
                table: "ThongTinCongTy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiCapNhatID",
                table: "ThongTinCongTy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiTaoID",
                table: "ThongTinCongTy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiXoaID",
                table: "ThongTinCongTy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "MucSanPham",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongTinCongTy",
                table: "ThongTinCongTy",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "LuongThoiGian",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLuongThoiGian = table.Column<int>(type: "int", nullable: false),
                    LuongNam = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LuongThang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LuongTuan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LuongNgay = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LuongGio = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NgayApDungLuongThoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongThoiGian", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LuongThoiGian_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaDangKiCaLam",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianCaLamBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCaLamKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenMaDangKi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaDangKi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrangThaiDangKiCaLamViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaTrangThai", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDangVien_DonViCongTacID",
                table: "ThongTinDangVien",
                column: "DonViCongTacID");

            migrationBuilder.CreateIndex(
                name: "IX_LuongThoiGian_MaSoNhanVien",
                table: "LuongThoiGian",
                column: "MaSoNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinDangVien_DonViCongTac_DonViCongTacID",
                table: "ThongTinDangVien",
                column: "DonViCongTacID",
                principalTable: "DonViCongTac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinDangVien_DonViCongTac_DonViCongTacID",
                table: "ThongTinDangVien");

            migrationBuilder.DropTable(
                name: "LuongThoiGian");

            migrationBuilder.DropTable(
                name: "MaDangKiCaLam");

            migrationBuilder.DropTable(
                name: "TrangThaiDangKiCaLamViec");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinDangVien_DonViCongTacID",
                table: "ThongTinDangVien");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongTinCongTy",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "ChucVuDang",
                table: "ThongTinDangVien");

            migrationBuilder.DropColumn(
                name: "DonViCongTacID",
                table: "ThongTinDangVien");

            migrationBuilder.DropColumn(
                name: "TrinhDoChinhTri",
                table: "ThongTinDangVien");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NgayCapNhatCuoi",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NgayXoa",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NguoiCapNhatID",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ThongTinCongTy");

            migrationBuilder.DropColumn(
                name: "NguoiXoaID",
                table: "ThongTinCongTy");

            migrationBuilder.RenameColumn(
                name: "NgayCapNhatCuoi",
                table: "MucSanPham",
                newName: "NgayCapNhat");

            migrationBuilder.AlterColumn<int>(
                name: "MaDoanhNghiep",
                table: "ThongTinCongTy",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "MucSanPham",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongTinCongTy",
                table: "ThongTinCongTy",
                column: "MaDoanhNghiep");

            migrationBuilder.CreateTable(
                name: "ChiTietDangVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DangVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonViCongTacID = table.Column<int>(type: "int", nullable: false),
                    ChucVuDang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoChinhTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDangVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietDangVien_DonViCongTac_DonViCongTacID",
                        column: x => x.DonViCongTacID,
                        principalTable: "DonViCongTac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDangVien_ThongTinDangVien_DangVienID",
                        column: x => x.DangVienID,
                        principalTable: "ThongTinDangVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoaiCongTac",
                columns: new[] { "ID", "TenLoaiCongTac", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "CongTacNoiBo", null, null, null, null, null, null },
                    { 2, "CongTacNuocNgoai", null, null, null, null, null, null },
                    { 3, "CongTacKyKetHopDong", null, null, null, null, null, null },
                    { 4, "CongTacKhaoSatDuAn", null, null, null, null, null, null },
                    { 5, "CongTacHoiThao", null, null, null, null, null, null },
                    { 6, "CongTacDaoTao", null, null, null, null, null, null },
                    { 7, "CongTacKiemTra", null, null, null, null, null, null },
                    { 8, "CongTacKhac", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "LoaiHoaDon",
                columns: new[] { "ID", "TenLoaiHoaDon", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "HoaDonDiLai", null, null, null, null, null, null },
                    { 2, "HoaDonChoO", null, null, null, null, null, null },
                    { 3, "HoaDonQuaBieuTang", null, null, null, null, null, null },
                    { 4, "HoaDonKhac", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "LoaiHopDong",
                columns: new[] { "ID", "TenHopDong", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "HopDongThuViec", null, null, null, null, null, null },
                    { 2, "HopDongCoThoiHan", null, null, null, null, null, null },
                    { 3, "HopDongKhongThoiHan", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "LoaiNghiPhep",
                columns: new[] { "ID", "TenLoaiNghiPhep", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "NghiPhepNam", null, null, null, null, null, null },
                    { 2, "NghiOm", null, null, null, null, null, null },
                    { 3, "NghiKhongLuong", null, null, null, null, null, null },
                    { 4, "NghiThaiSan", null, null, null, null, null, null },
                    { 5, "NghiKhac", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ThongTinChucDanh",
                columns: new[] { "ID", "TenChucDanh", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "GiamDoc", null, null, null, null, null, null },
                    { 2, "PhoGiamDoc", null, null, null, null, null, null },
                    { 3, "TruongPhong", null, null, null, null, null, null },
                    { 4, "PhoPhong", null, null, null, null, null, null },
                    { 5, "NhanVien", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ThongTinChucVu",
                columns: new[] { "ID", "TenChucVu", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "Admin", null, null, null, null, null, null },
                    { 2, "Truong Phong Nhan Su", null, null, null, null, null, null },
                    { 3, "Quan Li", null, null, null, null, null, null },
                    { 4, "Nhan Vien", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ThongTinGiamTru",
                columns: new[] { "ID", "TenMaGiamTru", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID", "SoTienGiamTru" },
                values: new object[,]
                {
                    { 1, "GiamTruBanThan", null, null, null, null, null, null, 11000000m },
                    { 2, "GiamTruNguoiPhuThuoc", null, null, null, null, null, null, 4400000m }
                });

            migrationBuilder.InsertData(
                table: "ThongTinQuaTrinhNhanSu",
                columns: new[] { "ID", "TenMaQuaTrinhNhanSu", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "ThangTien", null, null, null, null, null, null },
                    { 2, "BoNhiem", null, null, null, null, null, null },
                    { 3, "BaiNhiem", null, null, null, null, null, null },
                    { 4, "DieuDong", null, null, null, null, null, null },
                    { 5, "ThoiViec", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "ThongTinTinhTrangLamViec",
                columns: new[] { "ID", "TenMaTinhTrangLamViec", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "DangLamViec", null, null, null, null, null, null },
                    { 2, "DaNghiViec", null, null, null, null, null, null },
                    { 3, "DangThuViec", null, null, null, null, null, null },
                    { 4, "DangNghiPhep", null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "TrinhDoHocVan",
                columns: new[] { "ID", "TenTrinhDo", "NgayCapNhat", "NgayTao", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID" },
                values: new object[,]
                {
                    { 1, "Tien Si", null, null, null, null, null, null },
                    { 2, "Thac Si", null, null, null, null, null, null },
                    { 3, "Dai Hoc", null, null, null, null, null, null },
                    { 4, "Cao Dang", null, null, null, null, null, null },
                    { 5, "Trung Cap", null, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangVien_DangVienID",
                table: "ChiTietDangVien",
                column: "DangVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangVien_DonViCongTacID",
                table: "ChiTietDangVien",
                column: "DonViCongTacID");
        }
    }
}
