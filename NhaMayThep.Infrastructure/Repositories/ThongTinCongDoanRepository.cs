using AutoMapper;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class ThongTinCongDoanRepository : RepositoryBase<ThongTinCongDoanEntity, ThongTinCongDoanEntity, ApplicationDbContext>,
        IThongTinCongDoanRepository
    {
        public ThongTinCongDoanRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ThongTinCongDoanEntity>?> FindAll(CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x=> x.NguoiXoaID == null, cancellationToken);
        }
        public async Task<ThongTinCongDoanEntity?> FindById(string Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID.Equals(Id) && x.NguoiXoaID == null, cancellationToken);
        }
        public async Task<ThongTinCongDoanEntity?> FindByNhanVienId(string Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.NhanVienID.Equals(Id) && x.NguoiXoaID == null, cancellationToken);
        }
    }
}
