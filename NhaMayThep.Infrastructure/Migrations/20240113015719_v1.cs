using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiHopDong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaHopDong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinCanCuocCongDan",
                columns: table => new
                {
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanToc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TonGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinCanCuocCongDan", x => x.CanCuocCongDan);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChucDanhEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaChucDanh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChucVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaChucVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinGiamTru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTienGiamTru = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TenMaGiamTru = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaGiamTru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinTinhTrangLamViec",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMaTinhTrangLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaTinhTrangLamViecID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan_ThongTinCanCuocCongDan_CanCuocCongDan",
                        column: x => x.CanCuocCongDan,
                        principalTable: "ThongTinCanCuocCongDan",
                        principalColumn: "CanCuocCongDan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    TinhTrangLamViecID = table.Column<int>(type: "int", nullable: false),
                    NgayVaoCongTy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChiLienLac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoaiLienLac = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNganHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNguoiPhuThuoc = table.Column<int>(type: "int", nullable: true),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NhanVien_ThongTinChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ThongTinChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVien_ThongTinTinhTrangLamViec_TinhTrangLamViecID",
                        column: x => x.TinhTrangLamViecID,
                        principalTable: "ThongTinTinhTrangLamViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien_NhanVienMapThongTinCanCuocCongDans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien_NhanVienMapThongTinCanCuocCongDans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NhanVien_NhanVienMapThongTinCanCuocCongDans_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinGiamTruGiaCanh",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaGiamTruID = table.Column<int>(type: "int", nullable: false),
                    DiaChiLienLac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHeVoiNhanVien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgayXacNhanPhuThuoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinGiamTruGiaCanh", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinGiamTruGiaCanh_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinGiamTruGiaCanh_ThongTinCanCuocCongDan_CanCuocCongDan",
                        column: x => x.CanCuocCongDan,
                        principalTable: "ThongTinCanCuocCongDan",
                        principalColumn: "CanCuocCongDan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongTinGiamTruGiaCanh_ThongTinGiamTru_MaGiamTruID",
                        column: x => x.MaGiamTruID,
                        principalTable: "ThongTinGiamTru",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoaiHopDong",
                columns: new[] { "ID", "TenHopDong" },
                values: new object[,]
                {
                    { 1, "HopDongThuViec" },
                    { 2, "HopDongCoThoiHan" },
                    { 3, "HopDongKhongThoiHan" }
                });

            migrationBuilder.InsertData(
                table: "ThongTinChucDanhEntity",
                columns: new[] { "ID", "TenChucDanh" },
                values: new object[,]
                {
                    { 1, "GiamDoc" },
                    { 2, "PhoGiamDoc" },
                    { 3, "TruongPhong" },
                    { 4, "PhoPhong" },
                    { 5, "NhanVien" }
                });

            migrationBuilder.InsertData(
                table: "ThongTinChucVu",
                columns: new[] { "ID", "TenChucVu" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Truong Phong Nhan Su" },
                    { 3, "Quan Li" },
                    { 4, "Nhan Vien" }
                });

            migrationBuilder.InsertData(
                table: "ThongTinGiamTru",
                columns: new[] { "ID", "TenMaGiamTru", "SoTienGiamTru" },
                values: new object[,]
                {
                    { 1, "GiamTruBanThan", 11000000m },
                    { 2, "GiamTruNguoiPhuThuoc", 4400000m }
                });

            migrationBuilder.InsertData(
                table: "ThongTinTinhTrangLamViec",
                columns: new[] { "ID", "TenMaTinhTrangLamViec" },
                values: new object[,]
                {
                    { 1, "DangLamViec" },
                    { 2, "DaNghiViec" },
                    { 3, "DangThuViec" },
                    { 4, "DangNghiPhep" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuID",
                table: "NhanVien",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TinhTrangLamViecID",
                table: "NhanVien",
                column: "TinhTrangLamViecID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_NhanVienMapThongTinCanCuocCongDans_MaSoNhanVien",
                table: "NhanVien_NhanVienMapThongTinCanCuocCongDans",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan_CanCuocCongDan",
                table: "ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan",
                column: "CanCuocCongDan");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinGiamTruGiaCanh_CanCuocCongDan",
                table: "ThongTinGiamTruGiaCanh",
                column: "CanCuocCongDan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinGiamTruGiaCanh_MaGiamTruID",
                table: "ThongTinGiamTruGiaCanh",
                column: "MaGiamTruID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinGiamTruGiaCanh_NhanVienID",
                table: "ThongTinGiamTruGiaCanh",
                column: "NhanVienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiHopDong");

            migrationBuilder.DropTable(
                name: "NhanVien_NhanVienMapThongTinCanCuocCongDans");

            migrationBuilder.DropTable(
                name: "ThongTinCanCuocCongDan_NhanVienMapThongTinCanCuocCongDan");

            migrationBuilder.DropTable(
                name: "ThongTinChucDanhEntity");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTruGiaCanh");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThongTinCanCuocCongDan");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTru");

            migrationBuilder.DropTable(
                name: "ThongTinChucVu");

            migrationBuilder.DropTable(
                name: "ThongTinTinhTrangLamViec");
        }
    }
}
