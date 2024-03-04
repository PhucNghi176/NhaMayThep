using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapBacLuong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeSoLuong = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacLuong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DonViCongTac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViCongTac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiCongTac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiCongTac = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaLoaiCongTac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaLoaiHoaDon", x => x.ID);
                });

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
                name: "LoaiNghiPhep",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoGioNghiPhep = table.Column<int>(type: "int", nullable: false),
                    TenLoaiNghiPhep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaLoaiNghiPhep", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MucSanPham",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MucSanPhamToiThieu = table.Column<int>(type: "int", nullable: false),
                    MucSanPhamToiDa = table.Column<int>(type: "int", nullable: false),
                    LuongMucSanPham = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaMucSP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaPhongBan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChucDanh",
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
                name: "ThongTinCongTy",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDoanhNghiep = table.Column<int>(type: "int", nullable: false),
                    TenQuocTe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenVietTat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongNhanVien = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSoThue = table.Column<int>(type: "int", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NguoiDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHoatDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonViQuanLi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHinhDoanhNghiep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinCongTy", x => x.ID);
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
                name: "ThongTinPhuCap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTienPhuCap = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinPhuCap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinQuaTrinhNhanSu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMaQuaTrinhNhanSu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaQuaTrinhNhanSu", x => x.ID);
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
                name: "TrinhDoHocVan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaTrinhDoHocVan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
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
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "CanCuocCongDan",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanCuocCongDan = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanCuocCongDan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CanCuocCongDan_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHopDongID = table.Column<int>(type: "int", nullable: false),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiHanHopDong = table.Column<int>(type: "int", nullable: false),
                    DiaDiemLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoPhanLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    ChucDanhID = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HeSoLuongID = table.Column<int>(type: "int", nullable: false),
                    PhuCapID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HopDong_CapBacLuong_HeSoLuongID",
                        column: x => x.HeSoLuongID,
                        principalTable: "CapBacLuong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_LoaiHopDong_LoaiHopDongID",
                        column: x => x.LoaiHopDongID,
                        principalTable: "LoaiHopDong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_ThongTinChucDanh_ChucDanhID",
                        column: x => x.ChucDanhID,
                        principalTable: "ThongTinChucDanh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDong_ThongTinChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ThongTinChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LichSuCongTacNhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiCongTacID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoiCongTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuCongTacNhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LichSuCongTacNhanVien_LoaiCongTac_LoaiCongTacID",
                        column: x => x.LoaiCongTacID,
                        principalTable: "LoaiCongTac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuCongTacNhanVien_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSuNghiPhepNhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiNghiPhepID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuNghiPhepNhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LichSuNghiPhepNhanVien_LoaiNghiPhep_LoaiNghiPhepID",
                        column: x => x.LoaiNghiPhepID,
                        principalTable: "LoaiNghiPhep",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuNghiPhepNhanVien_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuNghiPhepNhanVien_NhanVien_NguoiDuyet",
                        column: x => x.NguoiDuyet,
                        principalTable: "NhanVien",
                        principalColumn: "ID");
                });

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
                name: "PhuCapNhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhuCap = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaPCNV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhuCapNhanVien_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuaTrinhNhanSu",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiQuaTrinhID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhongBanID = table.Column<int>(type: "int", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    ChucDanhID = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuaTrinhNhanSu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuaTrinhNhanSu_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuaTrinhNhanSu_PhongBan_PhongBanID",
                        column: x => x.PhongBanID,
                        principalTable: "PhongBan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuaTrinhNhanSu_ThongTinChucDanh_ChucDanhID",
                        column: x => x.ChucDanhID,
                        principalTable: "ThongTinChucDanh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuaTrinhNhanSu_ThongTinChucVu_ChucVuID",
                        column: x => x.ChucVuID,
                        principalTable: "ThongTinChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuaTrinhNhanSu_ThongTinQuaTrinhNhanSu_LoaiQuaTrinhID",
                        column: x => x.LoaiQuaTrinhID,
                        principalTable: "ThongTinQuaTrinhNhanSu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinCongDoan",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThuKiCongDoan = table.Column<bool>(type: "bit", nullable: false),
                    NgayGiaNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinCongDoan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinCongDoan_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinDangVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayVaoDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapDangVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinDangVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinDangVien_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinDaoTao",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTrinhDoHocVanID = table.Column<int>(type: "int", nullable: false),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamTotNghiep = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrinhDoVanHoa = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinDaoTao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinDaoTao_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinDaoTao_TrinhDoHocVan_MaTrinhDoHocVanID",
                        column: x => x.MaTrinhDoHocVanID,
                        principalTable: "TrinhDoHocVan",
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
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_ThongTinGiamTruGiaCanh_ThongTinGiamTru_MaGiamTruID",
                        column: x => x.MaGiamTruID,
                        principalTable: "ThongTinGiamTru",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonCongTacNhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LichSuCongTacID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHoaDonID = table.Column<int>(type: "int", nullable: false),
                    DuongDanFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonCongTacNhanVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDonCongTacNhanVien_LichSuCongTacNhanVien_LichSuCongTacID",
                        column: x => x.LichSuCongTacID,
                        principalTable: "LichSuCongTacNhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonCongTacNhanVien_LoaiHoaDon_LoaiHoaDonID",
                        column: x => x.LoaiHoaDonID,
                        principalTable: "LoaiHoaDon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDangVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DangVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonViCongTacID = table.Column<int>(type: "int", nullable: false),
                    ChucVuDang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrinhDoChinhTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                columns: new[] { "ID", "TenLoaiCongTac" },
                values: new object[,]
                {
                    { 1, "CongTacNoiBo" },
                    { 2, "CongTacNuocNgoai" },
                    { 3, "CongTacKyKetHopDong" },
                    { 4, "CongTacKhaoSatDuAn" },
                    { 5, "CongTacHoiThao" },
                    { 6, "CongTacDaoTao" },
                    { 7, "CongTacKiemTra" },
                    { 8, "CongTacKhac" }
                });

            migrationBuilder.InsertData(
                table: "LoaiHoaDon",
                columns: new[] { "ID", "TenLoaiHoaDon" },
                values: new object[,]
                {
                    { 1, "ChiPhiDiLai" },
                    { 2, "ChiPhiChoO" },
                    { 3, "ChiPhiQuaBieuTang" },
                    { 4, "HoaDonKhac" }
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
                table: "LoaiNghiPhep",
                columns: new[] { "ID", "TenLoaiNghiPhep", "SoGioNghiPhep" },
                values: new object[,]
                {
                    { 1, "NghiPhepNam", 8 },
                    { 2, "NghiOm", 8 },
                    { 3, "NghiKhongLuong", 8 },
                    { 4, "NghiThaiSan", 8 },
                    { 5, "NghiKhac", 8 }
                });

            migrationBuilder.InsertData(
                table: "ThongTinChucDanh",
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
                table: "ThongTinQuaTrinhNhanSu",
                columns: new[] { "ID", "TenMaQuaTrinhNhanSu" },
                values: new object[,]
                {
                    { 1, "ThangTien" },
                    { 2, "BoNhiem" },
                    { 3, "BaiNhiem" },
                    { 4, "DieuDong" },
                    { 5, "ThoiViec" }
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

            migrationBuilder.InsertData(
                table: "TrinhDoHocVan",
                columns: new[] { "ID", "TenTrinhDo" },
                values: new object[,]
                {
                    { 1, "Tien Si" },
                    { 2, "Thac Si" },
                    { 3, "Dai Hoc" },
                    { 4, "Cao Dang" },
                    { 5, "Trung Cap" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "ID", "ChucVuID", "DiaChiLienLac", "Email", "HoVaTen", "MaSoThue", "NgayCapNhatCuoi", "NgayTao", "NgayVaoCongTy", "NgayXoa", "NguoiCapNhatID", "NguoiTaoID", "NguoiXoaID", "PasswordHash", "PasswordSalt", "SoDienThoaiLienLac", "SoNguoiPhuThuoc", "SoTaiKhoan", "TenNganHang", "TinhTrangLamViecID" },
                values: new object[] { "845f021510784efcb3e39b314c178e6f", 1, "TP.HCM", "string", "Test User 1", "1234567", new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9056), new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9056), new DateTime(2024, 1, 15, 11, 35, 18, 148, DateTimeKind.Local).AddTicks(9089), null, null, null, null, new byte[] { 138, 49, 40, 12, 212, 75, 45, 184, 16, 222, 120, 126, 52, 73, 4, 108, 204, 124, 244, 138, 237, 247, 2, 84, 46, 120, 89, 223, 104, 34, 200, 90, 98, 36, 141, 64, 149, 116, 152, 250, 26, 204, 3, 55, 152, 122, 169, 113, 223, 7, 183, 74, 241, 60, 183, 91, 13, 254, 192, 239, 211, 2, 137, 68 }, new byte[] { 111, 221, 89, 160, 45, 109, 14, 134, 114, 64, 165, 39, 235, 118, 87, 122, 144, 191, 196, 40, 68, 102, 198, 83, 188, 198, 10, 102, 230, 222, 200, 235, 60, 32, 192, 73, 141, 173, 34, 246, 87, 32, 117, 106, 110, 167, 10, 164, 84, 57, 180, 153, 191, 30, 90, 86, 215, 177, 117, 74, 88, 182, 188, 245, 95, 185, 66, 152, 228, 11, 66, 163, 85, 111, 141, 10, 116, 228, 57, 213, 170, 107, 235, 219, 37, 154, 78, 206, 76, 89, 23, 243, 169, 161, 196, 127, 240, 66, 161, 62, 23, 16, 40, 26, 129, 197, 199, 87, 104, 81, 82, 27, 154, 57, 39, 169, 75, 231, 17, 89, 22, 137, 234, 191, 164, 51, 148, 238 }, "0912123456", null, "03450126803", "TPBank", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CanCuocCongDan_NhanVienID",
                table: "CanCuocCongDan",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangVien_DangVienID",
                table: "ChiTietDangVien",
                column: "DangVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDangVien_DonViCongTacID",
                table: "ChiTietDangVien",
                column: "DonViCongTacID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCongTacNhanVien_LichSuCongTacID",
                table: "HoaDonCongTacNhanVien",
                column: "LichSuCongTacID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonCongTacNhanVien_LoaiHoaDonID",
                table: "HoaDonCongTacNhanVien",
                column: "LoaiHoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChucDanhID",
                table: "HopDong",
                column: "ChucDanhID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChucVuID",
                table: "HopDong",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_HeSoLuongID",
                table: "HopDong",
                column: "HeSoLuongID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_LoaiHopDongID",
                table: "HopDong",
                column: "LoaiHopDongID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_NhanVienID",
                table: "HopDong",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuCongTacNhanVien_LoaiCongTacID",
                table: "LichSuCongTacNhanVien",
                column: "LoaiCongTacID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuCongTacNhanVien_MaSoNhanVien",
                table: "LichSuCongTacNhanVien",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuNghiPhepNhanVien_LoaiNghiPhepID",
                table: "LichSuNghiPhepNhanVien",
                column: "LoaiNghiPhepID");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuNghiPhepNhanVien_MaSoNhanVien",
                table: "LichSuNghiPhepNhanVien",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuNghiPhepNhanVien_NguoiDuyet",
                table: "LichSuNghiPhepNhanVien",
                column: "NguoiDuyet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LuongThoiGian_MaSoNhanVien",
                table: "LuongThoiGian",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuID",
                table: "NhanVien",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TinhTrangLamViecID",
                table: "NhanVien",
                column: "TinhTrangLamViecID");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_ChucDanhID",
                table: "QuaTrinhNhanSu",
                column: "ChucDanhID");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_ChucVuID",
                table: "QuaTrinhNhanSu",
                column: "ChucVuID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_LoaiQuaTrinhID",
                table: "QuaTrinhNhanSu",
                column: "LoaiQuaTrinhID");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_MaSoNhanVien",
                table: "QuaTrinhNhanSu",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_PhongBanID",
                table: "QuaTrinhNhanSu",
                column: "PhongBanID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinCongDoan_NhanVienID",
                table: "ThongTinCongDoan",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDangVien_NhanVienID",
                table: "ThongTinDangVien",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDaoTao_MaTrinhDoHocVanID",
                table: "ThongTinDaoTao",
                column: "MaTrinhDoHocVanID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinDaoTao_NhanVienID",
                table: "ThongTinDaoTao",
                column: "NhanVienID");

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
                name: "CanCuocCongDanEntityNhanVienEntity");

            migrationBuilder.DropTable(
                name: "ChinhSachNhanSu");

            migrationBuilder.DropTable(
                name: "ChiTietBaoHiem");

            migrationBuilder.DropTable(
                name: "ChiTietDangVien");

            migrationBuilder.DropTable(
                name: "HoaDonCongTacNhanVien");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "LichSuNghiPhepNhanVien");

            migrationBuilder.DropTable(

                name: "LuongThoiGian");

            migrationBuilder.DropTable(
                name: "MucSanPham");

            migrationBuilder.DropTable(
                name: "PhuCap");

            migrationBuilder.DropTable(
                name: "QuaTrinhNhanSu");

            migrationBuilder.DropTable(
                name: "ThongTinCongDoan");

            migrationBuilder.DropTable(
                name: "ThongTinDaoTao");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTruGiaCanh");

            migrationBuilder.DropTable(
                name: "ThongTinPhuCap");

            migrationBuilder.DropTable(

                name: "ThueSuat");

            migrationBuilder.DropTable(
                name: "CanCuocCongDan");

            migrationBuilder.DropTable(
                name: "BaoHiem");

            migrationBuilder.DropTable(
                name: "DonViCongTac");

            migrationBuilder.DropTable(
                name: "ThongTinDangVien");

            migrationBuilder.DropTable(
                name: "LichSuCongTacNhanVien");

            migrationBuilder.DropTable(
                name: "LoaiHoaDon");

            migrationBuilder.DropTable(
                name: "CapBacLuong");

            migrationBuilder.DropTable(
                name: "LoaiHopDong");

            migrationBuilder.DropTable(
                name: "LoaiNghiPhep");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "ThongTinChucDanh");

            migrationBuilder.DropTable(
                name: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropTable(
                name: "TrinhDoHocVan");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTru");

            migrationBuilder.DropTable(
                name: "LoaiCongTac");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThongTinChucVu");

            migrationBuilder.DropTable(
                name: "ThongTinTinhTrangLamViec");
        }
    }
}
