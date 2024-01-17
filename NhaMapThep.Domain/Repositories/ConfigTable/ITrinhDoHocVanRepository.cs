using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories.ConfigTable
{
    public interface ITrinhDoHocVanRepository : IEFRepository<TrinhDoHocVanEntity, TrinhDoHocVanEntity>
    {
        Task<TrinhDoHocVanEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<TrinhDoHocVanEntity>> FindByIdsAsync(int[] ids, CancellationToken cancellationToken = default);
        //Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
