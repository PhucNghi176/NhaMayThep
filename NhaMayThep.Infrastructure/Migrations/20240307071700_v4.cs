using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NhaMayThep.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
