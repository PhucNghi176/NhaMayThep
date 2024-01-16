using AutoMapper;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;

public class LoaiNghiPhepRepository : RepositoryBase<LoaiNghiPhepEntity, LoaiNghiPhepEntity, ApplicationDbContext>, ILoaiNghiPhepRepository
{
    public LoaiNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

    public async Task<LoaiNghiPhepEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await FindAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<List<LoaiNghiPhepEntity>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default)
    {
        return await FindAllAsync(x => ids.Contains(x.ID), cancellationToken);
    }
}
