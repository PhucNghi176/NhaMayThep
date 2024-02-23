using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Infrastructure.Persistence.Configurations;
using NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NhanVienEntity> NhanVien { get; set; }
        public DbSet<ThongTinChucVuEntity> ChucVu { get; set; }
        public DbSet<TinhTrangLamViecEntity> TinhTrangLamViec { get; set; }
        public DbSet<ThongTinGiamTruEntity> ThongTinGiamTru { get; set; }
        public DbSet<CanCuocCongDanEntity> CanCuocCongDan { get; set; }
        public DbSet<ThongTinGiamTruGiaCanhEntity> GiamTruGiaCanh { get; set; }
        public DbSet<LoaiHopDongEntity> LoaiHopDong { get; set; }
        public DbSet<ThongTinChucDanhEntity> ChucDanh { get; set; }
        public DbSet<TrinhDoHocVanEntity> TrinhDoHocVan { get; set; }
        public DbSet<ThongTinDaoTaoEntity> ThongTinDaoTao { get; set; }
        public DbSet<ThongTinCongDoanEntity> ThongTinCongDoan { get; set; }
        public DbSet<ThongTinDangVienEntity> ThongTinDangVien { get; set; }
        public DbSet<ThongTinPhuCapEntity> ThongTinPhuCap { get; set; }
        public DbSet<ChiTietDangVienEntity> ChiTietDangVien { get; set; }
        public DbSet<DonViCongTacEntity> DonViCongTac { get; set; }
        public DbSet<CapBacLuongEntity> CapBacLuong { get; set; }
        public DbSet<HopDongEntity> HopDong { get; set; }
        public DbSet<PhongBanEntity> PhongBan { get; set; }
        public DbSet<ThongTinQuaTrinhNhanSuEntity> ThongTinQuaTrinhNhanSu { get; set; }
        public DbSet<QuaTrinhNhanSuEntity> QuaTrinhNhanSu { get; set; }
        public DbSet<LoaiNghiPhepEntity> LoaiNghiPhep { get; set; }
        public DbSet<LichSuNghiPhepNhanVienEntity> LichSuNghiPhepNhanVien { get; set; }
        public DbSet<LoaiCongTacEntity> LoaiCongTac { get; set; }
        public DbSet<LichSuCongTacNhanVienEntity> LichSuCongTacNhanVien { get; set; }
        public DbSet<LoaiHoaDonEntity> LoaiHoaDon { get; set; }
        public DbSet<HoaDonCongTacNhanVienEntity> HoaDonCongTacNhanVien { get; set; }
        public DbSet<ChinhSachNhanSuEntity> ChinhSachNhanSu { get; set; }
        public DbSet<ChiTietNgayNghiPhepEntity> ChiTietNgayNghiPhep { get; set; }
        public DbSet<ThongTinLuongNhanVienEntity> ThongTinLuongNhanVien { get; set; }
        public DbSet<ThongTinCongTyEntity> ThongTinCongTy {  get; set; }
        public DbSet<ThueSuatEntity> ThueSuat {  get; set; }
        public DbSet<MucSanPhamEntity> MucSanPham {  get; set; }
        public DbSet<BaoHiemEntity> BaoHiem {  get; set; }
        public DbSet<ChiTietBaoHiemEntity> ChiTietBaoHiem { get; set; }
        public DbSet<BaoHiemNhanVienEntity> BaoHiemNhanVien { get; set; }
        public DbSet<PhuCapEntity> PhuCap { get; set; }
        public DbSet<PhuCapNhanVienEntity> PhuCapNhanVien { get; set; }
        public DbSet<MaDangKiCaLamEntity> MaDangKiCaLam { get; set; }
        public DbSet<TrangThaiDangKiCaLamViecEntity> TrangThaiDangKiCaLamViec { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChinhSachNhanSuConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinLuongNhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiCongTacConfiguration());
            modelBuilder.ApplyConfiguration(new ChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiHopDongConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinChucDanhConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinGiamTruConfiguration());
            modelBuilder.ApplyConfiguration(new TinhTrangLamViecConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new CanCuocCongDanConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinGiamTruGiaCanhConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new TrinhDoHocVanConfiguration());
            modelBuilder.ApplyConfiguration(new HopDongConfiguration());
            modelBuilder.ApplyConfiguration(new PhongBanConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinQuaTrinhNhanSuConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiNghiPhepConfiguration());
            modelBuilder.ApplyConfiguration(new QuaTrinhNhanSuConfiguration());
            modelBuilder.ApplyConfiguration(new LichSuNghiPhepNhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiHoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinCongTyConfiguration());
            modelBuilder.ApplyConfiguration(new ThueSatConfiguration());
            modelBuilder.ApplyConfiguration(new MucSanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new BaoHiemConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietBaoHiemConfiguration());
            modelBuilder.ApplyConfiguration(new BaoHiemNhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new PhuCapConfiguration());
            modelBuilder.ApplyConfiguration(new PhuCapNhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new MaDangKiCaLamConfiguration());
            modelBuilder.ApplyConfiguration(new TrangThaiDangKiCaLamViecConfiguration());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {

           /* modelBuilder.Entity<LoaiHoaDonEntity>().HasData(
                new LoaiHoaDonEntity() { ID = 1, Name = "HoaDonDiLai" },
                new LoaiHoaDonEntity() { ID = 2, Name = "HoaDonChoO" },
                new LoaiHoaDonEntity() { ID = 3, Name = "HoaDonQuaBieuTang" },
                new LoaiHoaDonEntity() { ID = 4, Name = "HoaDonKhac" });
            modelBuilder.Entity<LoaiCongTacEntity>().HasData(
                new LoaiCongTacEntity() { ID = 1, Name = "CongTacNoiBo" },
                new LoaiCongTacEntity() { ID = 2, Name = "CongTacNuocNgoai" },
                new LoaiCongTacEntity() { ID = 3, Name = "CongTacKyKetHopDong" },
                new LoaiCongTacEntity() { ID = 4, Name = "CongTacKhaoSatDuAn" },
                new LoaiCongTacEntity() { ID = 5, Name = "CongTacHoiThao" },
                new LoaiCongTacEntity() { ID = 6, Name = "CongTacDaoTao" },
                new LoaiCongTacEntity() { ID = 7, Name = "CongTacKiemTra" },
                new LoaiCongTacEntity() { ID = 8, Name = "CongTacKhac" });

            modelBuilder.Entity<LoaiNghiPhepEntity>().HasData(
                new LoaiNghiPhepEntity() { ID = 1, Name = "NghiPhepNam"},
                new LoaiNghiPhepEntity() { ID = 2, Name = "NghiOm"},
                new LoaiNghiPhepEntity() { ID = 3, Name = "NghiKhongLuong" },
                new LoaiNghiPhepEntity() { ID = 4, Name = "NghiThaiSan"},
                new LoaiNghiPhepEntity() { ID = 5, Name = "NghiKhac"});
            modelBuilder.Entity<ThongTinQuaTrinhNhanSuEntity>().HasData(
                new ThongTinQuaTrinhNhanSuEntity() { ID = 1, Name = "ThangTien" },
                new ThongTinQuaTrinhNhanSuEntity() { ID = 2, Name = "BoNhiem" },
                new ThongTinQuaTrinhNhanSuEntity() { ID = 3, Name = "BaiNhiem" },
                new ThongTinQuaTrinhNhanSuEntity() { ID = 4, Name = "DieuDong" },
                new ThongTinQuaTrinhNhanSuEntity() { ID = 5, Name = "ThoiViec" });
            modelBuilder.Entity<TrinhDoHocVanEntity>().HasData(
                new TrinhDoHocVanEntity() { ID = 1, Name = "Tien Si" },
                new TrinhDoHocVanEntity() { ID = 2, Name = "Thac Si" },
                new TrinhDoHocVanEntity() { ID = 3, Name = "Dai Hoc" },
                new TrinhDoHocVanEntity() { ID = 4, Name = "Cao Dang" },
                new TrinhDoHocVanEntity() { ID = 5, Name = "Trung Cap" });
            modelBuilder.Entity<ThongTinChucVuEntity>().HasData(
                new ThongTinChucVuEntity() { ID = 1, Name = "Admin" },
                new ThongTinChucVuEntity() { ID = 2, Name = "Truong Phong Nhan Su" },
                new ThongTinChucVuEntity() { ID = 3, Name = "Quan Li" },
                new ThongTinChucVuEntity() { ID = 4, Name = "Nhan Vien" }
                );
            modelBuilder.Entity<TinhTrangLamViecEntity>().HasData(
                new TinhTrangLamViecEntity() { ID = 1, Name = "DangLamViec" },
                new TinhTrangLamViecEntity() { ID = 2, Name = "DaNghiViec" },
                new TinhTrangLamViecEntity() { ID = 3, Name = "DangThuViec" },
                new TinhTrangLamViecEntity() { ID = 4, Name = "DangNghiPhep" });
            modelBuilder.Entity<ThongTinGiamTruEntity>().HasData(
                new ThongTinGiamTruEntity() { ID = 1, Name = "GiamTruBanThan", SoTienGiamTru = 11000000M },
                new ThongTinGiamTruEntity() { ID = 2, Name = "GiamTruNguoiPhuThuoc", SoTienGiamTru = 4400000M });
            modelBuilder.Entity<LoaiHopDongEntity>().HasData(
                new LoaiHopDongEntity() { ID = 1, Name = "HopDongThuViec" },
                new LoaiHopDongEntity() { ID = 2, Name = "HopDongCoThoiHan" },
                new LoaiHopDongEntity() { ID = 3, Name = "HopDongKhongThoiHan" });
            modelBuilder.Entity<ThongTinChucDanhEntity>().HasData(
                 new ThongTinChucDanhEntity() { ID = 1, Name = "GiamDoc" },
                 new ThongTinChucDanhEntity() { ID = 2, Name = "PhoGiamDoc" },
                 new ThongTinChucDanhEntity() { ID = 3, Name = "TruongPhong" },
                 new ThongTinChucDanhEntity() { ID = 4, Name = "PhoPhong" },
                 new ThongTinChucDanhEntity() { ID = 5, Name = "NhanVien" });
           */
        }
    }
}
