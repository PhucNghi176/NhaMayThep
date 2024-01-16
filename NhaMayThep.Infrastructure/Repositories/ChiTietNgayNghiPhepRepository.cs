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
    public class ChiTietNgayNghiPhepRepository : RepositoryBase<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepEntity, ApplicationDbContext>, IChiTietNgayNghiPhepRepo
    {
        public ChiTietNgayNghiPhepRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public async Task<ChiTietNgayNghiPhepEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.ID == id, cancellationToken);
        }


        public async Task<List<ChiTietNgayNghiPhepEntity>> FindByIdsAsync(string[] ids, CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.ID), cancellationToken);
        }
    }
}
