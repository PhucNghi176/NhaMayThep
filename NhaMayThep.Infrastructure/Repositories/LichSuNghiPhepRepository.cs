using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

public class LichSuNghiPhepRepository : RepositoryBase<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepNhanVienEntity, ApplicationDbContext>, ILichSuNghiPhepRepository
{
    public LichSuNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<LichSuNghiPhepNhanVienEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await FindAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<LichSuNghiPhepNhanVienEntity> FindByMaSoNhanVienAsync(string maSoNhanVien, CancellationToken cancellationToken = default)
    {
        return await FindAsync(x => x.MaSoNhanVien == maSoNhanVien, cancellationToken);
    }
}
