using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Infrastructure.Persistence.Configurations;
using NhaMayThep.Infrastructure.Persistence.Configurations.ConfigTable;

namespace NhaMayThep.Infrastructure.Persistence;

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
    public DbSet<ThongTinCongTyEntity> ThongTinCongTy { get; set; }
    public DbSet<ThueSuatEntity> ThueSuat { get; set; }
    public DbSet<MucSanPhamEntity> MucSanPham { get; set; }
    public DbSet<BaoHiemEntity> BaoHiem { get; set; }
    public DbSet<ChiTietBaoHiemEntity> ChiTietBaoHiem { get; set; }
    public DbSet<BaoHiemNhanVienEntity> BaoHiemNhanVien { get; set; }
    public DbSet<PhuCapEntity> PhuCap { get; set; }
    public DbSet<PhuCapNhanVienEntity> PhuCapNhanVien { get; set; }
    public DbSet<MaDangKiCaLamEntity> MaDangKiCaLam { get; set; }
    public DbSet<TrangThaiDangKiCaLamViecEntity> TrangThaiDangKiCaLamViec { get; set; }
    public DbSet<LuongThoiGianEntity> LuongThoiGian { get; set; }
    public DbSet<DangKiCaLamEntity> DangKiCaLam { get; set; }
    public DbSet<DangKiTangCaEntity> DangKiTangCa { get; set; }
    public DbSet<ThongTinCapDangVienEntity> ThongTinCapDangVien { get; set; }
    public DbSet<ThongTinTrinhDoChinhTriEntity> ThongTinTrinhDoChinhTri { get; set; }
    public DbSet<ThongTinChucVuDangEntity> ThongTinChucVuDang { get; set; }
    public DbSet<KyLuatEntity> KyLuat { get; set; }
    public DbSet<KhenThuongEntity> khenThuongs { get; set; }
    public DbSet<KhaiBaoTangLuongEntity> KhaiBaoTangLuongs { get; set; }
    public DbSet<LoaiTangCaEntity> LoaiTangCas { get; set; }
    public DbSet<LuongCongNhatEntity> LuongCongNhats { get; set; }
    public DbSet<LuongSanPhamEntity> LuongSanPhams { get; set; }
    public DbSet<PhiCongDoanEntity> PhiCongDoans { get; set; }
    public DbSet<PhuCapCongDoanEntity> PhuCapCongDoans { get; set; }
    public DbSet<TangCaEntity> TangCas { get; set; }
    public DbSet<NghiPhepEntity> NghiPheps { get; set; }



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
        modelBuilder.ApplyConfiguration(new LuongThoiGianConfiguration());
        modelBuilder.ApplyConfiguration(new DangKiCaLamConfiguration());
        modelBuilder.ApplyConfiguration(new DangKiTangCaConfiguration());
        modelBuilder.ApplyConfiguration(new ThongTinCapDangVienConfiguration());
        modelBuilder.ApplyConfiguration(new ThongTinChucVuDangConfiguration());
        modelBuilder.ApplyConfiguration(new ThongTinTrinhDoChinhTriConfiguration());
        ConfigureModel(modelBuilder);
    }
    private void ConfigureModel(ModelBuilder modelBuilder)
    {


    }
}
