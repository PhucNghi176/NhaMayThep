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
    }
}
