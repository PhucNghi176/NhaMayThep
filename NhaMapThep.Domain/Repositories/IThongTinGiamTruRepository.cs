using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinGiamTruRepository: IEFRepository<ThongTinGiamTruEntity, ThongTinGiamTruEntity>
    {
        Task<List<ThongTinGiamTruEntity>?> FindAll(CancellationToken cancellationToken = default);
        Task<ThongTinGiamTruEntity?> FindById(int Id, CancellationToken cancellationToken = default);
    }
}
