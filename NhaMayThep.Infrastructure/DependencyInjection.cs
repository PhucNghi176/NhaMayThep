﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;

namespace NhaMayThep.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            
            services.AddTransient<ICanCuocCongDanRepository, CanCuocCongDanRepository>();
            services.AddTransient<IChucVuRepository, BangChucVuRepository>();
            services.AddTransient<ITinhTrangLamViecRepository, TinhTrangLamViecRepository>();
            services.AddTransient<ICapBacLuongRepository, CapBacLuongRepository>();
            services.AddTransient<IChucDanhRepository, ChucDanhRepository>();
            services.AddTransient<ILoaiHopDongReposity, LoaiHopDongRepository>();
            services.AddTransient<IHopDongRepository, HopDongRepository>();
            services.AddTransient<IPhuCapRepository, ThongTinPhuCapRepository>();
            services.AddTransient<IBaoHiemRepository, BaoHiemRepository>();
            return services;
        }
    }
}