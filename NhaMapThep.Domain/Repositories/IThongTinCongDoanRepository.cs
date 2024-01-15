using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinCongDoanRepository: IEFRepository<ThongTinCongDoanEntity, ThongTinCongDoanEntity>,
        IRepository<ThongTinCongDoanEntity>
    {
        Task<List<ThongTinCongDoanEntity>?> FindAll(CancellationToken cancellationToken = default);
        Task<ThongTinCongDoanEntity?> FindById(string Id, CancellationToken cancellationToken = default);
        Task<ThongTinCongDoanEntity?> FindByNhanVienId(string Id, CancellationToken cancellationToken = default);
    }
}
