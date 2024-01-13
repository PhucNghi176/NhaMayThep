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
        public DbSet<ThongTinGiamTruGiaCanhEntity> ThongTinGiamTruGiaCanh { get; set; }

        public DbSet<LoaiHopDongEntity> LoaiHopDong { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiHopDongConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinChucDanhConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinGiamTruConfiguration());
            modelBuilder.ApplyConfiguration(new TinhTrangLamViecConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new CanCuocCongDanConfiguration());
            modelBuilder.ApplyConfiguration(new ThongTinGiamTruGiaCanhConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
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
        }
    }
}
