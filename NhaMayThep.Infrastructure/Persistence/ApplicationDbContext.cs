using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Infrastructure.Persistence.Configurations;

namespace NhaMayThep.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<NhanVienEntity> NhanVien { get; set; }
        public DbSet<BangChucVuEntity> BangChucVu { get; set; }
        public DbSet<BangTinhTrangLamViecEntity> BangTinhTrangLamViec { get; set; }
        public DbSet<ChiTietNhanVienEntity> ChiTietNhanVien { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BangChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new BangTinhTrangLamViecConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietNhanVienConfiguration());
            modelBuilder.ApplyConfiguration(new NhanVienConfiguration());
            ConfigureModel(modelBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
            // Seed data
            // https://rehansaeed.com/migrating-to-entity-framework-core-seed-data/
            /* Eg.
            
            modelBuilder.Entity<Car>().HasData(
            new Car() { CarId = 1, Make = "Ferrari", Model = "F40" },
            new Car() { CarId = 2, Make = "Ferrari", Model = "F50" },
            new Car() { CarId = 3, Make = "Lamborghini", Model = "Countach" });
            */

            modelBuilder.Entity<BangChucVuEntity>().HasData(
                new BangChucVuEntity() { ID = 1, Name = "Admin" },
                new BangChucVuEntity() { ID = 2, Name = "HR" },
                new BangChucVuEntity() { ID = 3, Name = "Manager" }
                );
            modelBuilder.Entity<BangTinhTrangLamViecEntity>().HasData(
                new BangTinhTrangLamViecEntity() { ID = 1, Name = "DangLamViec" },
                new BangTinhTrangLamViecEntity() { ID = 2, Name = "DaNghiViec" },
                new BangTinhTrangLamViecEntity() { ID = 3, Name = "DangThuViec" },
                new BangTinhTrangLamViecEntity() { ID = 4, Name = "DangNghiPhep" });

        }
    }
}
