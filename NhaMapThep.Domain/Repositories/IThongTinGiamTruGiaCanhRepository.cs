using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinGiamTruGiaCanhRepository: IEFRepository<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhEntity>,
        IRepository<ThongTinGiamTruGiaCanhEntity>
    {
        Task<List<ThongTinGiamTruGiaCanhEntity>?> FindAll(CancellationToken cancellationToken = default);
        Task<ThongTinGiamTruGiaCanhEntity?> FindById(string Id, CancellationToken cancellationToken = default);
        Task<ThongTinGiamTruGiaCanhEntity?> FindByNhanVienId(string Id, CancellationToken cancellationToken = default);
        Task<ThongTinGiamTruGiaCanhEntity?> FindByCanCuocCongDan(string cccd, CancellationToken cancellationToken = default);

    }
}
