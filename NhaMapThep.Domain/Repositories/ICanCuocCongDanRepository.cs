using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface ICanCuocCongDanRepository: IEFRepository<CanCuocCongDanEntity, CanCuocCongDanEntity>
    {
        Task<CanCuocCongDanEntity?> FindById(string cccd, CancellationToken cancellationToken = default);
    }
}
