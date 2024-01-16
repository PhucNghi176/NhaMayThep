using AutoMapper;
using NhaMapThep.Domain.Entities;
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
    public class ThongTinGiamTruGiaCanhRepository : RepositoryBase<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhEntity, ApplicationDbContext>,
        IThongTinGiamTruGiaCanhRepository
    {
        public ThongTinGiamTruGiaCanhRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<ThongTinGiamTruGiaCanhEntity>?> FindAll(CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x=> x.NguoiXoaID == null && x.NgayXoa== null,cancellationToken);
        }
        public async Task<ThongTinGiamTruGiaCanhEntity?> FindById(string Id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID.Equals(Id) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
        }
        public async Task<List<ThongTinGiamTruGiaCanhEntity>?> FindByNhanVienId(string Id, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => x.NhanVienID.Equals(Id) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
        }
        public async Task<ThongTinGiamTruGiaCanhEntity?> FindByCanCuocCongDan(string cccd, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.CanCuocCongDan.Equals(cccd) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
        }
    }
}
