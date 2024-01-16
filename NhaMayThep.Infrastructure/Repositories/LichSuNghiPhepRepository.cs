using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using NhaMapThep.Infrastructure.Repositories;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LichSuNghiPhepRepository : RepositoryBase<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepNhanVienEntity, ApplicationDbContext>, ILichSuNghiPhepRepo
    {
        public LichSuNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<LichSuNghiPhepNhanVienEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.MaSoNhanVien == id, cancellationToken);
        }

        public async Task<List<LichSuNghiPhepNhanVienEntity>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.MaSoNhanVien), cancellationToken);
        }
    }
}
