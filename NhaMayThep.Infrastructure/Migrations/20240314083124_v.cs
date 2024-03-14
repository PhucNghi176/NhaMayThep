﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    TrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacLuong", x => x.ID);
                });

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
                name: "DonViCongTac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenLoaiCongTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenLoaiHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenLoaiNghiPhep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaLoaiNghiPhep", x => x.ID);
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
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaPhongBan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinCapDangVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapDangVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenCapDangVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaCapDangVien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChucDanh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucDanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaChucVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinChucVuDang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChucVuDang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenChucVuDang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaChucVuDang", x => x.ID);
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
                    TenMaGiamTru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    PhanTramPhuCap = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenMaQuaTrinhNhanSu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    TenMaTinhTrangLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaTinhTrangLamViecID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinTrinhDoChinhTri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrinhDoChinhTri = table.Column<int>(type: "int", nullable: false),
                    TenTrinhDoChinhTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaTrinhDoChinhTri", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThueSuat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BacThue = table.Column<int>(type: "int", nullable: false),
                    DauThuNhapTinhThueTrenNam = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CuoiThuNhapTinhThueTrenNam = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DauThuNhapTinhThueTrenThang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CuoiThuNhapTinhThueTrenThang = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PhanTramThueSuat = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaThueSuat", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "TrinhDoHocVan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    DaCoHopDong = table.Column<bool>(type: "bit", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "BaoHiemNhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BaoHiem = table.Column<int>(type: "int", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaBHNV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaoHiemNhanVien_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "DangKiCaLam",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayDangKi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaDangKi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianCaLamBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCaLamKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianChamCongBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianChamCongKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeSoNgayCong = table.Column<double>(type: "float", nullable: false),
                    MaSoNguoiQuanLy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKiCaLam", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DangKiCaLam_MaDangKiCaLam_CaDangKi",
                        column: x => x.CaDangKi,
                        principalTable: "MaDangKiCaLam",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKiCaLam_NhanVien_MaSoNguoiQuanLy",
                        column: x => x.MaSoNguoiQuanLy,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKiCaLam_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DangKiCaLam_TrangThaiDangKiCaLamViec_TrangThai",
                        column: x => x.TrangThai,
                        principalTable: "TrangThaiDangKiCaLamViec",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DangKiTangCa",
                columns: table => new
                {
                    MaTangCa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLamTangCa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaDangKi = table.Column<int>(type: "int", nullable: false),
                    LiDoTangCa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianCaLamBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianCaLamKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoGioTangCa = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeSoLuongTangCa = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TrangThaiDuyet = table.Column<int>(type: "int", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKiTangCa", x => x.MaTangCa);
                    table.ForeignKey(
                        name: "FK_DangKiTangCa_MaDangKiCaLam_CaDangKi",
                        column: x => x.CaDangKi,
                        principalTable: "MaDangKiCaLam",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKiTangCa_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DangKiTangCa_NhanVien_NguoiDuyet",
                        column: x => x.NguoiDuyet,
                        principalTable: "NhanVien",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NhanVienID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHopDongID = table.Column<int>(type: "int", nullable: false),
                    NgayKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiHanHopDong = table.Column<int>(type: "int", nullable: true),
                    DiaDiemLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoPhanLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVuID = table.Column<int>(type: "int", nullable: false),
                    ChucDanhID = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    HeSoLuongID = table.Column<int>(type: "int", nullable: false),
                    PhuCapID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "KhaiBaoTangLuong",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhanTramTang = table.Column<float>(type: "real", nullable: false),
                    NgayApDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhaiBaoTangLuong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KhaiBaoTangLuong_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhenThuong",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChinhSachNhanSuID = table.Column<int>(type: "int", nullable: false),
                    TenDotKhenThuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKhenThuong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongThuong = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhenThuong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KhenThuong_ChinhSachNhanSu_ChinhSachNhanSuID",
                        column: x => x.ChinhSachNhanSuID,
                        principalTable: "ChinhSachNhanSu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhenThuong_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KyLuat",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChinhSachNhanSuID = table.Column<int>(type: "int", nullable: false),
                    TenDotKyLuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKiLuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongPhat = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyLuat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KyLuat_ChinhSachNhanSu_ChinhSachNhanSuID",
                        column: x => x.ChinhSachNhanSuID,
                        principalTable: "ChinhSachNhanSu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KyLuat_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    DonViCongTacID = table.Column<int>(type: "int", nullable: false),
                    ChucVuDang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrinhDoChinhTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayVaoDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapDangVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinDangVien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThongTinDangVien_DonViCongTac_DonViCongTacID",
                        column: x => x.DonViCongTacID,
                        principalTable: "DonViCongTac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "BaoHiem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiBaoHiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramKhauTru = table.Column<double>(type: "float", nullable: false),
                    BaoHiem = table.Column<int>(type: "int", nullable: true),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaBaoHiem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BaoHiem_BaoHiemNhanVien_BaoHiem",
                        column: x => x.BaoHiem,
                        principalTable: "BaoHiemNhanVien",
                        principalColumn: "ID");
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

            migrationBuilder.CreateTable(
                name: "HoaDonCongTacNhanVien",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LichSuCongTacID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHoaDonID = table.Column<int>(type: "int", nullable: false),
                    DuongDanFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "PhuCap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoanPhuCap = table.Column<double>(type: "float", nullable: false),
                    PhuCap = table.Column<int>(type: "int", nullable: true),
                    TenPhuCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaPhuCap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhuCap_PhuCapNhanVien_PhuCap",
                        column: x => x.PhuCap,
                        principalTable: "PhuCapNhanVien",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietBaoHiem",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSoNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiBaoHiem = table.Column<int>(type: "int", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTaoID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiCapNhatID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhatCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiXoaID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXoa = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MaSo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietBaoHiem_BaoHiem_LoaiBaoHiem",
                        column: x => x.LoaiBaoHiem,
                        principalTable: "BaoHiem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietBaoHiem_NhanVien_MaSoNhanVien",
                        column: x => x.MaSoNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiem_BaoHiem",
                table: "BaoHiem",
                column: "BaoHiem");

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiemNhanVien_MaSoNhanVien",
                table: "BaoHiemNhanVien",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_CanCuocCongDan_NhanVienID",
                table: "CanCuocCongDan",
                column: "NhanVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoHiem_LoaiBaoHiem",
                table: "ChiTietBaoHiem",
                column: "LoaiBaoHiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietBaoHiem_MaSoNhanVien",
                table: "ChiTietBaoHiem",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNgayNghiPhep_LoaiNghiPhepID",
                table: "ChiTietNgayNghiPhep",
                column: "LoaiNghiPhepID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNgayNghiPhep_MaSoNhanVien",
                table: "ChiTietNgayNghiPhep",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiCaLam_CaDangKi",
                table: "DangKiCaLam",
                column: "CaDangKi");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiCaLam_MaSoNguoiQuanLy",
                table: "DangKiCaLam",
                column: "MaSoNguoiQuanLy");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiCaLam_MaSoNhanVien",
                table: "DangKiCaLam",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiCaLam_TrangThai",
                table: "DangKiCaLam",
                column: "TrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiTangCa_CaDangKi",
                table: "DangKiTangCa",
                column: "CaDangKi");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiTangCa_MaSoNhanVien",
                table: "DangKiTangCa",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKiTangCa_NguoiDuyet",
                table: "DangKiTangCa",
                column: "NguoiDuyet");

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
                name: "IX_KhaiBaoTangLuong_MaSoNhanVien",
                table: "KhaiBaoTangLuong",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_ChinhSachNhanSuID",
                table: "KhenThuong",
                column: "ChinhSachNhanSuID");

            migrationBuilder.CreateIndex(
                name: "IX_KhenThuong_MaSoNhanVien",
                table: "KhenThuong",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_KyLuat_ChinhSachNhanSuID",
                table: "KyLuat",
                column: "ChinhSachNhanSuID");

            migrationBuilder.CreateIndex(
                name: "IX_KyLuat_MaSoNhanVien",
                table: "KyLuat",
                column: "MaSoNhanVien");

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
                column: "NguoiDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_LuongThoiGian_MaSoNhanVien",
                table: "LuongThoiGian",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuID",
                table: "NhanVien",
                column: "ChucVuID");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_Email",
                table: "NhanVien",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TinhTrangLamViecID",
                table: "NhanVien",
                column: "TinhTrangLamViecID");

            migrationBuilder.CreateIndex(
                name: "IX_PhuCap_PhuCap",
                table: "PhuCap",
                column: "PhuCap");

            migrationBuilder.CreateIndex(
                name: "IX_PhuCapNhanVien_MaSoNhanVien",
                table: "PhuCapNhanVien",
                column: "MaSoNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_ChucDanhID",
                table: "QuaTrinhNhanSu",
                column: "ChucDanhID");

            migrationBuilder.CreateIndex(
                name: "IX_QuaTrinhNhanSu_ChucVuID",
                table: "QuaTrinhNhanSu",
                column: "ChucVuID");

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
                name: "IX_ThongTinDangVien_DonViCongTacID",
                table: "ThongTinDangVien",
                column: "DonViCongTacID");

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
                name: "CanCuocCongDan");

            migrationBuilder.DropTable(
                name: "ChiTietBaoHiem");

            migrationBuilder.DropTable(
                name: "ChiTietNgayNghiPhep");

            migrationBuilder.DropTable(
                name: "DangKiCaLam");

            migrationBuilder.DropTable(
                name: "DangKiTangCa");

            migrationBuilder.DropTable(
                name: "HoaDonCongTacNhanVien");

            migrationBuilder.DropTable(
                name: "KhaiBaoTangLuong");

            migrationBuilder.DropTable(
                name: "KhenThuong");

            migrationBuilder.DropTable(
                name: "KyLuat");

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
                name: "ThongTinCapDangVien");

            migrationBuilder.DropTable(
                name: "ThongTinChucVuDang");

            migrationBuilder.DropTable(
                name: "ThongTinCongDoan");

            migrationBuilder.DropTable(
                name: "ThongTinCongTy");

            migrationBuilder.DropTable(
                name: "ThongTinDangVien");

            migrationBuilder.DropTable(
                name: "ThongTinDaoTao");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTruGiaCanh");

            migrationBuilder.DropTable(
                name: "ThongTinLuongNhanVien");

            migrationBuilder.DropTable(
                name: "ThongTinPhuCap");

            migrationBuilder.DropTable(
                name: "ThongTinTrinhDoChinhTri");

            migrationBuilder.DropTable(
                name: "ThueSuat");

            migrationBuilder.DropTable(
                name: "BaoHiem");

            migrationBuilder.DropTable(
                name: "TrangThaiDangKiCaLamViec");

            migrationBuilder.DropTable(
                name: "MaDangKiCaLam");

            migrationBuilder.DropTable(
                name: "LichSuCongTacNhanVien");

            migrationBuilder.DropTable(
                name: "LoaiHoaDon");

            migrationBuilder.DropTable(
                name: "ChinhSachNhanSu");

            migrationBuilder.DropTable(
                name: "LoaiNghiPhep");

            migrationBuilder.DropTable(
                name: "PhuCapNhanVien");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "ThongTinQuaTrinhNhanSu");

            migrationBuilder.DropTable(
                name: "DonViCongTac");

            migrationBuilder.DropTable(
                name: "TrinhDoHocVan");

            migrationBuilder.DropTable(
                name: "ThongTinGiamTru");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "BaoHiemNhanVien");

            migrationBuilder.DropTable(
                name: "LoaiCongTac");

            migrationBuilder.DropTable(
                name: "CapBacLuong");

            migrationBuilder.DropTable(
                name: "LoaiHopDong");

            migrationBuilder.DropTable(
                name: "ThongTinChucDanh");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThongTinChucVu");

            migrationBuilder.DropTable(
                name: "ThongTinTinhTrangLamViec");
        }
    }
}