using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Domain.Repositories
{
    public interface IThongTinDaoTaoRepository : IEFRepository<ThongTinDaoTaoEntity, ThongTinDaoTaoEntity>
    {
        Task<ThongTinDaoTaoEntity?> FindByIdAsync(string Id, CancellationToken cancellationToken = default);

        Task<List<ThongTinDaoTaoEntity>> FindByIdsAsync(string[] Ids, CancellationToken cancellationToken = default);

    }
}
