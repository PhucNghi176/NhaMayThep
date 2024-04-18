using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;

namespace NhaMayThep.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("Server"),
                b =>
                {
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    //b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            options.UseLazyLoadingProxies();
        });
        
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<INhanVienRepository, NhanVienRepository>();
        services.AddScoped<IThongTinDaoTaoRepository, ThongTinDaoTaoRepository>();
        services.AddScoped<ITrinhDoHocVanRepository, TrinhDoHocVanRepository>();            
        services.AddScoped<ICanCuocCongDanRepository, CanCuocCongDanRepository>();
        services.AddScoped<IChucVuRepository, BangChucVuRepository>();
        services.AddScoped<ITinhTrangLamViecRepository, TinhTrangLamViecRepository>();
        services.AddScoped<IThongTinCongDoanRepository, ThongTinCongDoanRepository>();
        services.AddScoped<IThongTinGiamTruGiaCanhRepository, ThongTinGiamTruGiaCanhRepository>();
        services.AddScoped<IThongTinGiamTruRepository, ThongTinGiamTruRepository>();
        services.AddScoped<IDonViCongTacRepository, DonViCongTacRepository>();
        services.AddScoped<IThongTinDangVienRepository, ThongTinDangVienRepository>();
        services.AddScoped<IChiTietNgayNghiPhepRepository, ChiTietNgayNghiPhepRepository>();
        services.AddScoped<ILoaiNghiPhepRepository, LoaiNghiPhepRepository>();
        services.AddScoped<ILichSuNghiPhepRepository, LichSuNghiPhepRepository>();
        services.AddScoped<ILichSuCongTacNhanVienRepository, LichSuCongTacNhanVienRepository>();
        services.AddScoped<IHoaDonCongTacNhanVienRepository, HoaDonCongTacNhanVienRepository>();
        services.AddScoped<ILoaiCongTacRepository, LoaiCongTacRepository>();
        services.AddScoped<ILoaiHoaDonRepository, LoaiHoaDonRepository>();
        services.AddScoped<IQuaTrinhNhanSuRepository, QuaTrinhNhanSuRepository>();
        services.AddScoped<IThongTinQuaTrinhNhanSuRepository, ThongTinQuaTrinhNhanSuRepository>();
        services.AddScoped<IPhongBanRepository, PhongBanRepository>();
        services.AddScoped<ICapBacLuongRepository, CapBacLuongRepository>();
        services.AddScoped<ILoaiHopDongReposity, LoaiHopDongRepository>();
        services.AddScoped<IHopDongRepository, HopDongRepository>();
        services.AddScoped<IPhuCapRepository, ThongTinPhuCapRepository>();
        services.AddScoped<IBaoHiemRepository, BaoHiemRepository>();
        services.AddScoped<IChucDanhRepository, ChucDanhRepository>();   
        services.AddScoped<IMucSanPhamRepository, MucSanPhamRepository>();
        services.AddScoped<IKyLuatRepository, KyLuatRepository>();
        services.AddScoped<IKhenThuongRepository, KhenThuongRepository>();
        services.AddScoped<IThongTinCongTyRepository, ThongTinCongTyRepository>();
        services.AddScoped<ILuongThoiGianRepository, LuongThoiGianRepository>();
        services.AddScoped<IThueSuatRepository, ThueSuatRepository>();
        services.AddScoped<ILoaiTangCaRepository, LoaiTangCaRepository>();
        services.AddScoped<ILuongCongNhatRepository, LuongCongNhatRepository>();
        services.AddScoped<ILuongSanPhamRepository, LuongSanPhamRepository>();
        services.AddScoped<IKhaiBaoTangLuongRepository, KhaiBaoTangLuongRepository>();
        services.AddScoped<IPhiCongDoanRepository, PhiCongDoanRepository>();
        services.AddScoped<IPhuCapCongDoanRepository, PhuCapCongDoanRepository>();
        services.AddScoped<ITangCaRepository, TangCaRepository>();
        services.AddScoped<IChiTietBaoHiemRepository, ChiTietBaoHiemRepository>();
        services.AddScoped<ITrangThaiDangKiCaLamViecRepository, TrangThaiDangKiCaLamViecRepository>();
        services.AddScoped<IMaDangKiCaLamRepository, MaDangKiCaLamRepository>();
        services.AddScoped<INghiPhepRepository, NghiPhepRepository>();
        services.AddScoped<IThongTinCapDangVienRepository, ThongTinCapDangVienRepository>();
        services.AddScoped<IThongTinChucVuDangRepository, ThongTinChucVuDangRepository>();
        services.AddScoped<IThongTinTrinhDoChinhTriRepository, ThongTinTrinhDoChinhTriRepository>();
        services.AddScoped<IChinhSachNhanSuRepository, ChinhSachNhanSuRepository>();
        services.AddScoped<IDangKiCaLamRepository, DangKiCaLamRepository>();
        services.AddScoped<IDangKiTangCaRepository, DangKiTangCaRepository>();
        services.AddScoped<IPhuCapNhanVienRepository, PhuCapNhanVienRepository>();
        services.AddScoped<IThongTinLuongNhanVienRepository,ThongTinLuongNhanVienRepository>();
        services.AddScoped<IBaoHiemNhanVienRepository, BaoHiemNhanVienRepository>();
        services.AddScoped<IBangLuongRepository, BangLuongRepository>();
        services.AddScoped<IGiamTruNhanVienRepository, GiamTruNhanVienRepository>();
        services.AddScoped<IBaoHiemNhanVienBaoHiemChiTietRepository, BaoHiemNhanVienBaoHiemChiTietRepository>();
        return services;
    }
}