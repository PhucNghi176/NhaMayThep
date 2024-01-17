using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories.ConfigTable
{
    public interface IThongTinGiamTruReposiyory : IEFRepository<ThongTinGiamTruEntity,ThongTinGiamTruEntity>
    {
        public Task<ThongTinGiamTruEntity?> GetThongTinGiamTruById(int id, CancellationToken cancellationToken);
    }
}
