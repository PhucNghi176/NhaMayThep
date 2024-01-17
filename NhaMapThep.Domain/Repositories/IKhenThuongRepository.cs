using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IKhenThuongRepository : IEFRepository<KhenThuongEntity, KhenThuongEntity>
    {
        Task<KhenThuongEntity?> FindByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
