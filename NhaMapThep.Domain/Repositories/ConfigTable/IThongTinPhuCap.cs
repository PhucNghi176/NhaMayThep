using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories.ConfigTable
{
    public interface IThongTinPhuCap : IEFRepository<ThongTinPhuCapEntity,ThongTinPhuCapEntity>
    {
        public Task<ThongTinPhuCapEntity?> GetThongTinPhuCapById(int id, CancellationToken cancellationToken);
    }
}
